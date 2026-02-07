using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Drawing2D; 
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting; 

namespace ModaTakip
{
    public partial class FrmRaporlama : Form
    {
        public FrmRaporlama()
        {
            InitializeComponent();
        }


        private void FrmRaporlama_Load(object sender, EventArgs e)
        {
            VerileriGetir();      
            GrafikleriDoldur();  

            
            PaneliYuvarlat(pnlToplamKumas, 30);
            PaneliYuvarlat(pnlOrtFiyat, 30);
            PaneliYuvarlat(pnlSolKutu, 30);
            PaneliYuvarlat(pnlSagKutu, 30);
            PaneliYuvarlat(panelTasarimci, 30);
        }

        
        void VerileriGetir()
        {
            using (SQLiteConnection conn = new SQLiteConnection(Baglanti.connectionString))
            {
                try
                {
                    conn.Open();

                    
                    SQLiteCommand cmd1 = new SQLiteCommand("SELECT COUNT(*) FROM Tbl_Kumaslar", conn);
                    object sonuc1 = cmd1.ExecuteScalar();
                    lblToplamKumas.Text = (sonuc1 != null) ? sonuc1.ToString() : "0";

                    
                    SQLiteCommand cmd2 = new SQLiteCommand("SELECT AVG(BirimFiyat) FROM Tbl_Kumaslar", conn);
                    object sonuc2 = cmd2.ExecuteScalar();

                    if (sonuc2 != DBNull.Value && sonuc2 != null)
                    {
                        double ortalama = Convert.ToDouble(sonuc2);
                        lblOrtalamaFiyat.Text = ortalama.ToString("C2");
                    }
                    else
                    {
                        lblOrtalamaFiyat.Text = "0.00 ₺";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri çekme hatası: " + ex.Message);
                }
            }
        }

  
        void GrafikleriDoldur()
        {
            using (SQLiteConnection conn = new SQLiteConnection(Baglanti.connectionString))
            {
                conn.Open();

          
                SQLiteCommand cmdSol = new SQLiteCommand("SELECT KumasTuru, SUM(StokMiktari) FROM Tbl_Kumaslar GROUP BY KumasTuru", conn);
                SQLiteDataReader drSol = cmdSol.ExecuteReader();

                chartSol.Series.Clear();
                Series seriSol = new Series("Stok Miktarı");
                seriSol.ChartType = SeriesChartType.Column; 
                chartSol.Palette = ChartColorPalette.SeaGreen;

                
                seriSol.IsValueShownAsLabel = true;

                chartSol.Series.Add(seriSol);

                while (drSol.Read())
                {
                    
                    
                    seriSol.Points.AddXY(drSol[0].ToString(), Convert.ToInt32(drSol[1]));
                }
                drSol.Close();


                
                SQLiteCommand cmdSag = new SQLiteCommand("SELECT UzmanlikAlani, Durum, COUNT(*) FROM Tbl_Kullanicilar GROUP BY UzmanlikAlani, Durum", conn);
                SQLiteDataReader drSag = cmdSag.ExecuteReader();

                chartSag.Series.Clear();
                Series seriSag = new Series("Kullanicilar");
                seriSag.ChartType = SeriesChartType.Pie; 
                chartSag.Palette = ChartColorPalette.BrightPastel;
                chartSag.Series.Add(seriSag);

                while (drSag.Read())
                {
                    string unvan = drSag[0].ToString(); 
                    string durum = drSag[1].ToString(); 
                    int sayi = Convert.ToInt32(drSag[2]);

                    string etiket = "";
                    if (unvan == "Admin") etiket = "Admin";
                    else etiket = durum + " Tasarımcı";

                    seriSag.Points.AddXY(etiket, sayi);
                }
                drSag.Close();


           
                SQLiteCommand cmdAlt = new SQLiteCommand("SELECT KumasTuru, AVG(BirimFiyat) FROM Tbl_Kumaslar GROUP BY KumasTuru", conn);
                SQLiteDataReader drAlt = cmdAlt.ExecuteReader();

                chartAlt.Series.Clear();
                Series seriAlt = new Series("FiyatAnalizi");
                seriAlt.ChartType = SeriesChartType.SplineArea;
                seriAlt.Color = Color.CornflowerBlue;
                chartAlt.Series.Add(seriAlt);

                while (drAlt.Read())
                {
                    seriAlt.Points.AddXY(drAlt[0].ToString(), Convert.ToDouble(drAlt[1]));
                }
                drAlt.Close();
            }
        }

       
        private void PaneliYuvarlat(Panel pnl, int yariCap)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.StartFigure();

            gp.AddArc(new Rectangle(0, 0, yariCap, yariCap), 180, 90);
            gp.AddArc(new Rectangle(pnl.Width - yariCap, 0, yariCap, yariCap), 270, 90);
            gp.AddArc(new Rectangle(pnl.Width - yariCap, pnl.Height - yariCap, yariCap, yariCap), 0, 90);
            gp.AddArc(new Rectangle(0, pnl.Height - yariCap, yariCap, yariCap), 90, 90);

            gp.CloseFigure();
            pnl.Region = new Region(gp);
        }
    }
}