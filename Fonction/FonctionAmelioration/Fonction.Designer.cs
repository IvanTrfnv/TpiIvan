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
            this.chkBParametrique = new System.Windows.Forms.CheckBox();
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
            // chkBParametrique
            // 
            this.chkBParametrique.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkBParametrique.AutoSize = true;
            this.chkBParametrique.Location = new System.Drawing.Point(862, 896);
            this.chkBParametrique.Name = "chkBParametrique";
            this.chkBParametrique.Size = new System.Drawing.Size(15, 14);
            this.chkBParametrique.TabIndex = 4;
            this.chkBParametrique.UseVisualStyleBackColor = true;
            // 
            // Fonction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 919);
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
        private CheckBox chkBParametrique;
    }
}

