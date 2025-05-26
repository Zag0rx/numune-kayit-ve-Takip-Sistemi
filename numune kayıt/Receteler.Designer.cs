namespace numune_kayıt
{
    partial class Receteler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Receteler));
            this.dgvReceteler = new System.Windows.Forms.DataGridView();
            this.txtReceteId = new System.Windows.Forms.TextBox();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbxBetonsinifi = new System.Windows.Forms.ComboBox();
            this.txtCimento = new System.Windows.Forms.TextBox();
            this.txtKul = new System.Windows.Forms.TextBox();
            this.txtKatki_2 = new System.Windows.Forms.TextBox();
            this.txtKatki = new System.Windows.Forms.TextBox();
            this.txt15_22 = new System.Windows.Forms.TextBox();
            this.txt5_15 = new System.Windows.Forms.TextBox();
            this.txt04 = new System.Windows.Forms.TextBox();
            this.txtSu = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtRctkod = new System.Windows.Forms.TextBox();
            this.cmbCimentoSinifi = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceteler)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvReceteler
            // 
            this.dgvReceteler.AllowUserToAddRows = false;
            this.dgvReceteler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvReceteler.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgvReceteler.Location = new System.Drawing.Point(432, 0);
            this.dgvReceteler.MultiSelect = false;
            this.dgvReceteler.Name = "dgvReceteler";
            this.dgvReceteler.ReadOnly = true;
            this.dgvReceteler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReceteler.Size = new System.Drawing.Size(735, 468);
            this.dgvReceteler.TabIndex = 1;
            this.dgvReceteler.SelectionChanged += new System.EventHandler(this.dgvReceteler_SelectionChanged);
            // 
            // txtReceteId
            // 
            this.txtReceteId.Location = new System.Drawing.Point(640, 0);
            this.txtReceteId.Name = "txtReceteId";
            this.txtReceteId.Size = new System.Drawing.Size(160, 20);
            this.txtReceteId.TabIndex = 7;
            this.txtReceteId.Visible = false;
            // 
            // btnEkle
            // 
            this.btnEkle.BackColor = System.Drawing.Color.Silver;
            this.btnEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEkle.Location = new System.Drawing.Point(12, 413);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(99, 43);
            this.btnEkle.TabIndex = 8;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = false;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.BackColor = System.Drawing.Color.Silver;
            this.btnGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGuncelle.Location = new System.Drawing.Point(117, 413);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(99, 43);
            this.btnGuncelle.TabIndex = 9;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = false;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnTemizle
            // 
            this.btnTemizle.BackColor = System.Drawing.Color.Silver;
            this.btnTemizle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTemizle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTemizle.Location = new System.Drawing.Point(327, 413);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(99, 43);
            this.btnTemizle.TabIndex = 11;
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.UseVisualStyleBackColor = false;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.Silver;
            this.btnSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSil.Location = new System.Drawing.Point(222, 413);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(99, 43);
            this.btnSil.TabIndex = 10;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Beton Sınıfı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(12, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Çimento:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(12, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Uçucu Kül:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(12, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Katkı:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(12, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 16);
            this.label5.TabIndex = 19;
            this.label5.Text = "Katkı\\2:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(12, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 16);
            this.label6.TabIndex = 18;
            this.label6.Text = "Su:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(9, 333);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "15-22mm çakıl:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(12, 297);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 16);
            this.label8.TabIndex = 16;
            this.label8.Text = "5-15mm çakıl:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(12, 261);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 16);
            this.label9.TabIndex = 20;
            this.label9.Text = "0-4mm kum:";
            // 
            // cmbxBetonsinifi
            // 
            this.cmbxBetonsinifi.FormattingEnabled = true;
            this.cmbxBetonsinifi.Location = new System.Drawing.Point(117, 8);
            this.cmbxBetonsinifi.Name = "cmbxBetonsinifi";
            this.cmbxBetonsinifi.Size = new System.Drawing.Size(157, 21);
            this.cmbxBetonsinifi.TabIndex = 21;
            // 
            // txtCimento
            // 
            this.txtCimento.Location = new System.Drawing.Point(117, 80);
            this.txtCimento.Name = "txtCimento";
            this.txtCimento.Size = new System.Drawing.Size(157, 20);
            this.txtCimento.TabIndex = 22;
            // 
            // txtKul
            // 
            this.txtKul.Location = new System.Drawing.Point(117, 116);
            this.txtKul.Name = "txtKul";
            this.txtKul.Size = new System.Drawing.Size(157, 20);
            this.txtKul.TabIndex = 23;
            // 
            // txtKatki_2
            // 
            this.txtKatki_2.Location = new System.Drawing.Point(117, 188);
            this.txtKatki_2.Name = "txtKatki_2";
            this.txtKatki_2.Size = new System.Drawing.Size(157, 20);
            this.txtKatki_2.TabIndex = 25;
            // 
            // txtKatki
            // 
            this.txtKatki.Location = new System.Drawing.Point(117, 152);
            this.txtKatki.Name = "txtKatki";
            this.txtKatki.Size = new System.Drawing.Size(157, 20);
            this.txtKatki.TabIndex = 24;
            // 
            // txt15_22
            // 
            this.txt15_22.Location = new System.Drawing.Point(117, 332);
            this.txt15_22.Name = "txt15_22";
            this.txt15_22.Size = new System.Drawing.Size(157, 20);
            this.txt15_22.TabIndex = 29;
            // 
            // txt5_15
            // 
            this.txt5_15.Location = new System.Drawing.Point(117, 296);
            this.txt5_15.Name = "txt5_15";
            this.txt5_15.Size = new System.Drawing.Size(157, 20);
            this.txt5_15.TabIndex = 28;
            // 
            // txt04
            // 
            this.txt04.Location = new System.Drawing.Point(117, 260);
            this.txt04.Name = "txt04";
            this.txt04.Size = new System.Drawing.Size(157, 20);
            this.txt04.TabIndex = 27;
            // 
            // txtSu
            // 
            this.txtSu.Location = new System.Drawing.Point(117, 224);
            this.txtSu.Name = "txtSu";
            this.txtSu.Size = new System.Drawing.Size(157, 20);
            this.txtSu.TabIndex = 26;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(9, 369);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 16);
            this.label10.TabIndex = 30;
            this.label10.Text = "Çimento Sınıfı";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.Location = new System.Drawing.Point(12, 45);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 16);
            this.label11.TabIndex = 33;
            this.label11.Text = "Reçete kodu:";
            // 
            // txtRctkod
            // 
            this.txtRctkod.Location = new System.Drawing.Point(117, 44);
            this.txtRctkod.Name = "txtRctkod";
            this.txtRctkod.Size = new System.Drawing.Size(157, 20);
            this.txtRctkod.TabIndex = 34;
            // 
            // cmbCimentoSinifi
            // 
            this.cmbCimentoSinifi.FormattingEnabled = true;
            this.cmbCimentoSinifi.Location = new System.Drawing.Point(117, 368);
            this.cmbCimentoSinifi.Name = "cmbCimentoSinifi";
            this.cmbCimentoSinifi.Size = new System.Drawing.Size(157, 21);
            this.cmbCimentoSinifi.TabIndex = 35;
            // 
            // Receteler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 468);
            this.Controls.Add(this.cmbCimentoSinifi);
            this.Controls.Add(this.txtRctkod);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt15_22);
            this.Controls.Add(this.txt5_15);
            this.Controls.Add(this.txt04);
            this.Controls.Add(this.txtSu);
            this.Controls.Add(this.txtKatki_2);
            this.Controls.Add(this.txtKatki);
            this.Controls.Add(this.txtKul);
            this.Controls.Add(this.txtCimento);
            this.Controls.Add(this.cmbxBetonsinifi);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTemizle);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.txtReceteId);
            this.Controls.Add(this.dgvReceteler);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Receteler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receteler";
            this.Load += new System.EventHandler(this.Receteler_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Receteler_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceteler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReceteler;
        private System.Windows.Forms.TextBox txtReceteId;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbxBetonsinifi;
        private System.Windows.Forms.TextBox txtCimento;
        private System.Windows.Forms.TextBox txtKul;
        private System.Windows.Forms.TextBox txtKatki_2;
        private System.Windows.Forms.TextBox txtKatki;
        private System.Windows.Forms.TextBox txt15_22;
        private System.Windows.Forms.TextBox txt5_15;
        private System.Windows.Forms.TextBox txt04;
        private System.Windows.Forms.TextBox txtSu;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtRctkod;
        private System.Windows.Forms.ComboBox cmbCimentoSinifi;
    }
}