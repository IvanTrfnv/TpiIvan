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
            float font_size = (float)Math.Max(Math.Abs(xmax - xmin), Math.Abs(ymax - ymin)) / (float)(frm.Width / 13);
            float trait_size = (float)Math.Max(Math.Abs(xmax - xmin), Math.Abs(ymax - ymin)) / frm.Height;

            // Draw the X-axis.
            Pen graphPen = new Pen(Color.Black, trait_size);
            double start_x = xmin;
            gr.DrawLine(graphPen, (float)xmin, 0, (float)xmax, 0);
            float dy = (float)((ymax - ymin) / 120.0);
            double nbGradX = 1;
            nbGradX = NbGrad(xmin);
            for (double x = start_x; x < 0; x += Math.Abs(nbGradX))
            {
                gr.DrawLine(graphPen, (float)x, -2 * dy,
                    (float)x, 2 * dy);

                gr.DrawString(Math.Round(x, 2).ToString(), new Font(arial, font_size), Brushes.Black, (float)x, -2 * dy);
            }
            nbGradX = NbGrad(xmax);
            for (double x = 0; x < xmax; x += Math.Abs(nbGradX))
            {
                gr.DrawLine(graphPen, (float)x, -2 * dy,
                    (float)x, 2 * dy);

                gr.DrawString(Math.Round(x, 2).ToString(), new Font(arial, font_size), Brushes.Black, (float)x, -2 * dy);
            }


            // Draw the Y-axis.
            double start_y = ymin;
            gr.DrawLine(graphPen, 0, (float)ymin, 0, (float)ymax);
            float dx = (float)((xmax - xmin) / 120.0);
            double nbGradY = Math.Max(NbGrad(ymin),NbGrad(ymax));
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
