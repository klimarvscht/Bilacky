using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilancniVypocty
{
    class Uzel
    {
        public static char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray(); // abeceda

        public static Uzel uzel; // zde drží odkaz na jedinou instanci

        public static List<Proud> celkemProudu = new List<Proud>(); // zde jsou drženy všechny proudy

        public List<Proud> vztupniProudy = new List<Proud>(); // vztupní proudy uzle
        public List<Proud> vystupniProudy = new List<Proud>(); // vystupní proudy uzle
        public static int slozek;

        public Uzel(int vztupneProudy, int vystupneProudy)
        {
            uzel = this;

            vztupniProudy = NastavProudy(vztupneProudy, celkemProudu.Count);
            celkemProudu.AddRange(vztupniProudy);

            vystupniProudy = NastavProudy(vystupneProudy, celkemProudu.Count);
            celkemProudu.AddRange(vystupniProudy);

            foreach (Proud item in vystupniProudy)
            {
                item.NastavNezname(slozek, vztupneProudy);
            }

            foreach (Proud item in this.vztupniProudy)
            {
                item.NastavNezname(slozek, vystupneProudy);
            }
        }

        private List<Proud> NastavProudy(int pocet, int pocatecniIndex) // inicializuje proudy a vrátí je
        {
            Proud[] proudy = new Proud[pocet];
            for (int i = 0; i < pocet; i++)
            {
                proudy[i] = new Proud(i + pocatecniIndex);
            }
            return proudy.ToList();
        }

        public void ExtrahujNezname() // extrahuje neznámé z proudů a uloží je do pole
        {
            List<Neznama> nezname = new List<Neznama>();

            foreach (Proud item in vztupniProudy)
            {
                nezname.AddRange(item.NeznameDoListu(nezname.Count, false));
            }

            foreach (Proud item in vystupniProudy)
            {
                nezname.AddRange(item.NeznameDoListu(nezname.Count, false));
            }

            ReseniSoustavyRovnic.nezname = nezname.ToArray();
        }

        public void ExtrahujRovnice() // extrahuje rovnice z proudů i rovnice mezi jednotlivými proudy
        {
            List<float[]> linearniMatice = new List<float[]>(), nasobiciMatice = new List<float[]>();
            List<float> rovnaseLinearni = new List<float>(), rovnaseNasobici = new List<float>();

            List<float[]> linearniRovnice, nasobiciRovnice;
            List<float> vysledkyLinearni, vysledkyNasobici;

            foreach (Proud item in vztupniProudy)
            {
                item.VnitroProudniRovnice(out linearniRovnice, out vysledkyLinearni, out nasobiciRovnice, out vysledkyNasobici);
                linearniMatice.AddRange(linearniRovnice);
                nasobiciMatice.AddRange(nasobiciRovnice);
                rovnaseLinearni.AddRange(vysledkyLinearni);
                rovnaseNasobici.AddRange(vysledkyNasobici);
            }
            foreach (Proud item in vystupniProudy)
            {
                item.VnitroProudniRovnice(out linearniRovnice, out vysledkyLinearni, out nasobiciRovnice, out vysledkyNasobici);
                linearniMatice.AddRange(linearniRovnice);
                nasobiciMatice.AddRange(nasobiciRovnice);
                rovnaseLinearni.AddRange(vysledkyLinearni);
                rovnaseNasobici.AddRange(vysledkyNasobici);
            }
            

            CelkoveBilance(out linearniRovnice, out vysledkyLinearni, out nasobiciRovnice, out vysledkyNasobici);
            linearniMatice.AddRange(linearniRovnice);
            nasobiciMatice.AddRange(nasobiciRovnice);
            rovnaseLinearni.AddRange(vysledkyLinearni);
            rovnaseNasobici.AddRange(vysledkyNasobici);

            ReseniSoustavyRovnic.linearniMatice = linearniMatice.ToArray();
            ReseniSoustavyRovnic.nasobiciMatice = nasobiciMatice.ToArray();
            ReseniSoustavyRovnic.vysledkyLinearni = rovnaseLinearni.ToArray();
            ReseniSoustavyRovnic.vysledkyNasobici = rovnaseNasobici.ToArray();
        }

        private void CelkoveBilance(out List<float[]> linearniRovnice, out List<float> vysledkyLinearni, out List<float[]> nasobiciRovnice, out List<float> vysledkyNasobici) // rovnice mezi jednotlivými proudy (celkové bilance)
        {
            linearniRovnice = new List<float[]>();
            nasobiciRovnice = new List<float[]>();
            vysledkyLinearni = new List<float>();
            vysledkyNasobici = new List<float>();

            float[] podrzRovnici = Proud.Rovice();

            // celková bilance hmotností
            foreach (Proud item in vztupniProudy)
            {
                podrzRovnici[item.celkovaHmotnost.indexVPoli] = 1;
            }

            foreach (Proud item in vystupniProudy)
            {
                podrzRovnici[item.celkovaHmotnost.indexVPoli] = -1;
            }

            linearniRovnice.Add(podrzRovnici);
            vysledkyLinearni.Add(0);

            // hmotnostní bilance jednotlivých složek
            for (int i = 0; i < slozek; i++)
            {
                podrzRovnici = Proud.Rovice();
                foreach (Proud item in vztupniProudy)
                {
                    podrzRovnici[item.hmotnostiSlozek[i].indexVPoli] = 1;
                }

                foreach (Proud item in vystupniProudy)
                {
                    podrzRovnici[item.hmotnostiSlozek[i].indexVPoli] = -1;
                }

                linearniRovnice.Add(podrzRovnici);
                vysledkyLinearni.Add(0);
            }

            // celková bilance látkového množství
            podrzRovnici = Proud.Rovice();
            foreach (Proud item in vztupniProudy)
            {
                podrzRovnici[item.celkemMolu.indexVPoli] = 1;
            }

            foreach (Proud item in vystupniProudy)
            {
                podrzRovnici[item.celkemMolu.indexVPoli] = -1;
            }

            linearniRovnice.Add(podrzRovnici);
            vysledkyLinearni.Add(0);

            // bilance látkového množství jedlotlivých složek
            for (int i = 0; i < slozek; i++)
            {
                podrzRovnici = Proud.Rovice();
                foreach (Proud item in vztupniProudy)
                {
                    podrzRovnici[item.latkoveMnozstvi[i].indexVPoli] = 1;
                }

                foreach (Proud item in vystupniProudy)
                {
                    podrzRovnici[item.latkoveMnozstvi[i].indexVPoli] = -1;
                }

                linearniRovnice.Add(podrzRovnici);
                vysledkyLinearni.Add(0);
            }

            // ámen
            for (int i = 0; i < slozek; i++)
            {
                NastavRovniceDoProudu(i, vztupniProudy, vystupniProudy, linearniRovnice, vysledkyLinearni, nasobiciRovnice, vysledkyNasobici);

                NastavRovniceDoProudu(i, vystupniProudy, vztupniProudy, linearniRovnice, vysledkyLinearni, nasobiciRovnice, vysledkyNasobici);
            }
        }

        private void NastavRovniceDoProudu(int slozka, List<Proud> zProudu, List<Proud> doProudu, List<float[]> linearniRovnice,  List<float> vysledkyLinearni,  List<float[]> nasobiciRovnice,  List<float> vysledkyNasobici) // rovnice obsahující doProudu
        {
            float[] podrzRovnici = Proud.Rovice();
            for (int j = 0; j < doProudu.Count; j++)
            {
                // týkající se hmotností
                podrzRovnici = Proud.Rovice();
                foreach (Proud item in zProudu)
                {
                    podrzRovnici = Proud.Rovice();
                    podrzRovnici[item.koeficientDoJakehoProudu[slozka][j].indexVPoli] = 1;

                    podrzRovnici[item.hmotnostiSlozek[slozka].indexVPoli] = 1;

                    podrzRovnici[item.pomocnaKoeficientDoProudu[slozka][j].indexVPoli] = -1;

                    nasobiciRovnice.Add(podrzRovnici);
                    vysledkyNasobici.Add(1);
                }

                podrzRovnici = Proud.Rovice();

                foreach (Proud item in zProudu)
                {
                    podrzRovnici[item.pomocnaKoeficientDoProudu[slozka][j].indexVPoli] = 1;
                }

                podrzRovnici[doProudu[j].hmotnostiSlozek[slozka].indexVPoli] = -1;

                linearniRovnice.Add(podrzRovnici);
                vysledkyLinearni.Add(0);

                // týkající se látkového množství
                podrzRovnici = Proud.Rovice();
                foreach (Proud item in zProudu)
                {
                    podrzRovnici = Proud.Rovice();
                    podrzRovnici[item.koeficientDoJakehoProudu[slozka][j].indexVPoli] = 1;

                    podrzRovnici[item.latkoveMnozstvi[slozka].indexVPoli] = 1;

                    podrzRovnici[item.pomocnaLatkoveKoeficientDoProudu[slozka][j].indexVPoli] = -1;

                    nasobiciRovnice.Add(podrzRovnici);
                    vysledkyNasobici.Add(1);
                }

                podrzRovnici = Proud.Rovice();

                foreach (Proud item in zProudu)
                {
                    podrzRovnici[item.pomocnaLatkoveKoeficientDoProudu[slozka][j].indexVPoli] = 1;
                }

                podrzRovnici[doProudu[j].hmotnostiSlozek[slozka].indexVPoli] = -1;

                linearniRovnice.Add(podrzRovnici);
                vysledkyLinearni.Add(0);
            }
        }

        private List<Proud> Rozsirit(List<Proud> proudy, int novaDelka, int delkaDruheStrany) // nastaví délku pole proudů na chtěnou délku
        {
            if (proudy.Count > novaDelka)
            {
                int delka = proudy.Count;
                for (int i = delka; i > novaDelka; i--)
                {
                    celkemProudu[proudy[i - 1].indexProudu] = null; // nutno odstranit i z celkového seznamu proudů
                    proudy.RemoveAt(i - 1);
                }
                proudy.RemoveRange(novaDelka, proudy.Count - novaDelka);
            }
            else
            {
                for (int i = proudy.Count; i < novaDelka; i++)
                {
                    proudy.Add(new Proud(celkemProudu.Count));
                    celkemProudu.Add(proudy[proudy.Count - 1]);
                }
            }
            return proudy;
        }

        public void RozsirProudy(int slozek, int vztup, int vyztup) // nastaví délky polí na novou délku podle nastavení
        {
            int puvodniVztup = vztupniProudy.Count;
            int puvodniVystup = vystupniProudy.Count;

            vystupniProudy = Rozsirit(vystupniProudy, vyztup, vztup);

            vztupniProudy = Rozsirit(vztupniProudy, vztup, vyztup);
            // nadefinuj nové
            for (int i = puvodniVystup; i < vystupniProudy.Count; i++)
            {
                vystupniProudy[i].NastavNezname(slozek, vztupniProudy.Count);
            }

            for (int i = puvodniVztup; i < vztupniProudy.Count; i++)
            {
                vztupniProudy[i].NastavNezname(slozek, vystupniProudy.Count);
            }

            // předefinuj staré
            for (int i = 0; i < puvodniVystup; i++)
            {
                vystupniProudy[i].Rozsirit(slozek, vztup);
            }

            for (int i = 0; i < puvodniVztup; i++)
            {
                vztupniProudy[i].Rozsirit(slozek, vyztup);
            }
        }

        public static void PrenastavProudIndexy() // nastaví odpovídající index v poli proudů
        {
            for (int i = 0; i < celkemProudu.Count; i++)
            {
                if (celkemProudu[i] == null)
                {
                    celkemProudu.RemoveAt(i);
                }
                else
                {
                    celkemProudu[i].indexProudu = i;
                }
            }
        }
    }
}
