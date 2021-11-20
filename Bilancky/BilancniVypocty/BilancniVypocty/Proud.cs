using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BilancniVypocty;

namespace BilancniVypocty
{
    class Proud
    {
        public int indexProudu;

        public bool plyn;

        // celkove proměnné
        public Neznama celkovaHmotnost;

        public Neznama hustota;

        public Neznama objem;

        public Neznama molarniHmotnostSmesi;

        // u jednotlyvých složek
        public Neznama[] hmotnostiSlozek;

        public Neznama[] hmotnostniZlomky;

        public Neznama[] relativnihmotnostniZlomky;

        public Neznama[] molarniZlomky;

        public Neznama[] relativniMolarniZlomky;

        public Neznama[] molarniKoncentrace;

        public Neznama[] hmotnostniKoncentrace;

        public Neznama[][] koeficientDoJakehoProudu;

        public Neznama[] latkoveMnozstvi;

        public Neznama[] pocetMolekul;

        public Neznama[] molarniHmotnost;

        // u plynu
        public Neznama[] objemJednotlivychLatek;

        public Neznama[] relativniobjemovaKoncentrace;

        public Neznama[] objemovaKoncentrace;

        public Proud(int slozek, int prouduNaDruheStrane, int indexProudu)
        {
            this.indexProudu = indexProudu;
            
            celkovaHmotnost = new Neznama((float)decimal.MaxValue, 0, "m", "kg", indexProudu, 0); // slozka 0 - celkova proudu

            hustota = new Neznama((float)decimal.MaxValue, 0, "ϱ", "kg*m^(-3)", indexProudu, 0);

            objem = new Neznama((float)decimal.MaxValue, 0, "V", "m^3", indexProudu, 0);

            molarniHmotnostSmesi = new Neznama((float)decimal.MaxValue, 0, "M", "kg*mol^(-1)", indexProudu, 0); ;

            hmotnostiSlozek = NastavPoleNeznamych( slozek, (float) decimal.MaxValue, 0, "m", "kg");

            relativnihmotnostniZlomky = NastavPoleNeznamych(slozek, (float)decimal.MaxValue, 0, "W", "1");
            
            hmotnostniZlomky = NastavPoleNeznamych(slozek, 1, 0, "w", "1");

            molarniZlomky = NastavPoleNeznamych( slozek, 1, 0, "x", "1");

            relativnihmotnostniZlomky = NastavPoleNeznamych(slozek, (float)decimal.MaxValue, 0, "W", "1");

            molarniKoncentrace = NastavPoleNeznamych(slozek, (float)decimal.MaxValue, 0, "c", "mol*m^(-3)");

            hmotnostniKoncentrace = NastavPoleNeznamych(slozek, (float)decimal.MaxValue, 0, "ϱ(m)", "kg*m^(-3)");

            latkoveMnozstvi = NastavPoleNeznamych(slozek, (float)decimal.MaxValue, 0, "n", "mol");

            pocetMolekul = NastavPoleNeznamych(slozek, (float)decimal.MaxValue, 0, "N", "1");

            molarniHmotnost = NastavPoleNeznamych(slozek, (float)decimal.MaxValue, 0, "M", "kg*mol^(-1)");

            koeficientDoJakehoProudu = NastavDoProudu(slozek, prouduNaDruheStrane);

            relativniMolarniZlomky = NastavPoleNeznamych(slozek, (float)decimal.MaxValue, 0, "X", "1");

            objemJednotlivychLatek = NastavPoleNeznamych(slozek , (float)decimal.MaxValue, 0, "V","m^3");

            relativniobjemovaKoncentrace = NastavPoleNeznamych(slozek, (float)decimal.MaxValue, 0, "W", "1");

            objemovaKoncentrace = NastavPoleNeznamych(slozek, 1, 0, "w", "1");

            plyn = false;
        }

        private Neznama[] NastavPoleNeznamych(int pocetSlozek, float maximum, float minimum, string jmeno, string jednotka)
        {
            Neznama[] nezname = new Neznama[pocetSlozek];

            for (int i = 0; i < pocetSlozek; i++)
            {
                nezname[i] = new Neznama(maximum, minimum, jmeno, jednotka, indexProudu, i + 1);
            }

            return nezname;
        }

        private Neznama[][] NastavDoProudu(int pocetSlozek, int pocetProudu)
        {
            Neznama[][] pomocna = new Neznama[pocetSlozek][];
            for (int i = 0; i < pocetSlozek; i++)
            {
                pomocna[i] = new Neznama[pocetProudu];
            }
            for (int i = 0; i < pocetSlozek; i++)
            {
                for (int j = 0; j < pocetProudu; j++)
                {
                    pomocna[i][j] = new Neznama(1, 0, indexProudu + "->", "1", j, i);
                }
            }

            return pomocna;
        }
    }
}
