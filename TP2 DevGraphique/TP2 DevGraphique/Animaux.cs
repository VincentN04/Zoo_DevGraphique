using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TP2
{
    
        
        public class Animaux
        {
        public int x;
        public int y;
        public int Prix = 0;
        public string Type;

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

            if(Type == "Licorne")
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
            if(Faim == 0)
            {
                Starve();
            }
        }

    }
    
}