using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace ModaTakip
{
    public partial class FrmTasarimciYonetimi : Form
    {
        
        private const string ID_COLUMN = "Id"; 

        private readonly string _connectionString = Baglanti.connectionString + ";BusyTimeout=5000;";

        
        private static bool _pragmasAppliedOnce = false;

        public FrmTasarimciYonetimi()
        {
            InitializeComponent();
        }

        private void FrmTasarimciYonetimi_Load(object sender, EventArgs e)
        {
            rbAktif.Checked = true;
            Listele();
        }

       
        private SQLiteConnection CreateConnection()
        {
            return new SQLiteConnection(_connectionString);
        }

        private void ApplyPragmas(SQLiteConnection conn)
        {
          
            if (_pragmasAppliedOnce) return;

            using (var cmd = new SQLiteCommand(conn))
            {
                cmd.CommandText = "PRAGMA journal_mode=WAL;";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "PRAGMA busy_timeout=5000;";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "PRAGMA foreign_keys=ON;";
                cmd.ExecuteNonQuery();

                
                cmd.CommandText = "PRAGMA synchronous=NORMAL;";
                cmd.ExecuteNonQuery();
            }

            _pragmasAppliedOnce = true;
        }

        private void RunDbAction(Action action)
        {
            
            btnEkle.Enabled = btnSil.Enabled = btnGuncelle.Enabled = false;
            Cursor = Cursors.WaitCursor;

            try { action(); }
            finally
            {
                Cursor = Cursors.Default;
                btnEkle.Enabled = btnSil.Enabled = btnGuncelle.Enabled = true;
            }
        }

        private bool IsAdmin()
        {
            return string.Equals(oturum.UzmanlikAlani, "Admin", StringComparison.OrdinalIgnoreCase);
        }

        private bool TryGetSelectedId(out int id)
        {
            id = 0;

            if (dataGridView1.CurrentRow == null)
                return false;

            var cell = dataGridView1.CurrentRow.Cells[ID_COLUMN];
            if (cell == null || cell.Value == null || cell.Value == DBNull.Value)
                return false;

            return int.TryParse(cell.Value.ToString(), out id);
        }

        private string GetDurum()
        {
            return rbAktif.Checked ? "Aktif" : "Pasif";
        }

        private void Temizle()
        {
            txtAd.Clear();
            txtSoyad.Clear();
            txtUzmanlik.Clear();
            txtKullaniciAdi.Clear();
            txtSifre.Clear();
            rbAktif.Checked = true;
        }

       
        private void Listele()
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    conn.Open();
                    ApplyPragmas(conn);

                    using (var da = new SQLiteDataAdapter("SELECT * FROM Tbl_Kullanicilar", conn))
                    {
                        var dt = new DataTable();
                        da.Fill(dt);

                        dataGridView1.DataSource = dt;
                    }

                    
                    if (dataGridView1.Columns[ID_COLUMN] != null)
                        dataGridView1.Columns[ID_COLUMN].Visible = false;

                    dataGridView1.ClearSelection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Listeleme Hatası: " + ex.Message);
                }
            }
        }

        
        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (!IsAdmin())
            {
                MessageBox.Show($"Bu işlemi yapmaya yetkiniz yok!\nSizin Yetkiniz: {oturum.UzmanlikAlani}",
                    "Erişim Engellendi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text) || string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                MessageBox.Show("Kullanıcı Adı ve Şifre zorunludur!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RunDbAction(() =>
            {
                using (var conn = CreateConnection())
                {
                    conn.Open();
                    ApplyPragmas(conn);

                    using (var tx = conn.BeginTransaction())
                    using (var cmd = new SQLiteCommand(conn))
                    {
                        cmd.Transaction = tx;
                        cmd.CommandText =
                            @"INSERT INTO Tbl_Kullanicilar (Ad, Soyad, UzmanlikAlani, KullaniciAdi, Sifre, Durum)
                              VALUES (@ad, @soyad, @uzmanlik, @kadi, @sifre, @durum);";

                        cmd.Parameters.AddWithValue("@ad", txtAd.Text.Trim());
                        cmd.Parameters.AddWithValue("@soyad", txtSoyad.Text.Trim());
                        cmd.Parameters.AddWithValue("@uzmanlik", txtUzmanlik.Text.Trim());
                        cmd.Parameters.AddWithValue("@kadi", txtKullaniciAdi.Text.Trim());
                        cmd.Parameters.AddWithValue("@sifre", txtSifre.Text.Trim());
                        cmd.Parameters.AddWithValue("@durum", GetDurum());

                        cmd.ExecuteNonQuery();
                        tx.Commit();
                    }
                }

                MessageBox.Show("Kullanıcı eklendi.", "Bilgi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
                Temizle();
            });
        }

        
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (!IsAdmin())
            {
                MessageBox.Show($"Silme işlemini yapmaya yetkiniz yok!\nSizin Yetkiniz: {oturum.UzmanlikAlani}",
                    "Erişim Engellendi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (!TryGetSelectedId(out int id))
            {
                MessageBox.Show("Lütfen silinecek satırı seçin.");
                return;
            }

            var cevap = MessageBox.Show("Kullanıcıyı silmek istiyor musunuz?", "Silme Onayı",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (cevap != DialogResult.Yes) return;

            RunDbAction(() =>
            {
                using (var conn = CreateConnection())
                {
                    conn.Open();
                    ApplyPragmas(conn);

                    using (var tx = conn.BeginTransaction())
                    using (var cmd = new SQLiteCommand(conn))
                    {
                        cmd.Transaction = tx;
                        cmd.CommandText = $"DELETE FROM Tbl_Kullanicilar WHERE {ID_COLUMN}=@id;";
                        cmd.Parameters.AddWithValue("@id", id);

                        cmd.ExecuteNonQuery();
                        tx.Commit();
                    }
                }

                MessageBox.Show("Kayıt Silindi");
                Listele();
                Temizle();
            });
        }

       
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (!IsAdmin())
            {
                MessageBox.Show("Güncelleme işlemini yapmaya yetkiniz yok!", "Erişim Engellendi",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (!TryGetSelectedId(out int id))
            {
                MessageBox.Show("Güncellenecek satırı seçin.");
                return;
            }

            RunDbAction(() =>
            {
                using (var conn = CreateConnection())
                {
                    conn.Open();
                    ApplyPragmas(conn);

                    using (var tx = conn.BeginTransaction())
                    using (var cmd = new SQLiteCommand(conn))
                    {
                        cmd.Transaction = tx;
                        cmd.CommandText =
                            $@"UPDATE Tbl_Kullanicilar
                               SET Ad=@ad, Soyad=@soyad, UzmanlikAlani=@uzmanlik,
                                   KullaniciAdi=@kadi, Sifre=@sifre, Durum=@durum
                               WHERE {ID_COLUMN}=@id;";

                        cmd.Parameters.AddWithValue("@ad", txtAd.Text.Trim());
                        cmd.Parameters.AddWithValue("@soyad", txtSoyad.Text.Trim());
                        cmd.Parameters.AddWithValue("@uzmanlik", txtUzmanlik.Text.Trim());
                        cmd.Parameters.AddWithValue("@kadi", txtKullaniciAdi.Text.Trim());
                        cmd.Parameters.AddWithValue("@sifre", txtSifre.Text.Trim());
                        cmd.Parameters.AddWithValue("@durum", GetDurum());
                        cmd.Parameters.AddWithValue("@id", id);

                        cmd.ExecuteNonQuery();
                        tx.Commit();
                    }
                }

                MessageBox.Show("Bilgiler güncellendi.", "Bilgi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
                Temizle();
            });
        }

        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridView1.Rows[e.RowIndex];

            txtAd.Text = row.Cells["Ad"]?.Value?.ToString() ?? "";
            txtSoyad.Text = row.Cells["Soyad"]?.Value?.ToString() ?? "";
            txtUzmanlik.Text = row.Cells["UzmanlikAlani"]?.Value?.ToString() ?? "";
            txtKullaniciAdi.Text = row.Cells["KullaniciAdi"]?.Value?.ToString() ?? "";
            txtSifre.Text = row.Cells["Sifre"]?.Value?.ToString() ?? "";

            string durum = row.Cells["Durum"]?.Value?.ToString() ?? "Aktif";
            rbAktif.Checked = durum.Equals("Aktif", StringComparison.OrdinalIgnoreCase);
            rbPasif.Checked = !rbAktif.Checked;
        }
    }
}

