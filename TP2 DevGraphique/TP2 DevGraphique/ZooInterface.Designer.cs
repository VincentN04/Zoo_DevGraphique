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
            this.carteJeu1 = new TP2.CarteJeu();
            this.toolStripInformative1 = new TP2_DevGraphique.ToolStripInformative();
            this.SuspendLayout();
            // 
            // carteJeu1
            // 
            this.carteJeu1.Location = new System.Drawing.Point(-3, 21);
            this.carteJeu1.Name = "carteJeu1";
            this.carteJeu1.Size = new System.Drawing.Size(1019, 672);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 690);
            this.Controls.Add(this.toolStripInformative1);
            this.Controls.Add(this.carteJeu1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ZooInterface";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private TP2.CarteJeu carteJeu1;
        private ToolStripInformative toolStripInformative1;
    }
}

