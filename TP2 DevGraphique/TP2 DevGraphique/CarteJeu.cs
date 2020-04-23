﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using TP2_DevGraphique;

namespace TP2
{
    public partial class CarteJeu : UserControl
    {

        private static TileVisiteur tile = new TileVisiteur();
        public static bool Villageois = true;
        private static string AnimalEnclos1; //En haut a gauche
        private static string AnimalEnclos2;//en haut a droite
        private static string AnimalEnclos3;// en bas a gauche
        private static string AnimalEnclos4;// en bas a droite
        private Bitmap[,] tabMap = new Bitmap[32, 32];
        private int Temps = 0;
        Random rand = new Random();
        private const int MapPixel = 32;
        public Image image;
        public Rectangle rect;
        public int posHor = 12 * MapPixel;
        public int posVer = 7 * MapPixel;
        public bool[,] MapObstacle = new bool[30, 30];
        public bool[,] MapDechet = new bool[30, 30];
        public static Animaux[] RegistreA = new Animaux[20];
        private static Visiteur[] RegistreV = new Visiteur[20];
        public static int compt = 0;
        public static Boolean Sauter = false;
        //AnimalInfoWindow info = new AnimalInfoWindow();
        int comptJour = 1;
        public bool Deplace = false;
        public static bool dechet = false;
        public static int comptAnimal = 0;
        public static int comptArgent = 100;

        public CarteJeu()
        {

            InitializeComponent();
            InitializeMapTiles();
            InitializeMapObstacles();
            image = TP2_DevGraphique.Properties.Resources.bas1;
        }

        /// <summary>
        /// Démarre les threads du jeu
        /// </summary>
        public void DemarrerJeu()
        {
            Thread thread = new Thread(new ThreadStart(this.BoucleDeJeu));
            thread.IsBackground = true;
            thread.Name = "Boucle de jeu";
            thread.Start();
        }

        /// <summary>
        /// Initialise le tableau boolean qui servira comme tableau d'obstacle pour le héros
        /// </summary>
        private void InitializeMapObstacles()
        {
            // Sortie 
            MapObstacle[13, 19] = true;
            MapObstacle[17, 19] = true;

            // Entree haut
            MapObstacle[27, 7] = true;
            MapObstacle[28, 7] = true;

            // Entree bas
            MapObstacle[27, 11] = true;
            MapObstacle[28, 11] = true;

            // Maison 
            for (int j = 16; j < 21; j++)
            {
                for (int i = 1; i < 5; i++)
                {
                    MapObstacle[i, j] = true;
                }
            }

            // Enclos horizontal haut
            for (int i = 2; i < 11; i++)
            {
                MapObstacle[i, 2] = true;
            }

            for (int i = 14; i < 23; i++)
            {
                MapObstacle[i, 2] = true;
            }

            for (int i = 2; i < 11; i++)
            {
                MapObstacle[i, 9] = true;
            }

            for (int i = 14; i < 23; i++)
            {
                MapObstacle[i, 9] = true;
            }

            // Enclos vertical 1
            for (int i = 2; i < 7; i++)
            {
                MapObstacle[2, i] = true;
            }

            for (int i = 9; i < 14; i++)
            {
                MapObstacle[2, i] = true;
            }

            // Enclos vertical 2
            for (int i = 2; i < 7; i++)
            {
                MapObstacle[10, i] = true;
            }

            for (int i = 9; i < 14; i++)
            {
                MapObstacle[10, i] = true;
            }

            // Enclos vertical 3
            for (int i = 2; i < 7; i++)
            {
                MapObstacle[14, i] = true;
            }

            for (int i = 9; i < 14; i++)
            {
                MapObstacle[14, i] = true;
            }

            // Enclos vertical 4
            for (int i = 2; i < 7; i++)
            {
                MapObstacle[22, i] = true;
            }

            for (int i = 9; i < 14; i++)
            {
                MapObstacle[22, i] = true;
            }

            // Enclos horizontal bas 1
            MapObstacle[3, 6] = true;
            MapObstacle[4, 6] = true;
            MapObstacle[5, 6] = true;

            // Enclos horizontal bas 2
            MapObstacle[7, 6] = true;
            MapObstacle[8, 6] = true;
            MapObstacle[9, 6] = true;

            // Enclos horizontal bas 3
            MapObstacle[15, 6] = true;
            MapObstacle[16, 6] = true;
            MapObstacle[17, 6] = true;

            // Enclos horizontal bas 4
            MapObstacle[19, 6] = true;
            MapObstacle[20, 6] = true;
            MapObstacle[21, 6] = true;

            // Enclos horizontal bas 5
            MapObstacle[3, 13] = true;
            MapObstacle[4, 13] = true;
            MapObstacle[5, 13] = true;

            // Enclos horizontal bas 6
            MapObstacle[7, 13] = true;
            MapObstacle[8, 13] = true;
            MapObstacle[9, 13] = true;

            // Enclos horizontal bas 7
            MapObstacle[15, 13] = true;
            MapObstacle[16, 13] = true;
            MapObstacle[17, 13] = true;

            // Enclos horizontal bas 8
            MapObstacle[19, 13] = true;
            MapObstacle[20, 13] = true;
            MapObstacle[21, 13] = true;
        }

        /// <summary>
        /// Regle le clignotement du form
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        /// <summary>
        /// Dessine dans tabMap pour créer la map initiale
        /// </summary>
        private void InitializeMapTiles()
        {
            Graphics g = this.CreateGraphics();

            for (int i = 0; i < tabMap.GetLength(0); i++)
            {
                for (int j = 0; j < tabMap.GetLength(1); j++)
                {
                    if (i > 2 && i < 10 && j > 2 && j < 6 ||
                        i > 2 && i < 10 && j > 9 && j < 13 ||
                        i > 14 && i < 22 && j > 2 && j < 6 ||
                        i > 14 && i < 22 && j > 9 && j < 13)
                    {
                        tabMap[i, j] = TestTilesetZoo.TilesetImageGenerator.GetTile(1);
                    }
                    else
                    {
                        tabMap[i, j] = TestTilesetZoo.TilesetImageGenerator.GetTile(0);
                    }
                }
            }
        }

        /// <summary>
        /// Dessine tout le contenu visuel de l'interface
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CarteJeu_Paint(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;
            Visiteur V = new Visiteur();

            if (Villageois)
            {
                V.x = 28;
                V.y = 9;
                RegistreV[compt] = V;
            }

            // Dessine le tableau "tabMap"
            for (int i = 0; i < tabMap.GetLength(0); i++)
            {
                for (int j = 0; j < tabMap.GetLength(1); j++)
                {
                    g.DrawImage(tabMap[i, j], i * MapPixel, j * MapPixel, MapPixel, MapPixel);
                }
            }

            // Dessine tous les enclos 
            for (int i = 2 * MapPixel; i < 23 * MapPixel; i = i + MapPixel)
            {
                for (int j = 3 * MapPixel; j < 13 * MapPixel; j = j + MapPixel)
                {
                    if (!(i > 10 * MapPixel && i < 14 * MapPixel))
                    {
                        g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(2), i, 2 * MapPixel);
                        g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(2), i, 6 * MapPixel);
                        g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(2), i, 9 * MapPixel);
                        g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(2), i, 13 * MapPixel);
                    }
                    if (!(j > 5 * MapPixel && j < 10 * MapPixel))
                    {
                        g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(2), 2 * MapPixel, j);
                        g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(2), 10 * MapPixel, j);
                        g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(2), 14 * MapPixel, j);
                        g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(2), 22 * MapPixel, j);
                    }
                }
            }

            // Dessine un bloc de gazon dans les enclos pour l'entrée
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(0), 6 * MapPixel, 6 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(0), 18 * MapPixel, 6 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(0), 6 * MapPixel, 13 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(0), 18 * MapPixel, 13 * MapPixel);

            // Dessine la maison 
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(4), 1 * MapPixel, 16 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(5), 2 * MapPixel, 16 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(6), 3 * MapPixel, 16 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(7), 4 * MapPixel, 16 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(8), 1 * MapPixel, 17 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(9), 2 * MapPixel, 17 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(10), 3 * MapPixel, 17 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(11), 4 * MapPixel, 17 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(12), 1 * MapPixel, 18 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(13), 2 * MapPixel, 18 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(14), 3 * MapPixel, 18 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(15), 4 * MapPixel, 18 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(16), 1 * MapPixel, 19 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(17), 2 * MapPixel, 19 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(18), 3 * MapPixel, 19 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(19), 4 * MapPixel, 19 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(20), 1 * MapPixel, 20 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(21), 2 * MapPixel, 20 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(22), 3 * MapPixel, 20 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(23), 4 * MapPixel, 20 * MapPixel);

            // Dessine le barrel
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(34), 0 * MapPixel, 20 * MapPixel);

            // Dessine l'entree
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(25), 27 * MapPixel, 7 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(25), 28 * MapPixel, 7 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(26), 29 * MapPixel, 7 * MapPixel);

            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(25), 27 * MapPixel, 11 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(25), 28 * MapPixel, 11 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(26), 29 * MapPixel, 11 * MapPixel);

            // Dessine le sable
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(27), 27 * MapPixel, 8 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(28), 28 * MapPixel, 8 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(28), 29 * MapPixel, 8 * MapPixel);

            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(29), 27 * MapPixel, 9 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(30), 28 * MapPixel, 9 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(30), 29 * MapPixel, 9 * MapPixel);

            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(31), 27 * MapPixel, 10 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(32), 28 * MapPixel, 10 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(32), 29 * MapPixel, 10 * MapPixel);

            // Dessine le héros
            g.DrawImage(image, posHor, posVer);

            // Dessine la cloture droite
            for (int i = 0; i < 22; i++)
            {
                if (i < 7 || i > 11)
                {
                    g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(33), 29 * MapPixel, i * MapPixel);
                }
            }

            // Dessine l'eau et le bas
            for (int i = 5; i < 30; i++)
            {
                if (i == 5) // Dessine le barrel
                {
                    g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(24), i * MapPixel, 20 * MapPixel);
                }
                else
                {
                    g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(34), i * MapPixel, 20 * MapPixel);
                }

                if (13 < i && i < 17) // Dessine le gazon entre cloture pour les entrées
                {
                    g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(0), i * MapPixel, 20 * MapPixel);

                }

                // Cloture en bas
                g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(33), 13 * MapPixel, 19 * MapPixel);
                g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(33), 17 * MapPixel, 19 * MapPixel);
                g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(33), 13 * MapPixel, 20 * MapPixel);
                g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(33), 17 * MapPixel, 20 * MapPixel);


            }
        
            
            if (compt != 0 || Sauter == false)
            {
                
                for (int h = 0; h < compt; h++)
                {
                    
                   
                    switch (CarteJeu.RegistreA[h].Type)
                    {
                        
                        case "Lion":
                            MapObstacle[CarteJeu.RegistreA[h].x, CarteJeu.RegistreA[h].y] = true;
                            
                            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(35), CarteJeu.RegistreA[h].x * MapPixel, CarteJeu.RegistreA[h].y * MapPixel);
                            g.DrawImage(TileVisiteur.GetTile(CarteJeu.RegistreV[h].modele,1), CarteJeu.RegistreV[h].x*MapPixel, CarteJeu.RegistreV[h].y*MapPixel,32,32);
                            MapObstacle[CarteJeu.RegistreV[h].x, CarteJeu.RegistreV[h].y] = true;
                            //((ZooInterface)Parent).LblAnimaux.Text = "Nombre d'animaux : " + (comptAnimal + 1).ToString();
                            //((ZooInterface)Parent).LblDollar.Text = (comptArgent + 2 + (2 * comptAnimal) - 35).ToString() + "$";
                            break;
                        case "Mouton":
                            MapObstacle[CarteJeu.RegistreA[h].x, CarteJeu.RegistreA[h].y] = true;
                            MapObstacle[CarteJeu.RegistreV[h].x, CarteJeu.RegistreV[h].y] = true;
                            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(36), CarteJeu.RegistreA[h].x * MapPixel, CarteJeu.RegistreA[h].y * MapPixel);
                            g.DrawImage(TileVisiteur.GetTile(CarteJeu.RegistreV[h].modele, 1), CarteJeu.RegistreV[h].x * MapPixel, CarteJeu.RegistreV[h].y * MapPixel,32,32);
                            //((ZooInterface)Parent).LblAnimaux.Text = "Nombre d'animaux : " + (comptAnimal + 1).ToString();
                            //((ZooInterface)Parent).LblDollar.Text = (comptArgent + 2 + (2 * comptAnimal) - 20).ToString() + "$";
                            break;
                        case "Licorne":
                            MapObstacle[CarteJeu.RegistreA[h].x, CarteJeu.RegistreA[h].y] = true;
                            MapObstacle[CarteJeu.RegistreV[h].x, CarteJeu.RegistreV[h].y] = true;
                            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(37), CarteJeu.RegistreA[h].x * MapPixel, CarteJeu.RegistreA[h].y * MapPixel);
                            g.DrawImage(TileVisiteur.GetTile(CarteJeu.RegistreV[h].modele, 1), CarteJeu.RegistreV[h].x * MapPixel, CarteJeu.RegistreV[h].y * MapPixel,32,32);
                            //((ZooInterface)Parent).LblAnimaux.Text = "Nombre d'animaux : " + (comptAnimal + 1).ToString();
                            //((ZooInterface)Parent).LblDollar.Text = (comptArgent + 2 + (2 * comptAnimal) - 50).ToString() + "$";
                            break;
                    }

                }
            }
            if(Deplace == true)
            {
                for (int y = 0; y < compt; y++)
                {
                    int Direction = rand.Next(1, 5);
                    switch (Direction)
                    {
                        case 1:
                            //up
                            if (CarteJeu.RegistreA[y].x > 0)
                            {
                                // Condition pour les obstacles
                                if (MapObstacle[CarteJeu.RegistreA[y].y , (CarteJeu.RegistreA[y].x - 1)] == false)
                                {
                                    if (CarteJeu.RegistreA[y].y > 2 && CarteJeu.RegistreA[y].y < 6 && CarteJeu.RegistreA[y].x > 2 && CarteJeu.RegistreA[y].x < 10 || 
                                        CarteJeu.RegistreA[y].y > 9 && CarteJeu.RegistreA[y].y < 13 && CarteJeu.RegistreA[y].x > 2 && CarteJeu.RegistreA[y].x < 10 ||
                    CarteJeu.RegistreA[y].y > 2 && CarteJeu.RegistreA[y].y < 6 && CarteJeu.RegistreA[y].x > 14 && CarteJeu.RegistreA[y].x < 22 || CarteJeu.RegistreA[y].y > 9 && CarteJeu.RegistreA[y].y < 13 && CarteJeu.RegistreA[y].x > 14 && CarteJeu.RegistreA[y].x < 22)
                                    {
                                        MapObstacle[CarteJeu.RegistreA[y].x, CarteJeu.RegistreA[y].y] = false;
                                        CarteJeu.RegistreA[y].x = (CarteJeu.RegistreA[y].x - 1);
                                        MapObstacle[CarteJeu.RegistreA[y].x, CarteJeu.RegistreA[y].y] = true;
                                    }
                                }
                            }
                            break;
                        case 2:
                            //down
                            if (CarteJeu.RegistreA[y].x * MapPixel< 19 * MapPixel)
                            {
                                // Condition pour les obstacles
                                if (MapObstacle[CarteJeu.RegistreA[y].y , (CarteJeu.RegistreA[y].x + 1) ] == false)
                                {
                                    if (CarteJeu.RegistreA[y].y > 2 && CarteJeu.RegistreA[y].y < 6 && CarteJeu.RegistreA[y].x > 2 && CarteJeu.RegistreA[y].x < 10 ||
                                       CarteJeu.RegistreA[y].y > 9 && CarteJeu.RegistreA[y].y < 13 && CarteJeu.RegistreA[y].x > 2 && CarteJeu.RegistreA[y].x < 10 ||
                   CarteJeu.RegistreA[y].y > 2 && CarteJeu.RegistreA[y].y < 6 && CarteJeu.RegistreA[y].x > 14 && CarteJeu.RegistreA[y].x < 22 || CarteJeu.RegistreA[y].y > 9 && CarteJeu.RegistreA[y].y < 13 && CarteJeu.RegistreA[y].x > 14 && CarteJeu.RegistreA[y].x < 22)
                                    {
                                        MapObstacle[CarteJeu.RegistreA[y].x, CarteJeu.RegistreA[y].y] = false;
                                        CarteJeu.RegistreA[y].x = CarteJeu.RegistreA[y].x + 1;
                                        MapObstacle[CarteJeu.RegistreA[y].x, CarteJeu.RegistreA[y].y] = true;
                                    }
                                }
                            }

                            break;
                        case 3:
                            //right
                            if (CarteJeu.RegistreA[y].y > 0)
                            {
                                // Condition pour les obstacles
                                if (MapObstacle[CarteJeu.RegistreA[y].y - 1 , (CarteJeu.RegistreA[y].x)] == false)
                                {
                                    if (CarteJeu.RegistreA[y].y > 2 && CarteJeu.RegistreA[y].y < 6 && CarteJeu.RegistreA[y].x > 2 && CarteJeu.RegistreA[y].x < 10 ||
                                       CarteJeu.RegistreA[y].y > 9 && CarteJeu.RegistreA[y].y < 13 && CarteJeu.RegistreA[y].x > 2 && CarteJeu.RegistreA[y].x < 10 ||
                   CarteJeu.RegistreA[y].y > 2 && CarteJeu.RegistreA[y].y < 6 && CarteJeu.RegistreA[y].x > 14 && CarteJeu.RegistreA[y].x < 22 || CarteJeu.RegistreA[y].y > 9 && CarteJeu.RegistreA[y].y < 13 && CarteJeu.RegistreA[y].x > 14 && CarteJeu.RegistreA[y].x < 22)
                                    {
                                        MapObstacle[CarteJeu.RegistreA[y].x, CarteJeu.RegistreA[y].y] = false;
                                        CarteJeu.RegistreA[y].x = (CarteJeu.RegistreA[y].y - 1);
                                        MapObstacle[CarteJeu.RegistreA[y].x, CarteJeu.RegistreA[y].y] = true;
                                    }
                                }
                            }

                            break;
                        case 4:
                            //left
                            if (CarteJeu.RegistreA[y].y * MapPixel > 28)
                            {
                                // Condition pour les obstacles
                                if (MapObstacle[CarteJeu.RegistreA[y].y + 1 , (CarteJeu.RegistreA[y].x ) ] == false)
                                {
                                    if (CarteJeu.RegistreA[y].y > 2 && CarteJeu.RegistreA[y].y < 6 && CarteJeu.RegistreA[y].x > 2 && CarteJeu.RegistreA[y].x < 10 ||
                                       CarteJeu.RegistreA[y].y > 9 && CarteJeu.RegistreA[y].y < 13 && CarteJeu.RegistreA[y].x > 2 && CarteJeu.RegistreA[y].x < 10 ||
                   CarteJeu.RegistreA[y].y > 2 && CarteJeu.RegistreA[y].y < 6 && CarteJeu.RegistreA[y].x > 14 && CarteJeu.RegistreA[y].x < 22 || CarteJeu.RegistreA[y].y > 9 && CarteJeu.RegistreA[y].y < 13 && CarteJeu.RegistreA[y].x > 14 && CarteJeu.RegistreA[y].x < 22)
                                    {
                                        MapObstacle[CarteJeu.RegistreA[y].x, CarteJeu.RegistreA[y].y] = false;
                                        CarteJeu.RegistreA[y].x = (CarteJeu.RegistreA[y].y + 1);
                                        MapObstacle[CarteJeu.RegistreA[y].x, CarteJeu.RegistreA[y].y] = true;
                                    }
                                }
                            }

                            break;


                    }

                }
                
                for (int y = 0; y < compt; y++)
                {
                    int Direction = rand.Next(1, 5);
                    switch (Direction)
                    {
                        case 1:
                            //up
                            if (CarteJeu.RegistreV[y].x > 0&& CarteJeu.RegistreV[y].x< 30)
                            {
                                // Condition pour les obstacles
                                if (MapObstacle[CarteJeu.RegistreV[y].y, (CarteJeu.RegistreV[y].x - 1)] == false)
                                {
                                    if (rand.Next(0, 2) == 1)
                                    {
                                        g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(38), CarteJeu.RegistreV[y].x * MapPixel, CarteJeu.RegistreV[y].y * MapPixel);
                                        MapDechet[CarteJeu.RegistreV[y].x, CarteJeu.RegistreV[y].y] = true;
                                    }
                                    else if (dechet == true)
                                    {
                                        g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(0), CarteJeu.RegistreV[y].x * MapPixel, CarteJeu.RegistreV[y].y * MapPixel);
                                        dechet = false;
                                    }
                                    if (CarteJeu.RegistreV[y].y > 2 && CarteJeu.RegistreV[y].y < 6 && CarteJeu.RegistreV[y].x > 2 && CarteJeu.RegistreV[y].x < 10 ||
                                       CarteJeu.RegistreV[y].y > 9 && CarteJeu.RegistreV[y].y < 13 && CarteJeu.RegistreV[y].x > 2 && CarteJeu.RegistreV[y].x < 10 ||
                   CarteJeu.RegistreV[y].y > 2 && CarteJeu.RegistreV[y].y < 6 && CarteJeu.RegistreV[y].x > 14 && CarteJeu.RegistreV[y].x < 22 || CarteJeu.RegistreV[y].y > 9 && CarteJeu.RegistreV[y].y < 13 && CarteJeu.RegistreV[y].x > 14 && CarteJeu.RegistreV[y].x < 22)
                                    {
                                       
                                }
                                    else
                                    {
                                        MapObstacle[CarteJeu.RegistreV[y].x, CarteJeu.RegistreV[y].y] = false;
                                        CarteJeu.RegistreV[y].x = (CarteJeu.RegistreV[y].x - 1);
                                        MapObstacle[CarteJeu.RegistreV[y].x, CarteJeu.RegistreV[y].y] = true;
                                    }
                                   
                                   
                                }
                            }
                            break;
                        case 2:
                            //down
                            if (CarteJeu.RegistreV[y].x * MapPixel < 19 * MapPixel)
                            {
                                // Condition pour les obstacles
                                if (MapObstacle[CarteJeu.RegistreV[y].y, (CarteJeu.RegistreV[y].x + 1)] == false)
                                {
                                    if (rand.Next(0, 2) == 1)
                                    {
                                        g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(38), CarteJeu.RegistreV[y].x * MapPixel, CarteJeu.RegistreV[y].y * MapPixel);
                                        MapDechet[CarteJeu.RegistreV[y].x, CarteJeu.RegistreV[y].y] = true;
                                    }
                                    else if (dechet == true)
                                    {
                                        g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(0), CarteJeu.RegistreV[y].x * MapPixel, CarteJeu.RegistreV[y].y * MapPixel);
                                        dechet = false;
                                    }
                                    if (CarteJeu.RegistreV[y].y > 2 && CarteJeu.RegistreV[y].y < 6 && CarteJeu.RegistreV[y].x > 2 && CarteJeu.RegistreV[y].x < 10 ||
                                      CarteJeu.RegistreV[y].y > 9 && CarteJeu.RegistreV[y].y < 13 && CarteJeu.RegistreV[y].x > 2 && CarteJeu.RegistreV[y].x < 10 ||
                  CarteJeu.RegistreV[y].y > 2 && CarteJeu.RegistreV[y].y < 6 && CarteJeu.RegistreV[y].x > 14 && CarteJeu.RegistreV[y].x < 22 || CarteJeu.RegistreV[y].y > 9 && CarteJeu.RegistreV[y].y < 13 && CarteJeu.RegistreV[y].x > 14 && CarteJeu.RegistreV[y].x < 22)
                                    {
                                        
                                    }
                                    else
                                    {
                                        MapObstacle[CarteJeu.RegistreV[y].x, CarteJeu.RegistreV[y].y] = false;
                                        CarteJeu.RegistreV[y].x = CarteJeu.RegistreV[y].x + 1;
                                        MapObstacle[CarteJeu.RegistreV[y].x, CarteJeu.RegistreV[y].y] = true;
                                    }
                                }
                                
                                
                            }

                            break;
                        case 3:
                            //right
                            if (0<CarteJeu.RegistreV[y].y&& CarteJeu.RegistreV[y].y < 21 )
                            {

                                // Condition pour les obstacles
                                if (MapObstacle[CarteJeu.RegistreV[y].y - 1, (CarteJeu.RegistreV[y].x)] == false)
                                {
                                    if (rand.Next(0, 2) == 1)
                                    {
                                        g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(38), CarteJeu.RegistreV[y].x * MapPixel, CarteJeu.RegistreV[y].y * MapPixel);
                                        MapDechet[CarteJeu.RegistreV[y].x, CarteJeu.RegistreV[y].y] = true;
                                    }
                                   else if (dechet == true)
                                    {
                                        g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(0), CarteJeu.RegistreV[y].x * MapPixel, CarteJeu.RegistreV[y].y * MapPixel);
                                        dechet = false;
                                    }
                                    if (CarteJeu.RegistreV[y].y > 2 && CarteJeu.RegistreV[y].y < 6 && CarteJeu.RegistreV[y].x > 2 && CarteJeu.RegistreV[y].x < 10 ||
                                         CarteJeu.RegistreV[y].y > 9 && CarteJeu.RegistreV[y].y < 13 && CarteJeu.RegistreV[y].x > 2 && CarteJeu.RegistreV[y].x < 10 ||
                     CarteJeu.RegistreV[y].y > 2 && CarteJeu.RegistreV[y].y < 6 && CarteJeu.RegistreV[y].x > 14 && CarteJeu.RegistreV[y].x < 22 || CarteJeu.RegistreV[y].y > 9 && CarteJeu.RegistreV[y].y < 13 && CarteJeu.RegistreV[y].x > 14 && CarteJeu.RegistreV[y].x < 22)
                                    {
                                        
                                    }
                                    else
                                    {
                                        MapObstacle[CarteJeu.RegistreV[y].x, CarteJeu.RegistreV[y].y] = false;
                                        CarteJeu.RegistreV[y].y = (CarteJeu.RegistreV[y].y - 1);
                                        MapObstacle[CarteJeu.RegistreV[y].x, CarteJeu.RegistreV[y].y] = true;
                                    }

                                }
                             
                            }

                            break;
                        case 4:
                            //left
                            if (CarteJeu.RegistreV[y].y  > 28)
                            {
                                // Condition pour les obstacles
                                if (MapObstacle[CarteJeu.RegistreV[y].y + 1, (CarteJeu.RegistreV[y].x)] == false)
                                {
                                    if (rand.Next(0, 2) == 1)
                                    {
                                        g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(38), CarteJeu.RegistreV[y].x * MapPixel, CarteJeu.RegistreV[y].y * MapPixel);
                                        MapDechet[CarteJeu.RegistreV[y].x, CarteJeu.RegistreV[y].y] = true;
                                    }
                                    else if (dechet == true)
                                    {
                                        g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(0), CarteJeu.RegistreV[y].x * MapPixel, CarteJeu.RegistreV[y].y * MapPixel);
                                        dechet = false;
                                    }
                                    if (CarteJeu.RegistreV[y].y > 2 && CarteJeu.RegistreV[y].y < 6 && CarteJeu.RegistreV[y].x > 2 && CarteJeu.RegistreV[y].x < 10 ||
                                       CarteJeu.RegistreV[y].y > 9 && CarteJeu.RegistreV[y].y < 13 && CarteJeu.RegistreV[y].x > 2 && CarteJeu.RegistreV[y].x < 10 ||
                   CarteJeu.RegistreV[y].y > 2 && CarteJeu.RegistreV[y].y < 6 && CarteJeu.RegistreV[y].x > 14 && CarteJeu.RegistreV[y].x < 22 || CarteJeu.RegistreV[y].y > 9 && CarteJeu.RegistreV[y].y < 13 && CarteJeu.RegistreV[y].x > 14 && CarteJeu.RegistreV[y].x < 22)
                                    {
                                        
                                    }
                                    else
                                    {
                                        MapObstacle[CarteJeu.RegistreV[y].x, CarteJeu.RegistreV[y].y] = false;
                                        CarteJeu.RegistreV[y].y = (CarteJeu.RegistreV[y].y + 1);
                                        MapObstacle[CarteJeu.RegistreV[y].x, CarteJeu.RegistreV[y].y] = true;
                                    }
                                }
                               
                                
                            }

                            break;


                    }

                }
               

            }
            int nbDechet = 0;
            Sauter = false;
            for (int j = 0; j < 30; j++)
            {
                for (int i = 0; i < 30; i++)
                {
                    if (MapDechet[j, i] == true)
                    {
                        nbDechet++;
                        g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(38), j * MapPixel, i * MapPixel);
                        //((ZooInterface)Parent).LblDechet.Text = "dechet : " + (nbDechet).ToString();
                    }

                }
            }
             




            

        }

        /// <summary>
        /// Prend le data de la méthode ProcessCmdKey et déplace le joueur en conséquence
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        public int EvenementClick(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Up:
                    // Condition pour les extrémités
                    if (posVer > 0)
                    {
                        // Condition pour les obstacles
                        if (MapObstacle[posHor / MapPixel, (posVer - 32) / MapPixel] == false)
                        {
                            image = TP2_DevGraphique.Properties.Resources.haut1;
                            posVer = posVer - 32;
                            Refresh();
                        }
                    }
                    return posVer;
                case Keys.Down:
                    if (posVer < 19 * MapPixel)
                    {
                        if (MapObstacle[posHor / MapPixel, (posVer + 32) / MapPixel] == false)
                        {
                            image = TP2_DevGraphique.Properties.Resources.bas1;
                            posVer = posVer + 32;
                            Refresh();
                        }
                    }
                    return posVer;
                case Keys.Left:
                    if (posHor > 0)
                    {
                        if (MapObstacle[(posHor - 32) / MapPixel, posVer / MapPixel] == false)
                        {
                            image = TP2_DevGraphique.Properties.Resources.gauche1;
                            posHor = posHor - 32;
                            Refresh();
                        }
                    }
                    return posHor;
                case Keys.Right:
                    if (posHor < 28 * MapPixel)
                    {
                        if (MapObstacle[(posHor + 32) / MapPixel, posVer / MapPixel] == false)
                        {
                            image = TP2_DevGraphique.Properties.Resources.droite1;
                            posHor = posHor + 32;
                            Refresh();
                        }
                    }
                    return posHor;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// Gère le thread qui sert au temps
        /// </summary>
        private void BoucleDeJeu()
        {
            
            
            while (true)
            {
                // Faire ici tous les calculs qui ne
                // nécessitent pas la modification
                // visuelle des composants de l’écran
                Temps += 1;
                if (Temps == 30)
                {
                    Deplace = true;
                    comptJour++;
                    Temps = 0;
                }
                else
                {
                    Deplace = false;
                }
                this.BeginInvoke(
                    (MethodInvoker)delegate ()
                    {
                        // Faire ici tous les changements qui auront des impacts visuels
                        // dans l’écran
                        //((ZooInterface)Parent).LblJourActuel.Text = Temps.ToString();
                        
                        //((ZooInterface)Parent).LblJourActuel.Text = "Jour " + comptJour;
                       
                        Refresh();
                    });
               
               
                Thread.Sleep(73);
            }
        }



        internal class Visiteur
        {
            static Random rand = new Random();
            public int x;
            public int y;
            public int modele = rand.Next(1, 9);
            public int X { get; set; }

            public int Y { get; set; }
        }

    }
}