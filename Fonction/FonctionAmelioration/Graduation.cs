using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FonctionAmelioration
{
    class Graduation
    {
        private double _xmin;
        private double _xmax;
        private double _ymin;
        private double _ymax;
        private float _dx;
        private double _zoomFacteur;
        private List<List<PointF>> listCordGradY;
        private List<List<PointF>> listCordGradX;

        public List<List<PointF>> ListCordGradY
        {
            get
            {
                return listCordGradY;
            }

            set
            {
                listCordGradY = value;
            }
        }

        public List<List<PointF>> ListCordGradX
        {
            get
            {
                return listCordGradX;
            }

            set
            {
                listCordGradX = value;
            }
        }

        

        public Graduation(double xmin, double xmax, float dx, double ymin, double ymax, double zoomFacteur)
        {
            _xmax = Math.Round(xmax, 0);
            _xmin = Math.Round(xmin, 0);
            _ymax = ymax;
            _ymin = ymin;
            _dx = dx;
            _zoomFacteur = -zoomFacteur;
            ListCordGradY = new List<List<PointF>>();
            ListCordGradX = new List<List<PointF>>();
            CreationGrad();
        }

        private void CreationGrad()
        {
            List<PointF> Listpointy = new List<PointF>();
            double division = 10 * _xmax;
            for (float i = (float)_ymin; i <= _ymax; i++)
            {
                if (i != 0)
                {
                    for (float x = (float)(_xmin / division); x <= _xmax / division; x += _dx)
                    {
                        Listpointy.Add(new PointF(x, i));
                        
                    }
                }
                ListCordGradY.Add(new List<PointF>(Listpointy));
                Listpointy.Clear();
            }

            for (float i = (float)_xmin; i <= _xmax; i++)
            {
                ListCordGradX.Add(new List<PointF> { new PointF(i, (float)(_ymin / division)), new PointF(i, (float)(_ymax / division)) });
            }
        }
    }
}
