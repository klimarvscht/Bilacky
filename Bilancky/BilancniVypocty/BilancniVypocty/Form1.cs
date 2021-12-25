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
    public partial class Form1 : Form
    {
        public static nastaveniSlozek nastaveni = null; // udržuje odkaz na nastavení složek
        public static Krmitko krmitko = null; // udržuje odkaz na krmítko
        public static bool pocitam = false; // probíhají výpočty?

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Uzel.slozek = 3;
            Uzel uzlik = new Uzel(2, 3);
        }

        private void btnNastaveniSlozek_Click(object sender, EventArgs e)
        {
            if (nastaveni == null && krmitko == null) // zkontroluji jestli není něco otevřené
            {
                nastaveni = new nastaveniSlozek();
                nastaveni.Show();
            }
            else
            {
                MessageBox.Show("Může být otevřeno pouze jedno okno!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void vztup_Click(object sender, EventArgs e)
        {
            if (nastaveni == null && krmitko == null && !pocitam)
            {
                krmitko = new Krmitko(Uzel.uzel.vztupniProudy.ToArray(), "Nastavení vztuních proudů");
                krmitko.Show();
            }
            else
            {
                MessageBox.Show("Může být otevřeno pouze jedno okno!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void vyztup_Click(object sender, EventArgs e)
        {
            if (nastaveni == null && krmitko == null && !pocitam)
            {
                krmitko = new Krmitko(Uzel.uzel.vystupniProudy.ToArray(), "Nastavení vztuních proudů");
                krmitko.Show();
            }
            else
            {
                MessageBox.Show("Může být otevřeno pouze jedno okno!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void Vypocet_Click(object sender, EventArgs e)
        {
            if (nastaveni == null && krmitko == null && !pocitam) // zkontroluji jestli se něco neděje
            {
                // zakáži uživateli vše
                Vypocet.Enabled = false;
                btnNastaveniSlozek.Enabled = false;
                vztup.Enabled = false;
                vyztup.Enabled = false;
                pocitam = true;

                // získám neznámé a rovnice
                Uzel.uzel.ExtrahujNezname();
                Uzel.uzel.ExtrahujRovnice();

                // pokusím se získat co nejvíce pouhým dosazením
                ReseniSoustavyRovnic.DosazeniDoRovnic();

                // pokusím si pomoc gausovou metodou
                LinearniCast();
                while (true) // dělám dokud se něco zjišťuje
                {
                    // zkusím i úpravu násobné rovnice
                    if (!NasobiciCast())
                    {
                        break;
                    }

                    
                    if (!LinearniCast())
                    {
                        break;
                    }
                }

                ReseniSoustavyRovnic.RESET(); // nastavím vše na původní stav se zachovanými výsledky

                pocitam = false;
                Vypocet.Enabled = true;
                btnNastaveniSlozek.Enabled = true;
                vztup.Enabled = true;
                vyztup.Enabled = true;
            }
            else
            {
                MessageBox.Show("Zavřete prosím nastavení.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private bool LinearniCast() // Gausova eliminace
        {
            ReseniSoustavyRovnic.PredPripravLinearni();
            return ReseniSoustavyRovnic.UpravaLinearniRovnice();
        }

        private bool NasobiciCast() // metoda pro úpravu násobící rovnice
        {
            ReseniSoustavyRovnic.PredPripravNasobici();
            return ReseniSoustavyRovnic.UpravaNasobneRovnice();
        }
    }
}
