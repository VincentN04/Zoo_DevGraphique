using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTilesetZoo
{
    class TilesetImageGenerator
    {
        // Différentes tailles concernant les images dans le fichier de tuiles de jeu
        public const int IMAGE_WIDTH = 32, IMAGE_HEIGHT = 32;
        private const int TILE_LEFT = 0, TILE_TOP = 0;
        private const int SEPARATEUR_TILE = 0;

        // La valeur entière correspond "par hasard" à la position de l'image dans la List<TileCoord>
        public static int GAZON = 0;
        public static int PLANCHER_BOIS = 1;
        public static int ENCLOS_HOR = 2;
        public static int ENCLOS_VER = 3;
        public static int MAISON1 = 4;
        public static int MAISON2 = 5;
        public static int MAISON3 = 6;
        public static int MAISON4 = 7;
        public static int MAISON5 = 8;
        public static int MAISON6 = 9;
        public static int MAISON7 = 10;
        public static int MAISON8 = 11;
        public static int MAISON9 = 12;
        public static int MAISON10 = 13;
        public static int MAISON11 = 14;
        public static int MAISON12 = 15;
        public static int MAISON13 = 16;
        public static int MAISON14 = 17;
        public static int MAISON15 = 18;
        public static int MAISON16 = 19;
        public static int MAISON17 = 20;
        public static int MAISON18 = 21;
        public static int MAISON19 = 22;
        public static int MAISON20 = 23;
        public static int BARREL = 24;
        public static int ENTREE1 = 25;
        public static int ENTREE2 = 26;
        public static int SABLE1 = 27;
        public static int SABLE2 = 28;
        public static int SABLE3 = 29;
        public static int SABLE4 = 30;
        public static int SABLE5 = 31;
        public static int SABLE6 = 32;
        public static int SABLE7 = 33;
        public static int SABLE8 = 34;
        public static int SABLE9 = 35;
        public static int MUR = 36;
        public static int EAU = 37;
        public static int LION = 38;
        public static int MOUTON = 39;
        public static int LICORNE = 40;
        public static int DECHET = 41;


        public static List<TileCoord> listeCoord = new List<TileCoord>();
        private static List<Bitmap> listeBitmap = new List<Bitmap>();

        /// <summary>
        /// Constructeur statique
        /// </summary>
        static TilesetImageGenerator()
        {
            listeCoord.Add(new TileCoord() { Ligne = 10, Colonne = 0 }); // GAZON
            listeCoord.Add(new TileCoord() { Ligne = 6, Colonne = 19 }); // PLANCHER_BOIS
            listeCoord.Add(new TileCoord() { Ligne = 9, Colonne = 19 }); // ENCLOS_HOR
            listeCoord.Add(new TileCoord() { Ligne = 14, Colonne = 23 }); // ENCLOS_VER

            for (int i = 4; i < 9; i++)
            {
                for (int j = 12; j < 16; j++)
                {
                    listeCoord.Add(new TileCoord() { Ligne = i, Colonne = j }); // MAISON
                }
            }

            listeCoord.Add(new TileCoord() { Ligne = 5, Colonne = 27 }); // BARREL

            listeCoord.Add(new TileCoord() { Ligne = 14, Colonne = 22 }); // ENTREE1
            listeCoord.Add(new TileCoord() { Ligne = 14, Colonne = 23 }); // ENTREE2

            listeCoord.Add(new TileCoord() { Ligne = 13, Colonne = 3 }); // SABLE1
            listeCoord.Add(new TileCoord() { Ligne = 13, Colonne = 4 }); // SABLE2
            listeCoord.Add(new TileCoord() { Ligne = 13, Colonne = 5 }); // SABLE3
            listeCoord.Add(new TileCoord() { Ligne = 14, Colonne = 3 }); // SABLE4
            listeCoord.Add(new TileCoord() { Ligne = 14, Colonne = 4 }); // SABLE5
            listeCoord.Add(new TileCoord() { Ligne = 14, Colonne = 5 }); // SABLE6
            listeCoord.Add(new TileCoord() { Ligne = 15, Colonne = 3 }); // SABLE7
            listeCoord.Add(new TileCoord() { Ligne = 15, Colonne = 4 }); // SABLE8
            listeCoord.Add(new TileCoord() { Ligne = 15, Colonne = 5 });// SABLE9

            listeCoord.Add(new TileCoord() { Ligne = 10, Colonne = 18 }); // MUR

            listeCoord.Add(new TileCoord() { Ligne = 2, Colonne = 1 }); // EAU
            listeCoord.Add(new TileCoord() { Ligne = 16, Colonne = 24 }); // LION
            listeCoord.Add(new TileCoord() { Ligne = 19, Colonne = 8 }); // MOUTON
            listeCoord.Add(new TileCoord() { Ligne = 16, Colonne = 16 }); // LICORNE
            listeCoord.Add(new TileCoord() { Ligne = 23, Colonne = 1 }); // DECHET

            listeBitmap.Add(LoadTile(GAZON)); // GAZON
            listeBitmap.Add(LoadTile(PLANCHER_BOIS)); // PLANCHER_BOIS
            listeBitmap.Add(LoadTile(ENCLOS_HOR)); // ENCLOS_HOR
            listeBitmap.Add(LoadTile(ENCLOS_VER)); // ENCLOS VER

            listeBitmap.Add(LoadTile(MAISON1)); // MAISON1
            listeBitmap.Add(LoadTile(MAISON2)); // MAISON2
            listeBitmap.Add(LoadTile(MAISON3)); // MAISON3
            listeBitmap.Add(LoadTile(MAISON4)); // MAISON4
            listeBitmap.Add(LoadTile(MAISON5)); // MAISON5
            listeBitmap.Add(LoadTile(MAISON6)); // MAISON6
            listeBitmap.Add(LoadTile(MAISON7)); // MAISON7
            listeBitmap.Add(LoadTile(MAISON8)); // MAISON8
            listeBitmap.Add(LoadTile(MAISON9)); // MAISON9
            listeBitmap.Add(LoadTile(MAISON10)); // MAISON10
            listeBitmap.Add(LoadTile(MAISON11)); // MAISON11
            listeBitmap.Add(LoadTile(MAISON12)); // MAISON12
            listeBitmap.Add(LoadTile(MAISON13)); // MAISON13
            listeBitmap.Add(LoadTile(MAISON14)); // MAISON14
            listeBitmap.Add(LoadTile(MAISON15)); // MAISON15
            listeBitmap.Add(LoadTile(MAISON16)); // MAISON16
            listeBitmap.Add(LoadTile(MAISON17)); // MAISON17
            listeBitmap.Add(LoadTile(MAISON18)); // MAISON18
            listeBitmap.Add(LoadTile(MAISON19)); // MAISON19
            listeBitmap.Add(LoadTile(MAISON20)); // MAISON20

            listeBitmap.Add(LoadTile(BARREL)); // BARREL

            listeBitmap.Add(LoadTile(ENTREE1)); // ENTREE1
            listeBitmap.Add(LoadTile(ENTREE2)); // ENTREE2

            listeBitmap.Add(LoadTile(SABLE1)); // SABLE1
            listeBitmap.Add(LoadTile(SABLE2)); // SABLE2
            listeBitmap.Add(LoadTile(SABLE3)); // SABLE3
            listeBitmap.Add(LoadTile(SABLE4)); // SABLE4
            listeBitmap.Add(LoadTile(SABLE5)); // SABLE5
            listeBitmap.Add(LoadTile(SABLE6)); // SABLE6
            listeBitmap.Add(LoadTile(SABLE7)); // SABLE7
            listeBitmap.Add(LoadTile(SABLE8)); // SABLE8
            listeBitmap.Add(LoadTile(SABLE9)); // SABLE9

            listeBitmap.Add(LoadTile(MUR)); // MUR

            listeBitmap.Add(LoadTile(EAU)); // EAU

            listeBitmap.Add(LoadTile(LION)); // Lion
            listeBitmap.Add(LoadTile(MOUTON)); // Mouton
            listeBitmap.Add(LoadTile(LICORNE)); // Licorne
            listeBitmap.Add(LoadTile(DECHET));
        }

        private static Bitmap LoadTile(int posListe)
        {
            Image source = TP2_DevGraphique.Properties.Resources.zoo_tileset;
            TileCoord coord = listeCoord[posListe];
            Rectangle crop = new Rectangle(TILE_LEFT + (coord.Colonne * (IMAGE_WIDTH + SEPARATEUR_TILE)), TILE_TOP + coord.Ligne * (IMAGE_HEIGHT + SEPARATEUR_TILE), IMAGE_WIDTH, IMAGE_HEIGHT);

            var bmp = new Bitmap(crop.Width, crop.Height);
            using (var gr = Graphics.FromImage(bmp))
            {
                gr.DrawImage(source, new Rectangle(0, 0, bmp.Width, bmp.Height), crop, GraphicsUnit.Pixel);
            }
            return bmp;
        }

        public static Bitmap GetTile(int posListe)
        {
            return listeBitmap[posListe];
        }

    }

    public class TileCoord
    {
        public int Ligne { get; set; }
        public int Colonne { get; set; }
    };
}

