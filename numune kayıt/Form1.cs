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
    public partial class Form1 : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.Shown += Form1_Shown;
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            btnBilgiDestek.Text = "Bilgi & Destek";

            btnBilgiDestek.FlatAppearance.BorderSize = 0;
            btnNumuneKayit.FlatAppearance.BorderSize = 0;
            btnİnsaat.FlatAppearance.BorderSize = 0;
            btnReceteler.FlatAppearance.BorderSize = 0;
            btnSantral.FlatAppearance.BorderSize = 0;
            btnKatki.FlatAppearance.BorderSize = 0;

            btnNumuneKayit.FlatAppearance.MouseOverBackColor = Color.FromArgb(140, 140, 140);
            btnNumuneKayit.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 100, 100);
            btnNumuneKayit.BackColor = Color.Silver;

            btnİnsaat.FlatAppearance.MouseOverBackColor = Color.FromArgb(140, 140, 140);
            btnİnsaat.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 100, 100);
            btnİnsaat.BackColor = Color.Silver;

            btnReceteler.FlatAppearance.MouseOverBackColor = Color.FromArgb(140, 140, 140);
            btnReceteler.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 100, 100);
            btnReceteler.BackColor = Color.Silver;

            btnSantral.FlatAppearance.MouseOverBackColor = Color.FromArgb(140, 140, 140);
            btnSantral.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 100, 100);
            btnSantral.BackColor = Color.Silver;

            btnKatki.FlatAppearance.MouseOverBackColor = Color.FromArgb(140, 140, 140);
            btnKatki.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 100, 100);
            btnKatki.BackColor = Color.Silver;

            btnBilgiDestek.FlatAppearance.MouseOverBackColor = Color.FromArgb(140, 140, 140);
            btnBilgiDestek.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 100, 100);
            btnBilgiDestek.BackColor = Color.Silver;

            this.BackColor = Color.FromArgb(217, 217, 217);
        }
        private void BugunkuKirimlariDoldur()
        {
            string query = @"
        SELECT
            N.numuneId AS ID, 
            N.numuneNo AS NumuneNo, 
            N.alinmaTarihi AS AlınmaTarihi,
            IFirma.firmaAdi AS Firma,
            N.receteId AS NumuneReceteId,  -- << BU SATIRI EKLEYİN (Reçete ID'sini almak için)
            CASE
                WHEN DATEADD(day, 1, N.alinmaTarihi) = CAST(GETDATE() AS DATE) THEN '1 Günlük Kırım'
                WHEN DATEADD(day, 2, N.alinmaTarihi) = CAST(GETDATE() AS DATE) THEN '2 Günlük Kırım'
                WHEN DATEADD(day, 3, N.alinmaTarihi) = CAST(GETDATE() AS DATE) THEN '3 Günlük Kırım'
                WHEN DATEADD(day, 7, N.alinmaTarihi) = CAST(GETDATE() AS DATE) THEN '7 Günlük Kırım'
                WHEN DATEADD(day, 14, N.alinmaTarihi) = CAST(GETDATE() AS DATE) THEN '14 Günlük Kırım'
                WHEN DATEADD(day, 28, N.alinmaTarihi) = CAST(GETDATE() AS DATE) THEN '28 Günlük Kırım'
                ELSE 'Diğer'
            END AS KirimPeriyodu
        FROM Numuneler AS N
        INNER JOIN InsaatFirmalari AS IFirma ON N.musteriFirmaId = IFirma.firmaId
        INNER JOIN Receteler AS R ON N.receteId = R.receteId 
        INNER JOIN Santraller AS S ON N.santralId = S.santralId
        WHERE
            (DATEADD(day, 1, N.alinmaTarihi) = CAST(GETDATE() AS DATE)) OR
            (DATEADD(day, 2, N.alinmaTarihi) = CAST(GETDATE() AS DATE)) OR
            (DATEADD(day, 3, N.alinmaTarihi) = CAST(GETDATE() AS DATE)) OR
            (DATEADD(day, 7, N.alinmaTarihi) = CAST(GETDATE() AS DATE)) OR
            (DATEADD(day, 14, N.alinmaTarihi) = CAST(GETDATE() AS DATE)) OR
            (DATEADD(day, 28, N.alinmaTarihi) = CAST(GETDATE() AS DATE))
        ORDER BY KirimPeriyodu ASC, N.alinmaTarihi ASC;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dgvBugunkuKirimlar.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bugünkü kırım listesi yüklenirken hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void YarinkiKirimlariDoldur()
        {
            string query = @"
        SELECT
            N.numuneId AS ID, 
            N.numuneNo AS NumuneNo, 
            N.alinmaTarihi AS AlınmaTarihi,
            IFirma.firmaAdi AS Firma,
            -- R.receteKodu AS Reçete,  -- BU SATIRI SİLİN VEYA YORUMA ALIN
            -- S.santralAdi AS Santral,   -- BU SATIRI SİLİN VEYA YORUMA ALIN
            CASE
                WHEN DATEADD(day, 1, N.alinmaTarihi) = CAST(DATEADD(day, 1, GETDATE()) AS DATE) THEN '1 Günlük Kırım'
                WHEN DATEADD(day, 2, N.alinmaTarihi) = CAST(DATEADD(day, 1, GETDATE()) AS DATE) THEN '2 Günlük Kırım'
                WHEN DATEADD(day, 3, N.alinmaTarihi) = CAST(DATEADD(day, 1, GETDATE()) AS DATE) THEN '3 Günlük Kırım'
                WHEN DATEADD(day, 7, N.alinmaTarihi) = CAST(DATEADD(day, 1, GETDATE()) AS DATE) THEN '7 Günlük Kırım'
                WHEN DATEADD(day, 14, N.alinmaTarihi) = CAST(DATEADD(day, 1, GETDATE()) AS DATE) THEN '14 Günlük Kırım'
                WHEN DATEADD(day, 28, N.alinmaTarihi) = CAST(DATEADD(day, 1, GETDATE()) AS DATE) THEN '28 Günlük Kırım'
                ELSE 'Diğer'
            END AS KirimPeriyodu
        FROM Numuneler AS N
        INNER JOIN InsaatFirmalari AS IFirma ON N.musteriFirmaId = IFirma.firmaId
        INNER JOIN Receteler AS R ON N.receteId = R.receteId
        INNER JOIN Santraller AS S ON N.santralId = S.santralId
        WHERE
            (DATEADD(day, 1, N.alinmaTarihi) = CAST(DATEADD(day, 1, GETDATE()) AS DATE)) OR
            (DATEADD(day, 2, N.alinmaTarihi) = CAST(DATEADD(day, 1, GETDATE()) AS DATE)) OR
            (DATEADD(day, 3, N.alinmaTarihi) = CAST(DATEADD(day, 1, GETDATE()) AS DATE)) OR
            (DATEADD(day, 7, N.alinmaTarihi) = CAST(DATEADD(day, 1, GETDATE()) AS DATE)) OR
            (DATEADD(day, 14, N.alinmaTarihi) = CAST(DATEADD(day, 1, GETDATE()) AS DATE)) OR
            (DATEADD(day, 28, N.alinmaTarihi) = CAST(DATEADD(day, 1, GETDATE()) AS DATE))
        ORDER BY KirimPeriyodu ASC, N.alinmaTarihi ASC;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dgvYarinkiKirimlar.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Yarınki kırım listesi yüklenirken hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void StilUygula(DataGridView dgv)
        {
            if (dgv == null) return;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BackgroundColor = Color.FromArgb(240, 240, 240);
            dgv.GridColor = Color.FromArgb(224, 224, 224);

            DataGridViewCellStyle defaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.FromArgb(50, 50, 50),
                SelectionBackColor = Color.FromArgb(52, 152, 219),
                SelectionForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                Padding = new Padding(5, 2, 5, 2)
            };
            dgv.DefaultCellStyle = defaultCellStyle;

            DataGridViewCellStyle alternatingCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(248, 249, 250),
                ForeColor = Color.FromArgb(50, 50, 50),
                SelectionBackColor = Color.FromArgb(62, 162, 229),
                SelectionForeColor = Color.White
            };
            dgv.AlternatingRowsDefaultCellStyle = alternatingCellStyle;

            dgv.EnableHeadersVisualStyles = false;
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(70, 70, 70), 
                ForeColor = Color.White,
                Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Padding = new Padding(5, 5, 5, 5)
            };
            dgv.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
            dgv.ColumnHeadersHeight = 30;

            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;

            if (dgv.Columns["ID"] != null) dgv.Columns["ID"].Visible = false;
            if (dgv.Columns["NumuneReceteId"] != null) dgv.Columns["NumuneReceteId"].Visible = false; 

            if (dgv.Columns["NumuneNo"] != null) dgv.Columns["NumuneNo"].HeaderText = "Numune No";
            if (dgv.Columns["AlınmaTarihi"] != null) dgv.Columns["AlınmaTarihi"].HeaderText = "Alınma Tarihi";
            if (dgv.Columns["Firma"] != null) dgv.Columns["Firma"].HeaderText = "Firma";
            if (dgv.Columns["KirimPeriyodu"] != null) dgv.Columns["KirimPeriyodu"].HeaderText = "Kırım Periyodu";

            dgv.ClearSelection();
        }
        private void ChildForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sender is Form childForm)
            {
                if (childForm is NumuneKayitForm numuneKayitFormInstance) 
                {
                    if (numuneKayitFormInstance.VeriDegisikligiYapildi) 
                    {
                        BugunkuKirimlariDoldur();
                        YarinkiKirimlariDoldur();
                    }
                }

                childForm.FormClosed -= ChildForm_FormClosed;
            }
            this.Show();
        }

        private void btnNumuneKayit_Click(object sender, EventArgs e)
        {
            NumuneKayitForm frm = new NumuneKayitForm();

            frm.FormClosed += ChildForm_FormClosed;
            this.Hide();
            frm.Show();
        }

        private void btnİnsaat_Click(object sender, EventArgs e)
        {
            InsaatFirmalar frm = new InsaatFirmalar();
            frm.FormClosed += ChildForm_FormClosed;
            this.Hide();
            frm.Show();
        }

        private void btnKatki_Click(object sender, EventArgs e)
        {
            KatkiFirmaForm frm = new KatkiFirmaForm();
            frm.FormClosed += ChildForm_FormClosed;
            this.Hide();
            frm.Show();
        }

        private void btnSantral_Click(object sender, EventArgs e)
        {
            Santraller frm = new Santraller();
            frm.FormClosed += ChildForm_FormClosed;
            this.Hide();
            frm.Show();
        }

        private void btnReceteler_Click(object sender, EventArgs e)
        {
            Receteler frm = new Receteler();
            frm.FormClosed += ChildForm_FormClosed;
            this.Hide();
            frm.Show();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult result = MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BugunkuKirimlariDoldur();
            YarinkiKirimlariDoldur();
            StilUygula(dgvBugunkuKirimlar);
            StilUygula(dgvYarinkiKirimlar);
        }

        private void dgvBugunkuKirimlar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvBugunkuKirimlar.Rows.Count)
            {
                DataGridViewRow selectedRow = dgvBugunkuKirimlar.Rows[e.RowIndex];
                int numuneId = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                int receteId = Convert.ToInt32(selectedRow.Cells["NumuneReceteId"].Value);

                if (pnlAnaMenuDimmer != null) 
                {
                     pnlAnaMenuDimmer.Visible = true;
                     pnlAnaMenuDimmer.BringToFront();
                    this.Refresh(); 
                }

                try
                {
                    using (NumuneDetay detayForm = new NumuneDetay(numuneId, receteId))
                    {
                        detayForm.ShowDialog(this);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Numune detayları açılırken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (pnlAnaMenuDimmer != null) 
                    {
                        pnlAnaMenuDimmer.Visible = false;
                    }

                    dgvBugunkuKirimlar.ClearSelection();
                }
            }
        }

        private void dgvYarinkiKirimlar_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvYarinkiKirimlar.SelectedRows.Count > 0)
            {
                dgvYarinkiKirimlar.ClearSelection();
            }
        }

        private void btnBilgiDestek_Click(object sender, EventArgs e)
        {
            BilgiVeDestek frm = new BilgiVeDestek();
            frm.FormClosed += ChildForm_FormClosed;
            this.Hide();
            frm.Show();
        }
    }
}
