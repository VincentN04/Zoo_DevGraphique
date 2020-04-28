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
            this.Close();
            choix = "Mouton";
            CarteJeu.SpawnerAnimal(choix);
        }
    }
}
