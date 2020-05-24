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
    public partial class ChoixConcierge : Form
    {
        public ChoixConcierge()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Fait apparaitre un concierge lors d'un click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ///CHanger le check pour ne pas depasser un certain nombre de concierges et non pas l'argent(20?)
            ///il faudra faire une liste or something for that
            if (Heros.monaieJoueur >= 2)
            {
                this.Close();
                CarteJeu.SpawnerConcierge();
            }
            else
            {
                MessageBox.Show("Vous n'avez pas encore assez d'argent pour engager un concierge!");

            }
        }
    }
}
