﻿using System;
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
        public static nastaveniSlozek nastaveni = null;
        public static Krmitko krmitko = null;
        public static bool pocitam = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Uzel.slozek = 3;
            Uzel uzlik = new Uzel(2, 3);

            /*
            uzlik.ExtrahujNezname();

            uzlik.ExtrahujRovnice();

            ReseniSoustavyRovnic.VypisNezname();

            ReseniSoustavyRovnic.VypisMatici(ReseniSoustavyRovnic.linearniMatice, ReseniSoustavyRovnic.vysledkyLinearni);
            ReseniSoustavyRovnic.VypisMatici(ReseniSoustavyRovnic.nasobiciMatice, ReseniSoustavyRovnic.vysledkyNasobici);
            */

            Console.WriteLine("done");
        }

        private void btnNastaveniSlozek_Click(object sender, EventArgs e)
        {
            if (nastaveni == null && krmitko == null)
            {
                nastaveni = new nastaveniSlozek();
                nastaveni.Show();
            }
        }

        private void vztup_Click(object sender, EventArgs e)
        {
            if (nastaveni == null && krmitko == null && !pocitam)
            {
                krmitko = new Krmitko(Uzel.uzel.vztupniProudy.ToArray(), "Nastavení vztuních proudů");
                krmitko.Show();
            }
        }

        private void vyztup_Click(object sender, EventArgs e)
        {
            if (nastaveni == null && krmitko == null && !pocitam)
            {
                krmitko = new Krmitko(Uzel.uzel.vystupniProudy.ToArray(), "Nastavení vztuních proudů");
                krmitko.Show();
            }
        }

        private void Vypocet_Click(object sender, EventArgs e)
        {
            Vypocet.Enabled = false;
            pocitam = true;
            Uzel.uzel.ExtrahujNezname();
            Uzel.uzel.ExtrahujRovnice();

            ReseniSoustavyRovnic.VypisMaticiChytre(ReseniSoustavyRovnic.nasobiciMatice, ReseniSoustavyRovnic.vysledkyNasobici);

            ReseniSoustavyRovnic.VypisMaticiChytre(ReseniSoustavyRovnic.linearniMatice, ReseniSoustavyRovnic.vysledkyLinearni);

            LinearniCast();
            while (true)
            {
                
                if (!NasobiciCast())
                {
                    break;
                }
                

                if (!LinearniCast())
                {
                    break;
                }
            }

            //ReseniSoustavyRovnic.VypisMatici(ReseniSoustavyRovnic.linearniMatice, ReseniSoustavyRovnic.vysledkyLinearni);

            ReseniSoustavyRovnic.RESET();

            pocitam = false;
            Vypocet.Enabled = true;
        }

        private bool LinearniCast()
        {
            ReseniSoustavyRovnic.PredPripravLinearni();
            return ReseniSoustavyRovnic.UpravaLinearniRovnice();
        }

        private bool NasobiciCast()
        {
            ReseniSoustavyRovnic.PredPripravNasobici();
            return ReseniSoustavyRovnic.UpravaNasobneRovnice();
        }
    }
}
