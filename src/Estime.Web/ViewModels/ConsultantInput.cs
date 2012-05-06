using System.ComponentModel.DataAnnotations;

namespace Estime.Web.ViewModels
{
	public class ConsultantInput
	{
		[Required]
		[StringLength(50)]
		public string Sku { get; set; }

		[Required]
		[StringLength(255)]
		public string Name { get; set; }
	}
}