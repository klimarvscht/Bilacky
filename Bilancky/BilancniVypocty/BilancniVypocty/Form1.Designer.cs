namespace BilancniVypocty
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnNastaveniSlozek = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.vztup = new System.Windows.Forms.Button();
            this.vyztup = new System.Windows.Forms.Button();
            this.Vypocet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNastaveniSlozek
            // 
            this.btnNastaveniSlozek.Location = new System.Drawing.Point(790, 62);
            this.btnNastaveniSlozek.Name = "btnNastaveniSlozek";
            this.btnNastaveniSlozek.Size = new System.Drawing.Size(75, 23);
            this.btnNastaveniSlozek.TabIndex = 0;
            this.btnNastaveniSlozek.Text = "Nastavit";
            this.btnNastaveniSlozek.UseVisualStyleBackColor = true;
            this.btnNastaveniSlozek.Click += new System.EventHandler(this.btnNastaveniSlozek_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(800, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nastaveni";
            // 
            // vztup
            // 
            this.vztup.Location = new System.Drawing.Point(234, 215);
            this.vztup.Name = "vztup";
            this.vztup.Size = new System.Drawing.Size(75, 23);
            this.vztup.TabIndex = 2;
            this.vztup.Text = "vztup";
            this.vztup.UseVisualStyleBackColor = true;
            this.vztup.Click += new System.EventHandler(this.vztup_Click);
            // 
            // vyztup
            // 
            this.vyztup.Location = new System.Drawing.Point(423, 215);
            this.vyztup.Name = "vyztup";
            this.vyztup.Size = new System.Drawing.Size(75, 23);
            this.vyztup.TabIndex = 3;
            this.vyztup.Text = "výstup";
            this.vyztup.UseVisualStyleBackColor = true;
            this.vyztup.Click += new System.EventHandler(this.vyztup_Click);
            // 
            // Vypocet
            // 
            this.Vypocet.Location = new System.Drawing.Point(369, 368);
            this.Vypocet.Name = "Vypocet";
            this.Vypocet.Size = new System.Drawing.Size(75, 23);
            this.Vypocet.TabIndex = 4;
            this.Vypocet.Text = "Vypočítat";
            this.Vypocet.UseVisualStyleBackColor = true;
            this.Vypocet.Click += new System.EventHandler(this.Vypocet_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 499);
            this.Controls.Add(this.Vypocet);
            this.Controls.Add(this.vyztup);
            this.Controls.Add(this.vztup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNastaveniSlozek);
            this.Name = "Form1";
            this.Text = "Výpočet bilančních ronvnic";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNastaveniSlozek;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button vztup;
        private System.Windows.Forms.Button vyztup;
        private System.Windows.Forms.Button Vypocet;
    }
}

