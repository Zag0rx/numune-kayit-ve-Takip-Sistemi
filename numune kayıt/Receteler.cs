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

namespace numune_kayıt
{
    public partial class Receteler : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;

        public int? YeniEklenenReceteId { get; private set; }

        public Receteler()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.YeniEklenenReceteId = null; 
            this.Shown += Receteler_Shown;
        }
        private void Receteler_Shown(object sender, EventArgs e)
        {
            btnEkle.FlatAppearance.BorderSize = 0;
            btnEkle.FlatAppearance.MouseOverBackColor = Color.FromArgb(140, 140, 140);
            btnEkle.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 100, 100);

            btnGuncelle.FlatAppearance.BorderSize = 0;
            btnGuncelle.FlatAppearance.MouseOverBackColor = Color.FromArgb(140, 140, 140);
            btnGuncelle.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 100, 100);

            btnSil.FlatAppearance.BorderSize = 0;
            btnSil.FlatAppearance.MouseOverBackColor = Color.FromArgb(140, 140, 140);
            btnSil.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 100, 100);

            btnTemizle.FlatAppearance.BorderSize = 0;
            btnTemizle.FlatAppearance.MouseOverBackColor = Color.FromArgb(140, 140, 140);
            btnTemizle.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 100, 100);

            txtCimento.BackColor = Color.FromArgb(242, 242, 242);
            txtSu.BackColor = Color.FromArgb(242, 242, 242);
            txt04.BackColor = Color.FromArgb(242, 242, 242);
            txt5_15.BackColor = Color.FromArgb(242, 242, 242);
            txt15_22.BackColor = Color.FromArgb(242, 242, 242);
            txtKatki.BackColor = Color.FromArgb(242, 242, 242);
            txtKatki_2.BackColor = Color.FromArgb(242, 242, 242);
            txtKul.BackColor = Color.FromArgb(242, 242, 242);
            txtRctkod.BackColor = Color.FromArgb(242, 242, 242);

            cmbxBetonsinifi.BackColor = Color.FromArgb(242, 242, 242);
            cmbCimentoSinifi.BackColor = Color.FromArgb(242, 242, 242);

            dgvReceteler.BackgroundColor = Color.FromArgb(240, 240, 240);
            dgvReceteler.GridColor = Color.FromArgb(224, 224, 224);

            DataGridViewCellStyle defaultCellStyle = new DataGridViewCellStyle();
            defaultCellStyle.BackColor = Color.White;
            defaultCellStyle.ForeColor = Color.FromArgb(50, 50, 50);
            defaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            defaultCellStyle.SelectionForeColor = Color.White;
            defaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            defaultCellStyle.Padding = new Padding(5, 2, 5, 2);
            dgvReceteler.DefaultCellStyle = defaultCellStyle;

            DataGridViewCellStyle alternatingCellStyle = new DataGridViewCellStyle();
            alternatingCellStyle.BackColor = Color.FromArgb(248, 249, 250);
            alternatingCellStyle.ForeColor = Color.FromArgb(50, 50, 50);
            alternatingCellStyle.SelectionBackColor = Color.FromArgb(62, 162, 229);
            alternatingCellStyle.SelectionForeColor = Color.White;
            dgvReceteler.AlternatingRowsDefaultCellStyle = alternatingCellStyle;

            dgvReceteler.EnableHeadersVisualStyles = false;
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            columnHeaderStyle.BackColor = Color.FromArgb(70, 70, 70);    
            columnHeaderStyle.ForeColor = Color.White;               
            columnHeaderStyle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold); 
            columnHeaderStyle.Alignment = DataGridViewContentAlignment.TopLeft; 
            columnHeaderStyle.Padding = new Padding(5, 5, 5, 5); 
            dgvReceteler.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
            dgvReceteler.ColumnHeadersHeight = 30;

            dgvReceteler.BorderStyle = BorderStyle.None; 
            dgvReceteler.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            this.BackColor = Color.FromArgb(217, 217, 217);
            dgvReceteler.ClearSelection(); 
        }
        private void BetonSinifiComboBoxDoldur()
        {
            
            string[] betonSiniflari = {
                                        "C16/20",
                                        "C20/25",
                                        "C25/30",
                                        "C30/37",
                                        "C35/45",
                                        "C40/50",
                                        "C45/55",
                                        "C50/60"
        
            };

            try
            {
                
                if (this.Controls.ContainsKey("cmbxBetonsinifi") && cmbxBetonsinifi != null)
                {                   
                    cmbxBetonsinifi.Items.Clear();

                    cmbxBetonsinifi.Items.AddRange(betonSiniflari);

                    cmbxBetonsinifi.SelectedIndex = -1; 

                    cmbxBetonsinifi.DropDownStyle = ComboBoxStyle.DropDownList;                    
                }
                else
                {
                    MessageBox.Show("Formda 'cmbBetonSinifi' adında bir ComboBox bulunamadı.", "Kontrol Eksik", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beton Sınıfı ComboBox'ı doldurulurken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CimentoSinifiComboBoxDoldur()
        {
            
            string[] CimentoSiniflari = {
                                        "32.5",
                                        "42.5",
                                        "52.5",
        
            };

            try
            {
                
                if (this.Controls.ContainsKey("cmbCimentoSinifi") && cmbCimentoSinifi != null)
                {
                    cmbCimentoSinifi.Items.Clear();

                    cmbCimentoSinifi.Items.AddRange(CimentoSiniflari);

                    cmbCimentoSinifi.SelectedIndex = -1; 

                    cmbCimentoSinifi.DropDownStyle = ComboBoxStyle.DropDownList;                    
                }
                else
                {
                    MessageBox.Show("Formda 'cmbCimentoSinifi' adında bir ComboBox bulunamadı.", "Kontrol Eksik", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Çimento Sınıfı ComboBox'ı doldurulurken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReceteleriYukle()
        {
            try
            {
                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"SELECT
                                        receteId,
                                        betonSinifi,
                                        Cimento,
                                        Su,
                                        Agrega1,
                                        Agrega2,
                                        Agrega3,
                                        Katki1,
                                        Katki2,
                                        ucucuKul,
                                        cimentoTipi,
                                        ReceteKodu
                                    FROM
                                        Receteler
                                    ORDER BY
                                        betonSinifi ASC"; 

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dgvReceteler.DataSource = dataTable;
                    }
                }
            }
            catch (SqlException sqlEx) 
            {
                MessageBox.Show($"Veritabanı hatası: {sqlEx.Message}\nBağlantı dizenizi kontrol edin.", "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Reçeteler yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DataGridViewYapılandırması()
        {
            
            dgvReceteler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; 


            if (dgvReceteler.Columns["receteId"] != null) dgvReceteler.Columns["receteId"].HeaderText = "ID";
            if (dgvReceteler.Columns["ReceteKodu"] != null) dgvReceteler.Columns["ReceteKodu"].HeaderText = "RÇTKodu";
            if (dgvReceteler.Columns["betonSinifi"] != null) dgvReceteler.Columns["betonSinifi"].HeaderText = "BT Sınıfı";
            if (dgvReceteler.Columns["Cimento"] != null) dgvReceteler.Columns["Cimento"].HeaderText = "Çimento";
            if (dgvReceteler.Columns["Su"] != null) dgvReceteler.Columns["Su"].HeaderText = "Su";
            if (dgvReceteler.Columns["Agrega1"] != null) dgvReceteler.Columns["Agrega1"].HeaderText = "0-4"; 
            if (dgvReceteler.Columns["Agrega2"] != null) dgvReceteler.Columns["Agrega2"].HeaderText = "5-15"; 
            if (dgvReceteler.Columns["Agrega3"] != null) dgvReceteler.Columns["Agrega3"].HeaderText = "15-22"; 
            if (dgvReceteler.Columns["Katki1"] != null) dgvReceteler.Columns["Katki1"].HeaderText = "Katkı 1";
            if (dgvReceteler.Columns["Katki2"] != null) dgvReceteler.Columns["Katki2"].HeaderText = "Katkı 2";
            if (dgvReceteler.Columns["ucucuKul"] != null) dgvReceteler.Columns["ucucuKul"].HeaderText = "Kül";
            if (dgvReceteler.Columns["cimentoTipi"] != null) dgvReceteler.Columns["cimentoTipi"].HeaderText = "Çimento Tipi";

            
            if (dgvReceteler.Columns["receteId"] != null) dgvReceteler.Columns["receteId"].Visible = false;

           
            dgvReceteler.ReadOnly = true;

            
            dgvReceteler.AllowUserToAddRows = false;
            dgvReceteler.AllowUserToDeleteRows = false;

            
            dgvReceteler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
            dgvReceteler.MultiSelect = false;
        }

        private void Receteler_Load(object sender, EventArgs e)
        {
            
            ReceteleriYukle();
            DataGridViewYapılandırması();
            GirişAlanlarınıTemizle();
            BetonSinifiComboBoxDoldur();
            CimentoSinifiComboBoxDoldur();
        }

        private void dgvReceteler_SelectionChanged(object sender, EventArgs e)
        {
            
            if (dgvReceteler.SelectedRows.Count > 0)
            {
                try
                {
                    
                    DataGridViewRow selectedRow = dgvReceteler.SelectedRows[0];
            
                    if (this.Controls.ContainsKey("txtReceteId")) 
                        txtReceteId.Text = selectedRow.Cells["receteId"].Value?.ToString() ?? string.Empty; 
                    
                    if (this.Controls.ContainsKey("cmbxBetonsinifi") && cmbxBetonsinifi != null)
                        cmbxBetonsinifi.Text = selectedRow.Cells["betonSinifi"].Value?.ToString() ?? string.Empty;
                    if (this.Controls.ContainsKey("cmbCimentoSinifi") && cmbCimentoSinifi != null)
                        cmbCimentoSinifi.Text = selectedRow.Cells["cimentoTipi"].Value?.ToString() ?? string.Empty;
                    if (this.Controls.ContainsKey("txtCimento")) txtCimento.Text = selectedRow.Cells["Cimento"].Value?.ToString() ?? string.Empty;
                    if (this.Controls.ContainsKey("txtSu")) txtSu.Text = selectedRow.Cells["Su"].Value?.ToString() ?? string.Empty;                 
                    if (this.Controls.ContainsKey("txt04")) txt04.Text = selectedRow.Cells["Agrega1"].Value?.ToString() ?? string.Empty; 
                    if (this.Controls.ContainsKey("txt5_15")) txt5_15.Text = selectedRow.Cells["Agrega2"].Value?.ToString() ?? string.Empty; 
                    if (this.Controls.ContainsKey("txt15_22")) txt15_22.Text = selectedRow.Cells["Agrega3"].Value?.ToString() ?? string.Empty;                  
                    if (this.Controls.ContainsKey("txtKatki")) txtKatki.Text = selectedRow.Cells["Katki1"].Value?.ToString() ?? string.Empty; 
                    if (this.Controls.ContainsKey("txtKatki_2")) txtKatki_2.Text = selectedRow.Cells["Katki2"].Value?.ToString() ?? string.Empty;
                    if (this.Controls.ContainsKey("txtKul")) txtKul.Text = selectedRow.Cells["ucucuKul"].Value?.ToString() ?? string.Empty;
                    if (this.Controls.ContainsKey("txtRctkod")) txtRctkod.Text = selectedRow.Cells["ReceteKodu"].Value?.ToString() ?? string.Empty;

                    btnEkle.Enabled = false;
                    btnGuncelle.Enabled = true;
                    btnSil.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Seçili reçete bilgileri yüklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    GirişAlanlarınıTemizle();
                }
            }
            else
            {

                GirişAlanlarınıTemizle();
            }
        }
        private void GirişAlanlarınıTemizle()
        {
            if (this.Controls.ContainsKey("txtReceteId")) txtReceteId.Text = string.Empty;
            if (this.Controls.ContainsKey("cmbxBetonsinifi") && cmbxBetonsinifi != null)
            {
                cmbxBetonsinifi.SelectedIndex = -1; 
                cmbxBetonsinifi.Text = string.Empty; 
            }
            if (this.Controls.ContainsKey("cmbCimentoSinifi") && cmbCimentoSinifi != null)
            {
                cmbCimentoSinifi.SelectedIndex = -1; 
                cmbCimentoSinifi.Text = string.Empty; 
            }
            if (this.Controls.ContainsKey("txtCimento")) txtCimento.Text = string.Empty;
            if (this.Controls.ContainsKey("txtSu")) txtSu.Text = string.Empty;
            if (this.Controls.ContainsKey("txt04")) txt04.Text = string.Empty; 
            if (this.Controls.ContainsKey("txt5_15")) txt5_15.Text = string.Empty; 
            if (this.Controls.ContainsKey("txt15_22")) txt15_22.Text = string.Empty; 
            if (this.Controls.ContainsKey("txtKatki")) txtKatki.Text = string.Empty;  
            if (this.Controls.ContainsKey("txtKatki_2")) txtKatki_2.Text = string.Empty;
            if (this.Controls.ContainsKey("txtKul")) txtKul.Text = string.Empty;
            if (this.Controls.ContainsKey("txtRctkod")) txtRctkod.Text = string.Empty;

            btnEkle.Enabled = true;
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
        }
   
        private bool ZorunluAlanKontrolü()
        {
            
            if (cmbxBetonsinifi.SelectedIndex == -1 || string.IsNullOrWhiteSpace(cmbxBetonsinifi.Text))
            {
                MessageBox.Show("Lütfen bir Beton Sınıfı seçin.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbxBetonsinifi.Focus(); 
                return false; 
            }
            if (cmbCimentoSinifi.SelectedIndex == -1 || string.IsNullOrWhiteSpace(cmbCimentoSinifi.Text))
            {
                MessageBox.Show("Lütfen bir Çimento Sınıfı seçin.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCimentoSinifi.Focus(); 
                return false; 
            }

            
            if (string.IsNullOrWhiteSpace(txtCimento.Text)) { ShowValidationError(txtCimento, "Çimento"); return false; }
            if (string.IsNullOrWhiteSpace(txtKul.Text)) { ShowValidationError(txtKul, "Uçucu Kül"); return false; }
            if (string.IsNullOrWhiteSpace(txtKatki.Text)) { ShowValidationError(txtKatki, "Katkı "); return false; }  
            if (string.IsNullOrWhiteSpace(txtKatki_2.Text)) { ShowValidationError(txtKatki_2, "Katkı 2"); return false; }
            if (string.IsNullOrWhiteSpace(txtSu.Text)) { ShowValidationError(txtSu, "Su"); return false; }
            if (string.IsNullOrWhiteSpace(txt04.Text)) { ShowValidationError(txt04, "04"); return false; } 
            if (string.IsNullOrWhiteSpace(txt5_15.Text)) { ShowValidationError(txt5_15, "05-15"); return false; } 
            if (string.IsNullOrWhiteSpace(txt15_22.Text)) { ShowValidationError(txt15_22, "15-22"); return false; } 
            if (string.IsNullOrWhiteSpace(txtRctkod.Text)) { ShowValidationError(txtRctkod, "Reçete Kodu"); return false; }

            if (!decimal.TryParse(txtCimento.Text, out _)) { ShowNumericValidationError(txtCimento, "Çimento"); return false; }
            if (!decimal.TryParse(txtSu.Text, out _)) { ShowNumericValidationError(txtSu, "Su"); return false; }
            if (!decimal.TryParse(txt04.Text, out _)) { ShowNumericValidationError(txt04, "04"); return false; } 
            if (!decimal.TryParse(txt5_15.Text, out _)) { ShowNumericValidationError(txt5_15, "05-15"); return false; } 
            if (!decimal.TryParse(txt15_22.Text, out _)) { ShowNumericValidationError(txt15_22, "15-22"); return false; } 
            if (!decimal.TryParse(txtKatki.Text, out _)) { ShowNumericValidationError(txtKatki, "Katkı 1"); return false; }  
            if (!decimal.TryParse(txtKatki_2.Text, out _)) { ShowNumericValidationError(txtKatki_2, "Katkı 2"); return false; }
            if (!decimal.TryParse(txtKul.Text, out _)) { ShowNumericValidationError(txtKul, "Uçucu Kül"); return false; }

            
            return true;
        }

        private void ShowValidationError(Control control, string fieldName)
        {
            MessageBox.Show($"Lütfen '{fieldName}' alanını boş bırakmayın.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus(); 
        }
        private void ShowNumericValidationError(Control control, string fieldName)
        {
            MessageBox.Show($"Lütfen '{fieldName}' alanına geçerli bir sayı girin (Ondalık ayıracı olarak virgül '.' veya sisteminize göre ',' kullanın).", "Geçersiz Değer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (!ZorunluAlanKontrolü())
            {
                return; 
            }

            decimal cimento, su, agrega1, agrega2, agrega3, katki1, katki2, ucucuKul;
            int ReceteKodu;
            try
            {
                cimento = decimal.Parse(txtCimento.Text);
                su = decimal.Parse(txtSu.Text);         
                agrega1 = decimal.Parse(txt04.Text);
                agrega2 = decimal.Parse(txt5_15.Text);
                agrega3 = decimal.Parse(txt15_22.Text);
                katki1 = decimal.Parse(txtKatki.Text);
                katki2 = decimal.Parse(txtKatki_2.Text);
                ucucuKul = decimal.Parse(txtKul.Text);
                ReceteKodu = Convert.ToInt32(txtRctkod.Text);


            }
            catch (FormatException)
            {
                MessageBox.Show("Lütfen tüm sayısal alanlara geçerli ondalık sayılar girin.", "Geçersiz Sayı Formatı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string betonSinifi = cmbxBetonsinifi.SelectedItem.ToString(); 
            string cimentoTipi = cmbCimentoSinifi.SelectedItem.ToString();

            try
            {
                
                using (SqlConnection connection = new SqlConnection(connectionString)) 
                {                   
                    string query = @"INSERT INTO Receteler
                                (betonSinifi, Cimento, Su, Agrega1, Agrega2, Agrega3, Katki1, Katki2, ucucuKul, cimentoTipi, ReceteKodu)
                             VALUES
                                (@betonSinifi, @Cimento, @Su, @Agrega1, @Agrega2, @Agrega3, @Katki1, @Katki2, @ucucuKul, @cimentoTipi, @ReceteKodu);
                              SELECT SCOPE_IDENTITY()";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {                       
                        cmd.Parameters.AddWithValue("@betonSinifi", betonSinifi);
                        cmd.Parameters.AddWithValue("@Cimento", cimento);
                        cmd.Parameters.AddWithValue("@Su", su);
                        cmd.Parameters.AddWithValue("@Agrega1", agrega1);
                        cmd.Parameters.AddWithValue("@Agrega2", agrega2);
                        cmd.Parameters.AddWithValue("@Agrega3", agrega3);
                        cmd.Parameters.AddWithValue("@Katki1", katki1);
                        cmd.Parameters.AddWithValue("@Katki2", katki2);
                        cmd.Parameters.AddWithValue("@ucucuKul", ucucuKul);
                        cmd.Parameters.AddWithValue("@cimentoTipi", cimentoTipi);
                        cmd.Parameters.AddWithValue("@ReceteKodu", ReceteKodu);

                        connection.Open(); 
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            this.YeniEklenenReceteId = Convert.ToInt32(result);
                            MessageBox.Show("Reçete başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ReceteleriYukle();
                            GirişAlanlarınıTemizle();

                        }

                        else
                        {
                            MessageBox.Show("Reçete eklenirken bir sorun oluştu (Etkilenen satır yok).", "Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    } 
                } 
            }
            catch (SqlException sqlEx) 
            {
                MessageBox.Show($"Veritabanı hatası oluştu: {sqlEx.Message}\nHata Kodu: {sqlEx.Number}", "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Reçete eklenirken genel bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int receteId;

            if (!this.Controls.ContainsKey("txtReceteId") || string.IsNullOrWhiteSpace(txtReceteId.Text))
            {
                MessageBox.Show("Lütfen güncellemek için listeden bir reçete seçin.", "Reçete Seçilmedi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            if (!int.TryParse(txtReceteId.Text, out receteId))
            {
                MessageBox.Show("Seçili reçetenin ID'si geçersiz.", "Geçersiz ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            if (!ZorunluAlanKontrolü())
            {
                return; 
            }

            decimal cimento, su, agrega1, agrega2, agrega3, katki1, katki2, ucucuKul;
            int ReceteKodu;
            try
            {
                cimento = decimal.Parse(txtCimento.Text);
                su = decimal.Parse(txtSu.Text);
                agrega1 = decimal.Parse(txt04.Text);       
                agrega2 = decimal.Parse(txt5_15.Text);     
                agrega3 = decimal.Parse(txt15_22.Text);    
                katki1 = decimal.Parse(txtKatki.Text);      
                katki2 = decimal.Parse(txtKatki_2.Text);    
                ucucuKul = decimal.Parse(txtKul.Text);
                ReceteKodu = Convert.ToInt32(txtReceteId.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Lütfen tüm sayısal alanlara geçerli ondalık sayılar girin.", "Geçersiz Sayı Formatı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string betonSinifi = cmbxBetonsinifi.SelectedItem.ToString(); 
            string cimentoTipi = cmbCimentoSinifi.SelectedItem.ToString();                 

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"UPDATE Receteler SET
                                betonSinifi = @betonSinifi,
                                Cimento = @Cimento,
                                Su = @Su,
                                Agrega1 = @Agrega1,
                                Agrega2 = @Agrega2,
                                Agrega3 = @Agrega3,
                                Katki1 = @Katki1,
                                Katki2 = @Katki2,
                                ucucuKul = @ucucuKul,
                                cimentoTipi = @cimentoTipi,
                                ReceteKodu = @ReceteKodu
                            WHERE
                                receteId = @receteId"; 

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@betonSinifi", betonSinifi);
                        cmd.Parameters.AddWithValue("@Cimento", cimento);
                        cmd.Parameters.AddWithValue("@Su", su);
                        cmd.Parameters.AddWithValue("@Agrega1", agrega1);
                        cmd.Parameters.AddWithValue("@Agrega2", agrega2);
                        cmd.Parameters.AddWithValue("@Agrega3", agrega3);
                        cmd.Parameters.AddWithValue("@Katki1", katki1);
                        cmd.Parameters.AddWithValue("@Katki2", katki2);
                        cmd.Parameters.AddWithValue("@ucucuKul", ucucuKul);
                        cmd.Parameters.AddWithValue("@cimentoTipi", cimentoTipi);
                        cmd.Parameters.AddWithValue("@receteId", receteId); 
                        cmd.Parameters.AddWithValue("@ReceteKodu", ReceteKodu); 

                        connection.Open();
                        int result = cmd.ExecuteNonQuery(); 
                        
                        if (result > 0) 
                        {
                            MessageBox.Show("Reçete başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ReceteleriYukle(); 
                            GirişAlanlarınıTemizle();
                        }
                        else
                        {
                            MessageBox.Show("Güncellenecek reçete bulunamadı veya kayıt zaten güncel.", "Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (SqlException sqlEx) 
            {
                MessageBox.Show($"Veritabanı hatası oluştu: {sqlEx.Message}\nHata Kodu: {sqlEx.Number}", "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Reçete güncellenirken genel bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {

            int receteId;
            if (!this.Controls.ContainsKey("txtReceteId") || string.IsNullOrWhiteSpace(txtReceteId.Text))
            {
                MessageBox.Show("Lütfen silmek için listeden bir reçete seçin.", "Reçete Seçilmedi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }
            if (!int.TryParse(txtReceteId.Text, out receteId))
            {
                MessageBox.Show("Seçili reçetenin ID'si geçersiz.", "Geçersiz ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            string seciliBetonSinifi = cmbxBetonsinifi.Text; 
            DialogResult confirmation = MessageBox.Show($" Beton Sınıfı: {seciliBetonSinifi} olan reçeteyi kalıcı olarak silmek istediğinizden emin misiniz?\nBu işlem geri alınamaz!",
                                                      "Silme Onayı", 
                                                      MessageBoxButtons.YesNo, 
                                                      MessageBoxIcon.Warning); 

            if (confirmation == DialogResult.No)
            {
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString)) 
                {
                    string query = "DELETE FROM Receteler WHERE receteId = @receteId";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@receteId", receteId);

                        connection.Open();
                        int result = cmd.ExecuteNonQuery(); 

                        if (result > 0) 
                        {
                            MessageBox.Show("Reçete başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ReceteleriYukle();    
                            GirişAlanlarınıTemizle(); 
                        }
                        else
                        {
                            MessageBox.Show("Silinecek reçete bulunamadı.", "Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    } 
                } 
            }
            catch (SqlException sqlEx) 
            {
                if (sqlEx.Number == 547)
                {
                    MessageBox.Show("Bu reçete başka kayıtlarda (örn: Numuneler) kullanıldığı için silinemez.\nÖnce ilgili numune kayıtlarını silmeniz veya reçetelerini değiştirmeniz gerekebilir.", "Silme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Veritabanı hatası oluştu: {sqlEx.Message}\nHata Kodu: {sqlEx.Number}", "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Reçete silinirken genel bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            GirişAlanlarınıTemizle();

            if (dgvReceteler.SelectedRows.Count > 0)
            {
                dgvReceteler.ClearSelection();
            }
            if (this.Controls.ContainsKey("cmbxBetonsinifi"))
            {
                cmbxBetonsinifi.Focus();
            }
        }

        private void Receteler_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
    
