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
        System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
        private List<PointF> pointsXY = new List<PointF>();
        private List<PointF> pointsXYFct2 = new List<PointF>();
        private List<PointF> pointsGraphiqueX = new List<PointF>();
        private List<PointF> pointsGraphiqueY = new List<PointF>();
        private Bitmap GraphImage;
        private double xmin;
        private double xmax;
        private double ymin;
        private double ymax;
        double newXminAFF;
        double newXmaxAFF;
        double newYminAFF;
        double newYmaxAFF;
        Graphics gr;     

        private string xZoomMin = "-5";
        private string xZoomMax = "5";
        private string yZoomMin = "-5";
        private string yZoomMax = "5";
        float zoomSacle;

        private float dx;
        private float dy;

        public Fonction()
        {
            InitializeComponent();
            Invalidate();
            txtBoxEquation.BringToFront();
            txtBoxFct2.BringToFront();
            this.MouseWheel += Fonction_MouseWheel;
            zoomSacle = Convert.ToInt32(Math.Round(Convert.ToDouble(yZoomMin)));
            newXminAFF = Convert.ToDouble(xZoomMin);
            newXmaxAFF = Convert.ToDouble(xZoomMax);
            newYminAFF = Convert.ToDouble(yZoomMin);
            newYmaxAFF = Convert.ToDouble(yZoomMax);
        }

        private void Fonction_MouseWheel(object sender, MouseEventArgs e)
        {
            
            zoomSacle += (float)((e.Delta / 120));

            this.Text = zoomSacle.ToString();
            #region //Zoom
            if (zoomSacle >= 0)
            {
                zoomSacle = 0;
            }
            if (zoomSacle <= -18)
            {
                zoomSacle = -18;
            }
            if (zoomSacle < 0)
            {
                xZoomMin = (zoomSacle).ToString();
                xZoomMax = (-1 * zoomSacle).ToString();
                yZoomMin = (zoomSacle).ToString();
                yZoomMax = (-1 * zoomSacle).ToString();
            }

            newXminAFF = e.X * dx + xmin;
            newXmaxAFF = e.X * dx + xmax;
            newYminAFF = e.Y * dy + ymin;
            newYmaxAFF = e.Y * dy + ymax;
            #endregion
            Invalidate();
            Update();
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
        
            // Remplacer par une vrai constante (ici 3) 21:9 ou 16:9 le rapport dépend de l'écran
            xmin = double.Parse(xZoomMin);
            xmax = double.Parse(xZoomMax);
            ymin = double.Parse(yZoomMin);
            ymax = double.Parse(yZoomMax);
            float world_width  = (float) Math.Abs(newXmaxAFF - newXminAFF);
            float world_height = (float) Math.Abs(newYmaxAFF - newYminAFF);

            // Scale to make the area fit the PictureBox.
            RectangleF world_coords = new RectangleF(
                (float)newXminAFF, (float)newXminAFF, world_width, world_height);
            
            PointF[] device_coords =
            {
                        new PointF(0, 0),
                        new PointF(picGraph.ClientSize.Width, 0),
                        new PointF(0, picGraph.ClientSize.Height)
                    };

            // Matrice de points proportionnelle au nombre de pixels affichés
            gr.Transform = new Matrix(world_coords, device_coords);
            Graphique.DessinGraphique(gr, xmin, xmax, ymin, ymax);

            // See how big a pixel is before scaling.
            Matrix inverse = gr.Transform;
            inverse.Invert();

            PointF[] pixel_pts =
            {
                    new PointF(0, 1),
                    new PointF(1, 0),
            };

            // Echantillonner en fonction de la taille de la fenetre affichée 
            // Par exemple sur un écran 4K en plein écran, on aura 3800 pixels calculés

            inverse.TransformPoints(pixel_pts);

            // Distance qui sépare deux pixels à l'écran en largeur
            dx = Math.Abs(pixel_pts[1].X - pixel_pts[0].X);
            // Utile en coordonnées paramétrique (x=cos(t,dx), y=sin(t,dy))
            dy = Math.Abs(pixel_pts[1].Y - pixel_pts[0].Y);

            Calcul();

            Pen pen = new Pen(Color.Black, 0);
            Pen penfct = new Pen(Color.Purple, 0.005f);
            Pen penfct2 = new Pen(Color.SteelBlue, 0.005f);

            Dessin(gr, penfct, pointsXY);
            Dessin(gr, penfct2, pointsXYFct2);

            //gr.DrawLines(pen, pointsGraphiqueX.ToArray());
            //gr.DrawLines(pen, pointsGraphiqueY.ToArray());
            DoubleBuffered = true;
            gr.Dispose();
            // Display the result.
            picGraph.Image = GraphImage;

        }

        private void Dessin(Graphics gr, Pen penfct, List<PointF> points)
        {
            if (points.Count > 0)
            {
                List<List<PointF>> lstDeLst = new List<List<PointF>>();
                List<PointF> lstTmp = new List<PointF>();
                foreach (var item in points)
                {
                    //Regarde la difference entre le point actuelle et l'ancien
                    if ((Math.Abs(item.Y) > (ymax+9.95)) || (Math.Abs(item.Y) < (ymin-9.95)))
                    {
                        lstDeLst.Add(lstTmp);
                        lstTmp = new List<PointF>();
                    }
                    lstTmp.Add(item);
                }

                //ajoute les points à la liste contenant toute la fonction si par exemple la fonction ne change pas de signe comme f(x) = sin(x)+2
                lstDeLst.Add(lstTmp);
                lstTmp = new List<PointF>();

                foreach (var item in lstDeLst)
                {
                    if (item.Count != 0)
                    {
                        if (item.Count > 1)
                            gr.DrawLines(penfct, item.ToArray());
                    }
                }
            }
        }

        private void TextChanged(object sender, EventArgs e)
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
                    pointsXY = fonctionParametrique.PointXYEquationParametrique(xmin, xmax, dx ,dy);
                }
                else
                {
                        Calcul fonctionNumeroUne = new Calcul(TraitementTexte.equation(txtBoxEquation.Text));
                        pointsXY = fonctionNumeroUne.PointXYEquation(xmin - 10, xmax + 10, dx, this);
                        Calcul fonctionNumeroDeux = new Calcul(TraitementTexte.equation(txtBoxFct2.Text));
                        pointsXYFct2 = fonctionNumeroDeux.PointXYEquation(xmin - 10, xmax + 10, dx, this);
                }
            }
            catch
            {
                //Attends que l'utilisateur rentre correctement son équation
            }
        }

        private void picGraph_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = (e.X * dx + xmin +" "+ e.Y*dy + ymin).ToString();
        }
    }
}