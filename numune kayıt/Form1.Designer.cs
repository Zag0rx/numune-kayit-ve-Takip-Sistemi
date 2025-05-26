namespace numune_kayıt
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnNumuneKayit = new System.Windows.Forms.Button();
            this.btnReceteler = new System.Windows.Forms.Button();
            this.btnSantral = new System.Windows.Forms.Button();
            this.btnKatki = new System.Windows.Forms.Button();
            this.btnİnsaat = new System.Windows.Forms.Button();
            this.dgvBugunkuKirimlar = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvYarinkiKirimlar = new System.Windows.Forms.DataGridView();
            this.pnlAnaMenuDimmer = new System.Windows.Forms.Panel();
            this.btnBilgiDestek = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBugunkuKirimlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvYarinkiKirimlar)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNumuneKayit
            // 
            this.btnNumuneKayit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNumuneKayit.Font = new System.Drawing.Font("Microsoft Tai Le", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNumuneKayit.Location = new System.Drawing.Point(936, 12);
            this.btnNumuneKayit.Name = "btnNumuneKayit";
            this.btnNumuneKayit.Size = new System.Drawing.Size(244, 66);
            this.btnNumuneKayit.TabIndex = 0;
            this.btnNumuneKayit.Text = "Numune Kayıtları";
            this.btnNumuneKayit.UseVisualStyleBackColor = true;
            this.btnNumuneKayit.Click += new System.EventHandler(this.btnNumuneKayit_Click);
            // 
            // btnReceteler
            // 
            this.btnReceteler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceteler.Font = new System.Drawing.Font("Microsoft Tai Le", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceteler.Location = new System.Drawing.Point(963, 84);
            this.btnReceteler.Name = "btnReceteler";
            this.btnReceteler.Size = new System.Drawing.Size(217, 61);
            this.btnReceteler.TabIndex = 2;
            this.btnReceteler.Text = "Reçeteler";
            this.btnReceteler.UseVisualStyleBackColor = true;
            this.btnReceteler.Click += new System.EventHandler(this.btnReceteler_Click);
            // 
            // btnSantral
            // 
            this.btnSantral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSantral.Font = new System.Drawing.Font("Microsoft Tai Le", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSantral.Location = new System.Drawing.Point(989, 151);
            this.btnSantral.Name = "btnSantral";
            this.btnSantral.Size = new System.Drawing.Size(191, 54);
            this.btnSantral.TabIndex = 3;
            this.btnSantral.Text = "Santraller";
            this.btnSantral.UseVisualStyleBackColor = true;
            this.btnSantral.Click += new System.EventHandler(this.btnSantral_Click);
            // 
            // btnKatki
            // 
            this.btnKatki.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKatki.Font = new System.Drawing.Font("Microsoft Tai Le", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKatki.Location = new System.Drawing.Point(989, 211);
            this.btnKatki.Name = "btnKatki";
            this.btnKatki.Size = new System.Drawing.Size(191, 54);
            this.btnKatki.TabIndex = 4;
            this.btnKatki.Text = "Katkı Firmaları";
            this.btnKatki.UseVisualStyleBackColor = true;
            this.btnKatki.Click += new System.EventHandler(this.btnKatki_Click);
            // 
            // btnİnsaat
            // 
            this.btnİnsaat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnİnsaat.Font = new System.Drawing.Font("Microsoft Tai Le", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnİnsaat.Location = new System.Drawing.Point(989, 271);
            this.btnİnsaat.Name = "btnİnsaat";
            this.btnİnsaat.Size = new System.Drawing.Size(191, 54);
            this.btnİnsaat.TabIndex = 5;
            this.btnİnsaat.Text = "İnşaat Firmaları";
            this.btnİnsaat.UseVisualStyleBackColor = true;
            this.btnİnsaat.Click += new System.EventHandler(this.btnİnsaat_Click);
            // 
            // dgvBugunkuKirimlar
            // 
            this.dgvBugunkuKirimlar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBugunkuKirimlar.Location = new System.Drawing.Point(12, 34);
            this.dgvBugunkuKirimlar.Name = "dgvBugunkuKirimlar";
            this.dgvBugunkuKirimlar.Size = new System.Drawing.Size(448, 377);
            this.dgvBugunkuKirimlar.TabIndex = 6;
            this.dgvBugunkuKirimlar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBugunkuKirimlar_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(322, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "BUGÜN KIRILMASI GEREKEN NUMUNELER";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Impact", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(465, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(313, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "YARIN KIRILMASI GEREKEN NUMUNELER";
            // 
            // dgvYarinkiKirimlar
            // 
            this.dgvYarinkiKirimlar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvYarinkiKirimlar.Location = new System.Drawing.Point(470, 34);
            this.dgvYarinkiKirimlar.Name = "dgvYarinkiKirimlar";
            this.dgvYarinkiKirimlar.Size = new System.Drawing.Size(448, 377);
            this.dgvYarinkiKirimlar.TabIndex = 8;
            this.dgvYarinkiKirimlar.SelectionChanged += new System.EventHandler(this.dgvYarinkiKirimlar_SelectionChanged);
            // 
            // pnlAnaMenuDimmer
            // 
            this.pnlAnaMenuDimmer.BackColor = System.Drawing.Color.Silver;
            this.pnlAnaMenuDimmer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAnaMenuDimmer.Location = new System.Drawing.Point(0, 0);
            this.pnlAnaMenuDimmer.Name = "pnlAnaMenuDimmer";
            this.pnlAnaMenuDimmer.Size = new System.Drawing.Size(1192, 423);
            this.pnlAnaMenuDimmer.TabIndex = 10;
            this.pnlAnaMenuDimmer.Visible = false;
            // 
            // btnBilgiDestek
            // 
            this.btnBilgiDestek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBilgiDestek.Font = new System.Drawing.Font("Microsoft Tai Le", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBilgiDestek.Location = new System.Drawing.Point(989, 331);
            this.btnBilgiDestek.Name = "btnBilgiDestek";
            this.btnBilgiDestek.Size = new System.Drawing.Size(191, 54);
            this.btnBilgiDestek.TabIndex = 11;
            this.btnBilgiDestek.Text = "Bilgi ve Destek\r\n";
            this.btnBilgiDestek.UseVisualStyleBackColor = true;
            this.btnBilgiDestek.Click += new System.EventHandler(this.btnBilgiDestek_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 423);
            this.Controls.Add(this.btnBilgiDestek);
            this.Controls.Add(this.pnlAnaMenuDimmer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvYarinkiKirimlar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvBugunkuKirimlar);
            this.Controls.Add(this.btnİnsaat);
            this.Controls.Add(this.btnKatki);
            this.Controls.Add(this.btnSantral);
            this.Controls.Add(this.btnReceteler);
            this.Controls.Add(this.btnNumuneKayit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Numune Kaydı Ve Takibi";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBugunkuKirimlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvYarinkiKirimlar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNumuneKayit;
        private System.Windows.Forms.Button btnReceteler;
        private System.Windows.Forms.Button btnSantral;
        private System.Windows.Forms.Button btnKatki;
        private System.Windows.Forms.Button btnİnsaat;
        private System.Windows.Forms.DataGridView dgvBugunkuKirimlar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvYarinkiKirimlar;
        private System.Windows.Forms.Panel pnlAnaMenuDimmer;
        private System.Windows.Forms.Button btnBilgiDestek;
    }
}

