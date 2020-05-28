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
    public partial class AnimalnfoWindow : Form
    {
        public AnimalnfoWindow()
        {
            InitializeComponent();
        }

        public void UpdateInfo(Button b, int pos)
        {
            LblNom1.Text = CarteJeu.RegistreA[pos].Nom;
            LblType1.Text = CarteJeu.RegistreA[pos].Type;
            LblFaim1.Text = CarteJeu.RegistreA[pos].Faim.ToString();
            //LblEnceinte1.Text = CarteJeu.RegistreA[pos].Enceinte.ToString() ;
            LblSexe1.Text = CarteJeu.RegistreA[pos].Sexe;
            pictureBox1.BackgroundImage = b.BackgroundImage;
            LblSexe1.Refresh();
            LblNom1.Refresh();
            LblFaim1.Refresh();
            LblEnceinte1.Refresh();
            LblType1.Refresh();
            pictureBox1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
