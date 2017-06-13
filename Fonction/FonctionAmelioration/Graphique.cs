using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FonctionAmelioration
{
    public static class Graphique
    {
        public static void DessinGraphique(Graphics gr,double xmin, double xmax, double ymin, double ymax, Form frm)
        {
            FontFamily arial = new FontFamily("Arial");
            //Calcul la taille du texte 
            float font_size = (float)Math.Max(Math.Abs(xmax - xmin), Math.Abs(ymax - ymin)) / (float)(frm.Width / 13);
            //Calcuk ka taille la taille des traits pour le graphique
            float trait_size = (float)Math.Max(Math.Abs(xmax - xmin), Math.Abs(ymax - ymin)) / frm.Height;

            // Dessin l'axe des x
            Pen graphPen = new Pen(Color.Black, trait_size);
            double start_x = xmin;
            gr.DrawLine(graphPen, (float)xmin, 0, (float)xmax, 0);
            float dy = (float)((ymax - ymin) / 120.0);
            double nbGradX = 1;
            nbGradX = NbGrad(xmin);
            for (double x = start_x; x < 0; x += Math.Abs(nbGradX))
            {
                //Dessine la graduation
                gr.DrawLine(graphPen, (float)x, -2 * dy,
                    (float)x, 2 * dy);
                //Dessine le chiffre de la graduation
                gr.DrawString(Math.Round(x, 2).ToString(), new Font(arial, font_size), Brushes.Black, (float)x, -2 * dy);
            }
            nbGradX = NbGrad(xmax);
            for (double x = 0; x < xmax; x += Math.Abs(nbGradX))
            {
                gr.DrawLine(graphPen, (float)x, -2 * dy,
                    (float)x, 2 * dy);

                gr.DrawString(Math.Round(x, 2).ToString(), new Font(arial, font_size), Brushes.Black, (float)x, -2 * dy);
            }


            // Dessin l'axe des y
            double start_y = ymin;
            gr.DrawLine(graphPen, 0, (float)ymin, 0, (float)ymax);
            float dx = (float)((xmax - xmin) / 120.0);
            double nbGradY = NbGrad(ymin);
            for (double y = start_y; y < 0; y += Math.Abs(nbGradY))
            {
                gr.DrawLine(graphPen, -2 * dx, (float)y, 2 * dx, (float)y);
                double yAffichage = Math.Round(-y, 2);
                gr.DrawString(yAffichage.ToString(), new Font(arial, font_size), Brushes.Black, new PointF(-2 * dx, (float)y));
            }
            nbGradY = NbGrad(ymax);
            for (double y = 0; y < ymax; y += Math.Abs(nbGradY))
            {
                gr.DrawLine(graphPen, -2 * dx, (float)y, 2 * dx, (float)y);
                double yAffichage = Math.Round(-y, 2);
                gr.DrawString(yAffichage.ToString(), new Font(arial, font_size), Brushes.Black, new PointF(-2 * dx, (float)y));
            }
        }
        /// <summary>
        /// Calcul le nombre de graduation pour chaque axe
        /// </summary>
        /// <param name="xmin"></param>
        /// <returns></returns>
        private static double NbGrad(double xmin)
        {
            double nbGradX;
            if (xmin % 5 == 0)
                nbGradX = xmin / 5;
            else
            {
                if (xmin % 3 == 0)
                    nbGradX = xmin / 3;
                else
                    nbGradX = xmin / 2;
            }

            return nbGradX;
        }
    }
}
