namespace BilancniVypocty
{
    partial class nastaveniSlozek
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(nastaveniSlozek));
            this.numPocetSlozek = new System.Windows.Forms.NumericUpDown();
            this.PocetSlozek = new System.Windows.Forms.Label();
            this.Ulozit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numVztupProud = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numVystoupProud = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numPocetSlozek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVztupProud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVystoupProud)).BeginInit();
            this.SuspendLayout();
            // 
            // numPocetSlozek
            // 
            this.numPocetSlozek.Location = new System.Drawing.Point(162, 7);
            this.numPocetSlozek.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numPocetSlozek.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numPocetSlozek.Name = "numPocetSlozek";
            this.numPocetSlozek.Size = new System.Drawing.Size(38, 20);
            this.numPocetSlozek.TabIndex = 0;
            this.numPocetSlozek.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // PocetSlozek
            // 
            this.PocetSlozek.AutoSize = true;
            this.PocetSlozek.Location = new System.Drawing.Point(88, 9);
            this.PocetSlozek.Name = "PocetSlozek";
            this.PocetSlozek.Size = new System.Drawing.Size(68, 13);
            this.PocetSlozek.TabIndex = 1;
            this.PocetSlozek.Text = "Počet složek";
            // 
            // Ulozit
            // 
            this.Ulozit.Location = new System.Drawing.Point(81, 156);
            this.Ulozit.Name = "Ulozit";
            this.Ulozit.Size = new System.Drawing.Size(75, 23);
            this.Ulozit.TabIndex = 2;
            this.Ulozit.Text = "Ulozit";
            this.Ulozit.UseVisualStyleBackColor = true;
            this.Ulozit.Click += new System.EventHandler(this.Ulozit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Počet vstupních proudů";
            // 
            // numVztupProud
            // 
            this.numVztupProud.Location = new System.Drawing.Point(162, 55);
            this.numVztupProud.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numVztupProud.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numVztupProud.Name = "numVztupProud";
            this.numVztupProud.Size = new System.Drawing.Size(38, 20);
            this.numVztupProud.TabIndex = 3;
            this.numVztupProud.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Počet vychozích proudů";
            // 
            // numVystoupProud
            // 
            this.numVystoupProud.Location = new System.Drawing.Point(162, 99);
            this.numVystoupProud.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numVystoupProud.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numVystoupProud.Name = "numVystoupProud";
            this.numVystoupProud.Size = new System.Drawing.Size(38, 20);
            this.numVystoupProud.TabIndex = 5;
            this.numVystoupProud.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // nastaveniSlozek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 198);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numVystoupProud);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numVztupProud);
            this.Controls.Add(this.Ulozit);
            this.Controls.Add(this.PocetSlozek);
            this.Controls.Add(this.numPocetSlozek);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "nastaveniSlozek";
            this.Text = "Nastavení složek";
            ((System.ComponentModel.ISupportInitialize)(this.numPocetSlozek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVztupProud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVystoupProud)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numPocetSlozek;
        private System.Windows.Forms.Label PocetSlozek;
        private System.Windows.Forms.Button Ulozit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numVztupProud;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numVystoupProud;
    }
}