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
        
        private static List<Button> buttony =  new List<Button>(); // list všech čudlíků ve formu

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Uzel.slozek = 3;
            Uzel uzlik = new Uzel(2, 3);
            
            buttony.Add(vypocet);
            buttony.Add(btnNastaveniSlozek);
            buttony.Add(vztup);
            buttony.Add(vyztup);
            buttony.Add(resetBTN);
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
                krmitko = new Krmitko(Uzel.uzel.vztupniProudy.ToArray(), "Nastavení vstuních proudů");
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
                krmitko = new Krmitko(Uzel.uzel.vystupniProudy.ToArray(), "Nastavení vystupních proudů");
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
                pocitam = true;

                async void karel () { await Task.Run(() => Vypocty()); }; // asychroní chování, aby nám to nelagovalo

                karel(); // co by to bylo za kód bez karla

                // zakáži uživateli vše
                ZapniButtony();
            }
            else
            {
                MessageBox.Show("Zavřete prosím nastavení.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        public static void Vypocty()
        {
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

            // povolím uživateli vše
            ZapniButtony();
        }

        private static void ZapniButtony() // zakáže / povolíme buttony
        {
            foreach (Button item in buttony)
            {
                // netuším proč, netuším jak, ale funguje to (nešmatat => křehké)
                item.BeginInvoke(new Action(() => {
                    item.Enabled = !pocitam;
                    }));
            }

            Application.UseWaitCursor = pocitam;
            Cursor.Current = Cursors.Default; // pokud není miší na aplikaci hrozí, že by mu zůstalo kolečko
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
