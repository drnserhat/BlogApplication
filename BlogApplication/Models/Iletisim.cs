namespace BlogApplication.Models
{
    public class Iletisim:BaseEntity
    {
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Adress { get; set; }
        public string Baslik { get; set; }
    }
}
