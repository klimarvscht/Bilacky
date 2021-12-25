using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilancniVypocty
{
    class Uzel
    {
        public static char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        public static Uzel uzel;

        public static List<Proud> celkemProudu = new List<Proud>();

        public List<Proud> vztupniProudy = new List<Proud>();
        public List<Proud> vystupniProudy = new List<Proud>();
        public static int slozek;

        public Uzel(int vztupneProudy, int vystupneProudy)
        {
            vztupniProudy = NastavProudy(vztupneProudy, vystupneProudy, celkemProudu.Count);
            celkemProudu.AddRange(vztupniProudy);

            vystupniProudy = NastavProudy(vystupneProudy, vztupneProudy, celkemProudu.Count);
            celkemProudu.AddRange(vystupniProudy);

            uzel = this;
        }

        private List<Proud> NastavProudy(int pocet, int pocetNaDruheStrane, int pocatecniIndex)
        {
            Proud[] proudy = new Proud[pocet];
            for (int i = 0; i < pocet; i++)
            {
                proudy[i] = new Proud(slozek, pocetNaDruheStrane, i + pocatecniIndex);
            }
            return proudy.ToList();
        }

        public void ExtrahujNezname()
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

        public void ExtrahujRovnice()
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

        private void CelkoveBilance(out List<float[]> linearniRovnice, out List<float> vysledkyLinearni, out List<float[]> nasobiciRovnice, out List<float> vysledkyNasobici)
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

        private void NastavRovniceDoProudu(int slozka, List<Proud> zProudu, List<Proud> doProudu, List<float[]> linearniRovnice,  List<float> vysledkyLinearni,  List<float[]> nasobiciRovnice,  List<float> vysledkyNasobici)
        {
            float[] podrzRovnici = Proud.Rovice();
            for (int j = 0; j < doProudu.Count; j++)
            {
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

        private List<Proud> Rozsirit(List<Proud> proudy, int novaDelka, int delkaDruheStrany)
        {
            if (proudy.Count > novaDelka)
            {
                int delka = proudy.Count;
                for (int i = delka; i > novaDelka; i--)
                {
                    celkemProudu[proudy[i - 1].indexProudu] = null;
                    proudy.RemoveAt(i - 1);
                }
                proudy.RemoveRange(novaDelka, proudy.Count - novaDelka);
            }
            else
            {
                for (int i = proudy.Count; i < novaDelka; i++)
                {
                    proudy.Add(new Proud(slozek, delkaDruheStrany, celkemProudu.Count));
                    celkemProudu.Add(proudy[proudy.Count - 1]);
                }
            }
            return proudy;
        }

        public void RozsirProudy(int slozek, int vztup, int vyztup)
        {
            foreach (Proud item in vystupniProudy)
            {
                item.Rozsirit(slozek, vztup);
            }

            foreach (Proud item in vztupniProudy)
            {
                item.Rozsirit(slozek, vyztup);
            }

            vystupniProudy = Rozsirit(vystupniProudy, vyztup, vztup);

            vztupniProudy = Rozsirit(vztupniProudy, vztup, vyztup);
        }
    }
}
