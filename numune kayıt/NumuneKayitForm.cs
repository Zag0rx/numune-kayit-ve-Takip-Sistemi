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
    public partial class NumuneKayitForm : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
        public bool VeriDegisikligiYapildi { get; private set; } = false;
        public NumuneKayitForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.VeriDegisikligiYapildi = false;
            this.Shown += NumuneKayitForm_Shown;

            cmbFirmalar.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbFirmalar.AutoCompleteSource = AutoCompleteSource.ListItems;

            cmbReceteler.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbReceteler.AutoCompleteSource = AutoCompleteSource.ListItems;

            cmbSantraller.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbSantraller.AutoCompleteSource = AutoCompleteSource.ListItems;

            cmbAra.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbAra.AutoCompleteSource = AutoCompleteSource.ListItems;
            
            
        }
        private void NumuneKayitForm_Shown(object sender, EventArgs e)
        {

            btnKaydet.FlatAppearance.BorderSize = 0;
            btnKaydet.FlatAppearance.MouseOverBackColor = Color.FromArgb(140, 140, 140);
            btnKaydet.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 100, 100);

            btnGuncelle.FlatAppearance.BorderSize = 0;
            btnGuncelle.FlatAppearance.MouseOverBackColor = Color.FromArgb(140, 140, 140);
            btnGuncelle.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 100, 100);

            btnSil.FlatAppearance.BorderSize = 0;
            btnSil.FlatAppearance.MouseOverBackColor = Color.FromArgb(140, 140, 140);
            btnSil.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 100, 100);

            btnTemizle.FlatAppearance.BorderSize = 0;
            btnTemizle.FlatAppearance.MouseOverBackColor = Color.FromArgb(140, 140, 140);
            btnTemizle.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 100, 100);

            btnKirimSonuc.FlatAppearance.BorderSize = 0;
            btnKirimSonuc.FlatAppearance.MouseOverBackColor = Color.FromArgb(140, 140, 140);
            btnKirimSonuc.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 100, 100);

            btnRecetelerSayfa.FlatAppearance.BorderSize = 0;
            btnRecetelerSayfa.FlatAppearance.MouseOverBackColor = Color.FromArgb(140, 140, 140);
            btnRecetelerSayfa.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 100, 100);

            txtNmNo.BackColor = Color.FromArgb(242, 242, 242);
            txtBtnSicklk.BackColor = Color.FromArgb(242, 242, 242);
            txtSlump.BackColor = Color.FromArgb(242, 242, 242);
            txtPlaka.BackColor = Color.FromArgb(242, 242, 242);
            txtHava.BackColor = Color.FromArgb(242, 242, 242);
            txtara.BackColor = Color.FromArgb(242, 242, 242);

            dateTimePickerTrh.BackColor = Color.FromArgb(242, 242, 242);

            cmbFirmalar.BackColor = Color.FromArgb(242, 242, 242);
            cmbReceteler.BackColor = Color.FromArgb(242, 242, 242);
            cmbSantraller.BackColor = Color.FromArgb(242, 242, 242);
            cmbKatliFirmalar.BackColor = Color.FromArgb(242, 242, 242);
            cmbAra.BackColor = Color.FromArgb(242, 242, 242);

            dgvNumuneler.BackgroundColor = Color.FromArgb(240, 240, 240);
            dgvNumuneler.GridColor = Color.FromArgb(224, 224, 224);

            DataGridViewCellStyle defaultCellStyle = new DataGridViewCellStyle();
            defaultCellStyle.BackColor = Color.White;
            defaultCellStyle.ForeColor = Color.FromArgb(50, 50, 50);
            defaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            defaultCellStyle.SelectionForeColor = Color.White;
            defaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            defaultCellStyle.Padding = new Padding(5, 2, 5, 2);
            dgvNumuneler.DefaultCellStyle = defaultCellStyle;

            DataGridViewCellStyle alternatingCellStyle = new DataGridViewCellStyle();
            alternatingCellStyle.BackColor = Color.FromArgb(248, 249, 250);
            alternatingCellStyle.ForeColor = Color.FromArgb(50, 50, 50);
            alternatingCellStyle.SelectionBackColor = Color.FromArgb(62, 162, 229);
            alternatingCellStyle.SelectionForeColor = Color.White;
            dgvNumuneler.AlternatingRowsDefaultCellStyle = alternatingCellStyle;

            dgvNumuneler.EnableHeadersVisualStyles = false;
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            columnHeaderStyle.BackColor = Color.FromArgb(70, 70, 70); 
            columnHeaderStyle.ForeColor = Color.White;
            columnHeaderStyle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            columnHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            columnHeaderStyle.Padding = new Padding(5, 5, 5, 5);
            dgvNumuneler.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
            dgvNumuneler.ColumnHeadersHeight = 30;

            dgvNumuneler.BorderStyle = BorderStyle.None;
            dgvNumuneler.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            this.BackColor = Color.FromArgb(217, 217, 217);

            UpdateButtonStates();
        }
        private void NumuneKayitForm_Load(object sender, EventArgs e)
        {
            
            FirmalariDoldur();
            ReceteleriDoldur();
            SantrallerDoldur();
            KatkiFirmalariniDoldur();

            FirmaFiltreDoldur();

            NumuneleriYukle(null);

            cmbAra.SelectedIndexChanged += new System.EventHandler(this.cmbAra_SelectedIndexChanged);

            dateTimePickerTrh.Value = DateTime.Now;
        }
        private void UpdateButtonStates()
        {
            bool kayitSecili = dgvNumuneler.SelectedRows.Count > 0;

            btnKaydet.Enabled = !kayitSecili;
            btnGuncelle.Enabled = kayitSecili;
            btnSil.Enabled = kayitSecili;
            btnKirimSonuc.Enabled = kayitSecili;
        }
        private void NumuneleriYukle(int? filterByFirmaId = null) 
        {
            StringBuilder queryBuilder = new StringBuilder(@"
                    SELECT
                             N.numuneId AS ID, N.numuneNo AS NumuneNo, N.alinmaTarihi AS AlınmaZamanı,
                             IFirma.firmaAdi AS Firma, R.receteKodu AS Reçete, N.receteId AS NumuneReceteId,
                             S.santralAdi AS Santral, KFirma.firmaAdi AS KatkıFirması, N.mikserPlaka AS Plaka,
                             N.sicaklik AS Sıcaklık, N.slumpDegeriCm AS Slump, N.havaIcerigiYuzde AS HavaYüzdesi
                    FROM Numuneler AS N
                        INNER JOIN InsaatFirmalari AS IFirma ON N.musteriFirmaId = IFirma.firmaId
                        INNER JOIN Receteler AS R ON N.receteId = R.receteId
                        INNER JOIN Santraller AS S ON N.santralId = S.santralId
                        LEFT JOIN KatkiFirmalari AS KFirma ON N.katkiFirmaId = KFirma.katkiFirmaId");

            List<SqlParameter> parameters = new List<SqlParameter>();

            if (filterByFirmaId.HasValue && filterByFirmaId.Value != 0)
            {
                queryBuilder.Append(" WHERE N.musteriFirmaId = @FilterFirmaId");
                parameters.Add(new SqlParameter("@FilterFirmaId", filterByFirmaId.Value));
            }

            queryBuilder.Append(" ORDER BY N.alinmaTarihi DESC;");

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(queryBuilder.ToString(), connection);
                    if (parameters.Any()) 
                    {
                        dataAdapter.SelectCommand.Parameters.AddRange(parameters.ToArray());
                    }
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dgvNumuneler.DataSource = dataTable;

                    DataGridViewYapılandırması();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Numuneler yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (dgvNumuneler.Rows.Count > 0)
                {
                    dgvNumuneler.ClearSelection();
                }
                else
                {
                    UpdateButtonStates(); 
                }
            }
        }
        private void FirmalariDoldur()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT firmaId, firmaAdi FROM InsaatFirmalari ORDER BY firmaAdi";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    cmbFirmalar.DataSource = dataTable;
                    cmbFirmalar.DisplayMember = "firmaAdi";
                    cmbFirmalar.ValueMember = "firmaId";
                    cmbFirmalar.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Firmalar yüklenirken hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void ReceteleriDoldur()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT receteId, ReceteKodu FROM Receteler ORDER BY ReceteKodu";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    cmbReceteler.DataSource = dataTable;
                    cmbReceteler.DisplayMember = "ReceteKodu";
                    cmbReceteler.ValueMember = "receteId";
                    cmbReceteler.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Reçeteler yüklenirken hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SantrallerDoldur()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT santralId, santralAdi FROM Santraller ORDER BY santralAdi";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    cmbSantraller.DataSource = dataTable;
                    cmbSantraller.DisplayMember = "santralAdi";
                    cmbSantraller.ValueMember = "santralId";
                    cmbSantraller.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Santraller yüklenirken hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void KatkiFirmalariniDoldur()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT katkiFirmaId, firmaAdi FROM KatkiFirmalari ORDER BY firmaAdi";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    cmbKatliFirmalar.DataSource = dataTable;
                    cmbKatliFirmalar.DisplayMember = "firmaAdi";
                    cmbKatliFirmalar.ValueMember = "katkiFirmaId";
                    cmbKatliFirmalar.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Katkı Firmaları yüklenirken hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ZorunluAlanKontrolü()
        {

            if (cmbFirmalar.SelectedIndex == -1 && string.IsNullOrWhiteSpace(cmbFirmalar.Text))
            {
                MessageBox.Show("Lütfen bir İnşaat Firması seçin veya yeni bir firma adı girin.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbFirmalar.Focus();
                return false;
            }
            if (cmbKatliFirmalar.SelectedIndex == -1 && string.IsNullOrWhiteSpace(cmbKatliFirmalar.Text))
            {
                MessageBox.Show("Lütfen bir Katkı Firması seçin.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbKatliFirmalar.Focus();
                return false;
            }
            if (cmbReceteler.SelectedIndex == -1 || string.IsNullOrWhiteSpace(cmbReceteler.Text))
            {
                MessageBox.Show("Lütfen bir Reçete seçin.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbReceteler.Focus();
                return false;
            }
            if (cmbSantraller.SelectedIndex == -1 && string.IsNullOrWhiteSpace(cmbSantraller.Text))
            {
                MessageBox.Show("Lütfen bir Santral seçin.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbSantraller.Focus();
                return false;
            }


            if (string.IsNullOrWhiteSpace(txtNmNo.Text)) { ShowValidationError(txtNmNo, "Numune No"); return false; }
            if (string.IsNullOrWhiteSpace(txtBtnSicklk.Text)) { ShowValidationError(txtBtnSicklk, "Beton Sıcaklığı "); return false; }
            if (string.IsNullOrWhiteSpace(txtSlump.Text)) { ShowValidationError(txtSlump, "Slump Değeri "); return false; }
            if (string.IsNullOrWhiteSpace(txtPlaka.Text)) { ShowValidationError(txtPlaka, "Mikser Plaka "); return false; }
            if (string.IsNullOrWhiteSpace(txtHava.Text)) { ShowValidationError(txtHava, "Hava İçeriği %"); return false; }

            if (!decimal.TryParse(txtSlump.Text, out _)) { ShowNumericValidationError(txtSlump, "Slump Değeri"); return false; }
            if (!decimal.TryParse(txtHava.Text, out _)) { ShowNumericValidationError(txtHava, "Hava İçeriği %"); return false; }
            if (!decimal.TryParse(txtBtnSicklk.Text, out _)) { ShowNumericValidationError(txtBtnSicklk, "Beton Sıcaklığı"); return false; }

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
        private int? AddNewSantral(string santralAdi)
        {
            string insertQuery = "INSERT INTO Santraller (santralAdi) VALUES (@santralAdi); SELECT SCOPE_IDENTITY();";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@santralAdi", santralAdi.Trim());
                        connection.Open();
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            int yeniSantralId = Convert.ToInt32(result);
                            MessageBox.Show($"'{santralAdi}' başarıyla yeni santral olarak eklendi.", "Santral Eklendi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            SantrallerDoldur();
                            return yeniSantralId;
                        }
                        else
                        {
                            MessageBox.Show("Yeni santral eklenirken bir ID alınamadı.", "Ekleme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return null;
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                if (sqlEx.Number == 2627 || sqlEx.Number == 2601)
                {
                    MessageBox.Show($"'{santralAdi}' adında bir santral zaten mevcut.", "Kayıt Mevcut", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }
                MessageBox.Show($"Yeni santral eklenirken veritabanı hatası oluştu: {sqlEx.Message}", "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Yeni santral eklenirken genel bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private int? AddNewKatkiFirma(string firmaAdi)
        {
            string insertQuery = "INSERT INTO KatkiFirmalari (firmaAdi) VALUES (@firmaAdi); SELECT SCOPE_IDENTITY();";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@firmaAdi", firmaAdi.Trim());
                        connection.Open();

                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            int yeniFirmaId = Convert.ToInt32(result);
                            MessageBox.Show($"'{firmaAdi}' başarıyla yeni firma olarak eklendi.", "Firma Eklendi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            KatkiFirmalariniDoldur();
                            return yeniFirmaId;
                        }

                        else
                        {
                            MessageBox.Show("Yeni firma eklenirken bir ID alınamadı.", "Ekleme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return null;
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {

                if (sqlEx.Number == 2627 || sqlEx.Number == 2601)
                {
                    MessageBox.Show($"'{firmaAdi}' adında bir firma zaten mevcut.", "Kayıt Mevcut", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }
                MessageBox.Show($"Yeni firma eklenirken veritabanı hatası oluştu: {sqlEx.Message}", "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Yeni firma eklenirken genel bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private int? AddNewFirma(string firmaAdi)
        {
            string insertQuery = "INSERT INTO InsaatFirmalari (firmaAdi) VALUES (@firmaAdi); SELECT SCOPE_IDENTITY();";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@firmaAdi", firmaAdi.Trim());
                        connection.Open();

                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            int yeniFirmaId = Convert.ToInt32(result);
                            MessageBox.Show($"'{firmaAdi}' başarıyla yeni firma olarak eklendi.", "Firma Eklendi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            FirmalariDoldur(); 

                            return yeniFirmaId;
                        }
                        else
                        {
                            MessageBox.Show("Yeni firma eklenirken bir ID alınamadı.", "Ekleme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return null;
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                if (sqlEx.Number == 2627 || sqlEx.Number == 2601) 
                {
                    MessageBox.Show($"'{firmaAdi}' adında bir firma zaten mevcut.", "Kayıt Mevcut", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }
                MessageBox.Show($"Yeni firma eklenirken veritabanı hatası oluştu: {sqlEx.Message}", "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Yeni firma eklenirken genel bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private void GirişAlanlarınıTemizle()
        {
            GirişAlanlarınıTemizleInternal();

            cmbAra.SelectedIndexChanged -= this.cmbAra_SelectedIndexChanged;
            txtara.TextChanged -= this.txtara_TextChanged;

            if (cmbAra.DataSource != null && cmbAra.Items.Count > 0)
            {
                cmbAra.SelectedValue = 0;
            }
            else if (cmbAra.Items.Count > 0)
            {
                cmbAra.SelectedIndex = 0; 
            }
            txtara.Clear();

            cmbAra.SelectedIndexChanged += this.cmbAra_SelectedIndexChanged;
            txtara.TextChanged += this.txtara_TextChanged;

            if (dgvNumuneler.SelectedRows.Count > 0)
            {
                dgvNumuneler.ClearSelection();
            }
            else
            {
                UpdateButtonStates();
            }

            NumuneleriYukle(null, null); 

            txtNmNo.Focus();
        }

        private void DataGridViewYapılandırması()
        {

            dgvNumuneler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvNumuneler.Columns["ID"] != null) dgvNumuneler.Columns["ID"].HeaderText = "ID";
            if (dgvNumuneler.Columns["NumuneNo"] != null) dgvNumuneler.Columns["NumuneNo"].HeaderText = "Numune No";
            if (dgvNumuneler.Columns["Firma"] != null) dgvNumuneler.Columns["Firma"].HeaderText = "Müşteri Firma";
            if (dgvNumuneler.Columns["Reçete"] != null) dgvNumuneler.Columns["Reçete"].HeaderText = "Reçete";
            if (dgvNumuneler.Columns["Santral"] != null) dgvNumuneler.Columns["Santral"].HeaderText = "Santral";
            if (dgvNumuneler.Columns["KatkıFirması"] != null) dgvNumuneler.Columns["KatkıFirması"].HeaderText = "Katkı Firması";
            if (dgvNumuneler.Columns["Plaka"] != null) dgvNumuneler.Columns["Plaka"].HeaderText = "Mikser Plaka";
            if (dgvNumuneler.Columns["AlınmaZamanı"] != null) dgvNumuneler.Columns["AlınmaZamanı"].HeaderText = "Alınma Tarihi";
            if (dgvNumuneler.Columns["Sıcaklık"] != null) dgvNumuneler.Columns["Sıcaklık"].HeaderText = "Sıcaklık";
            if (dgvNumuneler.Columns["Slump"] != null) dgvNumuneler.Columns["Slump"].HeaderText = "Slump";
            if (dgvNumuneler.Columns["HavaYüzdesi"] != null) dgvNumuneler.Columns["HavaYüzdesi"].HeaderText = "Hava içeriği %";


            if (dgvNumuneler.Columns["ID"] != null) dgvNumuneler.Columns["ID"].Visible = false;
            if (dgvNumuneler.Columns["NumuneReceteId"] != null) dgvNumuneler.Columns["NumuneReceteId"].Visible = false;


            dgvNumuneler.ReadOnly = true;
            dgvNumuneler.AllowUserToAddRows = false;
            dgvNumuneler.AllowUserToDeleteRows = false;
            dgvNumuneler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNumuneler.MultiSelect = false;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (!ZorunluAlanKontrolü())
            {
                return;
            }

            decimal sicaklık, slump, hava;
            try
            {
                sicaklık = decimal.Parse(txtBtnSicklk.Text.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);
                slump = decimal.Parse(txtSlump.Text.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);
                hava = decimal.Parse(txtHava.Text.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
                MessageBox.Show("Lütfen tüm sayısal alanlara geçerli ondalık sayılar girin.", "Geçersiz Sayı Formatı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int musteriFirmaId;
            object selectedFirmaValue = cmbFirmalar.SelectedValue;
            if (selectedFirmaValue != null && cmbFirmalar.SelectedIndex != -1)
            {
                musteriFirmaId = Convert.ToInt32(selectedFirmaValue);
            }
            else if (!string.IsNullOrWhiteSpace(cmbFirmalar.Text))
            {
                DialogResult drFirma = MessageBox.Show($"'{cmbFirmalar.Text.Trim()}' adlı inşaat firması listede bulunamadı.\nBu firmayı yeni bir kayıt olarak eklemek ister misiniz?",
                                                  "Yeni İnşaat Firması Ekle", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (drFirma == DialogResult.Yes)
                {
                    int? yeniEklenenFirmaId = AddNewFirma(cmbFirmalar.Text.Trim());
                    if (yeniEklenenFirmaId.HasValue) { cmbFirmalar.SelectedValue = yeniEklenenFirmaId.Value; musteriFirmaId = yeniEklenenFirmaId.Value; }
                    else { cmbFirmalar.Focus(); return; }
                }
                else { MessageBox.Show("Lütfen listeden geçerli bir inşaat firması seçin.", "Firma Gerekli", MessageBoxButtons.OK, MessageBoxIcon.Warning); cmbFirmalar.Focus(); return; }
            }
            else { MessageBox.Show("Lütfen bir İnşaat Firması seçin.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning); cmbFirmalar.Focus(); return; }


            int katkiFirmaId;
            object selectedKatkiFirmaValue = cmbKatliFirmalar.SelectedValue;
            if (selectedKatkiFirmaValue != null && cmbKatliFirmalar.SelectedIndex != -1)
            {
                katkiFirmaId = Convert.ToInt32(selectedKatkiFirmaValue);
            }
            else if (!string.IsNullOrWhiteSpace(cmbKatliFirmalar.Text))
            {
                DialogResult drKatki = MessageBox.Show($"'{cmbKatliFirmalar.Text.Trim()}' adlı katkı firması listede bulunamadı.\nBu firmayı yeni bir kayıt olarak eklemek ister misiniz?",
                                                     "Yeni Katkı Firması Ekle", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (drKatki == DialogResult.Yes)
                {
                    int? yeniEklenenKatkiId = AddNewKatkiFirma(cmbKatliFirmalar.Text.Trim());
                    if (yeniEklenenKatkiId.HasValue) { cmbKatliFirmalar.SelectedValue = yeniEklenenKatkiId.Value; katkiFirmaId = yeniEklenenKatkiId.Value; }
                    else { cmbKatliFirmalar.Focus(); return; }
                }
                else { MessageBox.Show("Lütfen listeden geçerli bir katkı firması seçin.", "Katkı Firması Gerekli", MessageBoxButtons.OK, MessageBoxIcon.Warning); cmbKatliFirmalar.Focus(); return; }
            }
            else { MessageBox.Show("Lütfen bir Katkı Firması seçin.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning); cmbKatliFirmalar.Focus(); return; }

            int santralId;
            object selectedSantralValue = cmbSantraller.SelectedValue;
            if (selectedSantralValue != null && cmbSantraller.SelectedIndex != -1)
            {
                santralId = Convert.ToInt32(selectedSantralValue);
            }
            else if (!string.IsNullOrWhiteSpace(cmbSantraller.Text))
            {
                DialogResult drSantral = MessageBox.Show($"'{cmbSantraller.Text.Trim()}' adlı santral listede bulunamadı.\nBu santrali yeni bir kayıt olarak eklemek ister misiniz?",
                                                       "Yeni Santral Ekle", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (drSantral == DialogResult.Yes)
                {
                    int? yeniEklenenSantralId = AddNewSantral(cmbSantraller.Text.Trim());
                    if (yeniEklenenSantralId.HasValue) { cmbSantraller.SelectedValue = yeniEklenenSantralId.Value; santralId = yeniEklenenSantralId.Value; }
                    else { cmbSantraller.Focus(); return; }
                }
                else { MessageBox.Show("Lütfen listeden geçerli bir santral seçin.", "Santral Gerekli", MessageBoxButtons.OK, MessageBoxIcon.Warning); cmbSantraller.Focus(); return; }
            }
            else { MessageBox.Show("Lütfen bir Santral seçin.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning); cmbSantraller.Focus(); return; }


            if (cmbReceteler.SelectedValue == null)
            {
                MessageBox.Show("Lütfen bir Reçete seçin.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbReceteler.Focus();
                return;
            }
            int receteId = Convert.ToInt32(cmbReceteler.SelectedValue);

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"INSERT INTO Numuneler
                                (numuneNo, musteriFirmaId, receteId ,santralId, katkiFirmaId, mikserPlaka, alinmaTarihi, sicaklik, slumpDegeriCm, havaIcerigiYuzde)
                             VALUES
                                (@numuneNo, @musteriFirmaId, @receteId , @santralId, @katkiFirmaId, @mikserPlaka, @alinmaTarihi, @sicaklik, @slumpDegeriCm, @havaIcerigiYuzde)";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@numuneNo", txtNmNo.Text.Trim());
                        cmd.Parameters.AddWithValue("@musteriFirmaId", musteriFirmaId);
                        cmd.Parameters.AddWithValue("@receteId", receteId);
                        cmd.Parameters.AddWithValue("@santralId", santralId);
                        cmd.Parameters.AddWithValue("@katkiFirmaId", katkiFirmaId);
                        cmd.Parameters.AddWithValue("@mikserPlaka", txtPlaka.Text.Trim());
                        cmd.Parameters.AddWithValue("@alinmaTarihi", dateTimePickerTrh.Value);
                        cmd.Parameters.AddWithValue("@sicaklik", sicaklık);
                        cmd.Parameters.AddWithValue("@slumpDegeriCm", slump);
                        cmd.Parameters.AddWithValue("@havaIcerigiYuzde", hava);

                        connection.Open();
                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Yeni numune kaydı başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.VeriDegisikligiYapildi = true;
                            NumuneleriYukle(null);
                            GirişAlanlarınıTemizle();
                        }
                        else
                        {
                            MessageBox.Show("Numune eklenirken bir sorun oluştu (Etkilenen satır yok).", "Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show($"Numune eklenirken genel bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvNumuneler_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNumuneler.SelectedRows.Count > 0)
            {
                try
                {

                    DataGridViewRow selectedRow = dgvNumuneler.SelectedRows[0];

                    if (this.Controls.ContainsKey("txtnumuneID") && selectedRow.Cells["ID"] != null)
                        txtnumuneID.Text = selectedRow.Cells["ID"].Value?.ToString() ?? string.Empty;

                    if (this.Controls.ContainsKey("cmbFirmalar")) cmbFirmalar.Text = selectedRow.Cells["Firma"].Value?.ToString() ?? string.Empty;
                    if (this.Controls.ContainsKey("cmbReceteler")) cmbReceteler.Text = selectedRow.Cells["Reçete"].Value?.ToString() ?? string.Empty;
                    if (this.Controls.ContainsKey("cmbSantraller")) cmbSantraller.Text = selectedRow.Cells["Santral"].Value?.ToString() ?? string.Empty;
                    if (this.Controls.ContainsKey("cmbKatliFirmalar")) cmbKatliFirmalar.Text = selectedRow.Cells["KatkıFirması"].Value?.ToString() ?? string.Empty;

                    if (this.Controls.ContainsKey("txtPlaka") && selectedRow.Cells["Plaka"] != null)
                        txtPlaka.Text = selectedRow.Cells["Plaka"].Value?.ToString() ?? string.Empty;

                    if (this.Controls.ContainsKey("txtHava") && selectedRow.Cells["HavaYüzdesi"] != null)
                        txtHava.Text = selectedRow.Cells["HavaYüzdesi"].Value?.ToString() ?? string.Empty;

                    if (this.Controls.ContainsKey("txtSlump") && selectedRow.Cells["Slump"] != null)
                        txtSlump.Text = selectedRow.Cells["Slump"].Value?.ToString() ?? string.Empty;

                    if (this.Controls.ContainsKey("txtBtnSicklk") && selectedRow.Cells["Sıcaklık"] != null)
                        txtBtnSicklk.Text = selectedRow.Cells["Sıcaklık"].Value?.ToString() ?? string.Empty;

                    if (this.Controls.ContainsKey("txtNmNo") && selectedRow.Cells["NumuneNo"] != null)
                        txtNmNo.Text = selectedRow.Cells["NumuneNo"].Value?.ToString() ?? string.Empty;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Seçili reçete bilgileri yüklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    GirişAlanlarınıTemizleInternal();
                }
            }
            else
            {

                GirişAlanlarınıTemizleInternal();
            }
            UpdateButtonStates();
        }
        private void GirişAlanlarınıTemizleInternal()
        {
            txtnumuneID.Clear();
            txtNmNo.Clear();
            txtBtnSicklk.Clear();
            txtSlump.Clear();
            txtPlaka.Clear();
            txtHava.Clear();
            cmbFirmalar.SelectedIndex = -1;
            cmbReceteler.SelectedIndex = -1;
            cmbSantraller.SelectedIndex = -1;
            cmbKatliFirmalar.SelectedIndex = -1;
            dateTimePickerTrh.Value = DateTime.Now;
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int numuneID;

            if (!this.Controls.ContainsKey("txtnumuneID") || string.IsNullOrWhiteSpace(txtnumuneID.Text))
            {
                MessageBox.Show("Lütfen güncellemek için listeden bir Numune kaydı seçin.", "Reçete Seçilmedi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtnumuneID.Text, out numuneID))
            {
                MessageBox.Show("Seçili numunenin ID'si geçersiz.", "Geçersiz ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ZorunluAlanKontrolü())
            {
                return;
            }

            decimal sicaklık, slump, hava;
            try
            {
                sicaklık = decimal.Parse(txtBtnSicklk.Text);
                slump = decimal.Parse(txtSlump.Text);
                hava = decimal.Parse(txtHava.Text);

            }
            catch (FormatException)
            {
                MessageBox.Show("Lütfen tüm sayısal alanlara geçerli ondalık sayılar girin.", "Geçersiz Sayı Formatı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int musteriFirmaId = Convert.ToInt32(cmbFirmalar.SelectedValue);
            int receteId = Convert.ToInt32(cmbReceteler.SelectedValue);
            int santralId = Convert.ToInt32(cmbSantraller.SelectedValue);
            int katkiFirmaId = Convert.ToInt32(cmbKatliFirmalar.SelectedValue);

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"UPDATE Numuneler SET
                                numuneNo = @numuneNo,
                                musteriFirmaId = @musteriFirmaId,
                                receteId = @receteId,
                                santralId = @santralId,
                                katkiFirmaId = @katkiFirmaId,
                                mikserPlaka = @mikserPlaka,
                                alinmaTarihi = @alinmaTarihi,
                                sicaklik = @sicaklik,
                                slumpDegeriCm = @slumpDegeriCm,
                                havaIcerigiYuzde = @havaIcerigiYuzde
                            WHERE
                                numuneId = @numuneId";


                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@numuneId", txtnumuneID.Text.Trim());
                        cmd.Parameters.AddWithValue("@numuneNo", txtNmNo.Text.Trim());
                        cmd.Parameters.AddWithValue("@musteriFirmaId", musteriFirmaId);
                        cmd.Parameters.AddWithValue("@receteId", receteId);
                        cmd.Parameters.AddWithValue("@santralId", santralId);
                        cmd.Parameters.AddWithValue("@katkiFirmaId", katkiFirmaId);
                        cmd.Parameters.AddWithValue("@mikserPlaka", txtPlaka.Text.Trim());
                        cmd.Parameters.AddWithValue("@alinmaTarihi", dateTimePickerTrh.Value);
                        cmd.Parameters.AddWithValue("@sicaklik", sicaklık);
                        cmd.Parameters.AddWithValue("@slumpDegeriCm", slump);
                        cmd.Parameters.AddWithValue("@havaIcerigiYuzde", hava);

                        connection.Open();
                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Numune başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.VeriDegisikligiYapildi = true;
                            NumuneleriYukle(null);
                            GirişAlanlarınıTemizle();
                        }
                        else
                        {
                            MessageBox.Show("Güncellenecek Numune bulunamadı veya kayıt zaten güncel.", "Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show($"Numune güncellenirken genel bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int numuneId;
            if (!this.Controls.ContainsKey("txtnumuneID") || string.IsNullOrWhiteSpace(txtnumuneID.Text))
            {
                MessageBox.Show("Lütfen silmek için listeden bir numune seçin.", "numune Seçilmedi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtnumuneID.Text, out numuneId))
            {
                MessageBox.Show("Seçili numune ID'si geçersiz.", "Geçersiz ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string seciliNumuneNo = txtNmNo.Text;
            DialogResult confirmation = MessageBox.Show($" Numune Numarası: {seciliNumuneNo} olan numuneyi kalıcı olarak silmek istediğinizden emin misiniz?\nBu işlem geri alınamaz!",
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
                    string query = "DELETE FROM Numuneler WHERE numuneId = @numuneId";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@numuneId", numuneId);

                        connection.Open();
                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("numune başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.VeriDegisikligiYapildi = true;
                            NumuneleriYukle(null);
                            GirişAlanlarınıTemizle();
                        }
                        else
                        {
                            MessageBox.Show("Silinecek numune bulunamadı.", "Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                if (sqlEx.Number == 547)
                {
                    MessageBox.Show("Bu Numune başka kayıtlarda (örn: Numune Kırım) kullanıldığı için silinemez.\nÖnce ilgili Numune Kırım kayıtlarını silmeniz veya Numune Kırımlarını değiştirmeniz gerekebilir.", "Silme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Veritabanı hatası oluştu: {sqlEx.Message}\nHata Kodu: {sqlEx.Number}", "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Numune silinirken genel bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            GirişAlanlarınıTemizle();

            if (dgvNumuneler.SelectedRows.Count > 0)
            {
                dgvNumuneler.ClearSelection();
            }
            if (this.Controls.ContainsKey("txtNmNo"))
            {
                txtNmNo.Focus();
            }
        }

        private void btnRecetelerSayfa_Click(object sender, EventArgs e)
        {
            using (Receteler recetelerForm = new Receteler())
            {
                if (pnldimmer != null)
                {
                    pnldimmer.Visible = true;
                    pnldimmer.BackColor = Color.FromArgb(100, 0, 0, 0);
                    pnldimmer.BringToFront();
                    this.Refresh();
                }

                try
                {
                    DialogResult result = recetelerForm.ShowDialog(this);
                }
                finally
                {
                    if (pnldimmer != null)
                    {
                        pnldimmer.Visible = false;
                    }
                }

                if (recetelerForm.YeniEklenenReceteId.HasValue)
                {
                    int yeniReceteId = recetelerForm.YeniEklenenReceteId.Value;

                    ReceteleriDoldur();

                    cmbReceteler.SelectedValue = yeniReceteId;

                    if (cmbReceteler.SelectedValue == null || (int)cmbReceteler.SelectedValue != yeniReceteId)
                    {
                        MessageBox.Show("Yeni eklenen reçete ComboBox'ta otomatik olarak seçilemedi. Lütfen manuel olarak seçin.", "Bilgi", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                }

            }
        }

        private void NumuneKayitForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void cmbReceteler_DropDown(object sender, EventArgs e)
        {
            ReceteleriDoldur();
        }
        private void OpenNumuneDetayForm(int numuneId, int receteId)
        {
            if (pnldimmer != null)
            {
                pnldimmer.Visible = true;
                pnldimmer.BackColor = Color.FromArgb(100, 0, 0, 0);
                pnldimmer.BringToFront();
                this.Refresh();
            }

            try
            {
                using (NumuneDetay detayForm = new NumuneDetay(numuneId, receteId))
                {
                    detayForm.ShowDialog(this);
                }
            }
            finally
            {
                if (pnldimmer != null)
                {
                    pnldimmer.Visible = false;
                }
            }
        }
        private void dgvNumuneler_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvNumuneler.Rows.Count)
            {
                DataGridViewRow selectedRow = dgvNumuneler.Rows[e.RowIndex];

                int numuneId = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                int receteId = Convert.ToInt32(selectedRow.Cells["NumuneReceteId"].Value);

                OpenNumuneDetayForm(numuneId, receteId);
            }
        }

        private void btnKirimSonuc_Click(object sender, EventArgs e)
        {
            if (dgvNumuneler.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvNumuneler.SelectedRows[0];

                int numuneId = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                int receteId = Convert.ToInt32(selectedRow.Cells["NumuneReceteId"].Value);

                OpenNumuneDetayForm(numuneId, receteId);

            }
            else
            {
                MessageBox.Show("Lütfen bir numune seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void FirmaFiltreDoldur()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT firmaId, firmaAdi FROM InsaatFirmalari ORDER BY firmaAdi";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    DataRow dr = dataTable.NewRow();
                    dr["firmaId"] = 0; 
                    dr["firmaAdi"] = "TÜM FİRMALAR";
                    dataTable.Rows.InsertAt(dr, 0);

                    cmbAra.SelectedIndexChanged -= this.cmbAra_SelectedIndexChanged;

                    cmbAra.DataSource = null;
                    cmbAra.Items.Clear();

                    cmbAra.DataSource = dataTable;
                    cmbAra.DisplayMember = "firmaAdi";
                    cmbAra.ValueMember = "firmaId";

                    cmbAra.SelectedValue = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Firma filtresi (cmbAra) yüklenirken hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void NumuneleriYukle(int? filterByFirmaId = null, string filterByNumuneNo = null)
        {
            StringBuilder queryBuilder = new StringBuilder(@"
        SELECT
            N.numuneId AS ID, N.numuneNo AS NumuneNo, N.alinmaTarihi AS AlınmaZamanı,
            IFirma.firmaAdi AS Firma, R.receteKodu AS Reçete, N.receteId AS NumuneReceteId,
            S.santralAdi AS Santral, KFirma.firmaAdi AS KatkıFirması, N.mikserPlaka AS Plaka,
            N.sicaklik AS Sıcaklık, N.slumpDegeriCm AS Slump, N.havaIcerigiYuzde AS HavaYüzdesi
        FROM Numuneler AS N
        INNER JOIN InsaatFirmalari AS IFirma ON N.musteriFirmaId = IFirma.firmaId
        INNER JOIN Receteler AS R ON N.receteId = R.receteId
        INNER JOIN Santraller AS S ON N.santralId = S.santralId
        LEFT JOIN KatkiFirmalari AS KFirma ON N.katkiFirmaId = KFirma.katkiFirmaId");

            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> whereClauses = new List<string>();

            if (filterByFirmaId.HasValue && filterByFirmaId.Value != 0) 
            {
                whereClauses.Add("N.musteriFirmaId = @FilterFirmaId");
                parameters.Add(new SqlParameter("@FilterFirmaId", filterByFirmaId.Value));
            }

            if (!string.IsNullOrWhiteSpace(filterByNumuneNo))
            {
                whereClauses.Add("N.numuneNo LIKE @FilterNumuneNo");
                parameters.Add(new SqlParameter("@FilterNumuneNo", "%" + filterByNumuneNo + "%"));
            }

            if (whereClauses.Any())
            {
                queryBuilder.Append(" WHERE " + string.Join(" AND ", whereClauses));
            }

            queryBuilder.Append(" ORDER BY N.alinmaTarihi DESC;");

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(queryBuilder.ToString(), connection);
                    if (parameters.Any())
                    {
                        dataAdapter.SelectCommand.Parameters.AddRange(parameters.ToArray());
                    }
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dgvNumuneler.DataSource = dataTable;

                    DataGridViewYapılandırması();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Numuneler yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (dgvNumuneler.Rows.Count > 0)
                {
                    dgvNumuneler.ClearSelection();
                }
                else
                {
                    UpdateButtonStates();
                }
            }
        }
        private void cmbAra_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAra.DataSource == null || cmbAra.SelectedIndex == -1 || cmbAra.SelectedValue == null)
            {
                return;
            }

            try
            {
                object selectedValueObj = cmbAra.SelectedValue;
                if (selectedValueObj == DBNull.Value)
                {
                    NumuneleriYukle(null, txtara.Text.Trim()); 
                    return;
                }

                int secilenFirmaId = Convert.ToInt32(selectedValueObj);
                string numuneNoFilter = txtara.Text.Trim();

                if (secilenFirmaId == 0) 
                {
                    NumuneleriYukle(null, numuneNoFilter);
                }
                else
                {
                    NumuneleriYukle(secilenFirmaId, numuneNoFilter);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Firma filtresi uygulanırken bir hata oluştu: {ex.Message}", "Filtre Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NumuneleriYukle(null, txtara.Text.Trim()); 
            }
        }

        private void txtara_TextChanged(object sender, EventArgs e)
        {
            string numuneNoFilter = txtara.Text.Trim();
            int? firmaIdFilter = null;

            if (cmbAra.SelectedValue != null && cmbAra.SelectedIndex != -1) 
            {
                try
                {
                    int secilenFirmaId = Convert.ToInt32(cmbAra.SelectedValue);
                    if (secilenFirmaId != 0) 
                    {
                        firmaIdFilter = secilenFirmaId;
                    }
                }
                catch {}
            }

            NumuneleriYukle(firmaIdFilter, numuneNoFilter);
        }

        private void dgvNumuneler_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvNumuneler.Rows.Count)
            {
                DataGridViewRow selectedRow = dgvNumuneler.Rows[e.RowIndex];

                int numuneId = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                int receteId = Convert.ToInt32(selectedRow.Cells["NumuneReceteId"].Value);

                OpenNumuneDetayForm(numuneId, receteId);
            }
        }
    }
}
