using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FonctionAmelioration
{
    public static class Graphique
    {
        public static void DessinGraphique(Graphics gr,double xmin, double xmax, double ymin, double ymax)
        {
            FontFamily arial = new FontFamily("Arial");
            double font_size = Math.Max(Math.Abs(xmax - xmin), Math.Abs(ymax - ymin))/100.0f; 

            // Draw the X-axis.
            Pen graphPen = new Pen(Color.Black, 0.005f);
            double start_x = xmin;
            gr.DrawLine(graphPen, (float)xmin, 0, (float)xmax, 0);
            float dy = (float)((ymax - ymin) / 120.0);
            double nbGradX = 1;
            if (xmax%5 == 0)
            {
                nbGradX = xmax / 5;
            }
            else
            {
                nbGradX = xmax / 2;
            }

            for (double x = start_x; x <= xmax; x += nbGradX)
            {
                gr.DrawLine(graphPen, (float)x, -2 * dy,
                    (float)x, 2 * dy);
                
                gr.DrawString(x.ToString(),new Font(arial, (float) font_size), Brushes.Black, (float)x, -2 * dy);
            }


            // Draw the Y-axis.
            double start_y = ymin;
            gr.DrawLine(graphPen, 0, (float)ymin, 0, (float)ymax);
            float dx = (float)((xmax - xmin) / 120.0);
            double nbGradY = 1;
            if (ymax % 5== 0)
            {
                nbGradY = ymax / 5;
            }
            else
            {
                nbGradY = ymax / 2;
            }
            for (double y = start_y; y <= ymax; y += nbGradY)
            {
                gr.DrawLine(graphPen, -2 * dx, (float)y, 2 * dx, (float)y);
                double yAffichage = -y;
                gr.DrawString(yAffichage.ToString(), new Font(arial, (float) font_size), Brushes.Black, new PointF(-2*dx, (float)y));
            }



        }
    }
}
