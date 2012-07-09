using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Estime.Web.ViewModels
{
	public class TaskInput
	{
		public TaskInput()
		{
			Wares = new List<SelectListItem>();
		}

		[HiddenInput(DisplayValue = false)]
		public Guid? Id { get; set; }

		[Required(ErrorMessage = "Konsulent skal udfyldes")]
		[Display(Name = "Konsulent")]
		public Guid ConsultantId { get; set; }

		[Required(ErrorMessage = "Kunde/projekt skal udfyldes")]
		[Display(Name = "Kunde/projekt")]
		public Guid ProjectId { get; set; }

		[Required(ErrorMessage = "Dato skal udfyldes")]
		[Display(Name = "Dato")]
		public DateTime Timestamp { get; set; }

		public int DurationInMinutes { get; set; }

		public string Description { get; set; }

		[Display(Name = "Kørsel")]
		public bool Mileage { get; set; }

		[Display(Name = "Lukket")]
		public bool Closed { get; set; }

		[Display(Name = "Hardware/software anvendt")]
		public List<SelectListItem> Wares { get; set; }

		[HiddenInput(DisplayValue = false)]
		public string SelectedWares { get; set; }
	}
}