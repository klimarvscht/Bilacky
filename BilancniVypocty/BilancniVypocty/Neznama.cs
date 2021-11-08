using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilancniVypocty
{
    class Neznama
    {
        public float max;
        public float min;
        public float value;
        public bool known;
        public string jmeno;
        public string jednotka;
        public int indexProudu;
        public int indexSlozky;

        public Neznama(float maximum, float minimum, string jmeno, string jednotka, int indexProudu,int indexSlozky)
        {
            this.max = maximum;
            this.min = minimum;
            this.jmeno = jmeno;
            this.indexProudu = indexProudu;
            this.indexSlozky = indexSlozky;
            this.jednotka = jednotka;
            known = false;
            if (minimum > 0)
            {
                value = minimum;
            }
            else
            {
                value = 0;
            }
        }
    }
}
