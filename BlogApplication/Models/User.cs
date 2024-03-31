using BlogApplication.Enums;

namespace BlogApplication.Models
{
    public class User:BaseEntity
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
        public string KullaniciAdi { get; set; }
        public Role Role { get; set; }
    }
}
