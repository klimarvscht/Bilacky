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
            ReseniSoustavyRovnic.linearniMatice = new float[4][];

            ReseniSoustavyRovnic.linearniMatice[0] = new float[]{ 4, 3, 6 ,7};
            ReseniSoustavyRovnic.linearniMatice[1] = new float[] { 2, 4, 8, 9 };
            ReseniSoustavyRovnic.linearniMatice[2] = new float[] { 2, -3, 0, -9 };
            ReseniSoustavyRovnic.linearniMatice[3] = new float[] { 5, 1, 3, -3 };
            ReseniSoustavyRovnic.vysledkyLinearni = new float[] { 0, 1, 2, -3};

            ReseniSoustavyRovnic.UpravaLinearniRovnice();

            for (int i = 0; i < ReseniSoustavyRovnic.linearniMatice.Length; i++)
            {
                for (int j = 0; j < ReseniSoustavyRovnic.linearniMatice[i].Length; j++)
                {
                    Console.Write(ReseniSoustavyRovnic.linearniMatice[i][j] + "; ");
                }
                Console.WriteLine("= " + ReseniSoustavyRovnic.vysledkyLinearni[i]);
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
