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

        public string Equation
        {
            get
            {
                return _equation;
            }

            set
            {
                _equation = value;
            }
        }

        /// <summary>
        /// Constructeur pour la fonction catésienne
        /// </summary>
        /// <param name="equation">équation de la droite</param>
        /// <param name="frm">la forme ou l'équation va être dessiner</param>
        public Calcul(string equation)
        {
            this.Equation = equation.ToLower();
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
        /// Calcul tous les points d'une équation cartésienne affine
        /// </summary>
        /// <param name="xmin">bord gauche en x du rectangle/carré</param>
        /// <param name="xmax">bord droit en x du rectangle/carré</param>
        /// <param name="dx">distance entre deux pixels (plus le nombre est petit plus la précision est meilleure)</param>
        /// <returns>Retourne une liste avec les points X et Y de la courbe</returns>
        public List<PointF> PointXYEquation(double xmin, double xmax, float dx)
        {
            List<PointF> XY = new List<PointF>();
            for (float x = (float)xmin; x <= xmax; x += dx)
            {
                float y = Convert.ToSingle(Calculate(Equation,x));
                // vérifie si le résultat donne un nombre et est différent de zéro
                if (!(double.IsNaN(y)) && (y != 0))
                {
                    XY.Add(new PointF(x, -y));
                }
            }
            return XY;
        }

        /// <summary>
        /// Calcul tous les points d'une équation cartésienne affine avec le paramètre y 
        /// </summary>
        /// <param name="xmin">>bord gauche en x du rectangle/carré</param>
        /// <param name="xmax">bord droit en x du rectangle/carré</param>
        /// <param name="dx">distance entre deux pixels (plus le nombre est petit plus la précision est meilleure)</param>
        /// <param name="paramY">nombre dans la équation semblable à x </param>
        /// <returns>Retourne une liste avec les points X et Y de la courbe</returns>
        public List<PointF> PointXYEquation(double xmin, double xmax, float dx, float paramY)
        {
            List<PointF> XY = new List<PointF>();
            for (float x = (float)xmin; x <= xmax; x += dx)
            {
                float y = Convert.ToSingle(Calculate(Equation, x, paramY));

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

        /// <summary>
        ///  CODE • http://www.bestcode.com/assets/docs/bcParserNET/
        /// </summary>
        /// <param name="formula">équation string qu'on doit calculer</param>
        /// <returns>le résultat de l'équation donc le point Y</returns>
        double Calculate(string equation, float x, float y)
        {
            parser.Expression = equation;
            parser.X = x;
            parser.Y = y;
            return parser.ValueAsDouble;
        }
    }
}
