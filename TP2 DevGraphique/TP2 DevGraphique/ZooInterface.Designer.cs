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
            this.SuspendLayout();
            // 
            // carteJeu1
            // 
            this.carteJeu1.Location = new System.Drawing.Point(13, 0);
            this.carteJeu1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.carteJeu1.Name = "carteJeu1";
            this.carteJeu1.Size = new System.Drawing.Size(1323, 643);
            this.carteJeu1.TabIndex = 0;
            // 
            // ZooInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1335, 638);
            this.Controls.Add(this.carteJeu1);
            this.Name = "ZooInterface";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private TP2.CarteJeu carteJeu1;
    }
}

