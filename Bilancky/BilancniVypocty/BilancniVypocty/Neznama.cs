﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilancniVypocty
{
    public class Neznama
    {
        public int indexVPoli = -1;
        public float max;
        public float min;
        public float value;
        public bool known;
        public string jmeno;
        public string jednotka;
        public int indexProudu;
        public int indexSlozky;
        public bool chciVypsat;
        public bool pozeProPlyn;

        public Neznama(float maximum, float minimum, string jmeno, string jednotka, int indexProudu,int indexSlozky, bool chciVeVypisu, bool plyn)
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
            if (minimum > 0)
            {
                value = minimum;
            }
            else
            {
                value = 0;
            }
        }

        public Neznama(float maximum, float minimum, string jmeno, string jednotka, int indexProudu, int indexSlozky)
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
        }

        public string GetName()
        {
            string name = jmeno;

            if (indexSlozky != 0)
            {
                name += Uzel.alpha[indexSlozky - 1];
            }

            return name;
        }
    }
}
