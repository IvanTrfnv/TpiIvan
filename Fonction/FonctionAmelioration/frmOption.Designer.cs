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
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.nmUpParamK = new System.Windows.Forms.NumericUpDown();
            this.nmUpparamKMax = new System.Windows.Forms.NumericUpDown();
            this.nmUpYmax = new System.Windows.Forms.NumericUpDown();
            this.nmUpXmax = new System.Windows.Forms.NumericUpDown();
            this.nmUpYmin = new System.Windows.Forms.NumericUpDown();
            this.nmUpXmin = new System.Windows.Forms.NumericUpDown();
            this.lblXmin = new System.Windows.Forms.Label();
            this.lblXmax = new System.Windows.Forms.Label();
            this.lblYmin = new System.Windows.Forms.Label();
            this.lblYmax = new System.Windows.Forms.Label();
            this.btnReinitialiser = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpPrecisionCalcul)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpParamK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpparamKMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpYmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpXmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpYmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpXmin)).BeginInit();
            this.SuspendLayout();
            // 
            // nmUpPrecisionCalcul
            // 
            this.nmUpPrecisionCalcul.Location = new System.Drawing.Point(152, 12);
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
            // btnEnregistrer
            // 
            this.btnEnregistrer.Location = new System.Drawing.Point(152, 141);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(120, 23);
            this.btnEnregistrer.TabIndex = 4;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = true;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click);
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
            1000,
            0,
            0,
            -2147483648});
            this.nmUpParamK.Name = "nmUpParamK";
            this.nmUpParamK.Size = new System.Drawing.Size(56, 20);
            this.nmUpParamK.TabIndex = 3;
            this.nmUpParamK.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nmUpparamKMax
            // 
            this.nmUpparamKMax.Location = new System.Drawing.Point(216, 42);
            this.nmUpparamKMax.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nmUpparamKMax.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nmUpparamKMax.Name = "nmUpparamKMax";
            this.nmUpparamKMax.Size = new System.Drawing.Size(56, 20);
            this.nmUpparamKMax.TabIndex = 5;
            this.nmUpparamKMax.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nmUpYmax
            // 
            this.nmUpYmax.Location = new System.Drawing.Point(216, 109);
            this.nmUpYmax.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nmUpYmax.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nmUpYmax.Name = "nmUpYmax";
            this.nmUpYmax.Size = new System.Drawing.Size(56, 20);
            this.nmUpYmax.TabIndex = 6;
            this.nmUpYmax.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nmUpXmax
            // 
            this.nmUpXmax.Location = new System.Drawing.Point(58, 109);
            this.nmUpXmax.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nmUpXmax.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nmUpXmax.Name = "nmUpXmax";
            this.nmUpXmax.Size = new System.Drawing.Size(56, 20);
            this.nmUpXmax.TabIndex = 7;
            this.nmUpXmax.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nmUpYmin
            // 
            this.nmUpYmin.Location = new System.Drawing.Point(216, 83);
            this.nmUpYmin.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nmUpYmin.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nmUpYmin.Name = "nmUpYmin";
            this.nmUpYmin.Size = new System.Drawing.Size(56, 20);
            this.nmUpYmin.TabIndex = 8;
            this.nmUpYmin.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // nmUpXmin
            // 
            this.nmUpXmin.Location = new System.Drawing.Point(58, 83);
            this.nmUpXmin.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nmUpXmin.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nmUpXmin.Name = "nmUpXmin";
            this.nmUpXmin.Size = new System.Drawing.Size(56, 20);
            this.nmUpXmin.TabIndex = 9;
            this.nmUpXmin.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // lblXmin
            // 
            this.lblXmin.AutoSize = true;
            this.lblXmin.Location = new System.Drawing.Point(12, 85);
            this.lblXmin.Name = "lblXmin";
            this.lblXmin.Size = new System.Drawing.Size(39, 13);
            this.lblXmin.TabIndex = 10;
            this.lblXmin.Text = "Xmin : ";
            // 
            // lblXmax
            // 
            this.lblXmax.AutoSize = true;
            this.lblXmax.Location = new System.Drawing.Point(12, 111);
            this.lblXmax.Name = "lblXmax";
            this.lblXmax.Size = new System.Drawing.Size(42, 13);
            this.lblXmax.TabIndex = 11;
            this.lblXmax.Text = "Xmax : ";
            // 
            // lblYmin
            // 
            this.lblYmin.AutoSize = true;
            this.lblYmin.Location = new System.Drawing.Point(175, 85);
            this.lblYmin.Name = "lblYmin";
            this.lblYmin.Size = new System.Drawing.Size(39, 13);
            this.lblYmin.TabIndex = 12;
            this.lblYmin.Text = "Ymin : ";
            // 
            // lblYmax
            // 
            this.lblYmax.AutoSize = true;
            this.lblYmax.Location = new System.Drawing.Point(173, 111);
            this.lblYmax.Name = "lblYmax";
            this.lblYmax.Size = new System.Drawing.Size(42, 13);
            this.lblYmax.TabIndex = 13;
            this.lblYmax.Text = "Ymax : ";
            // 
            // btnReinitialiser
            // 
            this.btnReinitialiser.Location = new System.Drawing.Point(12, 141);
            this.btnReinitialiser.Name = "btnReinitialiser";
            this.btnReinitialiser.Size = new System.Drawing.Size(102, 23);
            this.btnReinitialiser.TabIndex = 14;
            this.btnReinitialiser.Text = "Réinitialiser";
            this.btnReinitialiser.UseVisualStyleBackColor = true;
            this.btnReinitialiser.Click += new System.EventHandler(this.btnReinitialiser_Click);
            // 
            // frmOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 176);
            this.Controls.Add(this.btnReinitialiser);
            this.Controls.Add(this.lblYmax);
            this.Controls.Add(this.lblYmin);
            this.Controls.Add(this.lblXmax);
            this.Controls.Add(this.lblXmin);
            this.Controls.Add(this.nmUpXmin);
            this.Controls.Add(this.nmUpYmin);
            this.Controls.Add(this.nmUpXmax);
            this.Controls.Add(this.nmUpYmax);
            this.Controls.Add(this.nmUpparamKMax);
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
            ((System.ComponentModel.ISupportInitialize)(this.nmUpparamKMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpYmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpXmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpYmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpXmin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nmUpPrecisionCalcul;
        private System.Windows.Forms.Label lblPrecisionCalcul;
        private System.Windows.Forms.Label lblParamK;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.NumericUpDown nmUpParamK;
        private System.Windows.Forms.NumericUpDown nmUpparamKMax;
        private System.Windows.Forms.NumericUpDown nmUpYmax;
        private System.Windows.Forms.NumericUpDown nmUpXmax;
        private System.Windows.Forms.NumericUpDown nmUpYmin;
        private System.Windows.Forms.NumericUpDown nmUpXmin;
        private System.Windows.Forms.Label lblXmin;
        private System.Windows.Forms.Label lblXmax;
        private System.Windows.Forms.Label lblYmin;
        private System.Windows.Forms.Label lblYmax;
        private System.Windows.Forms.Button btnReinitialiser;
    }
}