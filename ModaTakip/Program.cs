using System;
using System.Windows.Forms;

namespace ModaTakip
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // .NET 6/8 kullaniyorsan bu ayarlar varsayilan gelir:
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // ÖNEMLİ: Veritabanını kontrol et ve yoksa oluştur
            Baglanti.VeritabaniOlustur();

            // Giriş formuyla başla
            Application.Run(new FrmGiris());
        }
    }
}
