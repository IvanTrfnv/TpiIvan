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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBoxEquation
            // 
            this.txtBoxEquation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxEquation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxEquation.Location = new System.Drawing.Point(883, 889);
            this.txtBoxEquation.Name = "txtBoxEquation";
            this.txtBoxEquation.Size = new System.Drawing.Size(100, 20);
            this.txtBoxEquation.TabIndex = 0;
            this.txtBoxEquation.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // txtBoxFct2
            // 
            this.txtBoxFct2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxFct2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxFct2.Location = new System.Drawing.Point(883, 915);
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
            this.picGraph.Location = new System.Drawing.Point(3, 24);
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
            this.lblCheckBoxParam.Location = new System.Drawing.Point(659, 891);
            this.lblCheckBoxParam.Name = "lblCheckBoxParam";
            this.lblCheckBoxParam.Size = new System.Drawing.Size(113, 13);
            this.lblCheckBoxParam.TabIndex = 5;
            this.lblCheckBoxParam.Text = "Fonction Paramètrique";
            // 
            // lblFctUn
            // 
            this.lblFctUn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFctUn.AutoSize = true;
            this.lblFctUn.Location = new System.Drawing.Point(804, 889);
            this.lblFctUn.Name = "lblFctUn";
            this.lblFctUn.Size = new System.Drawing.Size(75, 13);
            this.lblFctUn.TabIndex = 6;
            this.lblFctUn.Text = "Fonction 1 / X";
            // 
            // lblFct2
            // 
            this.lblFct2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFct2.AutoSize = true;
            this.lblFct2.Location = new System.Drawing.Point(804, 917);
            this.lblFct2.Name = "lblFct2";
            this.lblFct2.Size = new System.Drawing.Size(75, 13);
            this.lblFct2.TabIndex = 7;
            this.lblFct2.Text = "Fonction 2 / Y";
            // 
            // chkBParametrique
            // 
            this.chkBParametrique.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkBParametrique.AutoSize = true;
            this.chkBParametrique.Location = new System.Drawing.Point(778, 891);
            this.chkBParametrique.Name = "chkBParametrique";
            this.chkBParametrique.Size = new System.Drawing.Size(15, 14);
            this.chkBParametrique.TabIndex = 4;
            this.chkBParametrique.UseVisualStyleBackColor = true;
            this.chkBParametrique.CheckedChanged += new System.EventHandler(this.chkBParametrique_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 892);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 8;
            // 
            // lblCordSourisX
            // 
            this.lblCordSourisX.AutoSize = true;
            this.lblCordSourisX.Location = new System.Drawing.Point(16, 915);
            this.lblCordSourisX.Name = "lblCordSourisX";
            this.lblCordSourisX.Size = new System.Drawing.Size(0, 13);
            this.lblCordSourisX.TabIndex = 9;
            // 
            // lblSourisX
            // 
            this.lblSourisX.AutoSize = true;
            this.lblSourisX.Location = new System.Drawing.Point(23, 891);
            this.lblSourisX.Name = "lblSourisX";
            this.lblSourisX.Size = new System.Drawing.Size(0, 13);
            this.lblSourisX.TabIndex = 10;
            // 
            // lblSourisY
            // 
            this.lblSourisY.AutoSize = true;
            this.lblSourisY.Location = new System.Drawing.Point(23, 915);
            this.lblSourisY.Name = "lblSourisY";
            this.lblSourisY.Size = new System.Drawing.Size(0, 13);
            this.lblSourisY.TabIndex = 11;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            this.optionToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.optionToolStripMenuItem.Text = "Option";
            this.optionToolStripMenuItem.Click += new System.EventHandler(this.optionToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "?";
            // 
            // Fonction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 940);
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
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Fonction";
            this.Text = "Fonction";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private MenuStrip menuStrip1;
        private ToolStripMenuItem optionToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
    }
}

