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
            this.SuspendLayout();
            // 
            // nazev
            // 
            this.nazev.AutoSize = true;
            this.nazev.Location = new System.Drawing.Point(27, 19);
            this.nazev.Name = "nazev";
            this.nazev.Size = new System.Drawing.Size(83, 13);
            this.nazev.TabIndex = 1;
            this.nazev.Text = "Nazev Proměné";
            // 
            // zname
            // 
            this.zname.AutoSize = true;
            this.zname.Location = new System.Drawing.Point(181, 19);
            this.zname.Name = "zname";
            this.zname.Size = new System.Drawing.Size(40, 13);
            this.zname.TabIndex = 2;
            this.zname.Text = "Známe";
            // 
            // hodnota
            // 
            this.hodnota.AutoSize = true;
            this.hodnota.Location = new System.Drawing.Point(319, 19);
            this.hodnota.Name = "hodnota";
            this.hodnota.Size = new System.Drawing.Size(48, 13);
            this.hodnota.TabIndex = 3;
            this.hodnota.Text = "Hodnota";
            // 
            // panel
            // 
            this.panel.AutoScroll = true;
            this.panel.Location = new System.Drawing.Point(1, 50);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(493, 482);
            this.panel.TabIndex = 4;
            // 
            // Krmitko
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 572);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.hodnota);
            this.Controls.Add(this.zname);
            this.Controls.Add(this.nazev);
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
    }
}