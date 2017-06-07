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
        bool calcul;     

        private string xZoomMin = "-10";
        private string xZoomMax = "10";
        private string yZoomMin = "-10";
        private string yZoomMax = "10";
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
            calcul = false;
        }

        private void Fonction_MouseWheel(object sender, MouseEventArgs e)
        {
           
            this.Text = zoomSacle.ToString();
            #region //Zoom
            if (zoomSacle >= 0)
                zoomSacle += (float)((e.Delta / 120)/10);
            else
                zoomSacle += (float)((e.Delta / 120));
            if (zoomSacle < 0)
            {
                xZoomMin = (zoomSacle).ToString();
                xZoomMax = (-1 * zoomSacle).ToString();
                yZoomMin = (zoomSacle).ToString();
                yZoomMax = (-1 * zoomSacle).ToString();
            }
            double posSourisY = Math.Round(-(e.Y * dy - ymax),2);
            double posSourisX = Math.Round(e.X * dx + xmin,2);
            newXminAFF = posSourisX + xmin/4;
            newXmaxAFF = posSourisX + xmax/4;
            newYminAFF = posSourisY + ymin/4;
            newYmaxAFF = posSourisY + ymax/4;
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
            if (xmin != Convert.ToDouble(xZoomMin))
                calcul = true;
        
            // Remplacer par une vrai constante (ici 3) 21:9 ou 16:9 le rapport dépend de l'écran
            xmin = double.Parse(xZoomMin);
            xmax = double.Parse(xZoomMax);
            ymin = double.Parse(yZoomMin);
            ymax = double.Parse(yZoomMax);
            float world_width  = (float) Math.Abs(xmax - xmin);
            float world_height = (float) Math.Abs(ymax - ymin);

            // Scale to make the area fit the PictureBox.
            RectangleF world_coords = new RectangleF((float)xmin, (float)xmin, world_width, world_height);
            
            PointF[] device_coords ={ new PointF(0, 0), new PointF(picGraph.ClientSize.Width, 0), new PointF(0, picGraph.ClientSize.Height) };

            // Matrice de points proportionnelle au nombre de pixels affichés
            gr.Transform = new Matrix(world_coords, device_coords);

            Graphique.DessinGraphique(gr, xmin, xmax, ymin, ymax);

            // See how big a pixel is before scaling.
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

            dx /= (float)xmax;
            dy /= (float)ymax;

            if (calcul)
            {
                Calcul();
                calcul = false;
            }

            Pen pen = new Pen(Color.Black, 0);
            Pen penfct = new Pen(Color.Purple, 0.005f);
            Pen penfct2 = new Pen(Color.SteelBlue, 0.005f);

            Dessin(gr, penfct, pointsXY);
            Dessin(gr, penfct2, pointsXYFct2);

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
                    if ((Math.Abs(item.Y) > (ymax+ymax/5)) || (Math.Abs(item.Y) < (ymin-ymax/5)))
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
                    pointsXY = fonctionParametrique.PointXYEquationParametrique(xmin, xmax, dx);
                }
                else
                {
                    if (txtBoxEquation.Text != string.Empty)
                    {
                        Calcul fonctionNumeroUne = new Calcul(TraitementTexte.equation(txtBoxEquation.Text));
                        pointsXY = fonctionNumeroUne.PointXYEquation(xmin - xmax / 10, xmax + xmax/10, dx, this);
                    }
                    if (txtBoxFct2.Text != string.Empty)
                    {
                        Calcul fonctionNumeroDeux = new Calcul(TraitementTexte.equation(txtBoxFct2.Text));
                        pointsXYFct2 = fonctionNumeroDeux.PointXYEquation(xmin - xmax / 10, xmax + xmax/10, dx, this);
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
            lblSourisX.Text = (" X :" + Math.Round((e.X * (dx*xmax) + xmin),2)).ToString();
            lblSourisY.Text = (" Y "+Math.Round(-(e.Y * (dy*ymax) - ymax),2)).ToString();
        }
    }
}