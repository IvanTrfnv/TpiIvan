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

        public static string equation(string equationUtilisateur)
        {
            for (int i = 0; i < equationUtilisateur.Length; i++)
            {
                if (equationUtilisateur[i] == 'x' || equationUtilisateur[i] == 'y')
                {
                    foreach (int nombre in tableauNombre)
                    {
                            //éviter un exception de type IndexOutOfRangeException et regarde si il y a un nombre avant et après 
                            if (i>0  && (equationUtilisateur[i - 1].ToString() == nombre.ToString()))
                            {
                                //CODE pour ajouter le fois pour que le code pussie écrire 3x en 3*x et ou x est une variable réel
                                equationUtilisateur =  equationUtilisateur.Insert(i, "*");
                            }


                            if ((i + 1) < equationUtilisateur.Length)
                            {
                                //éviter un exception de type IndexOutOfRangeException et regarde si il y a un nombre avant et après 
                                if (equationUtilisateur[i + 1].ToString() == nombre.ToString())
                                {
                                    //CODE pour ajouter le fois pour que le code pussie écrire x3 en x*3 et ou x est une variable réel
                                    equationUtilisateur = equationUtilisateur.Insert((i + 1), "*");
                                }
                            }
                    }
                }
            }
            if (equationUtilisateur == "")
                equationUtilisateur = "0";
            return equationUtilisateur;
        }

    }
}
