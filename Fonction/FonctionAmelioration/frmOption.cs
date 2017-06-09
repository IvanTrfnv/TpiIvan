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
        public frmOption(Fonction frm)
        {
            InitializeComponent();
            nmUpPrecisionCalcul.Value = Option.PrecisionCalcul/10;
            nmUpXmin.Value = Convert.ToDecimal(Option.Xmin);
            nmUpXmax.Value = Convert.ToDecimal(Option.Xmax);
            nmUpYmin.Value = Convert.ToDecimal(Option.Ymin);
            nmUpYmax.Value = Convert.ToDecimal(Option.Ymax);
            nmUpParamK.Value = Option.ParamK;
            nmUpparamKMax.Value = Option.ParamKMax;
            this.frm = frm;
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
    }
}
