using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    class Heros
    {
        public static int X = 12 * 32;
        public static int Y = 7 * 32;
        public int monaieJoueur = 100;

        public class HerosPos
        {
            public int X
            {
                get;
                set;
            }

            public int Y
            {
                get;
                set;
            }
        }
        
        public void ajoutArgent(int profit)
        {
            monaieJoueur += profit;
        }

        public void baisseArgent(int perte)
        {
            monaieJoueur -= perte;
            if(monaieJoueur < 0)
            {
                monaieJoueur = 0;
                //ATTENTION : Ca veut dire qu'il n'a plus d'argent.
            }
        }

        public int getMonaie()
        {
            return monaieJoueur;
        }
    }

   
}
