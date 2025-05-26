using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace numune_kayıt
{
    public partial class NumuneDetay : Form
    {
        private int _gelenNumuneId;
        private int _gelenReceteId;
        private int? _mevcutKirimSonucId = null;
        private string connectionString = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
        public NumuneDetay(int numuneId, int receteId)
        {
            InitializeComponent();
            this.KeyPreview= true;
            _gelenNumuneId = numuneId;
            _gelenReceteId = receteId;
            this.Shown += NumuneDetay_Shown;

        }
        private void NumuneDetay_Shown(object sender, EventArgs e)
        {
            txtGun1Sonuc.Focus();

            pictureBox1.MouseDown += (s, ev) =>
            {
                pictureBox1.BackColor = Color.FromArgb(140, 140, 140);
            };

            txtGun1Sonuc.BackColor = Color.FromArgb(242, 242, 242);
            txtGun2Sonuc.BackColor = Color.FromArgb(242, 242, 242);
            txtGun3Sonuc.BackColor = Color.FromArgb(242, 242, 242);
            txtGun7Sonuc.BackColor = Color.FromArgb(242, 242, 242);
            txtGun14Sonuc.BackColor = Color.FromArgb(242, 242, 242);
            txtGun28_1Sonuc.BackColor = Color.FromArgb(242, 242, 242);
            txtGun28_2Sonuc.BackColor = Color.FromArgb(242, 242, 242);
            txtGun28_3Sonuc.BackColor = Color.FromArgb(242, 242, 242);

            label18.BackColor = Color.FromArgb(204, 204, 204);
            label19.BackColor = Color.FromArgb(204, 204, 204);
            label20.BackColor = Color.FromArgb(204, 204, 204);

            btnkaydet.FlatAppearance.BorderColor = btnkaydet.BackColor;
            btnkaydet.FlatAppearance.MouseOverBackColor = Color.FromArgb(140, 140, 140);

            btnguncelle.FlatAppearance.BorderColor = btnguncelle.BackColor;
            btnguncelle.FlatAppearance.MouseOverBackColor = Color.FromArgb(140, 140, 140);

            panel1.BackColor = Color.FromArgb(217, 217, 217);
            panel2.BackColor = Color.FromArgb(217, 217, 217);
            panel3.BackColor = Color.FromArgb(217, 217, 217);

            this.BackColor = Color.FromArgb(140, 140, 140);   
        }
        private void NumuneDetay_Load(object sender, EventArgs e)
        {
            NumuneBilgileriniYukle();
            ReceteBilgileriniYukle();
            KirimSonuclariniYukle();


            txtGun1Sonuc.TextChanged += (s, ev) => HesaplaVeGosterDayanim(txtGun1Sonuc, lblGun1);
            txtGun2Sonuc.TextChanged += (s, ev) => HesaplaVeGosterDayanim(txtGun2Sonuc, lblGun2);
            txtGun3Sonuc.TextChanged += (s, ev) => HesaplaVeGosterDayanim(txtGun3Sonuc, lblGun3);
            txtGun7Sonuc.TextChanged += (s, ev) => HesaplaVeGosterDayanim(txtGun7Sonuc, lblGun7);
            txtGun14Sonuc.TextChanged += (s, ev) => HesaplaVeGosterDayanim(txtGun14Sonuc, lblGun14);
            txtGun28_1Sonuc.TextChanged += (s, ev) => HesaplaVeGosterDayanim(txtGun28_1Sonuc, lblGun28_1);
            txtGun28_2Sonuc.TextChanged += (s, ev) => HesaplaVeGosterDayanim(txtGun28_2Sonuc, lblGun28_2);
            txtGun28_3Sonuc.TextChanged += (s, ev) => HesaplaVeGosterDayanim(txtGun28_3Sonuc, lblGun28_3);

            HesaplaVeGosterDayanim(txtGun1Sonuc, lblGun1);
            HesaplaVeGosterDayanim(txtGun2Sonuc, lblGun2);
            HesaplaVeGosterDayanim(txtGun3Sonuc, lblGun3);
            HesaplaVeGosterDayanim(txtGun7Sonuc, lblGun7);
            HesaplaVeGosterDayanim(txtGun14Sonuc, lblGun14);
            HesaplaVeGosterDayanim(txtGun28_1Sonuc, lblGun28_1);
            HesaplaVeGosterDayanim(txtGun28_2Sonuc, lblGun28_2);
            HesaplaVeGosterDayanim(txtGun28_3Sonuc, lblGun28_3);

            
        }
        private void KirimSonuclariniYukle()
        {
            string query = "SELECT kirimSonucId, gun1, gun2, gun3, gun7, gun14, gun28_1, gun28_2, gun28_3 FROM KirimSonuclari WHERE numuneId = @numuneId";
            _mevcutKirimSonucId = null; 

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@numuneId", _gelenNumuneId);
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            _mevcutKirimSonucId = Convert.ToInt32(reader["kirimSonucId"]); 

                            txtGun1Sonuc.Text = reader["gun1"] != DBNull.Value ? reader["gun1"].ToString() : string.Empty;
                            txtGun2Sonuc.Text = reader["gun2"] != DBNull.Value ? reader["gun2"].ToString() : string.Empty;
                            txtGun3Sonuc.Text = reader["gun3"] != DBNull.Value ? reader["gun3"].ToString() : string.Empty;
                            txtGun7Sonuc.Text = reader["gun7"] != DBNull.Value ? reader["gun7"].ToString() : string.Empty;
                            txtGun14Sonuc.Text = reader["gun14"] != DBNull.Value ? reader["gun14"].ToString() : string.Empty;
                            txtGun28_1Sonuc.Text = reader["gun28_1"] != DBNull.Value ? reader["gun28_1"].ToString() : string.Empty;
                            txtGun28_2Sonuc.Text = reader["gun28_2"] != DBNull.Value ? reader["gun28_2"].ToString() : string.Empty;
                            txtGun28_3Sonuc.Text = reader["gun28_3"] != DBNull.Value ? reader["gun28_3"].ToString() : string.Empty;
                        }
                        else
                        {
                            _mevcutKirimSonucId = null;
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Kırım sonuçları yüklenirken hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            } 
        }
        private void NumuneBilgileriniYukle()
        {
            string query = @"
                SELECT 
                    N.numuneNo, N.alinmaTarihi, N.mikserPlaka, N.sicaklik, N.slumpDegeriCm, N.havaIcerigiYuzde,
                    IFirma.firmaAdi AS MusteriFirmaAdi,
                    S.santralAdi,
                    KF.firmaAdi AS KatkiFirmasiAdi
                FROM Numuneler N
                LEFT JOIN InsaatFirmalari IFirma ON N.musteriFirmaId = IFirma.firmaId
                LEFT JOIN Santraller S ON N.santralId = S.santralId
                LEFT JOIN KatkiFirmalari KF ON N.katkiFirmaId = KF.katkiFirmaId
                WHERE N.numuneId = @numuneId";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@numuneId", _gelenNumuneId);
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            lblNumuneNo.Text = reader["numuneNo"].ToString();
                            lblAlinmaTarihi.Text = Convert.ToDateTime(reader["alinmaTarihi"]).ToString("dd.MM.yyyy");
                            lblMusteriFirma.Text = reader["MusteriFirmaAdi"].ToString();
                            lblSantral.Text = reader["santralAdi"].ToString();
                            lblKatkiFirmasi.Text = reader["KatkiFirmasiAdi"] != DBNull.Value ? reader["KatkiFirmasiAdi"].ToString() : "Yok";
                            lblMikserPlaka.Text = reader["mikserPlaka"].ToString();
                            lblSicaklik.Text = reader["sicaklik"].ToString();
                            lblSlump.Text = reader["slumpDegeriCm"].ToString();
                            lblHava.Text = reader["havaIcerigiYuzde"].ToString();
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Numune bilgileri yüklenirken hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private decimal? ParseNullableDecimal(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return null;
            }
            if (decimal.TryParse(text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
        private bool GetKirimSonucValues(out Dictionary<string, decimal?> sonuclar)
        {
            sonuclar = new Dictionary<string, decimal?>();
            try
            {
                sonuclar["gun1"] = ParseNullableDecimal(txtGun1Sonuc.Text);
                sonuclar["gun2"] = ParseNullableDecimal(txtGun2Sonuc.Text);
                sonuclar["gun3"] = ParseNullableDecimal(txtGun3Sonuc.Text);
                sonuclar["gun7"] = ParseNullableDecimal(txtGun7Sonuc.Text);
                sonuclar["gun14"] = ParseNullableDecimal(txtGun14Sonuc.Text);
                sonuclar["gun28_1"] = ParseNullableDecimal(txtGun28_1Sonuc.Text);
                sonuclar["gun28_2"] = ParseNullableDecimal(txtGun28_2Sonuc.Text);
                sonuclar["gun28_3"] = ParseNullableDecimal(txtGun28_3Sonuc.Text);
                return true; // Tüm parse işlemleri başarılı veya değerler null
            }
            catch (FormatException ex) // Eğer ParseNullableDecimal exception fırlatırsa
            {
                MessageBox.Show(ex.Message, "Geçersiz Sayısal Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        private void ReceteBilgileriniYukle()
        {
            string query = "SELECT * FROM Receteler WHERE receteId = @receteId"; 

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@receteId", _gelenReceteId);
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            lblReceteKodu.Text = reader["ReceteKodu"].ToString();
                            lblBetonSinifi.Text = reader["betonSinifi"].ToString();
                            lblCimentoMiktari.Text = reader["Cimento"].ToString();
                            lblsu.Text = reader["Su"].ToString();
                            lblkul.Text = reader["ucucuKul"].ToString();
                            lblKatki_1.Text = reader["Katki1"].ToString();
                            lblKatki_2.Text = reader["Katki2"].ToString();
                            lbl0_4.Text = reader["Agrega1"].ToString();
                            lbl05_15.Text = reader["Agrega2"].ToString();
                            lbl15_22.Text = reader["Agrega3"].ToString();
                            lblCimentoSinifi.Text = reader["cimentoTipi"].ToString();
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Reçete bilgileri yüklenirken hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void NumuneDetay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        
        private void btnkaydet_Click(object sender, EventArgs e)
        {
            if (!GetKirimSonucValues(out Dictionary<string, decimal?> sonuclar))
            {
                return; // Geçersiz giriş varsa işlemi durdur
            }

            string query;
            bool isUpdate = _mevcutKirimSonucId.HasValue;

            if (isUpdate) // Mevcut bir kayıt varsa GÜNCELLE
            {
                query = @"UPDATE KirimSonuclari SET 
                        gun1 = ISNULL(@gun1, gun1), 
                        gun2 = ISNULL(@gun2, gun2), 
                        gun3 = ISNULL(@gun3, gun3), 
                        gun7 = ISNULL(@gun7, gun7), 
                        gun14 = ISNULL(@gun14, gun14), 
                        gun28_1 = ISNULL(@gun28_1, gun28_1), 
                        gun28_2 = ISNULL(@gun28_2, gun28_2), 
                        gun28_3 = ISNULL(@gun28_3, gun28_3)
                      WHERE kirimSonucId = @kirimSonucId AND numuneId = @numuneId";
            }
            else // Mevcut bir kayıt yoksa YENİ EKLE
            {
                query = @"INSERT INTO KirimSonuclari 
                        (numuneId, gun1, gun2, gun3, gun7, gun14, gun28_1, gun28_2, gun28_3) 
                      VALUES 
                        (@numuneId, @gun1, @gun2, @gun3, @gun7, @gun14, @gun28_1, @gun28_2, @gun28_3);
                      SELECT SCOPE_IDENTITY();";
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@numuneId", _gelenNumuneId);
                    cmd.Parameters.AddWithValue("@gun1", (object)sonuclar["gun1"] ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@gun2", (object)sonuclar["gun2"] ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@gun3", (object)sonuclar["gun3"] ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@gun7", (object)sonuclar["gun7"] ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@gun14", (object)sonuclar["gun14"] ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@gun28_1", (object)sonuclar["gun28_1"] ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@gun28_2", (object)sonuclar["gun28_2"] ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@gun28_3", (object)sonuclar["gun28_3"] ?? DBNull.Value);

                    if (isUpdate)
                    {
                        cmd.Parameters.AddWithValue("@kirimSonucId", _mevcutKirimSonucId.Value);
                    }

                    try
                    {
                        conn.Open();
                        if (isUpdate)
                        {
                            int result = cmd.ExecuteNonQuery();
                            if (result > 0)
                            {
                                MessageBox.Show("Kırım sonuçları başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Kırım sonuçları güncellenirken bir sorun oluştu veya değişiklik yapılmadı.", "Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else // INSERT işlemi
                        {
                            object newId = cmd.ExecuteScalar();
                            if (newId != null && newId != DBNull.Value)
                            {
                                _mevcutKirimSonucId = Convert.ToInt32(newId); // Yeni ID'yi sakla
                                MessageBox.Show("Kırım sonuçları başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                // Artık kayıt eklendiği için buton durumları bir sonraki kayıtta "güncelle" modunda olacak
                                // UpdateKirimButtonStates(); // Eğer butonları enable/disable eden bir mantığınız varsa burada çağırın
                            }
                            else
                            {
                                MessageBox.Show("Kırım sonuçları eklenirken bir sorun oluştu (ID alınamadı).", "Ekleme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        // Her kayıttan sonra buton durumunu güncelleyebiliriz (eğer UpdateKirimButtonStates metodunu kullanıyorsak)
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Kırım sonuçları {(isUpdate ? "güncellenirken" : "eklenirken")} veritabanı hatası: {ex.Message}", "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void HesaplaVeGosterDayanim(TextBox kaynakTextBox, Label hedefLabel)
        {
            if (string.IsNullOrWhiteSpace(kaynakTextBox.Text))
            {
                hedefLabel.Text = string.Empty; 
                return;
            }

            if (decimal.TryParse(kaynakTextBox.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal girilenKuvvet))
            {
                if (girilenKuvvet >= 0) // Negatif kuvvet anlamsız olacağından kontrol edilebilir
                {
                    decimal dayanim = girilenKuvvet / 22.5m; // 22.5m -> m son eki decimal olduğunu belirtir
                    hedefLabel.Text = dayanim.ToString("N2"); // "N2" formatı sayıyı 2 ondalık basamakla gösterir (örn: 25.67)
                                                              // Farklı formatlar için "F2", "0.00" vb. kullanabilirsiniz.
                }
                else
                {
                    hedefLabel.Text = "Geçersiz"; // Negatif değer için
                }
            }
            else
            {
                hedefLabel.Text = "Hatalı Giriş"; // Sayıya çevrilemiyorsa
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            if (!_mevcutKirimSonucId.HasValue)
            {
                MessageBox.Show("Güncellenecek mevcut kırım sonucu kaydı bulunamadı. Lütfen önce kayıt ekleyin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!GetKirimSonucValues(out Dictionary<string, decimal?> sonuclar))
            {
                return; // Geçersiz giriş varsa işlemi durdur
            }

            string query = @"UPDATE KirimSonuclari SET 
                        gun1 = @gun1, gun2 = @gun2, gun3 = @gun3, gun7 = @gun7, gun14 = @gun14, 
                        gun28_1 = @gun28_1, gun28_2 = @gun28_2, gun28_3 = @gun28_3
                      WHERE kirimSonucId = @kirimSonucId AND numuneId = @numuneId";
            // numuneId ile de kontrol etmek iyi bir pratiktir.

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@kirimSonucId", _mevcutKirimSonucId.Value);
                    cmd.Parameters.AddWithValue("@numuneId", _gelenNumuneId); // Güvenlik için ekleyebiliriz
                    cmd.Parameters.AddWithValue("@gun1", (object)sonuclar["gun1"] ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@gun2", (object)sonuclar["gun2"] ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@gun3", (object)sonuclar["gun3"] ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@gun7", (object)sonuclar["gun7"] ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@gun14", (object)sonuclar["gun14"] ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@gun28_1", (object)sonuclar["gun28_1"] ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@gun28_2", (object)sonuclar["gun28_2"] ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@gun28_3", (object)sonuclar["gun28_3"] ?? DBNull.Value);

                    try
                    {
                        conn.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Kırım sonuçları başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Buton durumları zaten doğru olmalı (Ekle pasif, Güncelle aktif)
                        }
                        else
                        {
                            MessageBox.Show("Kırım sonuçları güncellenirken bir sorun oluştu veya değişiklik yapılmadı.", "Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Kırım sonuçları güncellenirken veritabanı hatası: " + ex.Message, "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
