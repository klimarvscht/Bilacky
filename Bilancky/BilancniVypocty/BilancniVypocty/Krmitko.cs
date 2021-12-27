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

        int[] indexy; // udrzuje indexy neznámých, které byly použitelné

        int indexik; // index aktuálního proudu

        public Krmitko(Proud[] proudy, string jmeno)
        {
            this.proudy = proudy;
            indexik = 0;
            InitializeComponent();
            this.Name = jmeno;
            this.Text = jmeno;
            Vygeneruj(indexik);
            FormClosing += Zaviracka;

            proudik.ItemHeight = proudy.Length;

            foreach (Proud item in proudy) // výběr proudů
            {
                proudik.Items.Add("Proud: " + (item.indexProudu + 1));
            }
            proudik.SelectedIndex = 0;
        }

        private void Vygeneruj(int cisloProudu) // vygeneruje nastavení neznámých
        {
            panel.Controls.Clear(); // vyčistí panel

            nezname = proudy[cisloProudu].NeznameDoListu(0, true).ToArray(); // extrahuje neznámé z určitého proudu

            // vyresetuje pole
            List<CheckBox> boxy = new List<CheckBox>();
            List<NumericUpDown> num = new List<NumericUpDown>();

            chkPlyn.Checked = proudy[cisloProudu].plyn; // nastaví jestli je daný proud plynný

            int odestup = 0; // odestup při generování

            List<int> listIndexu = new List<int>(); // reset

            for (int i = 0; i < nezname.Length; i++)
            {
                if (!nezname[i].chciVypsat) // pokud nechci vypsat přeskoč
                {
                    continue;
                }
                else if (!proudy[cisloProudu].plyn && nezname[i].pozeProPlyn) // pokud jsi nejsi plyn a nechci plynné neznámé přeskoč
                {
                    continue;
                }

                odestup += 30; // přidá k odestupu

                boxy.Add(NastavChkbox(odestup, i, nezname[i].known)); // přidá nový box do listu
                panel.Controls.Add(boxy[boxy.Count - 1]); // přidá na panel

                panel.Controls.Add(NastavLabel(odestup, nazev.Location.X, i, nezname[i].GetName()));

                panel.Controls.Add(NastavLabel(odestup, jednotka.Location.X, i, nezname[i].jednotka));

                num.Add(NastavNumericUpDown(odestup, i, nezname[i].value, nezname[i].min, nezname[i].max, nezname[i])); // přidá do listu
                panel.Controls.Add(num[num.Count - 1]); // přidá na panel

                listIndexu.Add(i); // přidá použitelný index
            }

            numeric = num.ToArray();
            chkBoxy = boxy.ToArray();
            indexy = listIndexu.ToArray();
        }


        private CheckBox NastavChkbox(int odestup, int poradi, bool known) // krátká varianta pro generické
        {
            return NastavChkbox(odestup, poradi, known, OnChkChanged);
        }

        private CheckBox NastavChkbox(int odestup, int poradi, bool known, EventHandler postChange) // pro plyn checkbox
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

        private Label NastavLabel(int odestup, int xPos, int poradi, string text)
        {
            Label label = new Label();
            label.Location = new Point(xPos, odestup);
            label.Name = text + poradi;
            label.Text = text;

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
            catch // debug
            {
                num.Value = num.Minimum;
            }
            num.DecimalPlaces = 7; 
            num.ValueChanged += OnNumChanged;

            return num;
        }

        private void OnNumChanged(object sender, EventArgs e)
        {
            int index = IndexSenderu(sender, numeric); // vytrasuje sendera v poli objektu
            int indexNezname = indexy[index]; // prevede na index neznámé
            nezname[indexNezname].value = (float)numeric[index].Value; // změní hodnotu neznámé
            chkBoxy[index].Checked = true; // změní hodnotu známe
        }

        private void OnChkChanged(object sender, EventArgs e)
        {
            int index = IndexSenderu(sender, chkBoxy); // vytrasuje sendera v poli objektu
            int indexNezname = indexy[index]; // prevede na index neznámé
            nezname[indexNezname].known = chkBoxy[index].Checked; // nastavi známe
        }

        private void OnPlynChanged(object sender, EventArgs e)
        {
            proudy[indexik].plyn = chkPlyn.Checked;

            Vygeneruj(indexik);
        }

        private int IndexSenderu(object sender, object[] objekty) // vrátí index v poli
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

            proudik.SelectedIndex = indexik;
        }

        private void btnPredchoziProud_Click(object sender, EventArgs e)
        {
            indexik -= 1;
            if (indexik < 0)
            {
                indexik += proudy.Length;
            }

            proudik.SelectedIndex = indexik;
        }

        private void Zaviracka(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = false;
            Form1.krmitko = null; // zruš odkaz na krmítko ve forms
        }

        private void OnProudChanged(object sender, EventArgs e) // když se změní proud
        {
            indexik = proudik.SelectedIndex;
            Vygeneruj(indexik);
        }
    }
}
