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
            List<CheckBox> boxy = new List<CheckBox>();
            List<NumericUpDown> num = new List<NumericUpDown>();

            chkPlyn.Checked = proudy[cisloProudu].plyn;

            int odestup = 0;

            List<int> listIndexu = new List<int>();
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

                boxy.Add(NastavChkbox(odestup, i, nezname[i].known));
                panel.Controls.Add(boxy[boxy.Count - 1]);

                panel.Controls.Add(NastavLabel(odestup, i, nezname[i].GetName()));

                num.Add(NastavNumericUpDown(odestup, i, nezname[i].value, nezname[i].min, nezname[i].max, nezname[i]));
                panel.Controls.Add(num[num.Count - 1]);

                listIndexu.Add(i);
            }

            numeric = num.ToArray();
            chkBoxy = boxy.ToArray();
            indexy = listIndexu.ToArray();
        }


        private CheckBox NastavChkbox(int odestup, int poradi, bool known)
        {
            return NastavChkbox(odestup, poradi, known, OnChkChanged);
        }

        private CheckBox NastavChkbox(int odestup, int poradi, bool known, EventHandler postChange)
        {
            CheckBox check = new CheckBox();
            check.Location = new Point(zname.Location.X, odestup);
            check.Name = "ChkBox" + poradi;
            check.Text = "";
            check.Checked = known;
            check.CheckedChanged += postChange;

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

        private NumericUpDown NastavNumericUpDown(int odestup, int poradi, float value, float min, float max, Neznama neznama)
        {
            NumericUpDown num = new NumericUpDown();
            num.Location = new Point(hodnota.Location.X, odestup);
            num.Name = "Num" + poradi;
            num.Minimum = (decimal)min;
            num.Maximum = (decimal)max;
            try
            {
                num.Value = (decimal)value;
            }
            catch
            {
                MessageBox.Show(neznama.GetName() + " = " + value + " minimum of this is " + min + " maximum is " + max, "Out of boundaries", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   
            }
            num.DecimalPlaces = 6;
            num.ValueChanged += OnNumChanged;

            return num;
        }

        private void OnNumChanged(object sender, EventArgs e)
        {
            int index = IndexSenderu(sender, numeric);
            int indexNezname = indexy[index];
            nezname[indexNezname].value = (float)numeric[index].Value;
            chkBoxy[index].Checked = true;
        }

        private void OnChkChanged(object sender, EventArgs e)
        {
            int index = IndexSenderu(sender, chkBoxy);
            int indexNezname = indexy[index];
            nezname[indexNezname].known = chkBoxy[index].Checked;
        }

        private void OnPlynChanged(object sender, EventArgs e)
        {
            proudy[indexik].plyn = chkPlyn.Checked;

            Vygeneruj(indexik);
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
