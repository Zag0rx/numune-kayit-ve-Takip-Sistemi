using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace numune_kayıt
{
    public partial class BilgiVeDestek : Form
    {
        public BilgiVeDestek()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void BilgiVeDestek_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        private void BilgiVeDestek_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(217, 217, 217);
            richTextBoxBilgi.BackColor = Color.FromArgb(242, 242, 242);

            richTextBoxBilgi.ReadOnly = true;
            richTextBoxBilgi.BorderStyle = BorderStyle.FixedSingle;
            richTextBoxBilgi.ScrollBars = RichTextBoxScrollBars.Vertical;

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Uygulama Kullanım İpuçları ve Kısayollar");
            sb.AppendLine("--------------------------------------------------");
            sb.AppendLine();

            sb.AppendLine("• Genel Kısayollar:");
            sb.AppendLine("  - ESC Tuşu: Aktif olan birçok sayfayı kapatmak için kullanılabilir.");
            sb.AppendLine();

            sb.AppendLine("• Numune Kayıt Formu:");
            sb.AppendLine("  - Numune Kayıtları ve Bu Gün Kırılması Gereken Numuneler Tablolarında bir satıra Çift Tıklama: Seçili numunenin detaylarını görmek için kırım sonuclarını görmek, kayıt eklemek veya güncellemek için bir satıra çift tıklayabilirsiniz.");
            sb.AppendLine();
            sb.AppendLine("  - Firma/Santral/Katkı Ekleme: Açılan Liste Kutusuna listede olmayan bir isim yazdığınızda, 'Kaydet' düğmesine basarken bu yeni kaydı eklemeniz istenecektir onlaylarsanız yazdığınız firma vs numune kaydına ve firmalar talosuna kaydedilmiş olur.");
            sb.AppendLine();
            sb.AppendLine("  - Filtreleme: Numune kayıtları listesinin üzerindeki Açılan Liste Kutusu ile firma filtreleme, Metin Kutusu ile numune numarasına göre arama yapabilirsiniz.");
            sb.AppendLine();
            sb.AppendLine("  - Reçete '+' Düğmesi: Numune kayıt ekranında reçete Seçim Kutusunun yanındaki '+' düğmesine tıklayarak Reçeteler yönetimi sayfasına gidebilir, yeni reçete ekleyebilir ve geri döndüğünüzde eklediğiniz reçetenin otomatik seçili gelmesini sağlayabilirsiniz.");
            sb.AppendLine();

            sb.AppendLine("• Numune Detay Formu:");
            sb.AppendLine("  - Kırım Sonucu Hesaplama: Kırım sonucu (kuvvet) girilen Metin Kutularının yanındaki Etiketlerde, girilen değerin 22.5'e bölünmesiyle elde edilen dayanım değeri otomatik olarak gösterilir.");
            sb.AppendLine();
            sb.AppendLine("  - Kaydet/Güncelle: Kırım sonuçları için 'Kaydet' düğmesi, o numune için ilk kez sonuç giriyorsanız yeni kayıt oluşturur. Daha önce kayıt varsa, mevcut kaydı günceller (veya ayrı 'Güncelle' düğmesi aktif olur).");
            sb.AppendLine();

            sb.AppendLine("• Diğer Formlar:");
            sb.AppendLine("  - Tüm veri yönetim formlarında (Firma, Reçete, Santral, Katkı) benzer şekilde Ekle, Güncelle, Sil ve Temizle düğmeleri bulunmaktadır.");
            sb.AppendLine("  - Listeden bir kayıt seçildiğinde Güncelle ve Sil düğmeleri aktif olurken, Kaydet düğmesi pasifleşir.");
            sb.AppendLine();

            sb.AppendLine("Daha fazla yardım veya teknik destek için lütfen zag0rx46@gmail.com adresindem iletişime geçin."); 

            richTextBoxBilgi.Text = sb.ToString();

            richTextBoxBilgi.Font = new Font("Segoe UI", 10F);
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
