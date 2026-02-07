![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET Framework](https://img.shields.io/badge/.NET_Framework-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![SQLite](https://img.shields.io/badge/SQLite-07405E?style=for-the-badge&logo=sqlite&logoColor=white)

#👗ModaTakip - Kumaş Envanter ve Personel Yönetim Sistemi
ModaTakip, moda evleri ve tekstil atölyeleri için tasarlanmış, rol tabanlı yetkilendirme sistemine sahip bir masaüstü envanter ve personel yönetim uygulamasıdır.

##Özellikler
🔐 Güvenlik ve Giriş Sistemi
Rol Tabanlı Erişim Kontrolü (RBAC): Kullanıcılar "Admin" veya "Tasarımcı" rollerine göre farklı yetkilere sahiptir.

Hesap Durum Yönetimi: Yöneticiler tarafından pasif hale getirilen kullanıcıların sisteme girişi otomatik olarak engellenir.

Dinamik Arayüz: Kullanıcının yetkisine göre menü seçenekleri kısıtlanır veya özelleştirilir.

##👤Yönetici (Admin) Paneli
Personel Yönetimi: Tasarımcı ekleme, silme, güncelleme ve aktiflik durumunu değiştirme.

Tam Envanter Kontrolü: Kumas stoklarını ekleme, güncelleme ve silme yetkisi.

##🎨Tasarımcı Paneli
Stok Görüntüleme: Mevcut kumaşların miktar ve özelliklerini anlık takip etme.

Raporlama ve Analiz: Grafik destekli raporlama ekranı ile üretim verilerini inceleme.

##🛠️Teknik Gereksinimler
Dil: C#

Platform: .NET Framework (Windows Forms)

Veritabanı: SQLite (System.Data.SQLite)

IDE: Visual Studio 2022+

##📂Proje Yapısı
SqliteHelper.cs: Veritabanı bağlantı yönetimi ve tablo oluşturma (DAL).

FrmGiris.cs: Kimlik doğrulama ve yetki kontrolü ekranı.

FrmAnasayfa.cs: Dinamik panel yapısı ile merkezi yönetim ekranı.

##⚙️Kurulum
Projeyi Visual Studio ile açın.

NuGet Paket Yöneticisi üzerinden System.Data.SQLite paketini kurun.

Projeyi derleyin (Build). Veritabanı dosyası (ModaTakipDB.sqlite) ilk çalıştırmada otomatik olarak oluşturulacaktır.

Varsayılan Giriş Bilgileri:

Kullanıcı Adı: admin

Şifre: 123
