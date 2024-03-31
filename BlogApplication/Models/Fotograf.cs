using BlogApplication.Enums;

namespace BlogApplication.Models
{
    public class Fotograf:BaseEntity
    {
        public string FotoUrl { get; set; }
        public FotoTipi FotoTipi { get; set; }
        public int IslemSayfaID { get; set; }
    }
}
