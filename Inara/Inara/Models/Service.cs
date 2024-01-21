using System.ComponentModel.DataAnnotations;

namespace Inara.Models
{
	public class Service
	{
		[Required]
		public int Id { get; set; }
		[Required,MinLength(3,ErrorMessage = "Length cannot be less than 3")]
		public string Title { get; set; }
		[Required, MinLength(5, ErrorMessage = "Length cannot be less than 5")]
		public string Description { get; set; }
		[Required]
		public string Image { get; set; }
	}
}
