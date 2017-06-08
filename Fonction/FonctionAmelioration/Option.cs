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
    }
}
