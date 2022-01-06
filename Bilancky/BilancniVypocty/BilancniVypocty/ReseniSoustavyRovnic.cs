using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilancniVypocty
{
    static class ReseniSoustavyRovnic
    {
        public static Neznama[] nezname; // seznam všech neznámých
        public static float[][] linearniMatice; // lineární rovnice (koeficienty)
        public static float[][] nasobiciMatice; // rovnice násobící (exponenty)
        public static float[] vysledkyLinearni; // konstanty
        public static float[] vysledkyNasobici; // konstaty

        public static bool UpravaLinearniRovnice() // gausova eliminace; vrací, jestli něco zjistila
        {
            int skipnuto = 0; // počítá kolik neznámých se v rovnících vůbec nevyskytuje (vyruší se nebo jsou už známy)

            bool staloSeNeco = false; // kontroluje jestli se něco zjistilo

            for (int i = 0; i < linearniMatice[0].Length && i < linearniMatice.Length + skipnuto - 1; i++) // jede dokud nedojdou rovnice nebo neznámé i udává index neznámé
            {
                staloSeNeco = ExthrahujHodnotyLinearni() || staloSeNeco; // zkusí něco získat z dané úpravy?
                int radek = VhodnySloupec(linearniMatice, i, i - skipnuto, 0); // zjistí nenulový koeficient u určité neznámé

                if (radek == -1) // pokud všechny neznámé mají koeficient 0
                {
                    skipnuto++;
                    continue;
                }

                if (i - skipnuto != radek) // poku není aktuální rovnice rovnice, kterou chci využít
                {
                    // vymění aktuální rovnici za vybranou rovnici
                    float[] podrzRovnici = linearniMatice[i - skipnuto];
                    linearniMatice[i - skipnuto] = linearniMatice[radek];
                    linearniMatice[radek] = podrzRovnici;
                    
                    float podrzVysledek = vysledkyLinearni[radek];
                    vysledkyLinearni[radek] = vysledkyLinearni[i - skipnuto];
                    vysledkyLinearni[i - skipnuto] = podrzVysledek;
                }
                
                for (int j = 0; j < linearniMatice.Length; j++) // projedu všechny rovnice
                {
                    if (j == i - skipnuto) // nechci odečítat tuto rovnici od této rovnice jelikož by mi vyšlo 0 = 0
                    {
                        continue;
                    }
                    
                    float koeficient = linearniMatice[j][i] / linearniMatice[i - skipnuto][i]; // zjistí kolikrát je nutno odečíst aktuální rovnici od rovnice j, aby koeficient u nezname[i] 0

                    vysledkyLinearni[j] -= vysledkyLinearni[i - skipnuto] * koeficient; // odečte výsledek aktuální rovnice od výsledku j

                    for (int k = i + 1; k < linearniMatice[j].Length; k++) // projede všechny koeficienty za aktuální zenámou i
                    {
                        linearniMatice[j][k] -= linearniMatice[i - skipnuto][k] * koeficient; // odečte koeficient v aktální rovnici * koeficient od koeficientu v danné rovnici
                    }
                    linearniMatice[j][i] = 0; // aby jsem předešel zaokrouhlovací chybě nastavím na 0
                }
            }

            staloSeNeco = ExthrahujHodnotyLinearni() || staloSeNeco;
            return staloSeNeco; // vrátí jestli to k něčemu vůbec bylo
        }

        public static bool ExthrahujHodnotyLinearni() // zjistí jestli nelze z matice zjistit hodnotu nějaké neznámé
        {
            bool upraveno = false; // zjistili jsme něco v této metodě?

            bool necoSeStalo; // zjistili jsme něco v této iteraci?
            do
            {
                necoSeStalo = false;

                for (int i = 0; i < linearniMatice.Length; i++) // projede všechny rovnice
                {
                    int posledniNeznama; // index posledního nenulového koeficientu
                    if (NeznamychVRovnici(linearniMatice[i], out posledniNeznama) == 1) // zjistí jestli je v rovnici pouze jedna neznámá
                    {
                        if (nezname[posledniNeznama].known) // pokud již známe hodnotu dané neznámé (nemělo by nastat, ale jistota je jistota)
                        {
                            continue;
                        }

                        nezname[posledniNeznama].value = vysledkyLinearni[i] / linearniMatice[i][posledniNeznama]; // hodnota neznámé je výsledek rovnice / koeficient u neznámé
                        nezname[posledniNeznama].known = true; // nyní známe

                        vysledkyLinearni[i] = 0; // nastaví výsledek rovnice na 0
                        linearniMatice[i][posledniNeznama] = 0; // nastaví koeficient na nula

                        DosazeniNeznameLinearni(posledniNeznama);

                        // něco jme zjistili
                        upraveno = true;
                        necoSeStalo = true;
                    }
                }
            } while (necoSeStalo);

            return upraveno;
        }

        public static void PredPripravLinearni() // dosaď známé neznámé do rovnic
        {
            for (int i = 0; i < nezname.Length; i++)
            {
                if (nezname[i].known)
                {
                    DosazeniNeznameLinearni(i); // dosaď za určitou neznámou
                }
            }
        }

        private static void DosazeniNeznameLinearni(int indexDosayovaneho) // dosadí za určitou hodnotu neznámé do rovnic
        {
            for (int j = 0; j < linearniMatice.Length; j++)
            {
                vysledkyLinearni[j] -= nezname[indexDosayovaneho].value * linearniMatice[j][indexDosayovaneho];
                linearniMatice[j][indexDosayovaneho] = 0;
            }
        }

        public static bool UpravaNasobneRovnice() // úprava násobících rovnic
        {
            int skipnuto = 0; // počítá kolik neznámých se v rovnících vůbec nevyskytuje (vyruší se nebo jsou už známy)

            int rovnaSeNula = 0; // kolik rovnic je tvaru x * y = 0

            bool staloSeNeco = false; // víme něco

            for (int i = 0; i < nasobiciMatice[0].Length && i < nasobiciMatice.Length + skipnuto - rovnaSeNula; i++) // jede dokud nedojdou rovnice nebo neznámé a nevyužívala rovnice, které jsou nulové
            {
                staloSeNeco = ExtrahujHodnotyNasobiciRovnice() || staloSeNeco; // zjistili jsme něco z rovnic

                int radek = VhodnySloupec(nasobiciMatice, i, i - skipnuto, rovnaSeNula); // zjistí index rovnice s nenulovým exponentem u neznámé i

                if (radek == -1) // nic jsme nenašli => další neznámá
                {
                    skipnuto++;
                    continue;
                }

                if (vysledkyNasobici[radek] == 0) //pokud je výsledek 0 tak se výsledek uloží na konec rovnic, aby nepřekážela
                {
                    float[] podrzRovnici = nasobiciMatice[nasobiciMatice.Length - 1];
                    nasobiciMatice[nasobiciMatice.Length - 1] = nasobiciMatice[radek];
                    nasobiciMatice[radek] = podrzRovnici;

                    float podrzVysledek = vysledkyNasobici[radek];
                    vysledkyNasobici[radek] = vysledkyNasobici[nasobiciMatice.Length - 1];
                    vysledkyNasobici[nasobiciMatice.Length - 1] = podrzVysledek;

                    rovnaSeNula++;
                    i--; // danná iterace nám nic neřekla
                    continue;
                }

                if (i - skipnuto != radek) // pokud vybraný řádek není aktuální řádek tak prohoď
                {
                    float[] podrzRovnici = nasobiciMatice[i - skipnuto];
                    nasobiciMatice[i - skipnuto] = nasobiciMatice[radek];
                    nasobiciMatice[radek] = podrzRovnici;

                    float podrzVysledek = vysledkyNasobici[radek];
                    vysledkyNasobici[radek] = vysledkyNasobici[i - skipnuto];
                    vysledkyNasobici[i - skipnuto] = podrzVysledek;
                }

                for (int j = 0; j < nasobiciMatice.Length; j++) // projeď všechny rovnice
                {
                    if (j == i - skipnuto) // kdyby vydělila sama sebou vyjde nám 0 = 0
                    {
                        continue;
                    }

                   float koeficient = nasobiciMatice[j][i] / nasobiciMatice[i - skipnuto][i]; // koeficient kolikrát je 
                   
                   vysledkyNasobici[j] = vysledkyNasobici[j] / (float)Math.Pow(vysledkyNasobici[i - skipnuto], koeficient); // vyděl výsledek j výsledkem aktuální rovnice na koeficient

                   for (int k = i + 1; k < nasobiciMatice[j].Length; k++)
                   {
                       nasobiciMatice[j][k] -= nasobiciMatice[i - skipnuto][k] * koeficient; // odečti od exponentu exponent aktualní rovnice * koeficient
                   }
                   nasobiciMatice[j][i] = 0; // pro zamezení zaokrouhlovací chyby nastav na 0
                }

                for (int k = 1; k <= rovnaSeNula; k++) // vyházej záporné koeficietny z rovnic x/y = 0; jelikož nemohou být nula
                {
                    VyhazejZaporneHodnotyZNasobiciRovnice(nasobiciMatice.Length - k);
                }
            }

            staloSeNeco = ExtrahujHodnotyNasobiciRovnice() || staloSeNeco; // extrahuj hodnoty, které můžeme zjistit

            return staloSeNeco;
        }

        public static bool ExtrahujHodnotyNasobiciRovnice() // zjisti hodnoty, které můžeš z aktuálního stavu rovnice
        {
            bool upraveno = false; // zjistil jsi něco

            bool necoSeStalo; // zjistil jsi něco tuto iteraci do while
            do
            {
                necoSeStalo = false;

                for (int i = 0; i < nasobiciMatice.Length; i++) // projeď všechny rovnice
                {
                    int posledniNeznama; // index poslední neznámé
                    if (NeznamychVRovnici(nasobiciMatice[i], out posledniNeznama) == 1) // je v danné rovnici pouze jedna neznámá
                    {
                        nezname[posledniNeznama].value = (float)Math.Pow(vysledkyNasobici[i], 1 / nasobiciMatice[i][posledniNeznama]); // odmocníme výsledek rovnice exponentem poslední neznámé
                        nezname[posledniNeznama].known = true;

                        vysledkyNasobici[i] = 0; // nastaví rovnici na 0 = 0
                        nasobiciMatice[i][posledniNeznama] = 0;

                        DosazeniNeznameNasobici(posledniNeznama); // Dosadí do všech ostatních rovnic hodnotu

                        upraveno = true;
                        necoSeStalo = true;
                    }
                }
            } while (necoSeStalo);

            return upraveno;
        }

        public static void PredPripravNasobici() // dosaď za známé hodnoty neznámých
        {
            for (int i = 0; i < nezname.Length; i++)
            {
                if (nezname[i].known)
                {
                    DosazeniNeznameNasobici(i);
                }
            }
        }

        public static void DosazeniNeznameNasobici(int indexDosayovaneho) // Dosadí za neznámou do násobících rovnic
        {
            for (int j = 0; j < nasobiciMatice.Length; j++) // projeď všechny rovnice
            {
                if (nasobiciMatice[j][indexDosayovaneho] == 0) // pokud je exponent 0 nic nedělej
                {
                    continue;
                }

                if (nezname[indexDosayovaneho].value == 0) // pokud hodnota dosazované neznámé je 0
                {
                    if (nasobiciMatice[j][indexDosayovaneho] > 0) // pokud se jedná o kladný exponet nastává dělení nulou
                    {
                        for (int i = 0; i < nasobiciMatice[j].Length; i++) // otočíme známénka exponentu jelikož nám všechny podmínky vzniky úpravou rovnice (takže to nakonec výjde)
                        {
                            nasobiciMatice[j][i] = -nasobiciMatice[j][i];
                        }
                        vysledkyNasobici[j] = 1 / vysledkyNasobici[j];
                    }
                    VyhazejZaporneHodnotyZNasobiciRovnice(j); // odebereme jmenovatele jelikož by se měl rovnat nule
                    vysledkyNasobici[j] = 0; // nastavíme pravou stranu na 0
                }
                else // pokud hodnota není nula tak normálně
                {
                    vysledkyNasobici[j] = vysledkyNasobici[j] / (float)Math.Pow(nezname[indexDosayovaneho].value, nasobiciMatice[j][indexDosayovaneho]);
                }
                nasobiciMatice[j][indexDosayovaneho] = 0; // exponent za známého = 0
            }
        }

        private static int VhodnySloupec(float[][] matice, int sloupec, int pocatecniRadek, int vynechatRadku) // Nalezne z matice z určitého sloupce první vhodnou rovnici
        {
            for (int i = pocatecniRadek; i < matice.Length - vynechatRadku; i++)
            {
                if (matice[i][sloupec] != 0) // není nula? tak to jsme předci hledali
                {
                    return i;
                }
            }

            return -1; // nenašel jsi nic tak vrať -1 ať to víme
        }

        private static int NeznamychVRovnici(float[] rovnice, out int indexPosledniNezname) // vrátí počet nenulových koeficientů/exponentů v rovnici a i index poslední nenulové hodnoty
        {
            int neznamych = 0;
            indexPosledniNezname = -1; // z debug důvodů -1 a navíc musí být definováno mimo if
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

        private static void VyhazejZaporneHodnotyZNasobiciRovnice(int indexRovnice) // vymění záporné exponenty násobící rovnice z rovnice (voláno když se rovnice rovná nule)
        {
            for (int j = 0; j < nasobiciMatice[indexRovnice].Length; j++) // projede všechny členy rovnice
            {
                if (nasobiciMatice[indexRovnice][j] < 0) // menší než nula
                {
                    nasobiciMatice[indexRovnice][j] = 0; // vynulovat
                }
            }
        }

        public static void DosazeniDoRovnic() // první část (dosazování do rovnic)
        {
            // nejdříve zavolám pouze dosazování a snažím se zjistit co nejvíce můžu bez úprav

            LinDosazeniDoRovnic(); // nejdříve zavolám mimo loop, abych před možným ukončením udělal obě metody

            while (true)
            {
                if (!NasDosazeniDoRovnic())
                {
                    break;
                }

                if (LinDosazeniDoRovnic())
                {
                    break;
                }
            }
        }

        private static bool LinDosazeniDoRovnic()
        {
            ReseniSoustavyRovnic.PredPripravLinearni(); // dosaď
            return ReseniSoustavyRovnic.ExthrahujHodnotyLinearni(); // víme z toho něco
        }

        private static bool NasDosazeniDoRovnic()
        {
            ReseniSoustavyRovnic.PredPripravNasobici(); // dosaď
            return ReseniSoustavyRovnic.ExtrahujHodnotyNasobiciRovnice(); // jsme z toho o něco chytřejší
        }

        public static void VypisMatici(float[][] matice, float[] hodnoty) // debug; metoda vypíše všechny hodnoty v matici s výsledky
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

        public static void VypisMaticiChytre(float[][] matice, float[] hodnoty, string znamenko) // debub; vypíše hodnotu z matice a jméno, ale jen u nenulových
        {
            Console.WriteLine();
            for (int i = 0; i < matice.Length; i++)
            {
                for (int j = 0; j < matice[i].Length; j++)
                {
                    if (matice[i][j] != 0)
                    {
                        Console.Write(matice[i][j] + " " + nezname[j].GetName());

                        if (matice == nasobiciMatice)
                        {
                            Console.Write(" * ");
                        }
                        else if (matice == linearniMatice)
                        {
                            Console.Write(" + ");
                        }
                        else
                        {
                            Console.Write("; ");
                        }
                    }
                }
                Console.WriteLine("= " + hodnoty[i]);
            }

            Console.WriteLine();
        }

        public static void VypisNezname() // debug; vypiš hodnoty pole neznámých
        {
            Console.WriteLine();
            for (int i = 0; i < nezname.Length; i++)
            {
                Console.WriteLine(nezname[i].GetName() + " = " + nezname[i].value);
            }
        }

        public static void RESET() // uvolni nepotřebné místo v paměti a odindexuj pole neznámých
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
