using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilancniVypocty
{
    static class ReseniSoustavyRovnic
    {
        public static Neznama[] nezname;
        public static float[][] linearniMatice;
        public static float[][] nasobiciMatice;
        public static float[] vysledkyLinearni;
        public static float[] vysledkyNasobici;

        public static void UpravaLinearniRovnice()
        {
            int skipnuto = 0;

            for (int i = 0; i < linearniMatice[0].Length && i < linearniMatice.Length + skipnuto - 1; i++)
            {
                int radek = VhodnySloupec(linearniMatice, i, i - skipnuto, 0);

                if (radek == -1)
                {
                    skipnuto++;
                    continue;
                }

                if (i - skipnuto != radek)
                {
                    
                    float[] podrzRovnici = linearniMatice[i - skipnuto];
                    linearniMatice[i - skipnuto] = linearniMatice[radek];
                    linearniMatice[radek] = podrzRovnici;
                    
                    float podrzVysledek = vysledkyLinearni[radek];
                    vysledkyLinearni[radek] = vysledkyLinearni[i - skipnuto];
                    vysledkyLinearni[i - skipnuto] = podrzVysledek;
                }

                if (linearniMatice[i - skipnuto][i] == 0)
                {
                    Console.WriteLine();
                }

                
                for (int j = 0; j < linearniMatice.Length; j++)
                {
                    if (j == i - skipnuto)
                    {
                        continue;
                    }
                    
                    float koeficient = linearniMatice[j][i] / linearniMatice[i - skipnuto][i];

                    vysledkyLinearni[j] -= vysledkyLinearni[i - skipnuto] * koeficient;

                    for (int k = i + 1; k < linearniMatice[j].Length; k++)
                    {
                        linearniMatice[j][k] -= linearniMatice[i - skipnuto][k] * koeficient;
                    }
                    linearniMatice[j][i] = 0;
                }

                float[][] pomoc = linearniMatice;
                Console.WriteLine();
            }
        }

        public static bool ExthrahujHodnotyLinearni()
        {
            bool upraveno = false;

            bool necoSeStalo;
            do
            {
                necoSeStalo = false;
                for (int i = 0; i < linearniMatice.Length; i++)
                {
                    int posledniNeznama;
                    if (NeznamychVRovnici(linearniMatice[i], out posledniNeznama) == 1)
                    {
                        nezname[posledniNeznama].value = vysledkyLinearni[i] / linearniMatice[i][posledniNeznama];
                        nezname[posledniNeznama].known = true;

                        vysledkyLinearni[i] = 0;
                        linearniMatice[i][posledniNeznama] = 0;

                        DosazeniNeznameLinearni(posledniNeznama);

                        upraveno = true;
                        necoSeStalo = true;
                    }
                }


            } while (necoSeStalo);

            return upraveno;
        }

        public static void PredPripravLinearni()
        {
            for (int i = 0; i < nezname.Length; i++)
            {
                if (nezname[i].known)
                {
                    DosazeniNeznameLinearni(i);

                    Console.WriteLine("nefachám");
                }
            }
        }

        private static void DosazeniNeznameLinearni(int indexDosayovaneho)
        {
            for (int j = 0; j < linearniMatice.Length; j++)
            {
                vysledkyLinearni[j] -= nezname[indexDosayovaneho].value * linearniMatice[j][indexDosayovaneho];
                linearniMatice[j][indexDosayovaneho] = 0;
            }
        }

        public static void UpravaNasobneRovnice()
        {
            int skipnuto = 0;

            int rovnaSeNula = 0;

            for (int i = 0; i < nasobiciMatice[0].Length && i < nasobiciMatice.Length + skipnuto - rovnaSeNula; i++)
            {
                int radek = VhodnySloupec(nasobiciMatice, i, i - skipnuto, rovnaSeNula);

                if (radek == -1)
                {
                    skipnuto++;
                    continue;
                }

                if (vysledkyNasobici[radek] == 0)
                {
                    float[] podrzRovnici = nasobiciMatice[nasobiciMatice.Length - 1];
                    nasobiciMatice[nasobiciMatice.Length - 1] = nasobiciMatice[radek];
                    nasobiciMatice[radek] = podrzRovnici;

                    float podrzVysledek = vysledkyNasobici[radek];
                    vysledkyNasobici[radek] = vysledkyNasobici[nasobiciMatice.Length - 1];
                    vysledkyNasobici[nasobiciMatice.Length - 1] = podrzVysledek;

                    rovnaSeNula++;
                    i--;
                    continue;
                }
                else if (i - skipnuto != radek)
                {
                    float[] podrzRovnici = nasobiciMatice[i - skipnuto];
                    nasobiciMatice[i - skipnuto] = nasobiciMatice[radek];
                    nasobiciMatice[radek] = podrzRovnici;

                    float podrzVysledek = vysledkyNasobici[radek];
                    vysledkyNasobici[radek] = vysledkyNasobici[i - skipnuto];
                    vysledkyNasobici[i - skipnuto] = podrzVysledek;
                }

                for (int j = i - skipnuto + 1; j < nasobiciMatice.Length; j++)
                {
                   float koeficient = nasobiciMatice[j][i] / nasobiciMatice[i - skipnuto][i];
                   
                   vysledkyNasobici[j] = vysledkyNasobici[j] / (float)Math.Pow(vysledkyNasobici[i - skipnuto], koeficient);
                   for (int k = i + 1; k < nasobiciMatice[j].Length; k++)
                   {
                       nasobiciMatice[j][k] -= nasobiciMatice[i - skipnuto][k] * koeficient;
                   }
                   nasobiciMatice[j][i] = 0;
                }

                for (int k = 1; k <= rovnaSeNula; k++)
                {
                    VyhazejZaporneHodnotyZNasobiciRovnice(nasobiciMatice.Length - k);
                }
            }
        }

        public static bool ExtrahujHodnotyNasobiciRovnice()
        {
            bool upraveno = false;

            bool necoSeStalo;
            do
            {
                necoSeStalo = false;
                for (int i = 0; i < nasobiciMatice.Length; i++)
                {
                    int posledniNeznama;
                    if (NeznamychVRovnici(nasobiciMatice[i], out posledniNeznama) == 1)
                    {
                        if (vysledkyNasobici[i] == 0)
                        {

                        }
                        else
                        {
                            nezname[posledniNeznama].value = (float)Math.Pow(vysledkyNasobici[i], 1 / nasobiciMatice[i][posledniNeznama]);
                        }
                        nezname[posledniNeznama].known = true;

                        vysledkyNasobici[i] = 0;
                        nasobiciMatice[i][posledniNeznama] = 0;

                        DosazeniNeznameNasobici(posledniNeznama);

                        //VypisMatici(nasobiciMatice, vysledkyNasobici);
                        //VypisNezname();

                        upraveno = true;
                        necoSeStalo = true;
                    }
                }

                Console.WriteLine("While true");
            } while (necoSeStalo);

            return upraveno;
        }

        public static void PredPripravNasobici()
        {
            for (int i = 0; i < nezname.Length; i++)
            {
                if (nezname[i].known)
                {
                    DosazeniNeznameNasobici(i);
                }
            }
        }

        public static void DosazeniNeznameNasobici(int indexDosayovaneho)
        {
            for (int j = 0; j < nasobiciMatice.Length; j++)
            {
                if (nasobiciMatice[j][indexDosayovaneho] == 0)
                {
                    continue;
                }
                if (nezname[indexDosayovaneho].value == 0)
                {
                    if (nasobiciMatice[j][indexDosayovaneho] > 0)
                    {
                        for (int i = 0; i < nasobiciMatice[j].Length; i++)
                        {
                            nasobiciMatice[j][i] = -nasobiciMatice[j][i];
                        }
                    }
                    VyhazejZaporneHodnotyZNasobiciRovnice(j);
                    vysledkyNasobici[j] = 0;
                }
                else
                {
                    vysledkyNasobici[j] = vysledkyNasobici[j] / (float)Math.Pow(nezname[indexDosayovaneho].value, nasobiciMatice[j][indexDosayovaneho]);
                }
                nasobiciMatice[j][indexDosayovaneho] = 0;
            }
        }

        private static int VhodnySloupec(float[][] matice, int sloupec, int pocatecniRadek, int vynechatRadku)
        {
            for (int i = pocatecniRadek; i < matice.Length - vynechatRadku; i++)
            {
                if (matice[i][sloupec] != 0)
                {
                    return i;
                }
            }

            return -1;
        }

        private static int NeznamychVRovnici(float[] rovnice, out int indexPosledniNezname)
        {
            int neznamych = 0;
            indexPosledniNezname = -1;
            for (int i = 0; i < rovnice.Length; i++)
            {
                if (rovnice[i] != 0)
                {
                    neznamych++;
                    indexPosledniNezname = i;
                }
            }
            return neznamych;
        }

        private static void VyhazejZaporneHodnotyZNasobiciRovnice(int indexRovnice)
        {
            for (int j = 0; j < nasobiciMatice[indexRovnice].Length; j++)
            {
                if (nasobiciMatice[indexRovnice][j] < 0)
                {
                    nasobiciMatice[indexRovnice][j] = 0;
                }
            }
        }

        public static void VypisMatici(float[][] matice, float[] hodnoty)
        {
            Console.WriteLine();
            for (int i = 0; i < matice.Length; i++)
            {
                for (int j = 0; j < matice[i].Length; j++)
                {
                    Console.Write(matice[i][j] + "; ");
                }
                Console.WriteLine("= " + hodnoty[i]);
            }

            Console.WriteLine();
        }

        public static void VypisNezname()
        {
            Console.WriteLine();
            for (int i = 0; i < nezname.Length; i++)
            {
                Console.WriteLine(nezname[i].jmeno + " = " + nezname[i].value);
            }
        }

        public static void RESET()
        {
            foreach (Neznama item in nezname)
            {
                item.indexVPoli = -1;
            }

            nezname = null;

            linearniMatice = null;
            nasobiciMatice = null;
            vysledkyLinearni = null;
            vysledkyNasobici = null;
        }
    }
}
