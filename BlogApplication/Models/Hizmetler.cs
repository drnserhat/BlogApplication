using BlogApplication.Enums;

namespace BlogApplication.Models
{
    public class Hizmetler:BaseEntity
    {

        public string HizmetBaslik { get; set; }
        public string HizmetAltBaslik { get; set; }
        public string HizmetDetay { get; set; }
        public HizmetTipi HizmetTipi { get; set; }
        public string FotoUrl { get; set; }

    }
}
