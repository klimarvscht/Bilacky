namespace BilancniVypocty
{
    partial class Krmitko
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nazev = new System.Windows.Forms.Label();
            this.zname = new System.Windows.Forms.Label();
            this.hodnota = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.LabelProud = new System.Windows.Forms.Label();
            this.btnDalsiProud = new System.Windows.Forms.Button();
            this.btnPredchoziProud = new System.Windows.Forms.Button();
            this.plyn = new System.Windows.Forms.Label();
            this.chkPlyn = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // nazev
            // 
            this.nazev.AutoSize = true;
            this.nazev.Location = new System.Drawing.Point(27, 80);
            this.nazev.Name = "nazev";
            this.nazev.Size = new System.Drawing.Size(83, 13);
            this.nazev.TabIndex = 1;
            this.nazev.Text = "Nazev Proměné";
            // 
            // zname
            // 
            this.zname.AutoSize = true;
            this.zname.Location = new System.Drawing.Point(181, 80);
            this.zname.Name = "zname";
            this.zname.Size = new System.Drawing.Size(40, 13);
            this.zname.TabIndex = 2;
            this.zname.Text = "Známe";
            // 
            // hodnota
            // 
            this.hodnota.AutoSize = true;
            this.hodnota.Location = new System.Drawing.Point(319, 80);
            this.hodnota.Name = "hodnota";
            this.hodnota.Size = new System.Drawing.Size(48, 13);
            this.hodnota.TabIndex = 3;
            this.hodnota.Text = "Hodnota";
            // 
            // panel
            // 
            this.panel.AutoScroll = true;
            this.panel.Location = new System.Drawing.Point(1, 96);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(493, 477);
            this.panel.TabIndex = 4;
            // 
            // LabelProud
            // 
            this.LabelProud.AutoSize = true;
            this.LabelProud.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LabelProud.Location = new System.Drawing.Point(195, 26);
            this.LabelProud.Name = "LabelProud";
            this.LabelProud.Size = new System.Drawing.Size(62, 17);
            this.LabelProud.TabIndex = 5;
            this.LabelProud.Text = "proudik";
            this.LabelProud.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDalsiProud
            // 
            this.btnDalsiProud.Location = new System.Drawing.Point(356, 20);
            this.btnDalsiProud.Name = "btnDalsiProud";
            this.btnDalsiProud.Size = new System.Drawing.Size(75, 23);
            this.btnDalsiProud.TabIndex = 6;
            this.btnDalsiProud.Text = "Další";
            this.btnDalsiProud.UseVisualStyleBackColor = true;
            this.btnDalsiProud.Click += new System.EventHandler(this.btnDalsiProud_Click);
            // 
            // btnPredchoziProud
            // 
            this.btnPredchoziProud.Location = new System.Drawing.Point(30, 20);
            this.btnPredchoziProud.Name = "btnPredchoziProud";
            this.btnPredchoziProud.Size = new System.Drawing.Size(75, 23);
            this.btnPredchoziProud.TabIndex = 7;
            this.btnPredchoziProud.Text = "Předchozí";
            this.btnPredchoziProud.UseVisualStyleBackColor = true;
            this.btnPredchoziProud.Click += new System.EventHandler(this.btnPredchoziProud_Click);
            // 
            // plyn
            // 
            this.plyn.AutoSize = true;
            this.plyn.Location = new System.Drawing.Point(195, 53);
            this.plyn.Name = "plyn";
            this.plyn.Size = new System.Drawing.Size(26, 13);
            this.plyn.TabIndex = 8;
            this.plyn.Text = "plyn";
            // 
            // chkPlyn
            // 
            this.chkPlyn.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.chkPlyn.AutoSize = true;
            this.chkPlyn.Location = new System.Drawing.Point(227, 52);
            this.chkPlyn.Name = "chkPlyn";
            this.chkPlyn.Size = new System.Drawing.Size(15, 14);
            this.chkPlyn.TabIndex = 9;
            this.chkPlyn.UseVisualStyleBackColor = true;
            this.chkPlyn.CheckedChanged += new System.EventHandler(this.OnPlynChanged);
            // 
            // Krmitko
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 572);
            this.Controls.Add(this.chkPlyn);
            this.Controls.Add(this.plyn);
            this.Controls.Add(this.btnPredchoziProud);
            this.Controls.Add(this.btnDalsiProud);
            this.Controls.Add(this.LabelProud);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.hodnota);
            this.Controls.Add(this.zname);
            this.Controls.Add(this.nazev);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Krmitko";
            this.Text = "Krmitko";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label nazev;
        private System.Windows.Forms.Label zname;
        private System.Windows.Forms.Label hodnota;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label LabelProud;
        private System.Windows.Forms.Button btnDalsiProud;
        private System.Windows.Forms.Button btnPredchoziProud;
        private System.Windows.Forms.Label plyn;
        private System.Windows.Forms.CheckBox chkPlyn;
    }
}