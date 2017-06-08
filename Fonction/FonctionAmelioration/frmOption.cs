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

        public frmOption()
        {
            InitializeComponent();
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            Option.PrecisionCalcul = Convert.ToInt32(nmUpPrecisionCalcul.Value);
            Option.ParamK = nmUpParamK.Value;
        }

        private void frmOption_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
