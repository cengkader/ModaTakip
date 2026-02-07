using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace ModaTakip
{
    public class Baglanti
    {
        
        private static string dbFileName = "Moda.db";
        
        public static string connectionString = $"Data Source={dbFileName};Version=3;";



        
        public static void VeritabaniOlustur()
        {
            if (!File.Exists(dbFileName))
            {
                SQLiteConnection.CreateFile(dbFileName);

                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    
                    string sqlUsers = @"CREATE TABLE Tbl_Kullanicilar (
                                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                        Ad TEXT,
                                        Soyad TEXT,
                                        UzmanlikAlani TEXT,
                                        KullaniciAdi TEXT UNIQUE,
                                        Sifre TEXT,
                                        Durum TEXT
                                        )";

                    SQLiteCommand cmdUsers = new SQLiteCommand(sqlUsers, conn);
                    cmdUsers.ExecuteNonQuery();

                    
                    string sqlAdminEkle = "INSERT INTO Tbl_Kullanicilar (Ad, Soyad, UzmanlikAlani, KullaniciAdi, Sifre, Durum) VALUES ('Sistem', 'Yöneticisi', 'Admin', 'admin', '123', 'Aktif')";
                    SQLiteCommand cmdAdmin = new SQLiteCommand(sqlAdminEkle, conn);
                    cmdAdmin.ExecuteNonQuery();

                    
                    string sqlFabrics = @"CREATE TABLE Tbl_Kumaslar (
                                          KumasId INTEGER PRIMARY KEY AUTOINCREMENT,
                                          KumasKodu TEXT,
                                          KumasTuru TEXT,
                                          RenkKodu TEXT,
                                          StokMiktari INTEGER,
                                          BirimFiyat DECIMAL,
                                          Tasarimci TEXT,
                                          GorselYolu TEXT
                                          )";

                    SQLiteCommand cmdFabrics = new SQLiteCommand(sqlFabrics, conn);
                    cmdFabrics.ExecuteNonQuery();
                }
            }
        }
    }
}
