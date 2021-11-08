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
            this.pocetSlozek = new System.Windows.Forms.NumericUpDown();
            this.pocetVzupnichProudu = new System.Windows.Forms.NumericUpDown();
            this.pocetVystupnichProudu = new System.Windows.Forms.NumericUpDown();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pocetSlozek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pocetVzupnichProudu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pocetVystupnichProudu)).BeginInit();
            this.SuspendLayout();
            // 
            // pocetSlozek
            // 
            this.pocetSlozek.Location = new System.Drawing.Point(158, 0);
            this.pocetSlozek.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.pocetSlozek.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.pocetSlozek.Name = "pocetSlozek";
            this.pocetSlozek.Size = new System.Drawing.Size(120, 20);
            this.pocetSlozek.TabIndex = 0;
            this.pocetSlozek.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // pocetVzupnichProudu
            // 
            this.pocetVzupnichProudu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pocetVzupnichProudu.Location = new System.Drawing.Point(470, 0);
            this.pocetVzupnichProudu.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.pocetVzupnichProudu.Name = "pocetVzupnichProudu";
            this.pocetVzupnichProudu.Size = new System.Drawing.Size(120, 20);
            this.pocetVzupnichProudu.TabIndex = 1;
            this.pocetVzupnichProudu.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // pocetVystupnichProudu
            // 
            this.pocetVystupnichProudu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pocetVystupnichProudu.Location = new System.Drawing.Point(779, 0);
            this.pocetVystupnichProudu.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.pocetVystupnichProudu.Name = "pocetVystupnichProudu";
            this.pocetVystupnichProudu.Size = new System.Drawing.Size(120, 20);
            this.pocetVystupnichProudu.TabIndex = 2;
            this.pocetVystupnichProudu.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox1.Location = new System.Drawing.Point(52, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 14);
            this.textBox1.TabIndex = 3;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "Počet složek:";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox2.Location = new System.Drawing.Point(314, 0);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(150, 14);
            this.textBox2.TabIndex = 4;
            this.textBox2.TabStop = false;
            this.textBox2.Text = "Počet výchozích proudů:";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox3.Location = new System.Drawing.Point(623, 0);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(150, 14);
            this.textBox3.TabIndex = 5;
            this.textBox3.TabStop = false;
            this.textBox3.Text = "Počet konečných proudů:";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 499);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pocetVystupnichProudu);
            this.Controls.Add(this.pocetVzupnichProudu);
            this.Controls.Add(this.pocetSlozek);
            this.Name = "Form1";
            this.Text = "Výpočet bilančních ronvnic";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pocetSlozek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pocetVzupnichProudu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pocetVystupnichProudu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown pocetSlozek;
        private System.Windows.Forms.NumericUpDown pocetVzupnichProudu;
        private System.Windows.Forms.NumericUpDown pocetVystupnichProudu;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
    }
}

