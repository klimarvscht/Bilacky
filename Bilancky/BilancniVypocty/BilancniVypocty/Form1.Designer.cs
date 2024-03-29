﻿namespace BilancniVypocty
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
            this.vypocet = new System.Windows.Forms.Button();
            this.schema = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.resetBTN = new System.Windows.Forms.Button();
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
            this.vztup.Text = "vstup";
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
            // vypocet
            // 
            this.vypocet.Location = new System.Drawing.Point(161, 214);
            this.vypocet.Name = "vypocet";
            this.vypocet.Size = new System.Drawing.Size(75, 23);
            this.vypocet.TabIndex = 4;
            this.vypocet.Text = "Vypočítat";
            this.vypocet.UseVisualStyleBackColor = true;
            this.vypocet.Click += new System.EventHandler(this.Vypocet_Click);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Resetuj proudy";
            // 
            // resetBTN
            // 
            this.resetBTN.Location = new System.Drawing.Point(12, 25);
            this.resetBTN.Name = "resetBTN";
            this.resetBTN.Size = new System.Drawing.Size(75, 23);
            this.resetBTN.TabIndex = 7;
            this.resetBTN.Text = "Reset";
            this.resetBTN.UseVisualStyleBackColor = true;
            this.resetBTN.Click += new System.EventHandler(this.resetBTN_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 254);
            this.Controls.Add(this.resetBTN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.vypocet);
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
        private System.Windows.Forms.Button vypocet;
        private System.Windows.Forms.PictureBox schema;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button resetBTN;
    }
}

