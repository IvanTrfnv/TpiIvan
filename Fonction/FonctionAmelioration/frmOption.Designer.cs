namespace FonctionAmelioration
{
    partial class frmOption
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nmUpPrecisionCalcul = new System.Windows.Forms.NumericUpDown();
            this.lblPrecisionCalcul = new System.Windows.Forms.Label();
            this.lblParamK = new System.Windows.Forms.Label();
            this.nmUpParamK = new System.Windows.Forms.NumericUpDown();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpPrecisionCalcul)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpParamK)).BeginInit();
            this.SuspendLayout();
            // 
            // nmUpPrecisionCalcul
            // 
            this.nmUpPrecisionCalcul.Location = new System.Drawing.Point(152, 12);
            this.nmUpPrecisionCalcul.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nmUpPrecisionCalcul.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmUpPrecisionCalcul.Name = "nmUpPrecisionCalcul";
            this.nmUpPrecisionCalcul.Size = new System.Drawing.Size(120, 20);
            this.nmUpPrecisionCalcul.TabIndex = 0;
            this.nmUpPrecisionCalcul.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblPrecisionCalcul
            // 
            this.lblPrecisionCalcul.AutoSize = true;
            this.lblPrecisionCalcul.Location = new System.Drawing.Point(12, 14);
            this.lblPrecisionCalcul.Name = "lblPrecisionCalcul";
            this.lblPrecisionCalcul.Size = new System.Drawing.Size(102, 13);
            this.lblPrecisionCalcul.TabIndex = 1;
            this.lblPrecisionCalcul.Text = "Précision de calcul :";
            // 
            // lblParamK
            // 
            this.lblParamK.AutoSize = true;
            this.lblParamK.Location = new System.Drawing.Point(12, 42);
            this.lblParamK.Name = "lblParamK";
            this.lblParamK.Size = new System.Drawing.Size(70, 13);
            this.lblParamK.TabIndex = 2;
            this.lblParamK.Text = "Paramètre k :";
            // 
            // nmUpParamK
            // 
            this.nmUpParamK.Location = new System.Drawing.Point(152, 42);
            this.nmUpParamK.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nmUpParamK.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmUpParamK.Name = "nmUpParamK";
            this.nmUpParamK.Size = new System.Drawing.Size(120, 20);
            this.nmUpParamK.TabIndex = 3;
            this.nmUpParamK.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.Location = new System.Drawing.Point(152, 68);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(120, 23);
            this.btnEnregistrer.TabIndex = 4;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = true;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click);
            // 
            // frmOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 101);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.nmUpParamK);
            this.Controls.Add(this.lblParamK);
            this.Controls.Add(this.lblPrecisionCalcul);
            this.Controls.Add(this.nmUpPrecisionCalcul);
            this.Name = "frmOption";
            this.Text = "Option";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOption_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nmUpPrecisionCalcul)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpParamK)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nmUpPrecisionCalcul;
        private System.Windows.Forms.Label lblPrecisionCalcul;
        private System.Windows.Forms.Label lblParamK;
        private System.Windows.Forms.NumericUpDown nmUpParamK;
        private System.Windows.Forms.Button btnEnregistrer;
    }
}