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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.labelMoney = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.labelAnimaux = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.labelVisiteurs = new System.Windows.Forms.ToolStripLabel();
            this.carteJeu1 = new TP2.CarteJeu();
            this.toolStripInformative1 = new TP2_DevGraphique.ToolStripInformative();
            this.SuspendLayout();
            // 

            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
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
            this.toolStrip1.Size = new System.Drawing.Size(1272, 35);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // labelJour
            // 
            this.labelJour.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelJour.ForeColor = System.Drawing.Color.White;
            this.labelJour.Name = "labelJour";
            this.labelJour.Size = new System.Drawing.Size(79, 32);
            this.labelJour.Text = "Jour : ";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 35);
            // 
            // labelMoney
            // 
            this.labelMoney.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMoney.ForeColor = System.Drawing.Color.White;
            this.labelMoney.Name = "labelMoney";
            this.labelMoney.Size = new System.Drawing.Size(109, 32);
            this.labelMoney.Text = "Money : ";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 35);
            // 
            // labelAnimaux
            // 
            this.labelAnimaux.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAnimaux.ForeColor = System.Drawing.Color.White;
            this.labelAnimaux.Name = "labelAnimaux";
            this.labelAnimaux.Size = new System.Drawing.Size(127, 32);
            this.labelAnimaux.Text = "Animaux : ";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 35);
            // 
            // labelVisiteurs
            // 
            this.labelVisiteurs.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVisiteurs.ForeColor = System.Drawing.Color.White;
            this.labelVisiteurs.Name = "labelVisiteurs";
            this.labelVisiteurs.Size = new System.Drawing.Size(124, 32);
            this.labelVisiteurs.Text = "Visiteurs : ";
            // 
            // carteJeu1
            // 
            this.carteJeu1.Location = new System.Drawing.Point(-4, 26);
            this.carteJeu1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.carteJeu1.Name = "carteJeu1";
            this.carteJeu1.Size = new System.Drawing.Size(1276, 827);
            this.carteJeu1.TabIndex = 0;
            this.carteJeu1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.carteJeu1_MouseDown);
            // 
            // toolStripInformative1
            // 
            this.toolStripInformative1.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.toolStripInformative1.Location = new System.Drawing.Point(-3, -1);
            this.toolStripInformative1.Name = "toolStripInformative1";
            this.toolStripInformative1.Size = new System.Drawing.Size(962, 28);
            this.toolStripInformative1.TabIndex = 1;
            // 
            // ZooInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 690);
            this.Controls.Add(this.toolStripInformative1);

            this.Controls.Add(this.carteJeu1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ZooInterface";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private TP2.CarteJeu carteJeu1;
        private ToolStripInformative toolStripInformative1;
    }
}

