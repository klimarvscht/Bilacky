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
        public static Button[] vychoziProudy;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Proud[] karel = new Proud[5];

            for (int i = 0; i < karel.Length; i++)
            {
                karel[i] = new Proud(6, karel.Length, i);
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
