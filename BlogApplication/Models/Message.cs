namespace BlogApplication.Models
{
	public class Message:BaseEntity
	{
		public string Konu { get; set; }
		public string Email { get; set; }
		public string Name { get; set; }
		public string Mesaj { get; set; }
	}
}
