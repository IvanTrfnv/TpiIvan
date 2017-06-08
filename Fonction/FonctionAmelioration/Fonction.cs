using System;
using System.Collections.Generic; // List
using System.Diagnostics;
using System.Drawing; // PointF
using System.Drawing.Drawing2D;
using System.Linq;
// Bitmap, Matrix, SmoothingMode
using System.Threading;
using System.Windows.Forms;

namespace FonctionAmelioration
{
    public partial class Fonction : Form
    {
        private List<PointF> pointsXY = new List<PointF>();
        private List<PointF> pointsXYFct2 = new List<PointF>();
        private List<PointF> pointsGraphiqueX = new List<PointF>();
        private List<PointF> pointsGraphiqueY = new List<PointF>();
        private Bitmap GraphImage;
        Graphics gr;


        private double xmin;
        private double xmax;
        private double ymin;
        private double ymax;
        float zoomX;
        float zoomY;

        private float dx;
        private float dy;

        public Fonction()
        {
            InitializeComponent();
            Invalidate();
            txtBoxEquation.BringToFront();
            txtBoxFct2.BringToFront();
            this.MouseWheel += Fonction_MouseWheel;
            xmin = -1;
            xmax = 1;
            ymin = -1;
            ymax = 1;
            zoomX = Convert.ToInt32(Math.Round(Convert.ToDouble(xmin)));
            zoomY = Convert.ToInt32(Math.Round(Convert.ToDouble(ymin)));

        }

        private void Fonction_MouseWheel(object sender, MouseEventArgs e)
        {
            Zoom(e, ref zoomX, ref xmin, ref xmax);
            Zoom(e, ref zoomY, ref ymin, ref ymax);
            Invalidate();
            Update();
        }

           
        private void Zoom(MouseEventArgs e,ref float zoom, ref double min,ref double max)
        {

            if (zoom < -1)
                zoom += (float)((e.Delta / 120.0));

            if (zoom > -1)
                zoom += (float)((e.Delta / 120) / 10.0);

            if (zoom == -1)
            {
                if (zoom + (float)((e.Delta / 120.0)) == 0)
                {
                    zoom += (float)((e.Delta / 120) / 10.0);
                }
                else
                {
                    if (zoom + (float)((e.Delta / 120.0) / 10.0) < -1)
                    {
                        zoom += (float)((e.Delta / 120.0));
                    }
                }
            }
            if (zoom < -0.1)
            {
                min = zoom;
                max = -1 * zoom;
            }
            else
            {
                zoom = -0.1f;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            picGraph.Refresh();
            // code trouvé sur : http://csharphelper.com/blog/2015/06/graph-the-sine-cosine-and-tangent-functions-in-c/ 
            if (GraphImage != null)
                GraphImage.Dispose();
            GraphImage = new Bitmap(picGraph.ClientSize.Width, picGraph.ClientSize.Height);


            gr = Graphics.FromImage(GraphImage);
            gr.Clear(Color.White);
            gr.SmoothingMode = SmoothingMode.HighQuality;
            gr.SmoothingMode = SmoothingMode.AntiAlias;

            float world_width  = (float) Math.Abs(xmax - xmin);
            float world_height = (float) Math.Abs(ymax - ymin);

            // Scale to make the area fit the PictureBox.
            RectangleF world_coords = new RectangleF((float)xmin, (float)ymin, world_width, world_height);
            
            PointF[] device_coords ={ new PointF(0, 0), new PointF(picGraph.ClientSize.Width, 0), new PointF(0, picGraph.ClientSize.Height) };

            // Matrice de points proportionnelle au nombre de pixels affichés
            gr.Transform = new Matrix(world_coords, device_coords);

            Graphique.DessinGraphique(gr, xmin, xmax, ymin, ymax, this);

            Matrix inverse = gr.Transform;
            inverse.Invert();

            PointF[] pixel_pts = {new PointF(0, 1),new PointF(1, 0), };

            // Echantillonner en fonction de la taille de la fenetre affichée 
            // Par exemple sur un écran 4K en plein écran, on aura 3800 pixels calculés
            inverse.TransformPoints(pixel_pts);

            // Distance qui sépare deux pixels à l'écran en largeur
            dx = Math.Abs(pixel_pts[1].X - pixel_pts[0].X);
            // Utile en coordonnées paramétrique (x=cos(t,dx), y=sin(t,dy))
            dy = Math.Abs(pixel_pts[1].Y - pixel_pts[0].Y);

            dx /= Option.PrecisionCalcul;
            dy /= Option.PrecisionCalcul;


            Calcul();

            Dessin.Dessiner(gr, new Pen(Color.Red, (float)xmax / this.Width), pointsXY, ymin, ymax);
            Dessin.Dessiner(gr, new Pen(Color.Red, (float)xmax / this.Width), pointsXYFct2, ymin, ymax);

            DoubleBuffered = true;
            gr.Dispose();
            // Display the result.
            picGraph.Image = GraphImage;

        }


        private new void TextChanged(object sender, EventArgs e)
        {
            Calcul();
            Invalidate();
            Update();
        }

        private void Calcul()
        {
            try
            {
                if (chkBParametrique.Checked)
                {
                    Calcul fonctionParametrique = new Calcul(TraitementTexte.equation(txtBoxEquation.Text), TraitementTexte.equation(txtBoxFct2.Text));
                    pointsXY = fonctionParametrique.PointXYEquationParametrique(xmin, xmax, dx);
                }
                else
                {
                    if (txtBoxEquation.Text != string.Empty)
                    {
                        Calcul fonctionNumeroUne = new Calcul(TraitementTexte.equation(txtBoxEquation.Text));
                        pointsXY = fonctionNumeroUne.PointXYEquation(xmin - xmax / 10, xmax + xmax / 10, dx);
                    }
                    if (txtBoxFct2.Text != string.Empty)
                    {
                        Calcul fonctionNumeroDeux = new Calcul(TraitementTexte.equation(txtBoxFct2.Text));
                        pointsXYFct2 = fonctionNumeroDeux.PointXYEquation(xmin - xmax / 10, xmax + xmax / 10, dx);
                    }
                    
                }
            }
            catch
            {
                //Attends que l'utilisateur rentre correctement son équation
            }
        }

        private void picGraph_MouseMove(object sender, MouseEventArgs e)
        {
            lblSourisX.Text = (" X : " + Math.Round((e.X * (dx*xmax) + xmin),2)).ToString();
            lblSourisY.Text = (" Y : "+Math.Round(-(e.Y * (dy*ymax) - ymax),2)).ToString();
        }

        private void chkBParametrique_CheckedChanged(object sender, EventArgs e)
        {
            Invalidate();
            Update();
        }

        private void optionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOption frmParam = new frmOption();
            frmParam.Show();
        }
    }
}