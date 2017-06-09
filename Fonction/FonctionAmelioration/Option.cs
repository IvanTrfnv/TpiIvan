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
    }
}
