namespace numune_kayıt
{
    partial class NumuneKayitForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NumuneKayitForm));
            this.cmbFirmalar = new System.Windows.Forms.ComboBox();
            this.cmbKatliFirmalar = new System.Windows.Forms.ComboBox();
            this.cmbReceteler = new System.Windows.Forms.ComboBox();
            this.cmbSantraller = new System.Windows.Forms.ComboBox();
            this.dgvNumuneler = new System.Windows.Forms.DataGridView();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnRecetelerSayfa = new System.Windows.Forms.Button();
            this.txtNmNo = new System.Windows.Forms.TextBox();
            this.txtPlaka = new System.Windows.Forms.TextBox();
            this.txtBtnSicklk = new System.Windows.Forms.TextBox();
            this.txtHava = new System.Windows.Forms.TextBox();
            this.txtSlump = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dateTimePickerTrh = new System.Windows.Forms.DateTimePicker();
            this.txtnumuneID = new System.Windows.Forms.TextBox();
            this.btnKirimSonuc = new System.Windows.Forms.Button();
            this.pnldimmer = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.txtara = new System.Windows.Forms.TextBox();
            this.cmbAra = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNumuneler)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbFirmalar
            // 
            this.cmbFirmalar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFirmalar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFirmalar.FormattingEnabled = true;
            this.cmbFirmalar.Location = new System.Drawing.Point(1023, 40);
            this.cmbFirmalar.Name = "cmbFirmalar";
            this.cmbFirmalar.Size = new System.Drawing.Size(161, 21);
            this.cmbFirmalar.TabIndex = 0;
            // 
            // cmbKatliFirmalar
            // 
            this.cmbKatliFirmalar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbKatliFirmalar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbKatliFirmalar.FormattingEnabled = true;
            this.cmbKatliFirmalar.Location = new System.Drawing.Point(1023, 79);
            this.cmbKatliFirmalar.Name = "cmbKatliFirmalar";
            this.cmbKatliFirmalar.Size = new System.Drawing.Size(161, 21);
            this.cmbKatliFirmalar.TabIndex = 1;
            // 
            // cmbReceteler
            // 
            this.cmbReceteler.FormattingEnabled = true;
            this.cmbReceteler.Location = new System.Drawing.Point(1023, 157);
            this.cmbReceteler.Name = "cmbReceteler";
            this.cmbReceteler.Size = new System.Drawing.Size(161, 21);
            this.cmbReceteler.TabIndex = 3;
            this.cmbReceteler.DropDown += new System.EventHandler(this.cmbReceteler_DropDown);
            // 
            // cmbSantraller
            // 
            this.cmbSantraller.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSantraller.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSantraller.FormattingEnabled = true;
            this.cmbSantraller.Location = new System.Drawing.Point(1023, 118);
            this.cmbSantraller.Name = "cmbSantraller";
            this.cmbSantraller.Size = new System.Drawing.Size(161, 21);
            this.cmbSantraller.TabIndex = 2;
            // 
            // dgvNumuneler
            // 
            this.dgvNumuneler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNumuneler.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvNumuneler.Location = new System.Drawing.Point(0, 284);
            this.dgvNumuneler.Name = "dgvNumuneler";
            this.dgvNumuneler.RowHeadersWidth = 51;
            this.dgvNumuneler.Size = new System.Drawing.Size(1270, 302);
            this.dgvNumuneler.TabIndex = 4;
            this.dgvNumuneler.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNumuneler_CellDoubleClick);
            this.dgvNumuneler.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvNumuneler_RowHeaderMouseDoubleClick);
            this.dgvNumuneler.SelectionChanged += new System.EventHandler(this.dgvNumuneler_SelectionChanged);
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.Color.Silver;
            this.btnKaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKaydet.Location = new System.Drawing.Point(307, 236);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(106, 42);
            this.btnKaydet.TabIndex = 5;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.BackColor = System.Drawing.Color.Silver;
            this.btnGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGuncelle.Location = new System.Drawing.Point(419, 236);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(106, 42);
            this.btnGuncelle.TabIndex = 6;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = false;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnTemizle
            // 
            this.btnTemizle.BackColor = System.Drawing.Color.Silver;
            this.btnTemizle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTemizle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTemizle.Location = new System.Drawing.Point(654, 236);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(106, 42);
            this.btnTemizle.TabIndex = 8;
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.UseVisualStyleBackColor = false;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.Silver;
            this.btnSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSil.Location = new System.Drawing.Point(542, 236);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(106, 42);
            this.btnSil.TabIndex = 7;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnRecetelerSayfa
            // 
            this.btnRecetelerSayfa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecetelerSayfa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRecetelerSayfa.Image = global::numune_kayıt.Properties.Resources.artı_22x22;
            this.btnRecetelerSayfa.Location = new System.Drawing.Point(1190, 153);
            this.btnRecetelerSayfa.Name = "btnRecetelerSayfa";
            this.btnRecetelerSayfa.Size = new System.Drawing.Size(25, 25);
            this.btnRecetelerSayfa.TabIndex = 9;
            this.btnRecetelerSayfa.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRecetelerSayfa.UseVisualStyleBackColor = true;
            this.btnRecetelerSayfa.Click += new System.EventHandler(this.btnRecetelerSayfa_Click);
            // 
            // txtNmNo
            // 
            this.txtNmNo.Location = new System.Drawing.Point(208, 40);
            this.txtNmNo.Name = "txtNmNo";
            this.txtNmNo.Size = new System.Drawing.Size(161, 20);
            this.txtNmNo.TabIndex = 10;
            // 
            // txtPlaka
            // 
            this.txtPlaka.Location = new System.Drawing.Point(589, 159);
            this.txtPlaka.Name = "txtPlaka";
            this.txtPlaka.Size = new System.Drawing.Size(161, 20);
            this.txtPlaka.TabIndex = 13;
            // 
            // txtBtnSicklk
            // 
            this.txtBtnSicklk.Location = new System.Drawing.Point(208, 159);
            this.txtBtnSicklk.Name = "txtBtnSicklk";
            this.txtBtnSicklk.Size = new System.Drawing.Size(161, 20);
            this.txtBtnSicklk.TabIndex = 12;
            // 
            // txtHava
            // 
            this.txtHava.Location = new System.Drawing.Point(589, 94);
            this.txtHava.Name = "txtHava";
            this.txtHava.Size = new System.Drawing.Size(161, 20);
            this.txtHava.TabIndex = 15;
            // 
            // txtSlump
            // 
            this.txtSlump.Location = new System.Drawing.Point(589, 40);
            this.txtSlump.Name = "txtSlump";
            this.txtSlump.Size = new System.Drawing.Size(161, 20);
            this.txtSlump.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(69, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 18);
            this.label1.TabIndex = 16;
            this.label1.Text = "Numune No:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(69, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 18);
            this.label2.TabIndex = 17;
            this.label2.Text = "Alınma Tarihi:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(69, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 18);
            this.label3.TabIndex = 18;
            this.label3.Text = "Beton Sıcaklığı:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(462, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 18);
            this.label4.TabIndex = 21;
            this.label4.Text = "Mikser Plaka:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(462, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 18);
            this.label5.TabIndex = 20;
            this.label5.Text = "Hava İçeriği %:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(462, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 18);
            this.label6.TabIndex = 19;
            this.label6.Text = "Slump Değeri:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(899, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 18);
            this.label7.TabIndex = 24;
            this.label7.Text = "Santral";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(899, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 18);
            this.label8.TabIndex = 23;
            this.label8.Text = "Katkı Firması";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(899, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 18);
            this.label9.TabIndex = 22;
            this.label9.Text = "İnşaat Firması";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(899, 156);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 18);
            this.label10.TabIndex = 25;
            this.label10.Text = "Reçete";
            // 
            // dateTimePickerTrh
            // 
            this.dateTimePickerTrh.Location = new System.Drawing.Point(208, 93);
            this.dateTimePickerTrh.Name = "dateTimePickerTrh";
            this.dateTimePickerTrh.Size = new System.Drawing.Size(161, 20);
            this.dateTimePickerTrh.TabIndex = 26;
            // 
            // txtnumuneID
            // 
            this.txtnumuneID.Location = new System.Drawing.Point(1109, 284);
            this.txtnumuneID.Name = "txtnumuneID";
            this.txtnumuneID.ReadOnly = true;
            this.txtnumuneID.Size = new System.Drawing.Size(161, 20);
            this.txtnumuneID.TabIndex = 27;
            this.txtnumuneID.Visible = false;
            // 
            // btnKirimSonuc
            // 
            this.btnKirimSonuc.BackColor = System.Drawing.Color.Silver;
            this.btnKirimSonuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKirimSonuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKirimSonuc.Location = new System.Drawing.Point(766, 236);
            this.btnKirimSonuc.Name = "btnKirimSonuc";
            this.btnKirimSonuc.Size = new System.Drawing.Size(141, 42);
            this.btnKirimSonuc.TabIndex = 28;
            this.btnKirimSonuc.Text = "Kırım Sonuçları";
            this.btnKirimSonuc.UseVisualStyleBackColor = false;
            this.btnKirimSonuc.Click += new System.EventHandler(this.btnKirimSonuc_Click);
            // 
            // pnldimmer
            // 
            this.pnldimmer.BackColor = System.Drawing.Color.Silver;
            this.pnldimmer.Location = new System.Drawing.Point(0, 0);
            this.pnldimmer.Name = "pnldimmer";
            this.pnldimmer.Size = new System.Drawing.Size(1270, 587);
            this.pnldimmer.TabIndex = 29;
            this.pnldimmer.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.Location = new System.Drawing.Point(5, 236);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 18);
            this.label11.TabIndex = 30;
            this.label11.Text = "Numune No:";
            // 
            // txtara
            // 
            this.txtara.Location = new System.Drawing.Point(5, 260);
            this.txtara.Name = "txtara";
            this.txtara.Size = new System.Drawing.Size(102, 20);
            this.txtara.TabIndex = 31;
            this.txtara.TextChanged += new System.EventHandler(this.txtara_TextChanged);
            // 
            // cmbAra
            // 
            this.cmbAra.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbAra.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbAra.FormattingEnabled = true;
            this.cmbAra.Location = new System.Drawing.Point(125, 260);
            this.cmbAra.Name = "cmbAra";
            this.cmbAra.Size = new System.Drawing.Size(140, 21);
            this.cmbAra.TabIndex = 32;
            this.cmbAra.SelectedIndexChanged += new System.EventHandler(this.cmbAra_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.Location = new System.Drawing.Point(139, 236);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(114, 18);
            this.label12.TabIndex = 33;
            this.label12.Text = "İnşaat Firması";
            // 
            // NumuneKayitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 586);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmbAra);
            this.Controls.Add(this.txtara);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.pnldimmer);
            this.Controls.Add(this.btnKirimSonuc);
            this.Controls.Add(this.txtnumuneID);
            this.Controls.Add(this.dateTimePickerTrh);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtHava);
            this.Controls.Add(this.txtSlump);
            this.Controls.Add(this.txtPlaka);
            this.Controls.Add(this.txtBtnSicklk);
            this.Controls.Add(this.txtNmNo);
            this.Controls.Add(this.btnRecetelerSayfa);
            this.Controls.Add(this.btnTemizle);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.dgvNumuneler);
            this.Controls.Add(this.cmbReceteler);
            this.Controls.Add(this.cmbSantraller);
            this.Controls.Add(this.cmbKatliFirmalar);
            this.Controls.Add(this.cmbFirmalar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NumuneKayitForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Numune Kayıtları";
            this.Load += new System.EventHandler(this.NumuneKayitForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NumuneKayitForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNumuneler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbFirmalar;
        private System.Windows.Forms.ComboBox cmbKatliFirmalar;
        private System.Windows.Forms.ComboBox cmbReceteler;
        private System.Windows.Forms.ComboBox cmbSantraller;
        private System.Windows.Forms.DataGridView dgvNumuneler;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnRecetelerSayfa;
        private System.Windows.Forms.TextBox txtNmNo;
        private System.Windows.Forms.TextBox txtPlaka;
        private System.Windows.Forms.TextBox txtBtnSicklk;
        private System.Windows.Forms.TextBox txtHava;
        private System.Windows.Forms.TextBox txtSlump;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dateTimePickerTrh;
        private System.Windows.Forms.TextBox txtnumuneID;
        private System.Windows.Forms.Button btnKirimSonuc;
        private System.Windows.Forms.Panel pnldimmer;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtara;
        private System.Windows.Forms.ComboBox cmbAra;
        private System.Windows.Forms.Label label12;
    }
}