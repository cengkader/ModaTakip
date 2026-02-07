using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace ModaTakip
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        private void FrmGiris_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnGiris;
            txtSifre.UseSystemPasswordChar = true;


        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string kAdi = txtKullaniciAdi.Text.Trim();
            string sifre = txtSifre.Text.Trim();

            if (string.IsNullOrWhiteSpace(kAdi) || string.IsNullOrWhiteSpace(sifre))
            {
                MessageBox.Show("Lütfen kullanıcı adı ve şifre giriniz.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = @"
                SELECT Id, Ad, Soyad, UzmanlikAlani, Durum
                FROM Tbl_Kullanicilar
                WHERE KullaniciAdi = @p1 AND Sifre = @p2
                LIMIT 1;";

            try
            {
                using (var conn = new SQLiteConnection(Baglanti.connectionString + ";BusyTimeout=5000;"))
                {
                    conn.Open();

                    // (Öneri) locked azaltmak için:
                    using (var pragma = new SQLiteCommand("PRAGMA journal_mode=WAL; PRAGMA busy_timeout=5000;", conn))
                        pragma.ExecuteNonQuery();

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@p1", kAdi);
                        cmd.Parameters.AddWithValue("@p2", sifre);

                        using (var dr = cmd.ExecuteReader())
                        {
                            if (!dr.Read())
                            {
                                MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre!", "Hata",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            string durum = dr["Durum"]?.ToString() ?? "";
                            if (durum.Equals("Pasif", StringComparison.OrdinalIgnoreCase))
                            {
                                MessageBox.Show("Giriş yetkiniz pasif. Sisteme giriş yapamazsınız.",
                                    "Erişim Engellendi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }

                            
                            string uzmanlik = dr["UzmanlikAlani"]?.ToString() ?? "";
                            string ad = dr["Ad"]?.ToString() ?? "";
                            string soyad = dr["Soyad"]?.ToString() ?? "";
                            string adSoyad = (ad + " " + soyad).Trim();

                            oturum.UzmanlikAlani = uzmanlik;   
                            oturum.AdSoyad = adSoyad;

                            MessageBox.Show($"Hoşgeldiniz {adSoyad}\nYetki: {uzmanlik}", "Giriş Başarılı",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                        
                            FrmAnasayfa frm = new FrmAnasayfa();

                            frm.Show();
                            this.Hide();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

