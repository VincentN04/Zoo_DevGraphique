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
    public partial class ListeAnimaux : Form
    {
        public static List<Button> list = new List<Button>();
        public ListeAnimaux()
        {
            InitializeComponent();
            list.Add(button1);
            list.Add(button2);
            list.Add(button3);
            list.Add(button4);
            list.Add(button5);
            list.Add(button6);
            list.Add(button7);
            list.Add(button8);
            list.Add(button9);
            list.Add(button10);
            list.Add(button11);
            list.Add(button12);
            list.Add(button13);
            list.Add(button14);
            list.Add(button15);
            list.Add(button16);
            list.Add(button17);
            list.Add(button18);
            list.Add(button19);
            list.Add(button20);
           
        }

        public void UpdateButton()
        {
            int comptLic = 0;
            int comptLion = 0;
            int ComptM = 0;
            
            for(int i = 0; CarteJeu.RegistreA[i] != null; i++)
            {
                if (CarteJeu.RegistreA[i].Type == "Mouton")
                {
                    list[i].BackgroundImage = Image.FromFile("C:/Users/J-P/Documents/GitHub/ZooNumberTwo/Zoo_DevGraphique/TP2 DevGraphique/TP2 DevGraphique/Resources/Dorset_Sheep-icon.png");
                    ComptM++;
                    list[i].Text = "Mouton "+ComptM.ToString();
                    list[i].Refresh();


                }
                if (CarteJeu.RegistreA[i].Type == "Lion")
                {
                    list[i].BackgroundImage = Image.FromFile("C:/Users/J-P/Documents/GitHub/ZooNumberTwo/Zoo_DevGraphique/TP2 DevGraphique/TP2 DevGraphique/Resources/Male_Lion-icon.png");
                    comptLion++;
                    list[i].Text = "Lion " + comptLion.ToString();
                    list[i].Refresh();

                }
                if (CarteJeu.RegistreA[i].Type == "Licorne")
                {
                    list[i].BackgroundImage = Image.FromFile("C:/Users/J-P/Documents/GitHub/ZooNumberTwo/Zoo_DevGraphique/TP2 DevGraphique/TP2 DevGraphique/Resources/UNICORN.png");
                    comptLic++;
                    list[i].Text = "Licorne " + comptLic.ToString();
                    list[i].Refresh();

                }
                
            }

        }
    }
}
