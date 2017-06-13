using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FonctionAmelioration
{
    public static class Dessin
    {
        public static void Dessiner(Graphics gr, Pen pinceaufct, List<PointF> points, double ymin, double ymax)
        {
            if (points.Count > 0)
            {
                List<List<PointF>> lstDeLst = new List<List<PointF>>();
                List<PointF> lstTmp = new List<PointF>();
                foreach (var item in points)
                {
                    //Regarde la difference entre le point actuelle et l'ancien
                    if ((Math.Abs(item.Y) > (ymax + ymax / 5)) || (Math.Abs(item.Y) < (ymin - ymax / 5)))
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
                            gr.DrawLines(pinceaufct, item.ToArray());
                    }
                }
            }
        }
    }
}
