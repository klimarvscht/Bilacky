using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

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
                resetBTN.Enabled = false;
                pocitam = true;

                Thread vypocet = new Thread(Vypocty); // aby aplikace odpovídala
                vypocet.Start();

                Vypocet.Enabled = true;
                btnNastaveniSlozek.Enabled = true;
                vztup.Enabled = true;
                vyztup.Enabled = true;
                resetBTN.Enabled = true;
            }
            else
            {
                MessageBox.Show("Zavřete prosím nastavení.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        public static void Vypocty()
        {
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

            Kontrola(); // zkontroluje jestli jsou hodnoty vrámci mezí

            ReseniSoustavyRovnic.RESET(); // nastavím vše na původní stav se zachovanými výsledky

            pocitam = false;
        }

        private static bool LinearniCast() // Gausova eliminace
        {
            ReseniSoustavyRovnic.PredPripravLinearni();
            return ReseniSoustavyRovnic.UpravaLinearniRovnice();
        }

        private static bool NasobiciCast() // metoda pro úpravu násobící rovnice
        {
            ReseniSoustavyRovnic.PredPripravNasobici();
            return ReseniSoustavyRovnic.UpravaNasobneRovnice();
        }

        private void resetBTN_Click(object sender, EventArgs e)
        {
            if (nastaveni == null && krmitko == null && !pocitam)
            {
                Uzel uzlik = new Uzel(Uzel.uzel.vztupniProudy.Count, Uzel.uzel.vystupniProudy.Count); // vyresetuje obsah všech proudů jelikož se znovu
            }
            else
            {
                MessageBox.Show("Nelze udělat během provádějí jiné akce.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        public static void Kontrola()
        {
            foreach (Neznama item in ReseniSoustavyRovnic.nezname)
            {
                if (!item.known)
                {
                    continue;
                }

                if (item.value > item.max || item.value < item.min)
                {
                    MessageBox.Show("Hodnota " + item.GetName() + " je mimo hranice možných hodnot" + Environment.NewLine + "Hodnota je " + item.value + ")", "out of bounds", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }
    }
}
