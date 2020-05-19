using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP2;

namespace TP2_DevGraphique
{
    public partial class ChoixAnimaux : Form
    {
        private string choix;

        public ChoixAnimaux()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (Heros.monaieJoueur >= 20)
            {
                this.Close();
                choix = "Mouton";
                CarteJeu.SpawnerAnimal(choix);
                Heros.baisseArgent(20);
                ToolStripInformative.miseAJourToolStrip();
            } else
            {
                MessageBox.Show("Vous n'avez pas assez d'argent pour acheter un mouton !");
            }
            
        }

        private void pictureBox2_Click(object sender, EventArgs e) //unicorn
        {
            if (Heros.monaieJoueur >= 35)
            {
 this.Close();
            choix = "Licorne";
            CarteJeu.SpawnerAnimal(choix);
                Heros.baisseArgent(35);
                ToolStripInformative.miseAJourToolStrip();

            }
            else
            {
                MessageBox.Show("Vous n'avez pas assez d'argent pour acheter une licorne !");

            }

        }

        private void pictureBox1_Click(object sender, EventArgs e) //lion
        {
            if (Heros.monaieJoueur >= 50)
            {
                this.Close();
                choix = "Lion";
                CarteJeu.SpawnerAnimal(choix);
                Heros.baisseArgent(50);
                ToolStripInformative.miseAJourToolStrip();


            }
            else
            {
                MessageBox.Show("Vous n'avez pas assez d'argent pour acheter un lion !");

            }
        }
    }
}
