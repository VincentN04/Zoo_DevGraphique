using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP2_DevGraphique
{
    public partial class ZooInterface : Form
    {
        public ZooInterface()
        {
            InitializeComponent();
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
    }
}
