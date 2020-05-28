using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.PropertyGridInternal;

namespace TP2
{


    public class Animaux
    {
        public int x;
        public int y;
        public int Prix = 0;
        public string Type;
        public string Nom;

        public int X { get; set; }

        public int Y { get; set; }

        public int PRIX { get; set; }

        public string TYPE { get; set; }

        public string Sexe { get; set; }

        public string Vie { get; set; }

        public int Faim { get; set; }

        public string Enceinte { get; set; }

        public void ResetLion()
        {
            Faim = 120;
        }

        public void ResetMouton()
        {
            Faim = 120;
        }

        public void ResetLicorne()
        {
            Faim = 180;
        }


        public void Starve()
        {
            Heros.baisseArgent(2);

            if (Type == "Licorne")
            {
                ResetLicorne();
            }

            else if (Type == "Mouton")
            {
                ResetMouton();
            }

            else
            {
                ResetLion();
            }
        }

        public void HungerDown()
        {
            Faim--;
            if (Faim == 0)
            {
                Starve();
            }
        }

        public void genererNom()
        {
            string resource_data = TP2_DevGraphique.Properties.Resources.ListeNomsFeminins;
            List<string> words = resource_data.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();

            Random random = new Random();
            int index = random.Next(words.Count);

            Nom = words[index];
            Console.WriteLine(Nom);
        }

    }
    
}