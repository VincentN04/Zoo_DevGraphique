using TP2;

namespace TP2_DevGraphique
{
    partial class ZooInterface
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.labelJour = new System.Windows.Forms.ToolStripLabel();
            this.labelAnimaux = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.labelMoney = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.labelVisiteurs = new System.Windows.Forms.ToolStripLabel();
            this.carteJeu1 = new TP2.CarteJeu();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelJour,
            this.toolStripSeparator1,
            this.labelMoney,
            this.toolStripSeparator2,
            this.labelAnimaux,
            this.toolStripSeparator3,
            this.labelVisiteurs});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(954, 28);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // labelJour
            // 
            this.labelJour.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelJour.ForeColor = System.Drawing.Color.White;
            this.labelJour.Name = "labelJour";
            this.labelJour.Size = new System.Drawing.Size(62, 25);
            this.labelJour.Text = "Jour : ";
            // 
            // labelAnimaux
            // 
            this.labelAnimaux.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAnimaux.ForeColor = System.Drawing.Color.White;
            this.labelAnimaux.Name = "labelAnimaux";
            this.labelAnimaux.Size = new System.Drawing.Size(100, 25);
            this.labelAnimaux.Text = "Animaux : ";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // labelMoney
            // 
            this.labelMoney.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMoney.ForeColor = System.Drawing.Color.White;
            this.labelMoney.Name = "labelMoney";
            this.labelMoney.Size = new System.Drawing.Size(84, 25);
            this.labelMoney.Text = "Money : ";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 28);
            // 
            // labelVisiteurs
            // 
            this.labelVisiteurs.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVisiteurs.ForeColor = System.Drawing.Color.White;
            this.labelVisiteurs.Name = "labelVisiteurs";
            this.labelVisiteurs.Size = new System.Drawing.Size(98, 25);
            this.labelVisiteurs.Text = "Visiteurs : ";
            // 
            // carteJeu1
            // 
            this.carteJeu1.Location = new System.Drawing.Point(-3, 21);
            this.carteJeu1.Name = "carteJeu1";
            this.carteJeu1.Size = new System.Drawing.Size(1019, 672);
            this.carteJeu1.TabIndex = 0;
            this.carteJeu1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.carteJeu1_MouseDown);
            // 
            // ZooInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 690);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.carteJeu1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ZooInterface";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TP2.CarteJeu carteJeu1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel labelJour;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel labelMoney;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel labelAnimaux;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel labelVisiteurs;
    }
}

