using System;
using System.Windows.Forms;

namespace FonctionAmelioration
{
    partial class Fonction
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
            this.txtBoxEquation = new System.Windows.Forms.TextBox();
            this.txtBoxFct2 = new System.Windows.Forms.TextBox();
            this.picGraph = new System.Windows.Forms.PictureBox();
            this.lblCheckBoxParam = new System.Windows.Forms.Label();
            this.lblFctUn = new System.Windows.Forms.Label();
            this.lblFct2 = new System.Windows.Forms.Label();
            this.chkBParametrique = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCordSourisX = new System.Windows.Forms.Label();
            this.lblSourisX = new System.Windows.Forms.Label();
            this.lblSourisY = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBoxEquation
            // 
            this.txtBoxEquation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxEquation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxEquation.Location = new System.Drawing.Point(883, 868);
            this.txtBoxEquation.Name = "txtBoxEquation";
            this.txtBoxEquation.Size = new System.Drawing.Size(100, 20);
            this.txtBoxEquation.TabIndex = 0;
            this.txtBoxEquation.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // txtBoxFct2
            // 
            this.txtBoxFct2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxFct2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxFct2.Location = new System.Drawing.Point(883, 894);
            this.txtBoxFct2.Name = "txtBoxFct2";
            this.txtBoxFct2.Size = new System.Drawing.Size(100, 20);
            this.txtBoxFct2.TabIndex = 2;
            this.txtBoxFct2.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // picGraph
            // 
            this.picGraph.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picGraph.Location = new System.Drawing.Point(3, 3);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(980, 859);
            this.picGraph.TabIndex = 3;
            this.picGraph.TabStop = false;
            this.picGraph.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picGraph_MouseMove);
            // 
            // lblCheckBoxParam
            // 
            this.lblCheckBoxParam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCheckBoxParam.AutoSize = true;
            this.lblCheckBoxParam.Location = new System.Drawing.Point(659, 870);
            this.lblCheckBoxParam.Name = "lblCheckBoxParam";
            this.lblCheckBoxParam.Size = new System.Drawing.Size(113, 13);
            this.lblCheckBoxParam.TabIndex = 5;
            this.lblCheckBoxParam.Text = "Fonction Paramètrique";
            // 
            // lblFctUn
            // 
            this.lblFctUn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFctUn.AutoSize = true;
            this.lblFctUn.Location = new System.Drawing.Point(804, 868);
            this.lblFctUn.Name = "lblFctUn";
            this.lblFctUn.Size = new System.Drawing.Size(75, 13);
            this.lblFctUn.TabIndex = 6;
            this.lblFctUn.Text = "Fonction 1 / X";
            // 
            // lblFct2
            // 
            this.lblFct2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFct2.AutoSize = true;
            this.lblFct2.Location = new System.Drawing.Point(804, 896);
            this.lblFct2.Name = "lblFct2";
            this.lblFct2.Size = new System.Drawing.Size(75, 13);
            this.lblFct2.TabIndex = 7;
            this.lblFct2.Text = "Fonction 2 / Y";
            // 
            // chkBParametrique
            // 
            this.chkBParametrique.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkBParametrique.AutoSize = true;
            this.chkBParametrique.Location = new System.Drawing.Point(778, 870);
            this.chkBParametrique.Name = "chkBParametrique";
            this.chkBParametrique.Size = new System.Drawing.Size(15, 14);
            this.chkBParametrique.TabIndex = 4;
            this.chkBParametrique.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 875);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 8;
            // 
            // lblCordSourisX
            // 
            this.lblCordSourisX.AutoSize = true;
            this.lblCordSourisX.Location = new System.Drawing.Point(23, 901);
            this.lblCordSourisX.Name = "lblCordSourisX";
            this.lblCordSourisX.Size = new System.Drawing.Size(0, 13);
            this.lblCordSourisX.TabIndex = 9;
            // 
            // lblSourisX
            // 
            this.lblSourisX.AutoSize = true;
            this.lblSourisX.Location = new System.Drawing.Point(30, 874);
            this.lblSourisX.Name = "lblSourisX";
            this.lblSourisX.Size = new System.Drawing.Size(0, 13);
            this.lblSourisX.TabIndex = 10;
            // 
            // lblSourisY
            // 
            this.lblSourisY.AutoSize = true;
            this.lblSourisY.Location = new System.Drawing.Point(30, 901);
            this.lblSourisY.Name = "lblSourisY";
            this.lblSourisY.Size = new System.Drawing.Size(0, 13);
            this.lblSourisY.TabIndex = 11;
            // 
            // Fonction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 919);
            this.Controls.Add(this.lblSourisY);
            this.Controls.Add(this.lblSourisX);
            this.Controls.Add(this.lblCordSourisX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblFct2);
            this.Controls.Add(this.lblFctUn);
            this.Controls.Add(this.lblCheckBoxParam);
            this.Controls.Add(this.chkBParametrique);
            this.Controls.Add(this.picGraph);
            this.Controls.Add(this.txtBoxFct2);
            this.Controls.Add(this.txtBoxEquation);
            this.Name = "Fonction";
            this.Text = "Fonction";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxEquation;
        private System.Windows.Forms.TextBox txtBoxFct2;
        private System.Windows.Forms.PictureBox picGraph;
        private Label lblCheckBoxParam;
        private Label lblFctUn;
        private Label lblFct2;
        private CheckBox chkBParametrique;
        private Label label1;
        private Label lblCordSourisX;
        private Label lblSourisX;
        private Label lblSourisY;
    }
}

