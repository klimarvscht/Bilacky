using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilancniVypocty
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReseniSoustavyRovnic.nasobiciMatice = new float[4][];

            ReseniSoustavyRovnic.nasobiciMatice[0] = new float[]{ 7, -3, 6, 4};
            ReseniSoustavyRovnic.nasobiciMatice[1] = new float[] { 2, 4, 0, 9 };
            ReseniSoustavyRovnic.nasobiciMatice[2] = new float[] { 2, -3, 0, -9 };
            ReseniSoustavyRovnic.nasobiciMatice[3] = new float[] { 5, 1, 0, -3 };
            ReseniSoustavyRovnic.vysledkyNasobici = new float[] { 0, 1, 2, 3};

            ReseniSoustavyRovnic.UpravaNasobneRovnice();

            for (int i = 0; i < ReseniSoustavyRovnic.nasobiciMatice.Length; i++)
            {
                for (int j = 0; j < ReseniSoustavyRovnic.nasobiciMatice[i].Length; j++)
                {
                    Console.Write(ReseniSoustavyRovnic.nasobiciMatice[i][j] + "; ");
                }
                Console.WriteLine("= " + ReseniSoustavyRovnic.vysledkyNasobici[i]);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void VygenerovatProudyVychozi()
        {

        }
    }
}
