using System;
using System.Data;
using System.Data.SQLite; // SQLite kütüphanesi
using System.Drawing;
using System.IO; 
using System.Windows.Forms;

namespace ModaTakip
{
    public partial class FrmKumasEnvanter : Form
    {
        
        public string yetkiDurumu;

      
        string secilenResimYolu = "";

        public FrmKumasEnvanter()
        {
            InitializeComponent();
        }

    
        private void FrmKumasEnvanter_Load(object sender, EventArgs e)
        {
            Listele();             
            TasarimcilariGetir();  
            KumasTurleriniDoldur();

            
            if (yetkiDurumu == "Tasarimci")
            {
                btnEkle.Enabled = false;
                btnGuncelle.Enabled = false;
                btnSil.Enabled = false;

                btnEkle.BackColor = Color.Gray;
                btnGuncelle.BackColor = Color.Gray;
                btnSil.BackColor = Color.Gray;
            }
        }

       

        void KumasTurleriniDoldur()
        {
            cmbKumasTuru.Items.Clear();
            string[] turler = {
                "Pamuk", "Polyester", "İpek", "Keten", "Saten",
                "Kadife", "Kot (Denim)", "Viskon", "Yün", "Şifon", "Deri"
            };
            cmbKumasTuru.Items.AddRange(turler);
        }

        void Listele()
        {
            using (SQLiteConnection conn = new SQLiteConnection(Baglanti.connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Tbl_Kumaslar";
                SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                if (dataGridView1.Columns["KumasId"] != null)
                {
                    dataGridView1.Columns["KumasId"].Visible = false;
                }
            }
        }

        void TasarimcilariGetir()
        {
            cmbTasarimci.Items.Clear();
            using (SQLiteConnection conn = new SQLiteConnection(Baglanti.connectionString))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand("SELECT KullaniciAdi FROM Tbl_Kullanicilar", conn);
                SQLiteDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cmbTasarimci.Items.Add(dr[0].ToString());
                }
            }
        }

        void Temizle()
        {
            txtKumasKodu.Clear();
            txtRenkKodu.Clear();
            txtFiyat.Clear();
            cmbKumasTuru.SelectedIndex = -1;
            cmbTasarimci.SelectedIndex = -1;
            nudStok.Value = 0;
            secilenResimYolu = "";
        }

    

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtKumasKodu.Text == "" || cmbKumasTuru.Text == "")
            {
                MessageBox.Show("Lütfen Kumaş Kodu ve Türünü giriniz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SQLiteConnection conn = new SQLiteConnection(Baglanti.connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "INSERT INTO Tbl_Kumaslar (KumasKodu, KumasTuru, RenkKodu, StokMiktari, BirimFiyat, Tasarimci, GorselYolu) VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7)";
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@p1", txtKumasKodu.Text);
                    cmd.Parameters.AddWithValue("@p2", cmbKumasTuru.Text);
                    cmd.Parameters.AddWithValue("@p3", txtRenkKodu.Text);
                    cmd.Parameters.AddWithValue("@p4", nudStok.Value);
                    cmd.Parameters.AddWithValue("@p5", txtFiyat.Text);
                    cmd.Parameters.AddWithValue("@p6", cmbTasarimci.Text);
                    cmd.Parameters.AddWithValue("@p7", secilenResimYolu);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kumaş başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Listele();
                    Temizle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu: " + ex.Message);
                }
            }
        }

        
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                
                decimal mevcutStok = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["StokMiktari"].Value);
                string kumasTuru = dataGridView1.CurrentRow.Cells["KumasTuru"].Value.ToString();
                string id = dataGridView1.CurrentRow.Cells["KumasId"].Value.ToString();

                
                if (mevcutStok <= 0)
                {
                    MessageBox.Show("Bu kumaşın stoğu zaten bitmiş. İşlem yapılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                
                DialogResult cevap = MessageBox.Show("Stoktan 1 adet düşmek istiyor musunuz?", "Stok Çıkışı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (cevap == DialogResult.Yes)
                {
                    using (SQLiteConnection conn = new SQLiteConnection(Baglanti.connectionString))
                    {
                        conn.Open();

                        
                        if (mevcutStok == 1)
                        {
                            string silSQL = "DELETE FROM Tbl_Kumaslar WHERE KumasId=@p1";
                            SQLiteCommand cmdSil = new SQLiteCommand(silSQL, conn);
                            cmdSil.Parameters.AddWithValue("@p1", id);
                            cmdSil.ExecuteNonQuery();

                            MessageBox.Show(kumasTuru + " kumaşı stoklarınızda tamamen bitti. Kayıt silindi.", "Stok Tükendi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        
                        else
                        {
                            string guncelleSQL = "UPDATE Tbl_Kumaslar SET StokMiktari = StokMiktari - 1 WHERE KumasId = @p1";
                            SQLiteCommand cmdGuncelle = new SQLiteCommand(guncelleSQL, conn);
                            cmdGuncelle.Parameters.AddWithValue("@p1", id);
                            cmdGuncelle.ExecuteNonQuery();

                            MessageBox.Show("Stok 1 adet eksiltildi. Kalan Stok: " + (mevcutStok - 1), "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        Listele(); 
                        Temizle();
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen işlem yapılacak kumaşı seçin.");
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string id = dataGridView1.CurrentRow.Cells["KumasId"].Value.ToString();

                using (SQLiteConnection conn = new SQLiteConnection(Baglanti.connectionString))
                {
                    try
                    {
                        conn.Open();
                        string sql = "UPDATE Tbl_Kumaslar SET KumasKodu=@p1, KumasTuru=@p2, RenkKodu=@p3, StokMiktari=@p4, BirimFiyat=@p5, Tasarimci=@p6, GorselYolu=@p7 WHERE KumasId=@id";
                        SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@p1", txtKumasKodu.Text);
                        cmd.Parameters.AddWithValue("@p2", cmbKumasTuru.Text);
                        cmd.Parameters.AddWithValue("@p3", txtRenkKodu.Text);
                        cmd.Parameters.AddWithValue("@p4", nudStok.Value);
                        cmd.Parameters.AddWithValue("@p5", txtFiyat.Text);
                        cmd.Parameters.AddWithValue("@p6", cmbTasarimci.Text);
                        cmd.Parameters.AddWithValue("@p7", secilenResimYolu);
                        cmd.Parameters.AddWithValue("@id", id);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Kumaş güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Listele();
                        Temizle();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen güncellenecek satırı seçin.");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            txtKumasKodu.Text = dataGridView1.Rows[e.RowIndex].Cells["KumasKodu"].Value.ToString();
            cmbKumasTuru.Text = dataGridView1.Rows[e.RowIndex].Cells["KumasTuru"].Value.ToString();
            txtRenkKodu.Text = dataGridView1.Rows[e.RowIndex].Cells["RenkKodu"].Value.ToString();
            txtFiyat.Text = dataGridView1.Rows[e.RowIndex].Cells["BirimFiyat"].Value.ToString();
            cmbTasarimci.Text = dataGridView1.Rows[e.RowIndex].Cells["Tasarimci"].Value.ToString();

            if (dataGridView1.Rows[e.RowIndex].Cells["StokMiktari"].Value != DBNull.Value)
            {
                nudStok.Value = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["StokMiktari"].Value);
            }

            string dbGelenYol = dataGridView1.Rows[e.RowIndex].Cells["GorselYolu"].Value.ToString();
            secilenResimYolu = dbGelenYol;

        }
    }
}