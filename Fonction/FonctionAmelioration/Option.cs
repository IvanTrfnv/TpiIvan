using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FonctionAmelioration
{
    public static class Option
    {
        private static int precisionCalcul = 100;
        private static decimal paramK = 1;
        private static decimal paramKMax = 5;
        private static double xmin = -5;
        private static double xmax = 5;
        private static double ymin = -5;
        private static double ymax = 5;

        private static double xminOld = xmin;
        private static double xmaxOld = xmax;
        private static double yminOld = ymin;
        private static double ymaxOld = ymax;

        public static int PrecisionCalcul
        {
            get
            {
                return precisionCalcul;
            }

            set
            {
                precisionCalcul = value;
            }
        }

        public static decimal ParamK
        {
            get
            {
                return paramK;
            }

            set
            {
                paramK = value;
            }
        }

        public static double Xmin
        {
            get
            {
                return xmin;
            }

            set
            {
                xminOld = Xmax;
                xmin = value;
            }
        }

        public static double Xmax
        {
            get
            {
                return xmax;
            }

            set
            {
                xmaxOld = xmin;
                xmax = value;
            }
        }

        public static double Ymin
        {
            get
            {
                return ymin;
            }

            set
            {
                yminOld = ymin;
                ymin = value;
            }
        }

        public static double Ymax
        {
            get
            {
                return ymax;
            }

            set
            {
                ymaxOld = ymax;
                ymax = value;
            }
        }

        public static decimal ParamKMax
        {
            get
            {
                return paramKMax;
            }

            set
            {
                paramKMax = value;
            }
        }

        public static double XminOld
        {
            get
            {
                return xminOld;
            }

            set
            {
                xminOld = value;
            }
        }

        public static double XmaxOld
        {
            get
            {
                return xmaxOld;
            }

            set
            {
                xmaxOld = value;
            }
        }

        public static double YminOld
        {
            get
            {
                return yminOld;
            }

            set
            {
                yminOld = value;
            }
        }

        public static double YmaxOld
        {
            get
            {
                return ymaxOld;
            }

            set
            {
                ymaxOld = value;
            }
        }
    }
}
