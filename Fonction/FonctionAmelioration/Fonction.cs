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
            #endregion
            Invalidate();
            Update();
        }

        private void GraphiqueXY()
        {
            pointsGraphiqueX = DessinGraphique.DessinX(xmin, xmax, dx);
            pointsGraphiqueY = DessinGraphique.DessinY(ymin, ymax, dx);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            picGraph.Refresh();
                // code trouvé sur : http://csharphelper.com/blog/2015/06/graph-the-sine-cosine-and-tangent-functions-in-c/ 
                if (GraphImage != null)
                    GraphImage.Dispose();
                GraphImage = new Bitmap(picGraph.ClientSize.Width, picGraph.ClientSize.Height);

                Graphics gr;
                gr = Graphics.FromImage(GraphImage);
                gr.Clear(Color.White);
                gr.SmoothingMode = SmoothingMode.HighQuality;


                // Remplacer par une vrai constante (ici 3) 21:9 ou 16:9 le rapport dépend de l'écran
                xmin = double.Parse(xZoomMin);
                xmax = double.Parse(xZoomMax);
                ymin = double.Parse(yZoomMin);
                ymax = double.Parse(yZoomMax);

                // Scale to make the area fit the PictureBox.
                RectangleF world_coords = new RectangleF(
                    (float)xmin, (float)ymax,
                    (float)(xmax - xmin),
                    (float)(ymin - ymax));

                PointF[] device_coords =
                {
                        new PointF(0, 0),
                        new PointF(picGraph.ClientSize.Width, 0),
                        new PointF(0, picGraph.ClientSize.Height),
                    };
                // Matrice de points proportionnelle au nombre de pixels affichés
                gr.Transform = new Matrix(world_coords, device_coords);


                // See how big a pixel is before scaling.
                Matrix inverse = gr.Transform;
                inverse.Invert();
                PointF[] pixel_pts =
                {
                        new PointF(0, 0),
                        new PointF(1, 0),
                };

                // Echantillonner en fonction de la taille de la fenetre affichée 
                // Par exemple sur un écran 4K en plein écran, on aura 3800 pixels calculés
                inverse.TransformPoints(pixel_pts);

                // Distance qui sépare deux pixels à l'écran en largeur
                dx = (pixel_pts[1].X - pixel_pts[0].X);
                // Utile en coordonnées paramétrique (x=cos(t,dx), y=sin(t,dy))
                dy = (pixel_pts[1].Y - pixel_pts[0].Y);


                GraphiqueXY();

                Pen penGrad = new Pen(Color.Black, 0);
                Graduation grad = new Graduation(xmin, xmax, dx, ymin, ymax, zoomSacle);
                int y = Convert.ToInt32(ymin);
                System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 30);
                foreach (var lists in grad.ListCordGradY)
                {
                    y++;
                    gr.DrawString(y.ToString(), drawFont, Brushes.Black, new Point(10,20));
                    if (lists.Count > 1)
                        gr.DrawLines(penGrad, lists.ToArray());
                }
                int x = Convert.ToInt32(xmin);
                foreach (var lists in grad.ListCordGradX)
                {
                    if (lists.Count > 1)
                        gr.DrawLines(penGrad, lists.ToArray());
                    
                }

                Calcul();

                Pen pen = new Pen(Color.Black, 0);
                Pen penfct = new Pen(Color.Purple, 0.005f);
                Pen penfct2 = new Pen(Color.SteelBlue, 0.005f);

                Dessin(gr, penfct, pointsXY);
                Dessin(gr, penfct2, pointsXYFct2);

                gr.DrawLines(pen, pointsGraphiqueX.ToArray());
                gr.DrawLines(pen, pointsGraphiqueY.ToArray());
                DoubleBuffered = true;
                gr.Dispose();
                // Display the result.
                picGraph.Image = GraphImage;
        }

        private void Dessin(Graphics gr, Pen penfct, List<PointF> points )
        {
            if (points.Count > 0)
            {
                List<List<PointF>> lstDeLst = new List<List<PointF>>();
                List<PointF> lstTmp = new List<PointF>();

                foreach (var item in points)
                {
                    //Regarde la difference entre le point actuelle et l'ancien
                    if ((Math.Abs(item.Y) > (ymax)) || (Math.Abs(item.Y) < (ymin)))
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
                    if (txtBoxEquation.Text != "")
                    {
                        Calcul fonctionNumeroUne = new Calcul(TraitementTexte.equation(txtBoxEquation.Text));
                        pointsXY = fonctionNumeroUne.PointXYEquation(xmin, xmax, dx, this);
                    }

                    if (txtBoxFct2.Text != "")
                    {
                        Calcul fonctionNumeroDeux = new Calcul(TraitementTexte.equation(txtBoxFct2.Text));
                        pointsXYFct2 = fonctionNumeroDeux.PointXYEquation(xmin, xmax, dx, this);
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

        }
    }
}