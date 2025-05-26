namespace numune_kayıt
{
    partial class BilgiVeDestek
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BilgiVeDestek));
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBoxBilgi = new System.Windows.Forms.RichTextBox();
            this.btnGeri = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnGeri)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(219, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kullanım İpuçları ve Kısa Yollar";
            // 
            // richTextBoxBilgi
            // 
            this.richTextBoxBilgi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxBilgi.Location = new System.Drawing.Point(40, 62);
            this.richTextBoxBilgi.Name = "richTextBoxBilgi";
            this.richTextBoxBilgi.ReadOnly = true;
            this.richTextBoxBilgi.Size = new System.Drawing.Size(663, 494);
            this.richTextBoxBilgi.TabIndex = 2;
            this.richTextBoxBilgi.Text = "";
            // 
            // btnGeri
            // 
            this.btnGeri.Image = global::numune_kayıt.Properties.Resources.dark_gray_arrow_41x38;
            this.btnGeri.Location = new System.Drawing.Point(690, 9);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new System.Drawing.Size(41, 38);
            this.btnGeri.TabIndex = 63;
            this.btnGeri.TabStop = false;
            this.btnGeri.Click += new System.EventHandler(this.btnGeri_Click);
            // 
            // BilgiVeDestek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 595);
            this.Controls.Add(this.btnGeri);
            this.Controls.Add(this.richTextBoxBilgi);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BilgiVeDestek";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bilgi Ve Destek";
            this.Load += new System.EventHandler(this.BilgiVeDestek_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BilgiVeDestek_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.btnGeri)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBoxBilgi;
        private System.Windows.Forms.PictureBox btnGeri;
    }
}