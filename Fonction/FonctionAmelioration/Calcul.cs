using Bestcode.MathParser;
using CSE;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Z.Expressions;

namespace FonctionAmelioration
{
    class Calcul
    {
        string _equation;

        string _equationParamX;

        string _equationParamY;

        MathParser parser;

        /// <summary>
        /// Constructeur pour la fonction catésienne
        /// </summary>
        /// <param name="equation">équation de la droite</param>
        /// <param name="frm">la forme ou l'équation va être dessiner</param>
        public Calcul(string equation)
        {
            this._equation = equation;
            parser = new MathParser();
        }
        /// <summary>
        /// Constructeur pour la fonction paramétrique
        /// </summary>
        /// <param name="equationParamX"></param>
        /// <param name="equationParamY"></param>
        public Calcul(string equationParamX, string equationParamY)
        {
            this._equationParamX = equationParamX;
            this._equationParamY = equationParamY;
            parser = new MathParser();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Retourn une liste avec les points X et Y de la droite</returns>
        public List<PointF> PointXYEquation(double xmin, double xmax, float dx, Form frm)
        {
            List<PointF> XY = new List<PointF>();
            for (float x = (float)xmin; x <= xmax; x += dx)
            {
                float y = Convert.ToSingle(Calculate(_equation,x));

                if (!(double.IsNaN(y)) && (y != 0))
                {
                    XY.Add(new PointF(x, -y));
                }
            }
            return XY;
        }

        public List<PointF> PointXYEquationParametrique(double xmin, double xmax, float dx)
        {
            List<PointF> XY = new List<PointF>();

            for (float t = (float)xmin; t < xmax; t += dx)
            {
                float x = Convert.ToSingle(Calculate(_equationParamX, t));
                float y = Convert.ToSingle(Calculate(_equationParamY, t));

                if (!(double.IsNaN(y))  && (y != 0) && !(double.IsNaN(x))  && (x != 0))
                {
                    XY.Add(new PointF(x, -y));
                }
            }
            return XY;
        }


        /// <summary>
        ///  CODE • http://www.bestcode.com/assets/docs/bcParserNET/
        /// </summary>
        /// <param name="formula">équation string qu'on doit calculer</param>
        /// <returns>le résultat de l'équation donc le point Y</returns>
        double Calculate(string equation,float x)
        {
            parser.Expression = equation;
            parser.X = x;
            return parser.ValueAsDouble;
        }
    }
}
