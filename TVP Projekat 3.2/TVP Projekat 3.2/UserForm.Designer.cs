namespace TVP_Projekat_3._2
{
    partial class UserForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.IstorijaCheckBox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.RezervacijeSearchButton = new System.Windows.Forms.Button();
            this.GradoviRezervacija = new System.Windows.Forms.ComboBox();
            this.DatumOdRezervacije = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.DatumDoRezervacije = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button4 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.DostupneCheckBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DestinacijeSearchButton = new System.Windows.Forms.Button();
            this.GradoviDestinacija = new System.Windows.Forms.ComboBox();
            this.DatumOdDestinacije = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.DatumDoDestinacije = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.IstorijaCheckBox);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.RezervacijeSearchButton);
            this.panel1.Controls.Add(this.GradoviRezervacija);
            this.panel1.Controls.Add(this.DatumOdRezervacije);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.DatumDoRezervacije);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(259, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(388, 104);
            this.panel1.TabIndex = 0;
            // 
            // IstorijaCheckBox
            // 
            this.IstorijaCheckBox.AutoSize = true;
            this.IstorijaCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IstorijaCheckBox.Location = new System.Drawing.Point(127, 70);
            this.IstorijaCheckBox.Name = "IstorijaCheckBox";
            this.IstorijaCheckBox.Size = new System.Drawing.Size(200, 24);
            this.IstorijaCheckBox.TabIndex = 12;
            this.IstorijaCheckBox.Text = "Ukljuci prosle rezervacije";
            this.IstorijaCheckBox.UseVisualStyleBackColor = true;
            this.IstorijaCheckBox.CheckedChanged += new System.EventHandler(this.IstorijaCheckBox_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(40, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Grad:";
            // 
            // RezervacijeSearchButton
            // 
            this.RezervacijeSearchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RezervacijeSearchButton.Location = new System.Drawing.Point(333, 5);
            this.RezervacijeSearchButton.Name = "RezervacijeSearchButton";
            this.RezervacijeSearchButton.Size = new System.Drawing.Size(52, 89);
            this.RezervacijeSearchButton.TabIndex = 2;
            this.RezervacijeSearchButton.Text = "🔍";
            this.RezervacijeSearchButton.UseVisualStyleBackColor = true;
            this.RezervacijeSearchButton.Click += new System.EventHandler(this.RezervacijeSearchButton_Click);
            // 
            // GradoviRezervacija
            // 
            this.GradoviRezervacija.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GradoviRezervacija.FormattingEnabled = true;
            this.GradoviRezervacija.Location = new System.Drawing.Point(97, 36);
            this.GradoviRezervacija.Name = "GradoviRezervacija";
            this.GradoviRezervacija.Size = new System.Drawing.Size(230, 28);
            this.GradoviRezervacija.TabIndex = 0;
            // 
            // DatumOdRezervacije
            // 
            this.DatumOdRezervacije.CustomFormat = "dd/MM/yyyy";
            this.DatumOdRezervacije.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatumOdRezervacije.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DatumOdRezervacije.Location = new System.Drawing.Point(75, 5);
            this.DatumOdRezervacije.Name = "DatumOdRezervacije";
            this.DatumOdRezervacije.Size = new System.Drawing.Size(103, 26);
            this.DatumOdRezervacije.TabIndex = 0;
            this.DatumOdRezervacije.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Od:";
            // 
            // DatumDoRezervacije
            // 
            this.DatumDoRezervacije.CustomFormat = "dd/MM/yyyy";
            this.DatumDoRezervacije.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatumDoRezervacije.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DatumDoRezervacije.Location = new System.Drawing.Point(224, 5);
            this.DatumDoRezervacije.Name = "DatumDoRezervacije";
            this.DatumDoRezervacije.Size = new System.Drawing.Size(103, 26);
            this.DatumDoRezervacije.TabIndex = 1;
            this.DatumDoRezervacije.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(184, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Do:";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Location = new System.Drawing.Point(259, 122);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(388, 425);
            this.panel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 159);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(283, 125);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(121, 125);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(113, 19);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(244, 100);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "Srbija // Beograd\r\nRezervisanih mesta: ??\r\nUkupna cena: ????\r\nOd: dd.mm.yyyy.\r\nDo" +
    ": dd.mm.yyyy.\r\n";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TVP_Projekat_3._2.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(7, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(202, 125);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Location = new System.Drawing.Point(663, 122);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(388, 425);
            this.panel3.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.numericUpDown2);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(364, 158);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(111, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Ukupna cena: 1000000";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.BackColor = System.Drawing.SystemColors.Control;
            this.numericUpDown2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown2.Location = new System.Drawing.Point(243, 125);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(34, 22);
            this.numericUpDown2.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(114, 19);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(244, 100);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "Srbija // Beograd\r\nDostupnih mesta: ??\r\nCena po osobi: ????\r\nOd: dd.mm.yyyy.\r\nDo:" +
    " dd.mm.yyyy.\r\n";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::TVP_Projekat_3._2.Properties.Resources.user;
            this.pictureBox2.Location = new System.Drawing.Point(7, 19);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 100);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(283, 125);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 2;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.DostupneCheckBox);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.DestinacijeSearchButton);
            this.panel4.Controls.Add(this.GradoviDestinacija);
            this.panel4.Controls.Add(this.DatumOdDestinacije);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.DatumDoDestinacije);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Location = new System.Drawing.Point(663, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(388, 104);
            this.panel4.TabIndex = 13;
            // 
            // DostupneCheckBox
            // 
            this.DostupneCheckBox.AutoSize = true;
            this.DostupneCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DostupneCheckBox.Location = new System.Drawing.Point(103, 70);
            this.DostupneCheckBox.Name = "DostupneCheckBox";
            this.DostupneCheckBox.Size = new System.Drawing.Size(224, 24);
            this.DostupneCheckBox.TabIndex = 12;
            this.DostupneCheckBox.Text = "Prikazi dostupne rezervacije";
            this.DostupneCheckBox.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(40, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Grad:";
            // 
            // DestinacijeSearchButton
            // 
            this.DestinacijeSearchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DestinacijeSearchButton.Location = new System.Drawing.Point(333, 5);
            this.DestinacijeSearchButton.Name = "DestinacijeSearchButton";
            this.DestinacijeSearchButton.Size = new System.Drawing.Size(52, 89);
            this.DestinacijeSearchButton.TabIndex = 2;
            this.DestinacijeSearchButton.Text = "🔍";
            this.DestinacijeSearchButton.UseVisualStyleBackColor = true;
            this.DestinacijeSearchButton.Click += new System.EventHandler(this.DestinacijeSearchButton_Click);
            // 
            // GradoviDestinacija
            // 
            this.GradoviDestinacija.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GradoviDestinacija.FormattingEnabled = true;
            this.GradoviDestinacija.Location = new System.Drawing.Point(97, 36);
            this.GradoviDestinacija.Name = "GradoviDestinacija";
            this.GradoviDestinacija.Size = new System.Drawing.Size(230, 28);
            this.GradoviDestinacija.TabIndex = 0;
            // 
            // DatumOdDestinacije
            // 
            this.DatumOdDestinacije.CustomFormat = "dd/MM/yyyy";
            this.DatumOdDestinacije.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatumOdDestinacije.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DatumOdDestinacije.Location = new System.Drawing.Point(75, 5);
            this.DatumOdDestinacije.Name = "DatumOdDestinacije";
            this.DatumOdDestinacije.Size = new System.Drawing.Size(103, 26);
            this.DatumOdDestinacije.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(40, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Od:";
            // 
            // DatumDoDestinacije
            // 
            this.DatumDoDestinacije.CustomFormat = "dd/MM/yyyy";
            this.DatumDoDestinacije.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatumDoDestinacije.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DatumDoDestinacije.Location = new System.Drawing.Point(224, 5);
            this.DatumDoDestinacije.Name = "DatumDoDestinacije";
            this.DatumDoDestinacije.Size = new System.Drawing.Size(103, 26);
            this.DatumDoDestinacije.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(184, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "Do:";
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 560);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "UserForm";
            this.Text = "UserForm";
            this.Load += new System.EventHandler(this.UserForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox GradoviRezervacija;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DateTimePicker DatumDoRezervacije;
        private System.Windows.Forms.DateTimePicker DatumOdRezervacije;
        private System.Windows.Forms.Button RezervacijeSearchButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox IstorijaCheckBox;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox DostupneCheckBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button DestinacijeSearchButton;
        private System.Windows.Forms.ComboBox GradoviDestinacija;
        private System.Windows.Forms.DateTimePicker DatumOdDestinacije;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker DatumDoDestinacije;
        private System.Windows.Forms.Label label7;
    }
}