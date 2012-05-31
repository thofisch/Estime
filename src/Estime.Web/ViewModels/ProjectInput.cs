using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Estime.Web.ViewModels
{
	public class ProjectInput
	{
		[HiddenInput(DisplayValue = false)]
		public Guid Id { get; set; }

		[HiddenInput(DisplayValue = false)]
		public Guid ClientId { get; set; }

		[Required]
		[StringLength(255)]
		public string Name { get; set; }
	}
}