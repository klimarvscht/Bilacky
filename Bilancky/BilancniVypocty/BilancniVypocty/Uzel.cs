using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilancniVypocty
{
    class Uzel
    {
        public Proud[] vztupniProudy;
        public Proud[] vystupniProudy;

        public Uzel(int vztupneProudy, int vystupneProudy)
        {
            vystupniProudy = NastavProudy(vystupneProudy, vztupneProudy);
            vztupniProudy = NastavProudy(vztupneProudy, vystupneProudy);
        }

        private Proud[] NastavProudy(int pocet, int pocetNaDruheStrane)
        {
            Proud[] proudy = new Proud[pocet];
            for (int i = 0; i < pocet;i++)
            {
                proudy[i] = new Proud(pocet, pocetNaDruheStrane, i);
            }
            return proudy;
        }
    }
}
