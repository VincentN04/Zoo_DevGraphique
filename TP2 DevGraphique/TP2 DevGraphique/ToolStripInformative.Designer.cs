namespace TP2_DevGraphique
{
    partial class ToolStripInformative
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            labelJour = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            labelArgent = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            labelAnimaux = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            labelVisiteurs = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            labelDechets = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            labelJour,
            this.toolStripSeparator1,
            labelArgent,
            this.toolStripSeparator2,
            labelAnimaux,
            this.toolStripSeparator3,
            labelVisiteurs,
            this.toolStripSeparator4,
            labelDechets,
            this.toolStripSeparator5});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(954, 28);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // labelJour
            // 
            labelJour.ForeColor = System.Drawing.Color.White;
            labelJour.Name = "labelJour";
            labelJour.Size = new System.Drawing.Size(62, 25);
            labelJour.Text = "Jour : ";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // labelArgent
            // 
            labelArgent.ForeColor = System.Drawing.Color.White;
            labelArgent.Name = "labelArgent";
            labelArgent.Size = new System.Drawing.Size(83, 25);
            labelArgent.Text = "Argent : ";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // labelAnimaux
            // 
            labelAnimaux.ForeColor = System.Drawing.Color.White;
            labelAnimaux.Name = "labelAnimaux";
            labelAnimaux.Size = new System.Drawing.Size(100, 25);
            labelAnimaux.Text = "Animaux : ";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 28);
            // 
            // labelVisiteurs
            // 
            labelVisiteurs.ForeColor = System.Drawing.Color.White;
            labelVisiteurs.Name = "labelVisiteurs";
            labelVisiteurs.Size = new System.Drawing.Size(98, 25);
            labelVisiteurs.Text = "Visiteurs : ";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 28);
            // 
            // labelDechets
            // 
            labelDechets.ForeColor = System.Drawing.Color.White;
            labelDechets.Name = "labelDechets";
            labelDechets.Size = new System.Drawing.Size(88, 25);
            labelDechets.Text = "Dechets :";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 28);
            // 
            // ToolStripInformative
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.Controls.Add(this.toolStrip1);
            this.Name = "ToolStripInformative";
            this.Size = new System.Drawing.Size(954, 28);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        public static System.Windows.Forms.ToolStripLabel labelJour;
        private static System.Windows.Forms.ToolStripLabel labelDechets;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private static System.Windows.Forms.ToolStripLabel labelArgent;
        private static System.Windows.Forms.ToolStripLabel labelAnimaux;
        private static System.Windows.Forms.ToolStripLabel labelVisiteurs;
    }
}
