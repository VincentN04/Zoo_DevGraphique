using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    class TileVisiteur
    {
        // Différentes tailles concernant les images dans le fichier de tuiles de jeu
        public const int IMAGE_WIDTH = 32, IMAGE_HEIGHT = 32;
        private const int TILE_LEFT = 0, TILE_TOP = 0;
        private const int SEPARATEUR_TILE = 0;

        // La valeur entière correspond "par hasard" à la position de l'image dans la List<TileCoord>
        private static List<TileCoord> listeCoord = new List<TileCoord>();
        private static List<Bitmap> listeBitmap = new List<Bitmap>();
        private static List<Bitmap> listePerso1 = new List<Bitmap>();
        private static List<Bitmap> listePerso2 = new List<Bitmap>();
        private static List<Bitmap> listePerso3 = new List<Bitmap>();
        private static List<Bitmap> listePerso4 = new List<Bitmap>();
        private static List<Bitmap> listePerso5 = new List<Bitmap>();
        private static List<Bitmap> listePerso6 = new List<Bitmap>();
        private static List<Bitmap> listePerso7 = new List<Bitmap>();
        private static List<Bitmap> listePerso8 = new List<Bitmap>();
        private static List<Bitmap> listePerso9 = new List<Bitmap>();

        static void TilesetImageGenerator()
        {
            for (int i = 1; i < 8; i++)
            {
                listePerso1.Add(LoadTile(0, i)); 
                listePerso2.Add(LoadTile(1, i));
                listePerso3.Add(LoadTile(2, i)); 
                listePerso4.Add(LoadTile(3, i));
                listePerso5.Add(LoadTile(4, i));
                listePerso6.Add(LoadTile(5, i));
                listePerso7.Add(LoadTile(6, i));
                listePerso8.Add(LoadTile(7, i));
                listePerso9.Add(LoadTile(8, i));
                int compt = 0;
                compt = i;
            }
        }

        private static Bitmap LoadTile(int Ligne, int Colonne)
        {

            Image source = TP2_DevGraphique.Properties.Resources.personnages;


            Rectangle crop = new Rectangle(TILE_LEFT + (Colonne * (IMAGE_WIDTH + SEPARATEUR_TILE)), TILE_TOP + Ligne * (IMAGE_HEIGHT + SEPARATEUR_TILE), IMAGE_WIDTH, IMAGE_HEIGHT);

            var bmp = new Bitmap(crop.Width, crop.Height);
            using (var gr = Graphics.FromImage(bmp))
            {
                gr.DrawImage(source, new Rectangle(0, 0, bmp.Width, bmp.Height), crop, GraphicsUnit.Pixel);
            }


            return bmp;
        }

        public static Bitmap GetTile(int Perso, int position)
        {
            TilesetImageGenerator();
            Bitmap Tile = null;
            switch (Perso)
            {
                case 1:
                  
                    Tile = listePerso1.ElementAt(position);
                   
                    break;
                case 2:

                    Tile = listePerso2.ElementAt(position);
                    break;
                case 3:

                    Tile = listePerso3.ElementAt(position);
                    
                    break;
                case 4:
                    Tile = listePerso4.ElementAt(position);
                 
                    break;
                case 5:

                    Tile = listePerso5.ElementAt(position);
                  
                    break;
                case 6:

                    Tile = listePerso6.ElementAt(position);
                   
                    break;
                case 7:

                    Tile = listePerso7.ElementAt(position);
                    
                    break;
                case 8:

                    Tile = listePerso8.ElementAt(position);
                    
                    break;
                case 9:

                    Tile = listePerso9.ElementAt(position);
                    break;


            }
            return Tile;
        }

    }

    public class TileCoord
    {
        public int Ligne { get; set; }
        public int Colonne { get; set; }
    };
}


