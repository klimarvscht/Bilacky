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
        private bool ulozit;

        public nastaveniSlozek()
        {
            // nastaví výchozí hodnoty 
            InitializeComponent();
            ulozit = false;
            numPocetSlozek.Value = Uzel.slozek;
            numVystoupProud.Value = Uzel.uzel.vystupniProudy.Count;
            numVztupProud.Value = Uzel.uzel.vztupniProudy.Count;
            FormClosing += new FormClosingEventHandler(PriZavreni);
        }

        private void PriZavreni(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (ulozit) // klikl na tlačítko uložit
            {
                UlozitHodnoty();
            }
            else
            {
                DialogResult odpoved = MessageBox.Show("Chcete nastavení uložit?", "Odejít?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1); // zeptáme se uživatele

                if (odpoved.Equals(DialogResult.Yes))
                {
                    UlozitHodnoty();
                    e.Cancel = false;
                }
                else if (odpoved.Equals(DialogResult.No))
                {
                    e.Cancel = false;
                }
                else if (odpoved.Equals(DialogResult.Cancel))
                {
                    e.Cancel = true;
                }
            }

            if (!e.Cancel) // pokud vypínáme tak odebereme referenci z Form1
            {
                Form1.nastaveni = null;
            }
        }

        private void Ulozit_Click(object sender, EventArgs e) // uživatel klikne na uložit
        {
            ulozit = true;
            Close();
        }

        private void UlozitHodnoty() // ulož hodnoty a vše nastav
        {
            Uzel.slozek = (int)numPocetSlozek.Value;
            Uzel.uzel.RozsirProudy(Uzel.slozek, (int)numVztupProud.Value, (int)numVystoupProud.Value);
            Uzel.PrenastavProudIndexy();
        }
    }
}
