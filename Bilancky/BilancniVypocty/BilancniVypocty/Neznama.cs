using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilancniVypocty
{
    public class Neznama // tato třída uchovává v sobě všechno potřebné o nějaké proměnné
    {
        public int indexVPoli = -1; // index v poli proměnných (-1 znamená, že není zařazen)
        public float max; // maximální hodnota
        public float min; // minimální hodnota
        public float value; // hodnota aktuální
        public bool known; // známe hodnotu danné proměnné
        public string jmeno; //značka danné proměnné
        public string jednotka; // jednotka
        public int indexProudu; // v jakém proudu se daná proměnná nachází
        public int indexSlozky; // jaké složky se danná neznámá týká (0 znamená celého proudu)
        public bool chciVypsat; // jestli chci, aby uživatel viděl hodnoty
        public bool pozeProPlyn; // jestli danná neznámá je duležitá pouze pro plyn
        public Proud doProudu; // pouze pro do Proudu proměnné, aby měly odkaz na danný proud

        public Neznama(float maximum, float minimum, string jmeno, string jednotka, int indexProudu, int indexSlozky, bool chciVeVypisu, bool plyn) // rozšířený konstruktor
        {
            this.max = maximum;
            this.min = minimum;
            this.jmeno = jmeno;
            this.indexProudu = indexProudu;
            this.indexSlozky = indexSlozky;
            this.jednotka = jednotka;
            known = false;
            chciVypsat = chciVeVypisu;
            pozeProPlyn = plyn;

            if (minimum > 0) // aby byla hodnota mezi maximem a minimem (nikdy by nemělo nastat, aby toto bylo potřeba)
            {
                value = minimum;
            }
            else
            {
                value = 0;
            }

            doProudu = null;
        }

        public Neznama(float maximum, float minimum, string jmeno, string jednotka, int indexProudu, int indexSlozky) // krátký konstruktor
        {
            this.max = maximum;
            this.min = minimum;
            this.jmeno = jmeno;
            this.indexProudu = indexProudu;
            this.indexSlozky = indexSlozky;
            this.jednotka = jednotka;
            known = false;
            chciVypsat = true;
            pozeProPlyn = false;
            if (minimum > 0)
            {
                value = minimum;
            }
            else
            {
                value = 0;
            }

            doProudu = null;
        }

        public Neznama(float maximum, float minimum, string jmeno, string jednotka, int indexProudu, int indexSlozky, bool chciVeVypisu, bool plyn, Proud proud) // krátký konstruktor
        {
            this.max = maximum;
            this.min = minimum;
            this.jmeno = jmeno;
            this.indexProudu = indexProudu;
            this.indexSlozky = indexSlozky;
            this.jednotka = jednotka;
            known = false;
            chciVypsat = chciVeVypisu;
            pozeProPlyn = plyn;

            if (minimum > 0) // aby byla hodnota mezi maximem a minimem (nikdy by nemělo nastat, aby toto bylo potřeba)
            {
                value = minimum;
            }
            else
            {
                value = 0;
            }

            doProudu = proud;
        }

        public string GetName() // nutno přidat i číslo složky
        {
            string name = jmeno;

            if (doProudu != null)
            {
                name = Uzel.alpha[indexSlozky - 1] + jmeno + (doProudu.indexProudu + 1);
            }
            else if (indexSlozky != 0) // jelikož nula je pro celý proud tak není nutno vypisovat
            {
                name += Uzel.alpha[indexSlozky - 1];
            }

            return name;
        }
    }
}
