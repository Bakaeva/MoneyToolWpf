
namespace MoneyToolWpf.UserControls
{
    partial class MoneyControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lSummaInRubles = new System.Windows.Forms.Label();
            this.cbCurrency = new System.Windows.Forms.ComboBox();
            this.nudSumma = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSumma)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lSummaInRubles);
            this.panel1.Controls.Add(this.cbCurrency);
            this.panel1.Controls.Add(this.nudSumma);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(168, 63);
            this.panel1.TabIndex = 3;
            // 
            // lSummaInRubles
            // 
            this.lSummaInRubles.AutoSize = true;
            this.lSummaInRubles.Location = new System.Drawing.Point(12, 36);
            this.lSummaInRubles.Name = "lSummaInRubles";
            this.lSummaInRubles.Size = new System.Drawing.Size(46, 17);
            this.lSummaInRubles.TabIndex = 5;
            this.lSummaInRubles.Text = "label1";
            // 
            // cbCurrency
            // 
            this.cbCurrency.FormattingEnabled = true;
            this.cbCurrency.Location = new System.Drawing.Point(101, 9);
            this.cbCurrency.Name = "cbCurrency";
            this.cbCurrency.Size = new System.Drawing.Size(56, 24);
            this.cbCurrency.TabIndex = 4;
            // 
            // nudSumma
            // 
            this.nudSumma.Location = new System.Drawing.Point(12, 10);
            this.nudSumma.Name = "nudSumma";
            this.nudSumma.Size = new System.Drawing.Size(74, 22);
            this.nudSumma.TabIndex = 3;
            // 
            // MoneyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "MoneyControl";
            this.Size = new System.Drawing.Size(173, 68);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSumma)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lSummaInRubles;
        private System.Windows.Forms.ComboBox cbCurrency;
        private System.Windows.Forms.NumericUpDown nudSumma;
    }
}
