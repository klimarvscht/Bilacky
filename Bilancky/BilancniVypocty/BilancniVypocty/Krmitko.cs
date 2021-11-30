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
        int[] indexy;

        int indexik;

        public Krmitko(Proud[] proudy, string jmeno)
        {
            this.proudy = proudy;
            indexik = 0;
            InitializeComponent();
            this.Name = jmeno;
            this.Text = jmeno;
            Vygeneruj(indexik);
            FormClosing += Zaviracka;
        }

        private void Vygeneruj(int cisloProudu)
        {
            panel.Controls.Clear();

            LabelProud.Text = "Proud: " + (proudy[cisloProudu].indexProudu + 1);

            nezname = proudy[cisloProudu].NeznameDoListu(0, true).ToArray();
            chkBoxy = new CheckBox[nezname.Length];
            numeric = new NumericUpDown[nezname.Length];

            List<int> listIndexu = new List<int>();
            int odestup = 0;
            for (int i = 0; i < nezname.Length; i++)
            {
                if (!nezname[i].chciVypsat)
                {
                    continue;
                }
                else if (!proudy[cisloProudu].plyn && nezname[i].pozeProPlyn)
                {
                    continue;
                }

                odestup += 30;

                chkBoxy[i] = NastavChkbox(odestup, i, nezname[i].known);
                panel.Controls.Add(chkBoxy[i]);
                
                panel.Controls.Add(NastavLabel(odestup, i, nezname[i].GetName()));

                numeric[i] = NastavNumericUpDown(odestup, i, nezname[i].value, nezname[i].min, nezname[i].max);
                panel.Controls.Add(numeric[i]);

                listIndexu.Add(i);
            }

            indexy = listIndexu.ToArray();
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
            int index = indexy[IndexSenderu(sender, numeric)];
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

        private void btnDalsiProud_Click(object sender, EventArgs e)
        {
            indexik += 1;
            if (indexik == proudy.Length)
            {
                indexik -= proudy.Length;
            }

            Vygeneruj(indexik);
        }

        private void btnPredchoziProud_Click(object sender, EventArgs e)
        {
            indexik -= 1;
            if (indexik < 0)
            {
                indexik += proudy.Length;
            }

            Vygeneruj(indexik);
        }

        private void Zaviracka(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = false;
            Form1.krmitko = null;
        }
    }
}
