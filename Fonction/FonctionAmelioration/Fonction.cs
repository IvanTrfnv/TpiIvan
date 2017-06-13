using System;
using System.Collections.Generic; // List
using System.Drawing; // PointF
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FonctionAmelioration
{
    public partial class Fonction : Form
    {
        private List<PointF> _pointsXY = new List<PointF>();
        private List<PointF> _pointsXYFct2 = new List<PointF>();
        private List<List<PointF>> _listsPointsXY = new List<List<PointF>>();
        private List<List<PointF>> _listsPointsXYFct2 = new List<List<PointF>>();
        private List<Pen> _pens = new List<Pen>();
        private Bitmap _GraphImage;
        Graphics _gr;
 
        float _zoomX;
        float _zoomY;

        private float dx;
        private float dy;

        public Fonction()
        {
            InitializeComponent();
            Invalidate();
            txtBoxEquation.BringToFront();
            txtBoxFct2.BringToFront();
            this.MouseWheel += Fonction_MouseWheel;

            _zoomX = Convert.ToInt32(Math.Round(Convert.ToDouble(Option.Xmin)));
            _zoomY = Convert.ToInt32(Math.Round(Convert.ToDouble(Option.Ymin)));
        }

        private void Fonction_MouseWheel(object sender, MouseEventArgs e)
        {
            double _xmin = 0.0;
            double _xmax = 0.0;
            double _ymin = 0.0;
            double _ymax = 0.0;
            Zoom(e, ref _zoomX, ref _xmin, ref _xmax);
            Zoom(e, ref _zoomY, ref _ymin, ref _ymax);
            Option.Xmin = Math.Round(_xmin,1);
            Option.Xmax = Math.Round(_xmax,1);
            Option.Ymin = Math.Round(_ymin,1);
            Option.Ymax = Math.Round(_ymax,1);
            Rafraichir();
        }


        private void Zoom(MouseEventArgs e, ref float zoom, ref double min, ref double max)
        {
            //Si zoom petit que 1 on avance +/-1
            if (zoom < -1)
                zoom += (float)((e.Delta / 120.0));
            else
            {
                //SI zoom == 1 on regarde si on passe à +/-0.1 ou on reste à +/-1
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
                else
                {
                    //+/-0.1
                    if (zoom > -1 && zoom < -0.1)
                        zoom += (float)((e.Delta / 120) / 10.0);
                }
            }

            if (Math.Round(zoom,1) < -0.1)
            {
                min = zoom;
                max = -zoom;
            }
            else
            {
                zoom = -0.1f;
                min = zoom;
                max = -zoom;
            }

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            picGraph.Refresh();
            // code trouvé sur : http://csharphelper.com/blog/2015/06/graph-the-sine-cosine-and-tangent-functions-in-c/ 
            if (_GraphImage != null)
                _GraphImage.Dispose();
            _GraphImage = new Bitmap(picGraph.ClientSize.Width, picGraph.ClientSize.Height);

            _gr = Graphics.FromImage(_GraphImage);
            _gr.Clear(Color.White);
            _gr.SmoothingMode = SmoothingMode.HighQuality;
            _gr.SmoothingMode = SmoothingMode.AntiAlias;

            //Hauteur et largeur du rectangle 
            float world_width = (float)(Math.Abs(Option.Xmax - Option.Xmin));
            float world_height = (float)(Math.Abs(Option.Ymax - Option.Ymin));



            // 
            RectangleF world_coords = new RectangleF((float)Option.Xmin, (float)Option.Ymin, world_width, world_height);

            PointF[] device_coords = { new PointF(0, 0), new PointF(picGraph.ClientSize.Width, 0), new PointF(0, picGraph.ClientSize.Height) };

            // Matrice de points proportionnelle au nombre de pixels affichés
            _gr.Transform = new Matrix(world_coords, device_coords);

            Graphique.DessinGraphique(_gr, Option.Xmin, Option.Xmax, Option.Ymin, Option.Ymax, this);

            Matrix inverse = _gr.Transform;
            inverse.Invert();

            PointF[] pixel_pts = { new PointF(0, 1), new PointF(1, 0) };

            // Echantillonner en fonction de la taille de la fenêtre  affichée 
            // Par exemple sur un écran 4K en plein écran, on aura 3800 pixels calculés
            inverse.TransformPoints(pixel_pts);

            // Distance qui sépare deux pixels à l'écran en largeur
            dx = Math.Abs(pixel_pts[1].X - pixel_pts[0].X);
            // Utile en coordonnées paramétrique (x=cos(t,dx), y=sin(t,dy))
            dy = Math.Abs(pixel_pts[1].Y - pixel_pts[0].Y);

            dx /= Option.PrecisionCalcul;
            dy /= Option.PrecisionCalcul;


            int penNumber = 0;
            //Affichage des équations contenant le paramètre y
            foreach (var list in _listsPointsXY)
            {
                Dessin.Dessiner(_gr, _pens[penNumber], list, Option.Ymin, Option.Ymax);
                penNumber++;
            }
            penNumber = 0;
            //Affichage des équations contenant le paramètre y
            foreach (var list in _listsPointsXYFct2)
            {
                Dessin.Dessiner(_gr, _pens[penNumber], list, Option.Ymin, Option.Ymax);
                penNumber++;
            }
            //Dessin des équations cartésiennes affines
            Dessin.Dessiner(_gr, new Pen(Color.Red, (float)Option.Xmax / this.Width), _pointsXY, Option.Ymin, Option.Ymax);
            Dessin.Dessiner(_gr, new Pen(Color.Red, (float)Option.Xmax / this.Width), _pointsXYFct2, Option.Ymin, Option.Ymax);

            DoubleBuffered = true;
            _gr.Dispose();
            //Affichage du graphique sur la picturebox
            picGraph.Image = _GraphImage;

        }


        private new void TextChanged(object sender, EventArgs e)
        {
            Rafraichir();
        }

        private void Calcul()
        {
            try
            {
                if (chkBParametrique.Checked)
                {
                    Calcul fonctionParametrique = new Calcul(TraitementTexte.TraitementEquation(txtBoxEquation.Text), TraitementTexte.TraitementEquation(txtBoxFct2.Text));
                    _pointsXY = fonctionParametrique.PointXYEquationParametrique(Option.Xmin, Option.Xmax, dx);
                }
                else
                {
                    Calcul fonctionNumeroUne = new Calcul(TraitementTexte.TraitementEquation(txtBoxEquation.Text));
                    if (txtBoxEquation.Text != string.Empty)
                    {
                        VerificationParamK(fonctionNumeroUne, ref _pointsXY, ref _listsPointsXY);
                    }
                    else
                    {
                        _pointsXY.Clear();
                        _listsPointsXY.Clear();
                    }
                    Calcul fonctionNumeroDeux = new Calcul(TraitementTexte.TraitementEquation(txtBoxFct2.Text));
                    if (txtBoxFct2.Text != string.Empty)
                    {
                        VerificationParamK(fonctionNumeroDeux, ref _pointsXYFct2, ref _listsPointsXYFct2);
                    }
                    else
                    {
                        _pointsXYFct2.Clear();
                        _listsPointsXYFct2.Clear();
                    }

                }
            }
            catch
            {
                //Attends que l'utilisateur rentre correctement son équation
                //Efface les lists pour évite d'afficher des erreurs 
                _listsPointsXY.Clear();
                _listsPointsXYFct2.Clear();
            }
        }
        /// <summary>
        /// Vérifie si les équations contienent le paramètre y 
        /// </summary>
        /// <param name="fonction">Objet qui contient l'équation et les méthodes de calcul</param>
        /// <param name="points">liste de points pour équation cartésienne affine</param>
        /// <param name="listOflistOfPoints">lists de liste pour les équations contenant le partamétre y</param>
        private void VerificationParamK(Calcul fonction, ref List<PointF> points, ref List<List<PointF>> listDelistDesPoints)
        {
                if (fonction.Equation.Contains("y"))
                {
                    Random rand = new Random();
                    listDelistDesPoints.Clear();
                    points.Clear();
                    _pens.Clear();
                    //Calcul la courbe avec l'intervalle que l'utilisateur à utiliser pour y
                    for (decimal i = Option.ParamK; i < Option.ParamKMax; i++)
                    {
                        listDelistDesPoints.Add(fonction.PointXYEquation(Option.Xmin - Option.Xmax / 10, Option.Xmax + Option.Xmax / 10, dx, (float)i));
                        _pens.Add(new Pen(Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256)), (float)Option.Xmax / this.Width));
                    }
                }
                else
                {
                    listDelistDesPoints.Clear();
                    points = fonction.PointXYEquation(Option.Xmin - Option.Xmax / 10, Option.Xmax + Option.Xmax / 10, dx);
                }
        }

        private void picGraph_MouseMove(object sender, MouseEventArgs e)
        {
            lblSourisX.Text = (" X : " + Math.Round((e.X * (dx * Option.PrecisionCalcul) + Option.Xmin), 2)).ToString();
            lblSourisY.Text = (" Y : " + Math.Round(-(e.Y * (dy * Option.PrecisionCalcul) - Option.Xmax), 2)).ToString();
        }

        private void chkBParametrique_CheckedChanged(object sender, EventArgs e)
        {
            Rafraichir();
        }

        private void optionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOption frmParam = new frmOption(this, txtBoxEquation, txtBoxFct2, chkBParametrique);
            frmParam.Show();
        }

        public void Rafraichir()
        {
            Calcul();
            Invalidate();
            Update();
        }
    }
}