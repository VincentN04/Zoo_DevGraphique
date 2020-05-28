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
        {/*
            int x = e.X / 32;
            int y = e.Y / 32;
            if (carteJeu1.MapObstacle[x, y] == false)
            {
                if (y > 2 && y < 6 && x > 2 && x < 10 || y > 9 && y < 13 && x > 2 && x < 10 ||
                    y > 2 && y < 6 && x > 14 && x < 22 || y > 9 && y < 13 && x > 14 && x < 22)
                {
                    ListeAnimaux ListForm = new ListeAnimaux();
                    ListForm.UpdateButton();
                    ListForm.Show();
                }
            }*/
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
        

        //Regarde s'il y a un dechet sur le curseur et l'enleve s'il y en a un
        private void VerifieDechet(MouseEventArgs e)
        {
        
            int x = e.X / 32;
            int y = e.Y / 32;

            if (CarteJeu.MapDechet[x,y]==true)
            {
                CarteJeu.MapDechet[x,y] = false;
            }       
        }


        /// <summary>
        /// Regarde la table des animaux pour voir si l'un d'eux est sur la case click/
        /// </summary>
        /// <param name="e"> endroit click/</param>
        private void VerifieAnimal(MouseEventArgs e)
        {
            int x = e.X / 32;
            int y = e.Y / 32;

            for (int i = 0; i < CarteJeu.comptAnimal; i++)
            {
                if (CarteJeu.RegistreA[i].x == x)
                {
                    if (CarteJeu.RegistreA[i].y == y)
                    {
                        CarteJeu.AnimalMenu(e, CarteJeu.RegistreA[i]);
                    }
                }
            }
        }

        /// <summary>
        /// Regarde la table des animaux pour voir si l'un d'eux est sur la case click/
        /// </summary>
        /// <param name="e"> endroit click/</param>
        private void VerifieAnimalClickGauche(MouseEventArgs e)
        {
            int x = e.X / 32;
            int y = e.Y / 32;

            for (int i = 0; i < CarteJeu.comptAnimal; i++)
            {
                if(CarteJeu.RegistreA[i].x==x)
                {
                    if (CarteJeu.RegistreA[i].y == y)
                    {
                        CarteJeu.Feed(e, CarteJeu.RegistreA[i]);
                    }
                }
            }
        }

        /// <summary>
        /// La les coordonn/es du click pour voir s'ils sont les meme que la porte de la maison
        /// </summary>
        /// <param name="e"> endroit click/</param>
        private void VerifieConcierge(MouseEventArgs e)
        {

             int x = e.X / 32;
            int y = e.Y / 32;

            if (x == 26 && y == 5 )
            {
                CarteJeu.Choix_Concierge(e);
            }  


        }

        /// <summary>
        /// Regarde si le click de la souris se produit autour du joueur
        /// </summary>
        /// <param name="e">Emplacement de la souris lors du click</param>
        /// <returns></returns>
        private bool ProcheHeros(MouseEventArgs e)
        {
            bool EstHeros = false;

            //regarde les positions en X
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


            //Regarde les positions en croix
            if (carteJeu1.posHor / 32 == (e.X) / 32 && carteJeu1.posVer / 32 == (e.Y + 32) / 32)
            {
                EstHeros = true;
            }
            if (carteJeu1.posHor / 32 == (e.X) / 32 && carteJeu1.posVer / 32 == (e.Y - 32) / 32)
            {
                EstHeros = true;
            }
            if (carteJeu1.posHor / 32 == (e.X - 32) / 32 && carteJeu1.posVer / 32 == (e.Y) / 32)
            {
                EstHeros = true;
            }
            if (carteJeu1.posHor / 32 == (e.X + 32) / 32 && carteJeu1.posVer / 32 == (e.Y) / 32)
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

        /// Gere les clicks gauches et les clicks droits
        private void carteJeu1_MouseDown(object sender, MouseEventArgs e)
        {
        //int x = e.X / 32;
        //int y = e.Y / 32;
        switch (e.Button)
        {
            case MouseButtons.Left:
                if (ProcheHeros(e) == true)
                {
                    VerifieG(e);
                    VerifieDechet(e);
                    VerifieConcierge(e);
                    VerifieAnimalClickGauche(e);
                }
                break;
            case MouseButtons.Right:
                    VerifieD(e);
                    VerifieAnimal(e);
                break;
            }
        }

       

    }
}
