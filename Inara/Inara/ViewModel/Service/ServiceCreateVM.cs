using System.ComponentModel.DataAnnotations;

namespace Inara.ViewModel.Service
{
	public class ServiceCreateVM
	{
		[Required, MinLength(3, ErrorMessage = "Length cannot be less than 3")]
		public string Title { get; set; }
		[Required, MinLength(5, ErrorMessage = "Length cannot be less than 5")]
		public string Description { get; set; }
		[Required]
		public IFormFile Image { get; set; }
	}
}