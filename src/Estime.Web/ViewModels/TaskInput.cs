using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Estime.Web.Models;

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
		public string ConsultantName { get; set; }

		[Required(ErrorMessage = "Kunde skal udfyldes")]
		[Display(Name = "Kunde")]
		public string ClientName { get; set; }

		[Required(ErrorMessage = "Dato skal udfyldes")]
		[Display(Name = "Dato")]
		public DateTime Timestamp { get; set; }

		[Display(Name = "Tid")]
		[Required(ErrorMessage = "Tid skal udfyldes")]
		[Range(1, int.MaxValue, ErrorMessage = "Tid skal udfyldes")]
		public int DurationInMinutes { get; set; }

		[Display(Name = "Tidstype")]
		[Required(ErrorMessage = "Du skal vælge tidstype")]
		public string Type { get; set; }

		[Display(Name = "Arbejdsbeskrivelse")]
		[Required(ErrorMessage = "Arbejdsbeskrivelse skal udfyldes")]
		public string Description { get; set; }

		[Display(Name = "Kørsel")]
		public bool Mileage { get; set; }

		public TaskStatus Status { get; set; }

		[Display(Name = "Hardware/software anvendt")]
		public List<SelectListItem> Wares { get; set; }

		[HiddenInput(DisplayValue = false)]
		public string SelectedWares { get; set; }
	}
}