using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BilancniVypocty;

namespace BilancniVypocty
{
    public class Proud
    {
        private const float plynovaKonstanta = 8.31446261815324f;

        public int indexProudu;

        public bool plyn;

        // celkove proměnné
        public Neznama celkovaHmotnost;

        public Neznama hustota;

        public Neznama objem;

        public Neznama molarniHmotnostSmesi;

        public Neznama celkemMolu;

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

        public Neznama[] objemJednotlivychLatek;

        public Neznama[] relativniObjemovaKoncentrace;

        public Neznama[] objemovaKoncentrace;

        public Neznama[] hustotaSlozky;

        // staticke promene
        public static Neznama[] molarniHmotnost;

        // u plynu
        public Neznama tlak;

        public Neznama teplota;

        public Neznama[] parcialniTlak;

        // pomocene promene

        public Neznama[] pomocnaSummaMolHmotnosti;

        public Neznama[] pomocnaSummaProVypocetmolarnichZlomku;

        public Neznama pomocnaCelkovaSummaProVypocetmolarnichZlomku;

        public Neznama[] pomocnyRelativniHmotnostniZlomek;

        public Neznama[] pomocnyRelativniMolarniZlomek;

        public Neznama[] pomocnaRelativniObjemovaKoncentrace;

        public Neznama[][] pomocnaKoeficientDoProudu;

        public Neznama[][] pomocnaLatkoveKoeficientDoProudu;

        public Proud(int slozek, int prouduNaDruheStrane, int indexProudu)
        {
            this.indexProudu = indexProudu;
            
            celkovaHmotnost = new Neznama((float)(decimal.MaxValue * (decimal)0.99), 0, "m", "kg", indexProudu, 0); // slozka 0 - celkova proudu

            hustota = new Neznama((float)(decimal.MaxValue * (decimal) 0.99), 0, "ϱ", "kg*m^(-3)", indexProudu, 0);

            objem = new Neznama((float)(decimal.MaxValue * (decimal)0.99), 0, "V", "m^3", indexProudu, 0);

            molarniHmotnostSmesi = new Neznama((float)(decimal.MaxValue * (decimal)0.99), 0, "M", "kg*mol^(-1)", indexProudu, 0);

            celkemMolu = new Neznama((float)(decimal.MaxValue * (decimal)0.99), 0, "n", "mol", indexProudu, 0);

            tlak = new Neznama((float)(decimal.MaxValue * (decimal)0.99), 0, "p", "Pa", indexProudu, 0, true, true);

            teplota = new Neznama((float)(decimal.MaxValue * (decimal)0.99), 0, "T", "K", indexProudu, 0, true, true);

            hmotnostiSlozek = NastavPoleNeznamych( slozek, (float)(decimal.MaxValue * (decimal)0.99), 0, "m", "kg");

            relativnihmotnostniZlomky = NastavPoleNeznamych(slozek, (float)(decimal.MaxValue * (decimal)0.99), 0, "W", "1");
            
            hmotnostniZlomky = NastavPoleNeznamych(slozek, 1, 0, "w", "1");

            molarniZlomky = NastavPoleNeznamych( slozek, 1, 0, "x", "1");

            relativnihmotnostniZlomky = NastavPoleNeznamych(slozek, (float)(decimal.MaxValue * (decimal)0.99), 0, "W", "1");

            molarniKoncentrace = NastavPoleNeznamych(slozek, (float)(decimal.MaxValue * (decimal)0.99), 0, "c", "mol*m^(-3)");

            hmotnostniKoncentrace = NastavPoleNeznamych(slozek, (float)(decimal.MaxValue * (decimal)0.99), 0, "ϱ(m)", "kg*m^(-3)");

            latkoveMnozstvi = NastavPoleNeznamych(slozek, (float)(decimal.MaxValue * (decimal)0.99), 0, "n", "mol");

            pocetMolekul = NastavPoleNeznamych(slozek, (float)(decimal.MaxValue * (decimal)0.99), 0, "N", "1");

            if (molarniHmotnost == null)
            {
                molarniHmotnost = NastavPoleNeznamych(slozek, (float)(decimal.MaxValue * (decimal)0.99), 0, "M", "kg*mol^(-1)");
            }

            koeficientDoJakehoProudu = NastavDoProudu(slozek, prouduNaDruheStrane);

            pomocnaKoeficientDoProudu = NastavDoProudu(slozek, prouduNaDruheStrane, false);

            pomocnaLatkoveKoeficientDoProudu = NastavDoProudu(slozek, prouduNaDruheStrane, false);

            relativniMolarniZlomky = NastavPoleNeznamych(slozek, (float)(decimal.MaxValue * (decimal)0.99), 0, "X", "1");

            objemJednotlivychLatek = NastavPoleNeznamych(slozek , (float)(decimal.MaxValue * (decimal)0.99), 0, "V","m^3");

            relativniObjemovaKoncentrace = NastavPoleNeznamych(slozek, (float)(decimal.MaxValue * (decimal)0.99), 0, "Vol", "1");

            objemovaKoncentrace = NastavPoleNeznamych(slozek, 1, 0, "vol", "1");

            pomocnaSummaMolHmotnosti = NastavPoleNeznamych(slozek, (float)(decimal.MaxValue * (decimal)0.99), 0, "(xi * Mi)", "kg/mol", false, false);

            pomocnaSummaProVypocetmolarnichZlomku = NastavPoleNeznamych(slozek, (float)(decimal.MaxValue * (decimal)0.99), 0, "(wi/Mi)", "mol/kg", false, false);

            pomocnaCelkovaSummaProVypocetmolarnichZlomku = new Neznama((float)(decimal.MaxValue * (decimal)0.99), 0, "(wi/Mi)", "mol/kg", indexProudu, 0, false, false);

            pomocnyRelativniHmotnostniZlomek = NastavPoleNeznamych(slozek, (float)(decimal.MaxValue * (decimal)0.99), 0, "(m-mi)", "kg", false, false);

            pomocnyRelativniMolarniZlomek = NastavPoleNeznamych(slozek, (float)(decimal.MaxValue * (decimal)0.99), 0, "(n-ni)", "mol", false, false);

            pomocnaRelativniObjemovaKoncentrace = NastavPoleNeznamych(slozek, (float)(decimal.MaxValue * (decimal)0.99), 0, "(V - V i)", "m^3", false, false);

            parcialniTlak = NastavPoleNeznamych(slozek, (float)(decimal.MaxValue * (decimal)0.99), 0, "pi", "Pa", false, true);

            hustotaSlozky = NastavPoleNeznamych(slozek, (float)(decimal.MaxValue * (decimal)0.99), 0, "ϱ", "kg*m^(-3)");

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

        private Neznama[] NastavPoleNeznamych(int pocetSlozek, float maximum, float minimum, string jmeno, string jednotka, bool chciVypsat, bool plyn)
        {
            Neznama[] nezname = new Neznama[pocetSlozek];

            for (int i = 0; i < pocetSlozek; i++)
            {
                nezname[i] = new Neznama(maximum, minimum, jmeno, jednotka, indexProudu, i + 1, chciVypsat, plyn);
            }

            return nezname;
        }

        private Neznama[][] NastavDoProudu(int pocetSlozek, int pocetProudu)
        {
            return NastavDoProudu(pocetSlozek, pocetProudu, true);
        }

        private Neznama[][] NastavDoProudu(int pocetSlozek, int pocetProudu, bool chciVypsat)
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
                    pomocna[i][j] = new Neznama(1, 0, indexProudu + "->", "1", j, i, chciVypsat, false);
                }
            }

            return pomocna;
        }

        public List<Neznama> NeznameDoListu(int pocatecnyIndex, bool chciINaindexovane)
        {
            List<Neznama> vratit = new List<Neznama>();

            celkovaHmotnost.indexVPoli = vratit.Count + pocatecnyIndex;
            vratit.Add(celkovaHmotnost);

            hustota.indexVPoli = vratit.Count + pocatecnyIndex;
            vratit.Add(hustota);

            objem.indexVPoli = vratit.Count + pocatecnyIndex;
            vratit.Add(objem);

            molarniHmotnostSmesi.indexVPoli = vratit.Count + pocatecnyIndex;
            vratit.Add(molarniHmotnostSmesi);

            celkemMolu.indexVPoli = vratit.Count + pocatecnyIndex;
            vratit.Add(celkemMolu);

            pomocnaCelkovaSummaProVypocetmolarnichZlomku.indexVPoli = vratit.Count + pocatecnyIndex;
            vratit.Add(pomocnaCelkovaSummaProVypocetmolarnichZlomku);

            vratit.AddRange(PoleNeznamychDoListu(hmotnostiSlozek, vratit.Count + pocatecnyIndex, chciINaindexovane));

            vratit.AddRange(PoleNeznamychDoListu(hmotnostniZlomky, vratit.Count + pocatecnyIndex, chciINaindexovane));

            vratit.AddRange(PoleNeznamychDoListu(relativnihmotnostniZlomky, vratit.Count + pocatecnyIndex, chciINaindexovane));

            vratit.AddRange(PoleNeznamychDoListu(molarniZlomky, vratit.Count + pocatecnyIndex, chciINaindexovane));

            vratit.AddRange(PoleNeznamychDoListu(relativniMolarniZlomky, vratit.Count + pocatecnyIndex, chciINaindexovane));

            vratit.AddRange(PoleNeznamychDoListu(molarniKoncentrace, vratit.Count + pocatecnyIndex, chciINaindexovane));

            vratit.AddRange(PoleNeznamychDoListu(hmotnostniKoncentrace, vratit.Count + pocatecnyIndex, chciINaindexovane));

            vratit.AddRange(PoleNeznamychDoListu(latkoveMnozstvi, vratit.Count + pocatecnyIndex, chciINaindexovane));

            vratit.AddRange(PoleNeznamychDoListu(pocetMolekul, vratit.Count + pocatecnyIndex, chciINaindexovane));

            vratit.AddRange(PoleNeznamychDoListu(molarniHmotnost, vratit.Count + pocatecnyIndex, chciINaindexovane));

            vratit.AddRange(PoleNeznamychDoListu(pomocnaSummaMolHmotnosti, vratit.Count + pocatecnyIndex, chciINaindexovane));

            vratit.AddRange(PoleNeznamychDoListu(pomocnaSummaProVypocetmolarnichZlomku, vratit.Count + pocatecnyIndex, chciINaindexovane));
            
            vratit.AddRange(PoleNeznamychDoListu(pomocnyRelativniHmotnostniZlomek, vratit.Count + pocatecnyIndex, chciINaindexovane));

            vratit.AddRange(PoleNeznamychDoListu(pomocnyRelativniMolarniZlomek, vratit.Count + pocatecnyIndex, chciINaindexovane));

            vratit.AddRange(PoleNeznamychDoListu(objemJednotlivychLatek, vratit.Count + pocatecnyIndex, chciINaindexovane));

            vratit.AddRange(PoleNeznamychDoListu(relativniObjemovaKoncentrace, vratit.Count + pocatecnyIndex, chciINaindexovane));

            vratit.AddRange(PoleNeznamychDoListu(pomocnaRelativniObjemovaKoncentrace, vratit.Count + pocatecnyIndex, chciINaindexovane));

            vratit.AddRange(PoleNeznamychDoListu(pomocnyRelativniMolarniZlomek, vratit.Count + pocatecnyIndex, chciINaindexovane));

            vratit.AddRange(PoleNeznamychDoListu(objemovaKoncentrace, vratit.Count + pocatecnyIndex, chciINaindexovane));

            vratit.AddRange(PoleNeznamychDoListu(objemovaKoncentrace, vratit.Count + pocatecnyIndex, chciINaindexovane));

            vratit.AddRange(PoleNeznamychDoListu(hustotaSlozky, vratit.Count + pocatecnyIndex, chciINaindexovane));

            foreach (Neznama[] item in koeficientDoJakehoProudu)
            {
                vratit.AddRange(PoleNeznamychDoListu(item, vratit.Count + pocatecnyIndex, chciINaindexovane));
            }

            foreach (Neznama[] item in pomocnaKoeficientDoProudu)
            {
                vratit.AddRange(PoleNeznamychDoListu(item, vratit.Count + pocatecnyIndex, chciINaindexovane));
            }

            foreach (Neznama[] item in pomocnaLatkoveKoeficientDoProudu)
            {
                vratit.AddRange(PoleNeznamychDoListu(item, vratit.Count + pocatecnyIndex, chciINaindexovane));
            }

            if (plyn)
            {
                teplota.indexVPoli = vratit.Count;
                vratit.Add(teplota);

                tlak.indexVPoli = vratit.Count;
                vratit.Add(tlak);

                vratit.AddRange(PoleNeznamychDoListu(parcialniTlak, vratit.Count + pocatecnyIndex, chciINaindexovane));
            }

            return vratit;
        }

        private List<Neznama> PoleNeznamychDoListu(Neznama[] nezname, int pocatecnyIndex, bool chciInaindexovane)
        {
            List<Neznama> vratit = new List<Neznama>();

            for (int i = 0; i < nezname.Length; i++)
            {
                if (chciInaindexovane)
                {
                    vratit.Add(nezname[i]);
                }
                else if (nezname[i].indexVPoli == -1)
                {
                    nezname[i].indexVPoli = pocatecnyIndex + i;
                    vratit.Add(nezname[i]);
                }
            }

            return vratit;
        }

        public void VnitroProudniRovnice(out List<float[]> linearniRovnice, out List<float> vysledkyLinearni, out List<float[]> nasobiciRovnice, out List<float> vysledkyNasobici)
        {
            linearniRovnice = new List<float[]>();

            vysledkyLinearni = new List<float>();

            nasobiciRovnice = new List<float[]>();

            vysledkyNasobici = new List<float>();

            // E wi = 1
            linearniRovnice.Add(Summa(hmotnostniZlomky));
            vysledkyLinearni.Add(1);

            // M snesi = E (xi * Mi)
            float[] podrzRovnici = Summa(pomocnaSummaMolHmotnosti);
            podrzRovnici[molarniHmotnostSmesi.indexVPoli] = -1;
            linearniRovnice.Add(podrzRovnici);
            vysledkyLinearni.Add(0);

            // E xi = 1
            linearniRovnice.Add(Summa(molarniZlomky));
            vysledkyLinearni.Add(1);

            // E (wi / Mi) = E(wi / Mi)
            podrzRovnici = Summa(pomocnaSummaProVypocetmolarnichZlomku);
            podrzRovnici[pomocnaCelkovaSummaProVypocetmolarnichZlomku.indexVPoli] = -1;
            linearniRovnice.Add(podrzRovnici);
            vysledkyLinearni.Add(0);

            // E mi = m celk
            podrzRovnici = Summa(hmotnostiSlozek);
            podrzRovnici[celkovaHmotnost.indexVPoli] = -1;
            linearniRovnice.Add(podrzRovnici);
            vysledkyLinearni.Add(0);

            // E ni = n celk
            podrzRovnici = Summa(latkoveMnozstvi);
            podrzRovnici[celkemMolu.indexVPoli] = -1;
            linearniRovnice.Add(podrzRovnici);
            vysledkyLinearni.Add(0);

            // ro i = hustota
            podrzRovnici = Summa(hmotnostniKoncentrace);
            podrzRovnici[hustota.indexVPoli] = -1;
            linearniRovnice.Add(podrzRovnici);
            vysledkyLinearni.Add(0);

            // m = hustota * V
            nasobiciRovnice.Add(Rovice(new Neznama[] { celkovaHmotnost, hustota, objem }, new float[] { 1, -1, -1 }));
            vysledkyNasobici.Add(1);

            // m = M * n
            nasobiciRovnice.Add(Rovice(new Neznama[] { celkovaHmotnost, molarniHmotnostSmesi, celkemMolu }, new float[] { 1, -1, -1 }));
            vysledkyNasobici.Add(1);

            // mi = Mi * ni
            for (int i = 0; i < Uzel.slozek; i++)
            {
                nasobiciRovnice.Add(Rovice(new Neznama[] { hmotnostiSlozek[i], molarniHmotnost[i], latkoveMnozstvi[i] }, new float[] { 1, -1, -1 }));
                vysledkyNasobici.Add(1);
            }

            // (wi/Mi) = xi * E (wi/Mi)
            for (int i = 0; i < Uzel.slozek; i++)
            {
                nasobiciRovnice.Add(Rovice(new Neznama[] { pomocnaSummaProVypocetmolarnichZlomku[i], pomocnaCelkovaSummaProVypocetmolarnichZlomku, molarniZlomky[i] }, new float[] { 1, -1, -1 }));
                vysledkyNasobici.Add(1);
            }

            // mi = wi * m celk
            for (int i = 0; i < Uzel.slozek; i++)
            {
                nasobiciRovnice.Add(Rovice(new Neznama[] { hmotnostiSlozek[i], hmotnostniZlomky[i], celkovaHmotnost }, new float[] { 1, -1, -1 }));
                vysledkyNasobici.Add(1);
            }

            // (xi * Mi) = wi * E (xi * Mi)
            for (int i = 0; i < Uzel.slozek; i++)
            {
                nasobiciRovnice.Add(Rovice(new Neznama[] { hmotnostniZlomky[i], pomocnaSummaMolHmotnosti[i], molarniHmotnostSmesi }, new float[] { -1, 1, -1 }));
                vysledkyNasobici.Add(1);
            }

            // (xi * Mi) = xi * Mi
            for (int i = 0; i < Uzel.slozek; i++)
            {
                nasobiciRovnice.Add(Rovice(new Neznama[] { pomocnaSummaMolHmotnosti[i], molarniZlomky[i], molarniHmotnost[i] }, new float[] { 1, -1, -1 }));
                vysledkyNasobici.Add(1);
            }

            // mi = ro i * V
            for (int i = 0; i < Uzel.slozek; i++)
            {
                nasobiciRovnice.Add(Rovice(new Neznama[] { hmotnostniKoncentrace[i], hmotnostiSlozek[i], objem }, new float[] { -1, 1, -1 }));
                vysledkyNasobici.Add(1);
            }

            // ni = ci * V
            for (int i = 0; i < Uzel.slozek; i++)
            {
                nasobiciRovnice.Add(Rovice(new Neznama[] { molarniKoncentrace[i], latkoveMnozstvi[i], objem }, new float[] { -1, 1, -1 }));
                vysledkyNasobici.Add(1);
            }

            // ci * Mi = wi * hustota
            for (int i = 0; i < Uzel.slozek; i++)
            {
                nasobiciRovnice.Add(Rovice(new Neznama[] { molarniKoncentrace[i], molarniHmotnost[i], hustota, hmotnostniZlomky[i] }, new float[] { 1, 1, -1, -1 }));
                vysledkyNasobici.Add(1);
            }

            // (m - mi) = m - mi
            for (int i = 0; i < Uzel.slozek; i++)
            {
                linearniRovnice.Add(Rovice(new Neznama[] { celkovaHmotnost, pomocnyRelativniHmotnostniZlomek[i], hmotnostiSlozek[i] }, new float[] { 1, -1, -1 }));
                vysledkyLinearni.Add(0);
            }

            // (m - mi) * W i = mi
            for (int i = 0; i < Uzel.slozek; i++)
            {
                nasobiciRovnice.Add(Rovice(new Neznama[] { hmotnostiSlozek[i], pomocnyRelativniHmotnostniZlomek[i], relativnihmotnostniZlomky[i] }, new float[] { 1, -1, -1 }));
                vysledkyNasobici.Add(1);
            }

            // (n - ni) = n - ni
            for (int i = 0; i < Uzel.slozek; i++)
            {
                linearniRovnice.Add(Rovice(new Neznama[] { celkemMolu, pomocnyRelativniMolarniZlomek[i], latkoveMnozstvi[i] }, new float[] { 1, -1, -1 }));
                vysledkyLinearni.Add(0);
            }

            // (n - ni) * X i = ni
            for (int i = 0; i < Uzel.slozek; i++)
            {
                nasobiciRovnice.Add(Rovice(new Neznama[] { latkoveMnozstvi[i], pomocnyRelativniMolarniZlomek[i], relativniMolarniZlomky[i] }, new float[] { 1, -1, -1 }));
                vysledkyNasobici.Add(1);
            }

            // (V - V i) = V - V i
            for (int i = 0; i < Uzel.slozek; i++)
            {
                linearniRovnice.Add(Rovice(new Neznama[] { objem, pomocnaRelativniObjemovaKoncentrace[i], objemJednotlivychLatek[i] }, new float[] { 1, -1, -1 }));
                vysledkyLinearni.Add(0);
            }

            // V * vol i = V i
            for (int i = 0; i < Uzel.slozek; i++)
            {
                nasobiciRovnice.Add(Rovice(new Neznama[] { objemJednotlivychLatek[i], objem, objemovaKoncentrace[i] }, new float[] { 1, -1, -1 }));
                vysledkyNasobici.Add(1);
            }

            // (V - V i) * Vol i = V i
            for (int i = 0; i < Uzel.slozek; i++)
            {
                nasobiciRovnice.Add(Rovice(new Neznama[] { objemJednotlivychLatek[i], pomocnaRelativniObjemovaKoncentrace[i], relativniObjemovaKoncentrace[i] }, new float[] { 1, -1, -1 }));
                vysledkyNasobici.Add(1);
            }

            // (V - V i) * Vol i = V i
            for (int i = 0; i < Uzel.slozek; i++)
            {
                nasobiciRovnice.Add(Rovice(new Neznama[] { objemJednotlivychLatek[i], pomocnaRelativniObjemovaKoncentrace[i], relativniObjemovaKoncentrace[i] }, new float[] { 1, -1, -1 }));
                vysledkyNasobici.Add(1);
            }

            // Vi * ro i = mi
            for (int i = 0; i < Uzel.slozek; i++)
            {
                nasobiciRovnice.Add(Rovice(new Neznama[] { objemJednotlivychLatek[i], hustotaSlozky[i], hmotnostiSlozek[i] }, new float[] { 1, 1, -1 }));
                vysledkyNasobici.Add(1);
            }

            if (plyn)
            {
                // p * V = R * T * n
                nasobiciRovnice.Add(Rovice(new Neznama[] { tlak, objem, teplota, celkemMolu }, new float[] { 1, 1, -1, -1 }));
                vysledkyNasobici.Add(plynovaKonstanta);

                //pi * V = R * T * ni
                for (int i = 0; i < Uzel.slozek; i++)
                {
                    nasobiciRovnice.Add(Rovice(new Neznama[] { parcialniTlak[i], objem, teplota, latkoveMnozstvi[i] }, new float[] { 1, 1, -1, -1 }));
                    vysledkyNasobici.Add(plynovaKonstanta);
                }

                // p * Vi = R * T * ni
                for (int i = 0; i < Uzel.slozek; i++)
                {
                    nasobiciRovnice.Add(Rovice(new Neznama[] { tlak, objemJednotlivychLatek[i], teplota, latkoveMnozstvi[i] }, new float[] { 1, 1, -1, -1 }));
                    vysledkyNasobici.Add(plynovaKonstanta);
                }

                // V = E Vi
                podrzRovnici = Summa(objemJednotlivychLatek);
                podrzRovnici[objem.indexVPoli] = -1;
                linearniRovnice.Add(podrzRovnici);
                vysledkyLinearni.Add(0);

                // ro i = xi
                for (int i = 0; i < Uzel.slozek; i++)
                {
                    linearniRovnice.Add(Rovice(new Neznama[] { objemovaKoncentrace[i], molarniZlomky[i] }, new float[] { 1, -1 }));
                    vysledkyLinearni.Add(0);
                }

                // p i = xi * p
                for (int i = 0; i < Uzel.slozek; i++)
                {
                    nasobiciRovnice.Add(Rovice(new Neznama[] { parcialniTlak[i], molarniZlomky[i], tlak }, new float[] { 1, -1, -1 }));
                    vysledkyNasobici.Add(1);
                }
            }
        }

        public static float[] Summa(Neznama[] summa)
        {
            float[] rovnice = new float[ReseniSoustavyRovnic.nezname.Length];

            foreach (Neznama item in summa)
            {
                rovnice[item.indexVPoli] = 1;
            }

            return rovnice;
        }

        public static float[] Summa(Neznama[] summa, float koeficient)
        {
            float[] rovnice = new float[ReseniSoustavyRovnic.nezname.Length];

            foreach (Neznama item in summa)
            {
                rovnice[item.indexVPoli] = koeficient;
            }

            return rovnice;
        }
        
        public static float[] SloucitRovnice(float[][] rovnice)
        {
            float[] vyslednarovnice = new float[rovnice[0].Length]; 

            for (int i = 0; i < rovnice.Length; i++)
            {
                for (int j = 0; j < rovnice[i].Length; j++)
                {
                    vyslednarovnice[j] += rovnice[i][j];
                }
            }

            return vyslednarovnice;
        }

        public static float[] Rovice(Neznama[] dosazovat, float[] koeficienty)
        {
            float[] rovnice = new float[ReseniSoustavyRovnic.nezname.Length];

            for (int i = 0; i < dosazovat.Length; i++)
            {
                rovnice[dosazovat[i].indexVPoli] = koeficienty[i];
            }

            return rovnice;
        }

        public static float[] Rovice()
        {
            float[] rovnice = new float[ReseniSoustavyRovnic.nezname.Length];

            return rovnice;
        }

        private static Neznama[] ZmenitDelku(Neznama[] puvodni, int novaDelka)
        {
            Neznama[] vratit = new Neznama[novaDelka];

            for (int i = 0; i < novaDelka; i++)
            {
                if (i < puvodni.Length)
                {
                    vratit[i] = puvodni[i];
                }
                else
                {
                    vratit[i] = new Neznama(vratit[i - 1].max, vratit[i - 1].min, vratit[i - 1].jmeno, vratit[i - 1].jednotka, vratit[i - 1].indexProudu, i + 1);
                }
            }

            return vratit;
        }

        private static Neznama[][] ZmenitDelkuProudu(Neznama[][] puvodni, int slozek, int proudy)
        {
            Neznama[][] vratit = new Neznama[slozek][];
            for (int i = 0; i < slozek; i++)
            {
                vratit[i] = new Neznama[proudy];
                if (i < puvodni.Length)
                {
                    for (int j = 0; j < proudy; j++)
                    {
                        if (j < puvodni[i].Length)
                        {
                            vratit[i][j] = puvodni[i][j];
                        }
                        else
                        {
                            vratit[i][j] = new Neznama(vratit[i][j - 1].max, vratit[i][j - 1].min, vratit[i][j - 1].jmeno, vratit[i][j - 1].jednotka, vratit[i][j - 1].indexProudu, i + 1);
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < proudy; j++)
                    {
                        vratit[i][j] = new Neznama(vratit[i - 1][j].max, vratit[i - 1][j].min, vratit[i - 1][j].jmeno, vratit[i - 1][j].jednotka, vratit[i - 1][j].indexProudu, i + 1);
                    }
                }
            }

            return vratit;
        }

        public void Rozsirit(int slozek, int protiproudu)
        {
            hmotnostiSlozek = ZmenitDelku(hmotnostiSlozek, slozek);

            relativnihmotnostniZlomky = ZmenitDelku(relativnihmotnostniZlomky, slozek);

            hmotnostniZlomky = ZmenitDelku(hmotnostniZlomky, slozek);

            molarniZlomky = ZmenitDelku(molarniZlomky, slozek);

            relativnihmotnostniZlomky = ZmenitDelku(relativnihmotnostniZlomky, slozek);

            molarniKoncentrace = ZmenitDelku(molarniKoncentrace, slozek);

            hmotnostniKoncentrace = ZmenitDelku(hmotnostniKoncentrace, slozek);

            latkoveMnozstvi = ZmenitDelku(latkoveMnozstvi, slozek);

            pocetMolekul = ZmenitDelku(pocetMolekul, slozek);
            
            molarniHmotnost = ZmenitDelku(molarniHmotnost, slozek);

            koeficientDoJakehoProudu = ZmenitDelkuProudu(koeficientDoJakehoProudu, slozek, protiproudu);

            pomocnaKoeficientDoProudu = ZmenitDelkuProudu(pomocnaKoeficientDoProudu, slozek, protiproudu);

            relativniMolarniZlomky = ZmenitDelku(relativniMolarniZlomky, slozek);

            objemJednotlivychLatek = ZmenitDelku(objemJednotlivychLatek, slozek);

            relativniObjemovaKoncentrace = ZmenitDelku(relativniObjemovaKoncentrace, slozek);

            objemovaKoncentrace = ZmenitDelku(objemovaKoncentrace, slozek);

            pomocnaSummaMolHmotnosti = ZmenitDelku(pomocnaSummaMolHmotnosti, slozek);

            pomocnaSummaProVypocetmolarnichZlomku = ZmenitDelku(pomocnaSummaProVypocetmolarnichZlomku, slozek);

            pomocnyRelativniHmotnostniZlomek = ZmenitDelku(pomocnyRelativniHmotnostniZlomek, slozek);

            pomocnyRelativniMolarniZlomek = ZmenitDelku(pomocnyRelativniMolarniZlomek, slozek);

            pomocnaRelativniObjemovaKoncentrace = ZmenitDelku(pomocnaRelativniObjemovaKoncentrace, slozek);

            parcialniTlak = ZmenitDelku(parcialniTlak, slozek);

            hustotaSlozky = ZmenitDelku(hustotaSlozky, slozek);
        }
    }
}
