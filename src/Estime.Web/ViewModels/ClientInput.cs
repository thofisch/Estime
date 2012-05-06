using System;
using System.ComponentModel.DataAnnotations;

namespace Estime.Web.ViewModels
{
	public class ClientInput
	{
		[ScaffoldColumn(false)]
		public Guid Id { get; set; }

		[Required]
		[StringLength(50)]
		public string Sku { get; set; }

		[Required]
		[StringLength(255)]
		public string Name { get; set; }
	}
}