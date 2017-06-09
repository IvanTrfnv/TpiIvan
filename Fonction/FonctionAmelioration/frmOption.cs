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
            nmUpParamK.Value = Option.ParamK;
            nmUpparamKMax.Value = Option.ParamKMax;
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            Option.PrecisionCalcul = Convert.ToInt32(nmUpPrecisionCalcul.Value)*10;
            Option.Xmin =Convert.ToDouble(nmUpXmin.Value);
            Option.Xmax = Convert.ToDouble(nmUpXmax.Value);
            Option.Ymin = Convert.ToDouble(nmUpYmin.Value);
            Option.Ymax = Convert.ToDouble(nmUpYmax.Value);
            Option.ParamK = nmUpParamK.Value;
            Option.ParamKMax = nmUpparamKMax.Value;
            frm.Rafraichir();
            this.Dispose();
        }

        private void frmOption_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
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
