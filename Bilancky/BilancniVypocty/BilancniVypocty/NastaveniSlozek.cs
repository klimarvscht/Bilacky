using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilancniVypocty
{
    public partial class nastaveniSlozek : Form
    {
        public nastaveniSlozek()
        {
            InitializeComponent();
            numPocetSlozek.Value = Uzel.slozek;
            numVystoupProud.Value = Uzel.uzel.vystupniProudy.Count;
            numVztupProud.Value = Uzel.uzel.vztupniProudy.Count;
            FormClosing += new FormClosingEventHandler(PriZavreni);
        }

        private void PriZavreni(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Uzel.slozek = (int) numPocetSlozek.Value;
            Uzel.uzel.RozsirProudy(Uzel.slozek, (int) numVztupProud.Value, (int)numVystoupProud.Value);
            Form1.nastaveni = null;
            e.Cancel = false;
        }

        private void Ulozit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
