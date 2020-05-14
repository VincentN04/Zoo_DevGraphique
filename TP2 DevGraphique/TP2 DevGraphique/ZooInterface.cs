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
    public partial class ZooInterface : Form
    { 
        public ZooInterface()
        {
            InitializeComponent();
            ToolStripInformative.miseAJourToolStrip();
        }
        

        /// <summary>
        /// Affiche les informations de l'animal ou du visiteur
        /// </summary>
        /// <param name="e"></param>
        private void VerifieD(MouseEventArgs e)
        {
            int x = e.X / 32;
            int y = e.Y / 32;
            if (carteJeu1.MapObstacle[x, y] == false)
            {
                if (y > 2 && y < 6 && x > 2 && x < 10 || y > 9 && y < 13 && x > 2 && x < 10 ||
                    y > 2 && y < 6 && x > 14 && x < 22 || y > 9 && y < 13 && x > 14 && x < 22)
                {
                    AnimalnfoWindow InfoForm = new AnimalnfoWindow();
                    InfoForm.Show();
                }
            }
        }

        /// <summary>
        /// Affiche le form qui accède à la classe qui permet le choix d'animal
        /// </summary>
        /// <param name="e"></param>
        private void VerifieG(MouseEventArgs e)
        {
            int x = e.X / 32;
            int y = e.Y / 32;
            if (carteJeu1.MapObstacle[x, y] == false)
            {
                if (y > 2 && y < 6 && x > 2 && x < 10 || y > 9 && y < 13 && x > 2 && x < 10 ||
                    y > 2 && y < 6 && x > 14 && x < 22 || y > 9 && y < 13 && x > 14 && x < 22)
                {
                    CarteJeu.Choix_Animal(e);

                }
            }

        }
        private bool ProcheHeros(MouseEventArgs e)
        {
            bool EstHeros = false;
            if (carteJeu1.posVer / 32 == (e.Y - 32) / 32)
            {
                EstHeros = true;
            }
            if (carteJeu1.posVer / 32 == (e.Y + 32) / 32)
            {
                EstHeros = true;
            }
            if (carteJeu1.posHor / 32 == (e.X - 32) / 32)
            {
                EstHeros = true;
            }
            if (carteJeu1.posHor / 32 == (e.X + 32) / 32)
            {
                EstHeros = true;
            }
            if (carteJeu1.posHor / 32 == (e.X - 32) / 32 && carteJeu1.posVer / 32 == (e.Y + 32) / 32)
            {
                EstHeros = true;
            }
            if (carteJeu1.posHor / 32 == (e.X - 32) / 32 && carteJeu1.posVer / 32 == (e.Y - 32) / 32)
            {
                EstHeros = true;
            }
            if (carteJeu1.posHor / 32 == (e.X + 32) / 32 && carteJeu1.posVer / 32 == (e.Y + 32) / 32)
            {
                EstHeros = true;
            }
            if (carteJeu1.posHor / 32 == (e.X + 32) / 32 && carteJeu1.posVer / 32 == (e.Y - 32) / 32)
            {
                EstHeros = true;
            }
            return EstHeros;
        }

        /// <summary>
        /// Détecte le click des touches de flèches
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns> La touche pesée </returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            carteJeu1.EvenementClick(keyData);
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void carteJeu1_MouseDown(object sender, MouseEventArgs e)
        {
        int x = e.X / 32;
        int y = e.Y / 32;
        switch (e.Button)
        {
            case MouseButtons.Left:
                if (ProcheHeros(e) == true)
                {
                    VerifieG(e);
                }
                break;
            case MouseButtons.Right:
                if (ProcheHeros(e) == true)
                {
                    VerifieD(e);
                }
                break;
            }
        }

       

    }
}
