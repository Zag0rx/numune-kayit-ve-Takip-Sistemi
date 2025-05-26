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
    public partial class Santraller : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;

        public Santraller()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.Shown += InsaatFirmalar_Shown;

        }

        private void SantralleriYukle()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT santralId, santralAdi FROM Santraller ORDER BY santralAdi";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvFirmalar.DataSource = dt;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Santraller yüklenirken bir hata oluştu" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dgvFirmalar.ClearSelection();
                FormuTemizle();
            }

        }
        private void DataGridViewYapılandırması()
        {

            dgvFirmalar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvFirmalar.Columns["santralAdi"] != null) dgvFirmalar.Columns["santralAdi"].HeaderText = "Santral Adı";


            if (dgvFirmalar.Columns["santralId"] != null) dgvFirmalar.Columns["santralId"].Visible = false;

            dgvFirmalar.ReadOnly = true;
            dgvFirmalar.AllowUserToAddRows = false;
            dgvFirmalar.AllowUserToDeleteRows = false;
            dgvFirmalar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFirmalar.MultiSelect = false;
        }
        private void FormuTemizle()
        {
            txtFirmaAdi.Clear();
            
            btnEkle.Enabled = true;
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
        }

        private void Santraller_Load(object sender, EventArgs e)
        {
            SantralleriYukle();
            DataGridViewYapılandırması();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirmaAdi.Text))
            {
                MessageBox.Show("Santral Adı Boş Bırakılamaz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirmaAdi.Focus();
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Santraller (santralAdi) VALUES (@santralAdi) ";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@santralAdi", txtFirmaAdi.Text.Trim());
                        connection.Open();

                        int affectedRows = command.ExecuteNonQuery();
                        if (affectedRows > 0)
                        {
                            MessageBox.Show("Santral başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            SantralleriYukle();
                            FormuTemizle();
                        }
                        else
                        {
                            MessageBox.Show("Santral eklenirken bir sorun oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (SqlException sqlex)
            {
                if (sqlex.Number == 2627 || sqlex.Number == 2601)
                {
                    MessageBox.Show("Bu Santral adı zaten mevcut. Lütfen farklı bir ad girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Veritabanı hatası oluştu: " + sqlex.Message, "SQL Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Santral eklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void InsaatFirmalar_Shown(object sender, EventArgs e)
        {
            Tasarimmlaree();
            dgvFirmalar.ClearSelection();
            FormuTemizle();
        }
        private void Tasarimmlaree()
        {
            btnEkle.FlatAppearance.BorderSize = 0;
            btnGuncelle.FlatAppearance.BorderSize = 0;
            btnSil.FlatAppearance.BorderSize = 0;
            btnTemizle.FlatAppearance.BorderSize = 0;

            btnEkle.FlatAppearance.MouseOverBackColor = Color.FromArgb(140, 140, 140);
            btnEkle.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 100, 100);

            btnGuncelle.FlatAppearance.MouseOverBackColor = Color.FromArgb(140, 140, 140);
            btnGuncelle.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 100, 100);

            btnSil.FlatAppearance.MouseOverBackColor = Color.FromArgb(140, 140, 140);
            btnSil.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 100, 100);

            btnTemizle.FlatAppearance.MouseOverBackColor = Color.FromArgb(140, 140, 140);
            btnTemizle.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 100, 100);

            txtFirmaAdi.BackColor = Color.FromArgb(242, 242, 242);
            txtArama.BackColor = Color.FromArgb(242, 242, 242);

            dgvFirmalar.BackgroundColor = Color.FromArgb(240, 240, 240);
            dgvFirmalar.GridColor = Color.FromArgb(224, 224, 224);

            DataGridViewCellStyle defaultCellStyle = new DataGridViewCellStyle();
            defaultCellStyle.BackColor = Color.White;
            defaultCellStyle.ForeColor = Color.FromArgb(50, 50, 50);
            defaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            defaultCellStyle.SelectionForeColor = Color.White;
            defaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            defaultCellStyle.Padding = new Padding(5, 2, 5, 2);
            dgvFirmalar.DefaultCellStyle = defaultCellStyle;

            DataGridViewCellStyle alternatingCellStyle = new DataGridViewCellStyle();
            alternatingCellStyle.BackColor = Color.FromArgb(248, 249, 250);
            alternatingCellStyle.ForeColor = Color.FromArgb(50, 50, 50);
            alternatingCellStyle.SelectionBackColor = Color.FromArgb(62, 162, 229);
            alternatingCellStyle.SelectionForeColor = Color.White;
            dgvFirmalar.AlternatingRowsDefaultCellStyle = alternatingCellStyle;

            dgvFirmalar.EnableHeadersVisualStyles = false;
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            columnHeaderStyle.BackColor = Color.FromArgb(70, 70, 70);     // Sütun başlıkları arka planı (koyu gri)
            columnHeaderStyle.ForeColor = Color.White;                  // Sütun başlıkları yazı rengi
            columnHeaderStyle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold); // Başlık yazı tipi
            columnHeaderStyle.Alignment = DataGridViewContentAlignment.TopLeft; // Başlıkları ortala
            columnHeaderStyle.Padding = new Padding(5, 5, 5, 5); // Başlık içi dolgu
            dgvFirmalar.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
            dgvFirmalar.ColumnHeadersHeight = 30;

            dgvFirmalar.BorderStyle = BorderStyle.None; // Kenar çerçevesi stili
            dgvFirmalar.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            this.BackColor = Color.FromArgb(217, 217, 217);
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirmaId.Text))
            {
                MessageBox.Show("Lütfen güncellemek için bir Santral seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtFirmaAdi.Text))
            {
                MessageBox.Show("Santral adı boş bırakılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirmaAdi.Focus();
                return;
            }
            try
            {
                int seciliId = Convert.ToInt32(txtFirmaId.Text);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Santraller SET santralAdi = @santralAdi WHERE santralId = @santralId ";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@santralAdi", txtFirmaAdi.Text);
                        command.Parameters.AddWithValue("@santralId", seciliId);

                        connection.Open();

                        int affectedRows = command.ExecuteNonQuery();
                        if (affectedRows > 0)
                        {
                            MessageBox.Show("Santral başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            SantralleriYukle();
                            FormuTemizle();
                        }
                        else
                        {
                            MessageBox.Show("Santral güncellenirken bir sorun oluştu veya seçili firma bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }

                    }


                }

            }

            catch (SqlException sqlex)
            {
                if (sqlex.Number == 2627 || sqlex.Number == 2601)
                {
                    MessageBox.Show("Bu santral adı zaten mevcut. Lütfen farklı bir ad girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Veritabanı hatası oluştu: " + sqlex.Message, "SQL Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            catch (FormatException)
            {
                MessageBox.Show("Geçersiz santral ID.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Santral güncellenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirmaId.Text))
            {
                MessageBox.Show("Lütfen silmek için bir santral seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult onay = MessageBox.Show($"'{txtFirmaAdi.Text}' santralini silmek istediğinizden emin misiniz? Bu işlem geri alınamaz!",
                                                "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (onay == DialogResult.Yes)
            {
                try
                {
                    int seciliId = Convert.ToInt32(txtFirmaId.Text);

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "DELETE FROM Santraller WHERE santralId = @santralId";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@santralId", seciliId);
                            connection.Open();
                            int affectedRows = command.ExecuteNonQuery();
                            if (affectedRows > 0)
                            {
                                MessageBox.Show("Santral başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                SantralleriYukle();
                                FormuTemizle();
                            }
                            else
                            {
                                MessageBox.Show("Santral silinirken bir sorun oluştu veya seçili santral bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }



                    }

                }
                catch (SqlException sqlEx)
                {
                    if (sqlEx.Number == 547)
                    {
                        MessageBox.Show("Bu firma silinemez çünkü ilişkili numune kayıtları bulunmaktadır.", "Silme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Veritabanı hatası oluştu: " + sqlEx.Message, "SQL Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Geçersiz Firma ID.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Firma silinirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void dgvFirmalar_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFirmalar.SelectedRows.Count > 0)
            {
                DataGridViewRow secilisatir = dgvFirmalar.SelectedRows[0];

                txtFirmaId.Text = secilisatir.Cells["santralId"].Value.ToString();
                txtFirmaAdi.Text = secilisatir.Cells["santralAdi"].Value.ToString();

                btnEkle.Enabled = false;
                btnGuncelle.Enabled = true;
                btnSil.Enabled = true;

            }
        }

        private void Santraller_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        private void FirmalariFiltrele(string aranan)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT santralId, santralAdi FROM Santraller WHERE santralAdi LIKE @aranan ORDER BY santralAdi";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@aranan", "%" + aranan + "%");
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvFirmalar.DataSource = dt;
                    }
                }

                dgvFirmalar.ClearSelection();
                FormuTemizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Arama yapılırken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            FirmalariFiltrele(txtArama.Text.Trim());
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            FormuTemizle();
            txtArama.Clear();

            if (dgvFirmalar.SelectedRows.Count > 0)
            {
                dgvFirmalar.ClearSelection();
            }
        }
    }
}
