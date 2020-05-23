using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP2;

namespace TP2_DevGraphique
{
    public partial class ToolStripInformative : UserControl
    {
        public ToolStripInformative()
        {
            InitializeComponent();
            labelJour.Text += DateTime.Today.ToString("D");

        }

        public static void miseAJourToolStrip()
        {

            CarteJeu.RefreshTrash();
            labelAnimaux.Text = "Animaux : " + CarteJeu.comptAnimal;
            labelArgent.Text = "Argent : " + Heros.monaieJoueur;
            labelVisiteurs.Text = "Visiteurs : " + CarteJeu.comptVisiteur;
            labelDechets.Text = "Dechets : " + CarteJeu.comptDechets;
        }
    }
}
