using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FonctionAmelioration
{
    static class DessinGraphique
    {
        static public List<PointF> DessinX(double xmin,double xmax,float dx)
        {
            List<PointF> pointsGraphiqueX = new List<PointF>();
            for (float x = (float)xmin; x <= xmax; x += dx)
            {
                pointsGraphiqueX.Add(new PointF(x,0));
            }
            return pointsGraphiqueX;
        }

        static public List<PointF> DessinY(double ymin, double ymax, float dx)
        {
            List<PointF> pointsGraphiqueX = new List<PointF>();
            for (float y = (float)ymin; y <= ymax; y += dx)
            {
                pointsGraphiqueX.Add(new PointF(0, y));
            }
            return pointsGraphiqueX;
        }

    }
}
