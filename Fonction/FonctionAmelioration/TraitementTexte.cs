using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FonctionAmelioration
{
    class TraitementTexte
    {
        static int[]  tableauNombre = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        public static string TraitementEquation(string equation)
        {
            for (int i = 0; i < equation.Length; i++)
            {
                if (equation[i] == 'x' || equation[i] == 'y')
                {
                    foreach (int nombre in tableauNombre)
                    {
                            //éviter un exception de type IndexOutOfRangeException et regarde si il y a un nombre avant et après 
                            if (i>0  && (equation[i - 1].ToString() == nombre.ToString()))
                            {
                            //CODE pour ajouter le fois pour que le code pussie écrire 3x en 3*x et ou x est une variable réel
                            equation = equation.Insert(i, "*");
                            }


                            if ((i + 1) < equation.Length)
                            {
                                //éviter un exception de type IndexOutOfRangeException et regarde si il y a un nombre avant et après 
                                if (equation[i + 1].ToString() == nombre.ToString())
                                {
                                //CODE pour ajouter le fois pour que le code pussie écrire x3 en x*3 et ou x est une variable réel
                                equation = equation.Insert((i + 1), "*");
                                }
                            }
                    }
                }
            }
            if (equation == "")
                equation = "0";
            return equation;
        }

    }
}
