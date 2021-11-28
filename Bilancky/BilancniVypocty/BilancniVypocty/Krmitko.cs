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
    public partial class Krmitko : Form
    {
        Proud[] proudy;
        Neznama[] nezname;
        CheckBox[] chkBoxy;
        NumericUpDown[] numeric;

        public Krmitko(Proud[] proudy, string jmeno)
        {
            this.proudy = proudy;
            this.Name = jmeno;
            InitializeComponent();
            Vygeneruj(0);
        }

        private void Vygeneruj(int cisloProudu)
        {
            panel.Controls.Clear();

            nezname = proudy[cisloProudu].NeznameDoListu(0).ToArray();
            chkBoxy = new CheckBox[nezname.Length];
            numeric = new NumericUpDown[nezname.Length];
            for (int i = 0; i < nezname.Length; i++)
            {
                int odestup = i * 30;

                chkBoxy[i] = NastavChkbox(odestup, i, nezname[i].known);
                panel.Controls.Add(chkBoxy[i]);
                
                panel.Controls.Add(NastavLabel(odestup, i, nezname[i].GetName()));

                numeric[i] = NastavNumericUpDown(odestup, i, nezname[i].value, nezname[i].min, nezname[i].max);
                panel.Controls.Add(numeric[i]);
                Console.WriteLine("funguju");
            }
        }


        private CheckBox NastavChkbox(int odestup, int poradi, bool known)
        {
            CheckBox check = new CheckBox();
            check.Location = new Point(zname.Location.X, odestup);
            check.Name = "ChkBox" + poradi;
            check.Text = "";
            check.Checked = known;
            check.CheckedChanged += OnChkChanged;

            check.Show();
            return check;
        }

        private Label NastavLabel(int odestup, int poradi, string jmeno)
        {
            Label label = new Label();
            label.Location = new Point(nazev.Location.X, odestup);
            label.Name = "Jmeno" + poradi;
            label.Text = jmeno;

            label.Show();
            return label;
        }

        private NumericUpDown NastavNumericUpDown(int odestup, int poradi, float value, float min, float max)
        {
            NumericUpDown num = new NumericUpDown();
            num.Location = new Point(hodnota.Location.X, odestup);
            num.Name = "Num" + poradi;
            num.Value = (decimal)value;
            num.Minimum = (decimal)min;
            num.Maximum = (decimal)max;
            num.DecimalPlaces = 6;
            num.ValueChanged += OnNumChanged;

            return num;
        }

        private void OnNumChanged(object sender, EventArgs e)
        {
            int index = IndexSenderu(sender, numeric);
            nezname[index].value = (float)numeric[index].Value;
            nezname[index].known = true;
            chkBoxy[index].Checked = true;
        }

        private void OnChkChanged(object sender, EventArgs e)
        {
            int index = IndexSenderu(sender, chkBoxy);
            nezname[index].known = chkBoxy[index].Checked;
        }

        private int IndexSenderu(object sender, object[] objekty)
        {
            for (int i = 0; i < objekty.Length; i++)
            {
                if (sender.Equals(objekty[i]))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
