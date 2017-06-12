using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FonctionAmelioration
{
    public partial class frmOption : Form
    {
        private Fonction frm;
        private TextBox fct1, fct2;
        CheckBox chk;
        private double deltax;
        private double deltay;
        private double deltaxOld;
        private double deltayOld;
        private double coefZoomx;
        private double coefZoomy;

        private double tmpxmin;
        private double tmpxmax;
        private double tmpymin;
        private double tmpymax;

        public frmOption(Fonction frm, TextBox fct1, TextBox fct2, CheckBox chk)
        {
            InitializeComponent();
            InisialisationComposent();
            this.frm = frm;
            this.fct1 = fct1;
            this.fct2 = fct2;
            this.chk = chk;
        }

        private void InisialisationComposent()
        {
            nmUpPrecisionCalcul.Value = Option.PrecisionCalcul / 10;
            nmUpXmin.Value = Convert.ToDecimal(Option.Xmin);
            nmUpXmax.Value = Convert.ToDecimal(Option.Xmax);
            nmUpYmin.Value = Convert.ToDecimal(Option.Ymin);
            nmUpYmax.Value = Convert.ToDecimal(Option.Ymax);
            tmpxmin = Option.Xmin; 
            tmpxmax =Option.Xmax; 
            tmpymin =Option.Ymin; 
            tmpymax = Option.Ymax;
            nmUpParamK.Value = Option.ParamK;
            nmUpparamKMax.Value = Option.ParamKMax;
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            Option.PrecisionCalcul = Convert.ToInt32(nmUpPrecisionCalcul.Value)*10;
            Option.ParamK = nmUpParamK.Value;
            Option.ParamKMax = nmUpparamKMax.Value;
            Option.Xmin = tmpxmin;
            Option.Xmax = tmpxmax;
            Option.Ymin = tmpymin;
            Option.Ymax = tmpymax;
            frm.Rafraichir();
            this.Dispose();
        }

        private void frmOption_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void nmUpXmin_ValueChanged(object sender, EventArgs e)
        {
            tmpxmin = Convert.ToDouble(nmUpXmin.Value);
            CalculNewDeltaY();
        }

        private void nmUpXmax_ValueChanged(object sender, EventArgs e)
        {
            tmpxmax = Convert.ToDouble(nmUpXmax.Value);
            CalculNewDeltaY();

        }

        private void CalculNewDeltaY()
        {
            deltayOld = Math.Abs(Option.YmaxOld - Option.YminOld);
            deltaxOld = Math.Abs(Option.XmaxOld - Option.XminOld);
            coefZoomy = deltaxOld / Math.Abs(tmpxmax - tmpxmin);
            deltax = Math.Round(deltayOld / coefZoomy);
            tmpymin = Math.Round((tmpymin + tmpymax) / 2 - deltax / 2);
            tmpymax = Math.Round((tmpymin + tmpymax) / 2 + deltax / 2);
         }


        private void nmUpYmin_ValueChanged(object sender, EventArgs e)
        {
            tmpymin = Convert.ToDouble(nmUpYmin.Value);
            CalculNewDeltaX();
        }

        private void CalculNewDeltaX()
        {
            deltaxOld = Math.Abs(Option.XmaxOld - Option.XminOld);
            deltayOld = Math.Abs(Option.YmaxOld - Option.YminOld);
            coefZoomx = deltayOld / Math.Abs(tmpymax - tmpymin);
            deltay = Math.Round(deltaxOld / coefZoomx);
            tmpxmin = Math.Round((tmpxmin + tmpxmax) / 2 - deltay / 2);
            tmpxmax = Math.Round((tmpxmin + tmpxmax) / 2 + deltay / 2);
        }

        private void nmUpYmax_ValueChanged(object sender, EventArgs e)
        {
            tmpymax = Convert.ToDouble(nmUpYmax.Value);
            CalculNewDeltaX();
        }

        private void btnReinitialiser_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez vous vraiment effacer l'ensemble de vos équations ?", "Confirm", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                Option.Xmin = -5;
                Option.Xmax = 5;
                Option.Ymin = -5;
                Option.Ymax = 5;
                Option.PrecisionCalcul = Convert.ToInt32(nmUpPrecisionCalcul.Value) * 10;
                fct1.Text = "";
                fct2.Text = "";
                chk.Checked = false;
                InisialisationComposent();
                frm.Rafraichir();
            }

        }
    }
}
