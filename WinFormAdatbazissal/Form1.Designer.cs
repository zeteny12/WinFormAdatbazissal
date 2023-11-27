namespace WinFormAdatbazissal
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listBox_Tagok = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_Orszagkod = new System.Windows.Forms.TextBox();
            this.numericUpDown_SzuletesiEv = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Iranyitoszam = new System.Windows.Forms.NumericUpDown();
            this.textBox_Nev = new System.Windows.Forms.TextBox();
            this.textBox_Azonosito = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_Torles = new System.Windows.Forms.Button();
            this.button_Modosit = new System.Windows.Forms.Button();
            this.button_Letrehoz = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_SzuletesiEv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Iranyitoszam)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox_Tagok
            // 
            this.listBox_Tagok.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBox_Tagok.FormattingEnabled = true;
            this.listBox_Tagok.ItemHeight = 25;
            this.listBox_Tagok.Location = new System.Drawing.Point(0, 0);
            this.listBox_Tagok.Name = "listBox_Tagok";
            this.listBox_Tagok.Size = new System.Drawing.Size(641, 702);
            this.listBox_Tagok.TabIndex = 0;
            this.listBox_Tagok.SelectedIndexChanged += new System.EventHandler(this.listBox_Tagok_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_Orszagkod);
            this.groupBox1.Controls.Add(this.numericUpDown_SzuletesiEv);
            this.groupBox1.Controls.Add(this.numericUpDown_Iranyitoszam);
            this.groupBox1.Controls.Add(this.textBox_Nev);
            this.groupBox1.Controls.Add(this.textBox_Azonosito);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(641, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(559, 377);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kiválasztott tag";
            // 
            // textBox_Orszagkod
            // 
            this.textBox_Orszagkod.Location = new System.Drawing.Point(141, 315);
            this.textBox_Orszagkod.Name = "textBox_Orszagkod";
            this.textBox_Orszagkod.Size = new System.Drawing.Size(100, 30);
            this.textBox_Orszagkod.TabIndex = 4;
            // 
            // numericUpDown_SzuletesiEv
            // 
            this.numericUpDown_SzuletesiEv.Location = new System.Drawing.Point(141, 245);
            this.numericUpDown_SzuletesiEv.Maximum = new decimal(new int[] {
            2023,
            0,
            0,
            0});
            this.numericUpDown_SzuletesiEv.Minimum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.numericUpDown_SzuletesiEv.Name = "numericUpDown_SzuletesiEv";
            this.numericUpDown_SzuletesiEv.Size = new System.Drawing.Size(120, 30);
            this.numericUpDown_SzuletesiEv.TabIndex = 3;
            this.numericUpDown_SzuletesiEv.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_SzuletesiEv.Value = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            // 
            // numericUpDown_Iranyitoszam
            // 
            this.numericUpDown_Iranyitoszam.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_Iranyitoszam.Location = new System.Drawing.Point(141, 177);
            this.numericUpDown_Iranyitoszam.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDown_Iranyitoszam.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_Iranyitoszam.Name = "numericUpDown_Iranyitoszam";
            this.numericUpDown_Iranyitoszam.Size = new System.Drawing.Size(120, 30);
            this.numericUpDown_Iranyitoszam.TabIndex = 3;
            this.numericUpDown_Iranyitoszam.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_Iranyitoszam.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // textBox_Nev
            // 
            this.textBox_Nev.Location = new System.Drawing.Point(141, 108);
            this.textBox_Nev.Name = "textBox_Nev";
            this.textBox_Nev.Size = new System.Drawing.Size(405, 30);
            this.textBox_Nev.TabIndex = 2;
            // 
            // textBox_Azonosito
            // 
            this.textBox_Azonosito.Location = new System.Drawing.Point(141, 37);
            this.textBox_Azonosito.Name = "textBox_Azonosito";
            this.textBox_Azonosito.ReadOnly = true;
            this.textBox_Azonosito.Size = new System.Drawing.Size(405, 30);
            this.textBox_Azonosito.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 320);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "Országkód:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 250);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Születési év:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Irányítószám:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Név:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Azonosító:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_Torles);
            this.groupBox2.Controls.Add(this.button_Modosit);
            this.groupBox2.Controls.Add(this.button_Letrehoz);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(641, 377);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(559, 325);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Műveletek";
            // 
            // button_Torles
            // 
            this.button_Torles.Location = new System.Drawing.Point(87, 210);
            this.button_Torles.Name = "button_Torles";
            this.button_Torles.Size = new System.Drawing.Size(404, 56);
            this.button_Torles.TabIndex = 0;
            this.button_Torles.Text = "Törlés";
            this.button_Torles.UseVisualStyleBackColor = true;
            // 
            // button_Modosit
            // 
            this.button_Modosit.Location = new System.Drawing.Point(87, 148);
            this.button_Modosit.Name = "button_Modosit";
            this.button_Modosit.Size = new System.Drawing.Size(404, 56);
            this.button_Modosit.TabIndex = 0;
            this.button_Modosit.Text = "Módosítás";
            this.button_Modosit.UseVisualStyleBackColor = true;
            this.button_Modosit.Click += new System.EventHandler(this.button_Modosit_Click);
            // 
            // button_Letrehoz
            // 
            this.button_Letrehoz.Location = new System.Drawing.Point(87, 86);
            this.button_Letrehoz.Name = "button_Letrehoz";
            this.button_Letrehoz.Size = new System.Drawing.Size(404, 56);
            this.button_Letrehoz.TabIndex = 0;
            this.button_Letrehoz.Text = "Létrehozás";
            this.button_Letrehoz.UseVisualStyleBackColor = true;
            this.button_Letrehoz.Click += new System.EventHandler(this.button_Letrehoz_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 702);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBox_Tagok);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form1";
            this.Text = "Tagok nyilvántartása";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_SzuletesiEv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Iranyitoszam)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_Tagok;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_Azonosito;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown_Iranyitoszam;
        private System.Windows.Forms.TextBox textBox_Nev;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown_SzuletesiEv;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_Orszagkod;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_Torles;
        private System.Windows.Forms.Button button_Modosit;
        private System.Windows.Forms.Button button_Letrehoz;
    }
}

