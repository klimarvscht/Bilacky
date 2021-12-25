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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnNastaveniSlozek = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.vztup = new System.Windows.Forms.Button();
            this.vyztup = new System.Windows.Forms.Button();
            this.Vypocet = new System.Windows.Forms.Button();
            this.schema = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.schema)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNastaveniSlozek
            // 
            this.btnNastaveniSlozek.Location = new System.Drawing.Point(161, 25);
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
            this.label1.Location = new System.Drawing.Point(148, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nastavení proudů";
            // 
            // vztup
            // 
            this.vztup.Location = new System.Drawing.Point(35, 86);
            this.vztup.Name = "vztup";
            this.vztup.Size = new System.Drawing.Size(75, 23);
            this.vztup.TabIndex = 2;
            this.vztup.Text = "vztup";
            this.vztup.UseVisualStyleBackColor = true;
            this.vztup.Click += new System.EventHandler(this.vztup_Click);
            // 
            // vyztup
            // 
            this.vyztup.Location = new System.Drawing.Point(281, 86);
            this.vyztup.Name = "vyztup";
            this.vyztup.Size = new System.Drawing.Size(75, 23);
            this.vyztup.TabIndex = 3;
            this.vyztup.Text = "výstup";
            this.vyztup.UseVisualStyleBackColor = true;
            this.vyztup.Click += new System.EventHandler(this.vyztup_Click);
            // 
            // Vypocet
            // 
            this.Vypocet.Location = new System.Drawing.Point(161, 227);
            this.Vypocet.Name = "Vypocet";
            this.Vypocet.Size = new System.Drawing.Size(75, 23);
            this.Vypocet.TabIndex = 4;
            this.Vypocet.Text = "Vypočítat";
            this.Vypocet.UseVisualStyleBackColor = true;
            this.Vypocet.Click += new System.EventHandler(this.Vypocet_Click);
            // 
            // schema
            // 
            this.schema.BackColor = System.Drawing.SystemColors.Control;
            this.schema.Image = ((System.Drawing.Image)(resources.GetObject("schema.Image")));
            this.schema.InitialImage = null;
            this.schema.Location = new System.Drawing.Point(12, 42);
            this.schema.Name = "schema";
            this.schema.Size = new System.Drawing.Size(377, 166);
            this.schema.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.schema.TabIndex = 5;
            this.schema.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 254);
            this.Controls.Add(this.Vypocet);
            this.Controls.Add(this.vyztup);
            this.Controls.Add(this.vztup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNastaveniSlozek);
            this.Controls.Add(this.schema);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Přípravy roztoků";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.schema)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNastaveniSlozek;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button vztup;
        private System.Windows.Forms.Button vyztup;
        private System.Windows.Forms.Button Vypocet;
        private System.Windows.Forms.PictureBox schema;
    }
}

