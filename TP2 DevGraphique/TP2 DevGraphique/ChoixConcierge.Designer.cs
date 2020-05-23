namespace TP2_DevGraphique
{
    partial class ChoixConcierge
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
            this.BtnConcierge = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnConcierge
            // 
            this.BtnConcierge.Location = new System.Drawing.Point(302, 134);
            this.BtnConcierge.Name = "BtnConcierge";
            this.BtnConcierge.Size = new System.Drawing.Size(197, 173);
            this.BtnConcierge.TabIndex = 0;
            this.BtnConcierge.Text = "PUT PRETTY IMAGE HERE";
            this.BtnConcierge.UseVisualStyleBackColor = true;
            this.BtnConcierge.Click += new System.EventHandler(this.BtnConcierge_Click);
            // 
            // ChoixConcierge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(50)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnConcierge);
            this.Name = "ChoixConcierge";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnConcierge;
    }
}