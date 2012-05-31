using System;
using System.ComponentModel.DataAnnotations;
using Estime.Web.Models;

namespace Estime.Web.ViewModels
{
	public class TaskQueryInput
	{
		[Display(Name = "Konsulent")]
		public Guid? ConsultantId { get; set; }

		[Display(Name = "Kunde/projekt")]
		public Guid? ProjectId { get; set; }

		[Display(Name = "Fra")]
		public DateTime? From { get; set; }

		[Display(Name = "Til")]
		public DateTime? Until { get; set; }

		[Display(Name = "Status")]
		public TaskStatus? Status { get; set; }

		[Display(Name = "Fritekst")]
		public string Text { get; set; }
	}
}