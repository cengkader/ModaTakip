using ModaTakip;
using System;
using System.Windows.Forms;


namespace ModaTakip
{
    public partial class FrmAnasayfa : Form
    {
        
        public string kullaniciYetkisi = "";

        
        public FrmAnasayfa()
        {
            InitializeComponent();
        }

        
        public FrmAnasayfa(string yetki)
        {
            InitializeComponent();
            kullaniciYetkisi = yetki;
        }

        
        private void FrmAnasayfa_Load(object sender, EventArgs e)
        {
            
            this.Text = "Moda Kumaş Takip Sistemi - Aktif Kullanıcı: " + kullaniciYetkisi;
        }

      
        private void FormGetir(Form form)
        {
            pnlIcerik.Controls.Clear(); 
            form.TopLevel = false;      
            form.FormBorderStyle = FormBorderStyle.None; 
            form.Dock = DockStyle.Fill; 

            pnlIcerik.Controls.Add(form); 
            form.Show();                  
            form.BringToFront();          
        }


        
        private void btnKumasEnvanter_Click(object sender, EventArgs e)
        {
            FrmKumasEnvanter fr = new FrmKumasEnvanter();
            fr.yetkiDurumu = kullaniciYetkisi; 
            FormGetir(fr);
        }
        
        private void btnTasarimciYonetimi_Click(object sender, EventArgs e)
        {
            
            if (kullaniciYetkisi == "Tasarimci")
            {
                MessageBox.Show("Bu sayfaya erişim yetkiniz yok!\nSadece Yöneticiler (Admin) erişebilir.",
                                "Erişim Engellendi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

           
            FrmTasarimciYonetimi fr = new FrmTasarimciYonetimi();
            FormGetir(fr);
        }

        
        private void btnRaporlama_Click(object sender, EventArgs e)
        {
            FrmRaporlama fr = new FrmRaporlama();
            FormGetir(fr);
        }



        private void btnCikis_Click(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("Oturumu kapatmak istediğinize emin misiniz?",
                                                 "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (cevap == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pnlIcerik_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}