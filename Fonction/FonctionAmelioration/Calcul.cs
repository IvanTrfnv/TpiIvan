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

        /// <summary>
        /// Constructeur pour la fonction catésienne
        /// </summary>
        /// <param name="equation">équation de la droite</param>
        /// <param name="frm">la forme ou l'équation va être dessiner</param>
        public Calcul(string equation)
        {
            this._equation = equation;
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

                if (!(double.IsNaN(y)) && (y < float.MaxValue) && (y > float.MinValue) && (y != 0))
                {
                    XY.Add(new PointF(x, y));
                }

            }
            return XY;
        }

        public List<PointF> PointXYEquationParametrique(double ymin, double ymax, float dx)
        {
            List<PointF> XY = new List<PointF>();
            for (float t = (float)ymin; t < ymax; t += dx)
            {
                float x = Convert.ToSingle(Calculate(_equationParamX, t));
                float y = Convert.ToSingle(Calculate(_equationParamY, t));

                if (!(double.IsNaN(y)) && (y < float.MaxValue) && (y > float.MinValue) && (y != 0) && !(double.IsNaN(x)) && (x < float.MaxValue) && (x > float.MinValue) && (x != 0))
                {
                    XY.Add(new PointF(x, y));
                }
            }
            return XY;
        }

        //Code utilisé avec l'ancienne libraire : Eval.Execute(formula).ToString(); http://csharp-eval.com/HowTo.php
        //public float XOfEquationParametrique(float x)
        //{
        //    return Convert.ToSingle(remplaceX(_equation, x));
        //}

        //private string remplaceX(string equation, double x)
        //{
        //    if (equation.Contains("x"))
        //        return remplaceX(equation.Replace("x", x.ToString()),x);
        //    else
        //        return Calculate(equation);
        //}


        /// <summary>
        ///  CODE • http://www.bestcode.com/assets/docs/bcParserNET/
        /// </summary>
        /// <param name="formula">équation string qu'on doit calculer</param>
        /// <returns>le résultat de l'équation donc le point Y</returns>
        string Calculate(string equation,float x)
        {
            MathParser parser = new MathParser();
            parser.Expression = equation;
            parser.X = x;
            return parser.ValueAsString;
        }
    }
}
