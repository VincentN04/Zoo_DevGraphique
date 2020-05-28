using System;
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


using System.Media;
using System.IO;
using System.Reflection;

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
        public static bool[,] MapDechet = new bool[30, 30];
        public static Animaux[] RegistreA = new Animaux[20];
        private static Visiteur[] RegistreV = new Visiteur[20];
        private static Concierge[] RegistreG = new Concierge[20];
        public static int compt = 0;
        public static Boolean Sauter = false;
        //AnimalInfoWindow info = new AnimalInfoWindow();
        int comptJour = 1;
        public bool Deplace = true;
        public static bool dechet = false;
        public static int comptAnimal = 0;
        public static int comptArgent = 100;
        public static int comptVisiteur = 0;
        public static int comptConcierge = 0;
        public static int comptDechets = 0;
        public static DateTime dateJeu = DateTime.Today;
        public static int DateFromStart = 0;

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
        internal static void Choix_Animal(MouseEventArgs e)
        {
            int x = e.X / 32;
            int y = e.Y / 32;
            Animaux anim = new Animaux();
            anim.genererNom();
            anim.x = x;
            anim.y = y;
            CarteJeu.RegistreA[compt] = anim;

            ChoixAnimaux choix = new ChoixAnimaux();
            choix.Show();
        }

        internal static void Feed(MouseEventArgs e, Animaux a)
        {

            int x = e.X / 32;
            int y = e.Y / 32;

            //do something to feed the animals
            //do something to either check the animals' via the constructor or by using the map


            if(a.Type == "Licorne")
            {
                SoundPlayer splayer = new SoundPlayer(TP2_DevGraphique.Properties.Resources.licorne);
                splayer.Play();
                a.ResetLicorne();
                Heros.baisseArgent(1);
            }
            else if(a.Type == "Mouton")
            {
                SoundPlayer splayer = new SoundPlayer(TP2_DevGraphique.Properties.Resources.mouton);
                splayer.Play();
                a.ResetMouton();
                Heros.baisseArgent(1);
            }
            else
            {
                SoundPlayer splayer = new SoundPlayer(TP2_DevGraphique.Properties.Resources.lion);
                splayer.Play();
                a.ResetLion();
                Heros.baisseArgent(1);
            }

        }
        internal static void AnimalMenu(MouseEventArgs e, Animaux a)
        {          
            int x = e.X / 32;
            int y = e.Y / 32;
   
            ListeAnimaux listeAni = new ListeAnimaux(a);           
            listeAni.Show();
        }


        //TO DO: Faire fonctionner comme un visiteur en terme de sprite(?) et mouvement
        internal static void Choix_Concierge(MouseEventArgs e)
        {
            int x = e.X / 32;
            int y = e.Y / 32;
            Concierge conc = new Concierge();

            conc.x = x;
            conc.y = y;
            // CarteJeu.RegistreA[compt] = anim;

            ChoixConcierge choix = new ChoixConcierge();
            choix.Show();


        }


        /// <summary>
        /// Recois les coordonnees du concierge et fait le menage autour de lui, puis change le ToolStrip
        /// </summary>
        /// <param name="x"> int representant la position x du conscierge</param>
        /// <param name="y">int representant la position y du conscierge</param>
        private void ConciergeMenage(int x, int y)
        {
            MapDechet[x + 1, y] = false;
            MapDechet[x - 1, y] = false;
            MapDechet[x, y + 1] = false;
            MapDechet[x, y - 1] = false;
            MapDechet[x + 1, y + 1] = false;
            MapDechet[x + 1, y - 1] = false;
            MapDechet[x - 1, y + 1] = false;
            MapDechet[x - 1, y - 1] = false;
        }

        public static void RefreshTrash()
        {

            comptDechets = 0;
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    if (MapDechet[i, j] == true)
                    {
                        comptDechets++;
                    }

                }
            }
        }



        public static void SpawnerAnimal(string choix)
        {
            switch (choix)
            {
                case "Lion":
                    CarteJeu.RegistreA[compt].Type = "Lion";

                    if (CarteJeu.RegistreA[compt].y > 2 &&
                        CarteJeu.RegistreA[compt].y < 6 && CarteJeu.RegistreA[compt].x > 2 && CarteJeu.RegistreA[compt].x < 10)
                    {
                        if (AnimalEnclos1 != "Lion")
                        {
                            if (AnimalEnclos1 != null)
                            {
                                Sauter = true;
                            }

                        }
                        else
                        {
                            Villageois = true;
                            AnimalEnclos1 = CarteJeu.RegistreA[compt].Type;
                            Sauter = false;
                        }

                    }
                    if (CarteJeu.RegistreA[compt].y > 9 &&
                        CarteJeu.RegistreA[compt].y < 13 &&
                        CarteJeu.RegistreA[compt].x > 2 && CarteJeu.RegistreA[compt].x < 10)
                    {
                        AnimalEnclos3 = CarteJeu.RegistreA[compt].Type;
                    }
                    if (CarteJeu.RegistreA[compt].y > 2 &&
                        CarteJeu.RegistreA[compt].y < 6 &&
                        CarteJeu.RegistreA[compt].x > 14 && CarteJeu.RegistreA[compt].x < 22)
                    {
                        AnimalEnclos4 = CarteJeu.RegistreA[compt].Type;
                    }
                    if (CarteJeu.RegistreA[compt].y > 9 &&
                        CarteJeu.RegistreA[compt].y < 13 &&
                        CarteJeu.RegistreA[compt].x > 14 && CarteJeu.RegistreA[compt].x < 22)
                    {
                        AnimalEnclos2 = CarteJeu.RegistreA[compt].Type;
                    }


                    compt++;
                    break;
                case "Mouton":
                    CarteJeu.RegistreA[compt].Type = "Mouton";
                    if (CarteJeu.RegistreA[compt].y > 2 &&
                        CarteJeu.RegistreA[compt].y < 6 && CarteJeu.RegistreA[compt].x > 2 && CarteJeu.RegistreA[compt].x < 10)
                    {
                        AnimalEnclos1 = CarteJeu.RegistreA[compt].Type;

                    }
                    if (CarteJeu.RegistreA[compt].y > 9 &&
                        CarteJeu.RegistreA[compt].y < 13 &&
                        CarteJeu.RegistreA[compt].x > 2 && CarteJeu.RegistreA[compt].x < 10)
                    {
                        AnimalEnclos3 = CarteJeu.RegistreA[compt].Type;
                    }
                    if (CarteJeu.RegistreA[compt].y > 2 &&
                        CarteJeu.RegistreA[compt].y < 6 &&
                        CarteJeu.RegistreA[compt].x > 14 && CarteJeu.RegistreA[compt].x < 22)
                    {
                        AnimalEnclos4 = CarteJeu.RegistreA[compt].Type;
                    }
                    if (CarteJeu.RegistreA[compt].y > 9 &&
                        CarteJeu.RegistreA[compt].y < 13 &&
                        CarteJeu.RegistreA[compt].x > 14 && CarteJeu.RegistreA[compt].x < 22)
                    {
                        AnimalEnclos2 = CarteJeu.RegistreA[compt].Type;
                    }

                    compt++;
                    break;
                case "Licorne":
                    CarteJeu.RegistreA[compt].Type = "Licorne";
                    if (CarteJeu.RegistreA[compt].y > 2 &&
                        CarteJeu.RegistreA[compt].y < 6 && CarteJeu.RegistreA[compt].x > 2 && CarteJeu.RegistreA[compt].x < 10)
                    {
                        AnimalEnclos1 = CarteJeu.RegistreA[compt].Type;

                    }
                    if (CarteJeu.RegistreA[compt].y > 9 &&
                        CarteJeu.RegistreA[compt].y < 13 &&
                        CarteJeu.RegistreA[compt].x > 2 && CarteJeu.RegistreA[compt].x < 10)
                    {
                        AnimalEnclos3 = CarteJeu.RegistreA[compt].Type;
                    }
                    if (CarteJeu.RegistreA[compt].y > 2 &&
                        CarteJeu.RegistreA[compt].y < 6 &&
                        CarteJeu.RegistreA[compt].x > 14 && CarteJeu.RegistreA[compt].x < 22)
                    {
                        AnimalEnclos4 = CarteJeu.RegistreA[compt].Type;
                    }
                    if (CarteJeu.RegistreA[compt].y > 9 &&
                        CarteJeu.RegistreA[compt].y < 13 &&
                        CarteJeu.RegistreA[compt].x > 14 && CarteJeu.RegistreA[compt].x < 22)
                    {
                        AnimalEnclos2 = CarteJeu.RegistreA[compt].Type;
                    }

                    compt++;
                    break;
            }

            comptAnimal++;

            //des qu'il y a un nouvel animal il y a un nouveau visiteur
            Heros.ajoutArgent(2 * comptAnimal); // ce que paie le visiteur
            comptVisiteur++;

        }
        /// <summary>
        /// Initialise le tableau boolean qui servira comme tableau d'obstacle pour le héros
        /// </summary>
        /// 

        public static void SpawnerConcierge()
        {
            Concierge G = new Concierge();          
            G.x = 28;
            G.y = 10;
            RegistreG[comptConcierge] = G;
            comptConcierge++;
        }
        private void InitializeMapObstacles()
        {
            for (int i = 24; i < 28; i++)
            {
                for (int j = 1; j < 6; j++)
                {
                    MapObstacle[i, j] = true;
                }
            }

            for (int i = 6; i < 9; i++)
            {
                for (int j = 17; j < 20; j++)
                {
                    MapObstacle[i, j] = true;
                }
            }
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
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(4), 24 * MapPixel, 1 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(5), 25 * MapPixel, 1 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(6), 26 * MapPixel, 1 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(7), 27 * MapPixel, 1 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(8), 24 * MapPixel, 2 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(9), 25 * MapPixel, 2 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(10), 26 * MapPixel, 2 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(11), 27 * MapPixel, 2 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(12), 24 * MapPixel, 3 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(13), 25 * MapPixel, 3 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(14), 26 * MapPixel, 3 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(15), 27 * MapPixel, 3 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(16), 24 * MapPixel, 4 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(17), 25 * MapPixel, 4 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(18), 26 * MapPixel, 4 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(19), 27 * MapPixel, 4 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(20), 24 * MapPixel, 5 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(21), 25 * MapPixel, 5 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(22), 26 * MapPixel, 5 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(23), 27 * MapPixel, 5 * MapPixel);

            //dessine le puit
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(44), 6 * MapPixel, 17 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(45), 7 * MapPixel, 17 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(46), 8 * MapPixel, 17 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(47), 6 * MapPixel, 18 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(48), 7 * MapPixel, 18 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(49), 8 * MapPixel, 18 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(50), 6 * MapPixel, 19 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(51), 7 * MapPixel, 19 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(52), 8 * MapPixel, 19 * MapPixel);

            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(39), 1 * MapPixel, 16 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(39), 2 * MapPixel, 16 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(39), 3 * MapPixel, 16 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(39), 4 * MapPixel, 16 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(39), 1 * MapPixel, 17 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(39), 2 * MapPixel, 17 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(39), 3 * MapPixel, 17 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(39), 4 * MapPixel, 17 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(39), 1 * MapPixel, 18 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(39), 2 * MapPixel, 18 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(39), 3 * MapPixel, 18 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(39), 4 * MapPixel, 18 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(39), 1 * MapPixel, 19 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(39), 2 * MapPixel, 19 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(39), 3 * MapPixel, 19 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(39), 4 * MapPixel, 19 * MapPixel);
            // Dessine le barrel
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(34), 1 * MapPixel, 20 * MapPixel);

            // Dessine l'entree
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(25), 27 * MapPixel, 7 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(25), 28 * MapPixel, 7 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(26), 29 * MapPixel, 7 * MapPixel);

            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(25), 27 * MapPixel, 11 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(25), 28 * MapPixel, 11 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(26), 29 * MapPixel, 11 * MapPixel);

            // Dessine le sable
            for (int i = 24; i < 30; i++)
            {
                g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(28), i * MapPixel, 8 * MapPixel);
                g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(31), i * MapPixel, 9 * MapPixel);
                g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(42), i * MapPixel, 10 * MapPixel);
            }
            for (int i = 2; i < 14; i++)
            {
                g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(30), 11 * MapPixel, i * MapPixel);
                g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(31), 12 * MapPixel, i * MapPixel);
                g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(32), 13 * MapPixel, i * MapPixel);
            }

            for (int i = 2; i < 23; i++)
            {
                g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(28), i * MapPixel, 7 * MapPixel);
                g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(42), i * MapPixel, 8 * MapPixel);
            }

            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(41), 23 * MapPixel, 10 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(30), 23 * MapPixel, 9 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(31), 23 * MapPixel, 8 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(28), 23 * MapPixel, 7 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(29), 24 * MapPixel, 7 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(31), 24 * MapPixel, 8 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(27), 1 * MapPixel, 7 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(41), 1 * MapPixel, 8 * MapPixel);

            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(27), 11 * MapPixel, 1 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(28), 12 * MapPixel, 1 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(29), 13 * MapPixel, 1 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(41), 11 * MapPixel, 14 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(42), 12 * MapPixel, 14 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(43), 13 * MapPixel, 14 * MapPixel);

            //milieu
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(31), 12 * MapPixel, 7 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(31), 12 * MapPixel, 8 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(31), 11 * MapPixel, 7 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(31), 11 * MapPixel, 8 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(31), 13 * MapPixel, 7 * MapPixel);
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(31), 13 * MapPixel, 8 * MapPixel);

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

            // g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(34), 0 * MapPixel, 20 * MapPixel);
            // Dessine l'eau et le bas
            for (int i = 0; i < 30; i++)
            {
                g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(34), i * MapPixel, 20 * MapPixel);

                if (13 < i && i < 17) // Dessine le gazon entre cloture pour les entrées
                {
                    g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(1), i * MapPixel, 20 * MapPixel);

                }

                // Cloture en bas
                g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(33), 13 * MapPixel, 19 * MapPixel);
                g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(33), 17 * MapPixel, 19 * MapPixel);
                g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(33), 13 * MapPixel, 20 * MapPixel);
                g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(33), 17 * MapPixel, 20 * MapPixel);


            }
            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(40), 23 * MapPixel, 18 * MapPixel);

            if (compt != 0 || Sauter == false)
            {

                for (int h = 0; h < compt; h++)
                {


                    switch (CarteJeu.RegistreA[h].Type)
                    {

                        case "Lion":
                            MapObstacle[CarteJeu.RegistreA[h].x, CarteJeu.RegistreA[h].y] = true;
                            MapObstacle[CarteJeu.RegistreV[h].x, CarteJeu.RegistreV[h].y] = true;
                            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(35), CarteJeu.RegistreA[h].x * MapPixel, CarteJeu.RegistreA[h].y * MapPixel);
                            g.DrawImage(TileVisiteur.GetTile(CarteJeu.RegistreV[h].modele, 1), CarteJeu.RegistreV[h].x * MapPixel, CarteJeu.RegistreV[h].y * MapPixel, 32, 32);
                            //((ZooInterface)Parent).LblAnimaux.Text = "Nombre d'animaux : " + (comptAnimal + 1).ToString();
                            //((ZooInterface)Parent).LblDollar.Text = (comptArgent + 2 + (2 * comptAnimal) - 35).ToString() + "$";
                            break;
                        case "Mouton":
                            MapObstacle[CarteJeu.RegistreA[h].x, CarteJeu.RegistreA[h].y] = true;
                            MapObstacle[CarteJeu.RegistreV[h].x, CarteJeu.RegistreV[h].y] = true;
                            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(36), CarteJeu.RegistreA[h].x * MapPixel, CarteJeu.RegistreA[h].y * MapPixel);
                            g.DrawImage(TileVisiteur.GetTile(CarteJeu.RegistreV[h].modele, 1), CarteJeu.RegistreV[h].x * MapPixel, CarteJeu.RegistreV[h].y * MapPixel, 32, 32);
                            //((ZooInterface)Parent).LblAnimaux.Text = "Nombre d'animaux : " + (comptAnimal + 1).ToString();
                            //((ZooInterface)Parent).LblDollar.Text = (comptArgent + 2 + (2 * comptAnimal) - 20).ToString() + "$";
                            break;
                        case "Licorne":
                            MapObstacle[CarteJeu.RegistreA[h].x, CarteJeu.RegistreA[h].y] = true;
                            MapObstacle[CarteJeu.RegistreV[h].x, CarteJeu.RegistreV[h].y] = true;
                            g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(37), CarteJeu.RegistreA[h].x * MapPixel, CarteJeu.RegistreA[h].y * MapPixel);
                            g.DrawImage(TileVisiteur.GetTile(CarteJeu.RegistreV[h].modele, 1), CarteJeu.RegistreV[h].x * MapPixel, CarteJeu.RegistreV[h].y * MapPixel, 32, 32);
                            //((ZooInterface)Parent).LblAnimaux.Text = "Nombre d'animaux : " + (comptAnimal + 1).ToString();
                            //((ZooInterface)Parent).LblDollar.Text = (comptArgent + 2 + (2 * comptAnimal) - 50).ToString() + "$";
                            break;
                    }

                }
            }
            if (Deplace == true)
            {
                MouvementsAnimaux(sender, e, g);
                MouvementsVisiteurs(sender, e, g);
                MouvementsConcierge(sender, e, g);
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
            ToolStripInformative.miseAJourToolStrip();
        }


        /// <summary>
        /// Methode qui deplace les animaux
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="g">Les graphiques qui permettent de paint</param>
        private void MouvementsAnimaux(object sender, PaintEventArgs e, Graphics g)
        {
            for (int y = 0; y < compt; y++) //change to comptAnimaux
            {
                int Direction = rand.Next(1, 5);
                switch (Direction)
                {
                    case 1:
                        //up
                        // - donc monte sur l'ecran
                        if (CarteJeu.RegistreA[y].x > 0)
                        {
                            // Condition pour les obstacles
                            if (MapObstacle[CarteJeu.RegistreA[y].x, (CarteJeu.RegistreA[y].y - 1)] == false)
                            {
                                MapObstacle[CarteJeu.RegistreA[y].x, CarteJeu.RegistreA[y].y] = false;
                                CarteJeu.RegistreA[y].y = (CarteJeu.RegistreA[y].y - 1);
                                MapObstacle[CarteJeu.RegistreA[y].x, CarteJeu.RegistreA[y].y] = true;
                            }
                        }
                        break;
                    case 2:
                        //down
                        if (CarteJeu.RegistreA[y].x * MapPixel < 19 * MapPixel)
                        {
                            // Condition pour les obstacles
                            if (MapObstacle[CarteJeu.RegistreA[y].x, (CarteJeu.RegistreA[y].y + 1)] == false
                                && !(CarteJeu.RegistreA[y].y + 1 == 6)
                                && !(CarteJeu.RegistreA[y].y + 1 == 13))
                            {
                                MapObstacle[CarteJeu.RegistreA[y].x, CarteJeu.RegistreA[y].y] = false;
                                CarteJeu.RegistreA[y].y = CarteJeu.RegistreA[y].y + 1;
                                MapObstacle[CarteJeu.RegistreA[y].x, CarteJeu.RegistreA[y].y] = true;
                            }
                        }

                        break;
                    case 3:
                        //right
                        if (CarteJeu.RegistreA[y].y > 0)
                        {
                            // Condition pour les obstacles
                            if (MapObstacle[CarteJeu.RegistreA[y].x + 1, (CarteJeu.RegistreA[y].y)] == false)
                            {
                                MapObstacle[CarteJeu.RegistreA[y].x, CarteJeu.RegistreA[y].y] = false;
                                CarteJeu.RegistreA[y].x = (CarteJeu.RegistreA[y].x + 1);
                                MapObstacle[CarteJeu.RegistreA[y].x, CarteJeu.RegistreA[y].y] = true;
                            }
                        }

                        break;
                    case 4:
                        //left
                        if (CarteJeu.RegistreA[y].y * MapPixel > 28)
                        {
                            // Condition pour les obstacles
                            if (MapObstacle[CarteJeu.RegistreA[y].x - 1, (CarteJeu.RegistreA[y].y)] == false)
                            {

                                MapObstacle[CarteJeu.RegistreA[y].x, CarteJeu.RegistreA[y].y] = false;
                                CarteJeu.RegistreA[y].x = (CarteJeu.RegistreA[y].x - 1);
                                MapObstacle[CarteJeu.RegistreA[y].x, CarteJeu.RegistreA[y].y] = true;

                            }
                        }

                        break;


                }
            }
        }
        /// <summary>
        /// Methode qui deplace les visiteurs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="g">Les graphiques qui permettent de paint</param>
        private void MouvementsVisiteurs(object sender, PaintEventArgs e, Graphics g)
        {
            for (int y = 0; y < compt; y++)//change to comptVisiteurs
            {
                int Direction = rand.Next(1, 5);
                switch (Direction)
                {
                    case 1:
                        //left
                        if (CarteJeu.RegistreV[y].x > 0 && CarteJeu.RegistreV[y].x < 30)
                        {
                            // Condition pour les obstacles
                            if (MapObstacle[CarteJeu.RegistreV[y].x - 1, (CarteJeu.RegistreV[y].y)] == false)
                            {
                                if (rand.Next(0, 10) == 1)
                                {
                                    g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(38), CarteJeu.RegistreV[y].x * MapPixel, CarteJeu.RegistreV[y].y * MapPixel);
                                    MapDechet[CarteJeu.RegistreV[y].x, CarteJeu.RegistreV[y].y] = true;
                                }
                                else if (dechet == true)
                                {
                                    g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(0), CarteJeu.RegistreV[y].x * MapPixel, CarteJeu.RegistreV[y].y * MapPixel);
                                    dechet = false;
                                }
                                MapObstacle[CarteJeu.RegistreV[y].x, CarteJeu.RegistreV[y].y] = false;
                                CarteJeu.RegistreV[y].x = (CarteJeu.RegistreV[y].x - 1);
                                MapObstacle[CarteJeu.RegistreV[y].x, CarteJeu.RegistreV[y].y] = true;
                            }

                        }
                        break;
                    case 2:
                        //right
                        if (CarteJeu.RegistreV[y].x * MapPixel < 19 * MapPixel)
                        {
                            // Condition pour les obstacles
                            if (MapObstacle[CarteJeu.RegistreV[y].x + 1, (CarteJeu.RegistreV[y].y)] == false)
                            {
                                if (rand.Next(0, 10) == 1)
                                {
                                    g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(38), CarteJeu.RegistreV[y].x * MapPixel, CarteJeu.RegistreV[y].y * MapPixel);
                                    MapDechet[CarteJeu.RegistreV[y].x, CarteJeu.RegistreV[y].y] = true;
                                }
                                else if (dechet == true)
                                {
                                    g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(0), CarteJeu.RegistreV[y].x * MapPixel, CarteJeu.RegistreV[y].y * MapPixel);
                                    dechet = false;
                                }

                                MapObstacle[CarteJeu.RegistreV[y].x, CarteJeu.RegistreV[y].y] = false;
                                CarteJeu.RegistreV[y].x = CarteJeu.RegistreV[y].x + 1;
                                MapObstacle[CarteJeu.RegistreV[y].x, CarteJeu.RegistreV[y].y] = true;
                            }
                        }

                        break;
                    case 3:
                        //up                         
                        if (CarteJeu.RegistreV[y].y > 0)
                        {

                            // Condition pour les obstacles
                            if (MapObstacle[CarteJeu.RegistreV[y].x, (CarteJeu.RegistreV[y].y - 1)] == false
                                && !(CarteJeu.RegistreV[y].x == 6 && CarteJeu.RegistreV[y].y - 1 == 6)
                                && !(CarteJeu.RegistreV[y].x == 6 && CarteJeu.RegistreV[y].y - 1 == 13)
                                && !(CarteJeu.RegistreV[y].x == 18 && CarteJeu.RegistreV[y].y - 1 == 6)
                                && !(CarteJeu.RegistreV[y].x == 18 && CarteJeu.RegistreV[y].y - 1 == 13))
                            {
                                if (rand.Next(0, 10) == 1)
                                {
                                    g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(38), CarteJeu.RegistreV[y].x * MapPixel, CarteJeu.RegistreV[y].y * MapPixel);
                                    MapDechet[CarteJeu.RegistreV[y].x, CarteJeu.RegistreV[y].y] = true;
                                }
                                else if (dechet == true)
                                {
                                    g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(0), CarteJeu.RegistreV[y].x * MapPixel, CarteJeu.RegistreV[y].y * MapPixel);
                                    dechet = false;
                                }

                                MapObstacle[CarteJeu.RegistreV[y].x, CarteJeu.RegistreV[y].y] = false;
                                CarteJeu.RegistreV[y].y = (CarteJeu.RegistreV[y].y - 1);
                                MapObstacle[CarteJeu.RegistreV[y].x, CarteJeu.RegistreV[y].y] = true;
                            }
                        }

                        break;
                    case 4:
                        //down
                        if (CarteJeu.RegistreV[y].y < 19)
                        {
                            // Condition pour les obstacles
                            if (MapObstacle[CarteJeu.RegistreV[y].x, (CarteJeu.RegistreV[y].y + 1)] == false)
                            {
                                if (rand.Next(0, 10) == 1)
                                {
                                    g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(38), CarteJeu.RegistreV[y].x * MapPixel, CarteJeu.RegistreV[y].y * MapPixel);
                                    MapDechet[CarteJeu.RegistreV[y].x, CarteJeu.RegistreV[y].y] = true;
                                }
                                else if (dechet == true)
                                {
                                    g.DrawImage(TestTilesetZoo.TilesetImageGenerator.GetTile(0), CarteJeu.RegistreV[y].x * MapPixel, CarteJeu.RegistreV[y].y * MapPixel);
                                    dechet = false;
                                }
                                MapObstacle[CarteJeu.RegistreV[y].x, CarteJeu.RegistreV[y].y] = false;
                                CarteJeu.RegistreV[y].y = (CarteJeu.RegistreV[y].y + 1);
                                MapObstacle[CarteJeu.RegistreV[y].x, CarteJeu.RegistreV[y].y] = true;
                            }
                        }
                        break;
                }

            }
        }

        private void MouvementsConcierge(object sender, PaintEventArgs e, Graphics g)
        {
            for (int y = 0; y < comptConcierge; y++)
            {
                int Direction = rand.Next(1, 5);
                switch (Direction)
                {
                    case 1:
                        //left
                        if (CarteJeu.RegistreG[y].x > 0 && CarteJeu.RegistreG[y].x < 30)
                        {
                            // Condition pour les obstacles
                            if (MapObstacle[CarteJeu.RegistreG[y].x - 1, (CarteJeu.RegistreG[y].y)] == false)
                            {
                                MapObstacle[CarteJeu.RegistreG[y].x, CarteJeu.RegistreG[y].y] = false;
                                CarteJeu.RegistreG[y].x = (CarteJeu.RegistreG[y].x - 1);
                                MapObstacle[CarteJeu.RegistreG[y].x, CarteJeu.RegistreG[y].y] = true;
                            }

                        }
                        break;
                    case 2:
                        //right
                        if (CarteJeu.RegistreG[y].x * MapPixel < 19 * MapPixel)
                        {
                            // Condition pour les obstacles
                            if (MapObstacle[CarteJeu.RegistreG[y].x + 1, (CarteJeu.RegistreG[y].y)] == false)
                            {
                                MapObstacle[CarteJeu.RegistreG[y].x, CarteJeu.RegistreG[y].y] = false;
                                CarteJeu.RegistreG[y].x = CarteJeu.RegistreG[y].x + 1;
                                MapObstacle[CarteJeu.RegistreG[y].x, CarteJeu.RegistreG[y].y] = true;
                            }
                        }

                        break;
                    case 3:
                        //up                         
                        if (CarteJeu.RegistreG[y].y > 0)
                        {

                            // Condition pour les obstacles
                            if (MapObstacle[CarteJeu.RegistreG[y].x, (CarteJeu.RegistreG[y].y - 1)] == false
                                && !(CarteJeu.RegistreG[y].x == 6 && CarteJeu.RegistreG[y].y - 1 == 6)
                                && !(CarteJeu.RegistreG[y].x == 6 && CarteJeu.RegistreG[y].y - 1 == 13)
                                && !(CarteJeu.RegistreG[y].x == 18 && CarteJeu.RegistreG[y].y - 1 == 6)
                                && !(CarteJeu.RegistreG[y].x == 18 && CarteJeu.RegistreG[y].y - 1 == 13))
                            {
                                MapObstacle[CarteJeu.RegistreG[y].x, CarteJeu.RegistreG[y].y] = false;
                                CarteJeu.RegistreG[y].y = (CarteJeu.RegistreG[y].y - 1);
                                MapObstacle[CarteJeu.RegistreG[y].x, CarteJeu.RegistreG[y].y] = true;
                            }
                        }

                        break;
                    case 4:
                        //down
                        if (CarteJeu.RegistreG[y].y < 19)
                        {
                            // Condition pour les obstacles
                            if (MapObstacle[CarteJeu.RegistreG[y].x, (CarteJeu.RegistreG[y].y + 1)] == false)
                            {
                                MapObstacle[CarteJeu.RegistreG[y].x, CarteJeu.RegistreG[y].y] = false;
                                CarteJeu.RegistreG[y].y = (CarteJeu.RegistreG[y].y + 1);
                                MapObstacle[CarteJeu.RegistreG[y].x, CarteJeu.RegistreG[y].y] = true;
                            }
                        }
                        break;
                }
                ConciergeMenage(CarteJeu.RegistreG[y].x, CarteJeu.RegistreG[y].y);

            }
        }




        /// <summary>
        /// Prend le data de la méthode ProcessCmdKey et déplace le joueur en conséquence
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        public int EvenementClick(Keys keyData)
        {
            if (Deplace == true)
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
                                Deplace = false;
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
                                Deplace = false;
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
                                Deplace = false;
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
                                Deplace = false;
                                Refresh();
                            }
                        }
                        return posHor;
                    default:
                        return 0;
                }
            }
            else
            {
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
                        //((ZooInterface)Parent).labelJour.Text = Temps.ToString();

                        //((ZooInterface)Parent).labelJour.Text = "Jour " + comptJour;


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



        internal class Concierge
        {
            static Random rand = new Random();
            public int x;
            public int y;
            public int modele = rand.Next(1, 9);
            public int X { get; set; }

            public int Y { get; set; }

        }




        /// <summary>
        /// Timer qui permet de prendre l'argent des visiteurs a chaque minute
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (comptVisiteur > 0)
            {
                Heros.ajoutArgent(comptVisiteur * comptAnimal); //toutes les minutes (60000 ms) chaque visiteur paie 1$ par animaux.                              
            }
        }

        /// <summary>
        /// Permet au jeu de bouger tout seul a chaque in game day (821 ms)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer2_Tick(object sender, EventArgs e)
        {
            dateJeu = dateJeu.AddDays(1);
            DateFromStart++;                      
            Refresh();
            ToolStripInformative.miseAJourToolStripJour();

            Hunger();

        }

        public void Hunger()
        {
            for (int i = 0; i < comptAnimal; i++)
            {
                RegistreA[i].HungerDown();
            }
        }

        /// <summary>
        /// Methode qui mais le deplacement a true, ce qui permet au joueur de bouger avec un petit retard
        /// Permet de ne pas mettre le jeu en pause lorsque le personnage bouge (100 ms)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer3_Tick(object sender, EventArgs e)
        {
            Deplace = true;
        }
    }
}