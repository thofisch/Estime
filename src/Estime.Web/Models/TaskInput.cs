using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Estime.Web.Models
{
	public static class DateTimeExtensions
	{
		public static DateTime GetNearestMinute(this DateTime date, int minute = 15)
		{
			//minute = Math.Max(30, Math.Min(5, minute));

			//var nearest = date.Minute / minute * minute;
			//var remainder = date.Minute % nearest;
			//if( remainder>nearest / 2 )
			//{
			//    nearest += nearest;
			//}

			return new DateTime(date.Year, date.Month, date.Day, date.Hour, 0, 0)/*.AddMinutes(nearest)*/;
		}
	}

	public class TaskInput
	{
		public TaskInput()
		{
			Timestamp = DateTime.Now.GetNearestMinute();
			Wares = new List<string>();
		}

		[Required(ErrorMessage = "Konsulent skal udfyldes")]
		[Display(Name = "Konsulent")]
		public string Consultant { get; set; }

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
		public List<string> Wares { get; set; }
	}

	public enum TaskStatus
	{
		Open = 0,
		Closed,
		Posted
	}

	public class Task
	{
		public Customer Customer { get; set; }
		public Consultant Consultant { get; set; }

		public DateTime Timestamp { get; set; }
		public Duration Duration { get; set; }
		public string Description { get; set; }
		public double Mileage { get; set; }
		public TimeType Type { get; set; }
		public TaskStatus Status { get; set; }

		// Asset/Ware

		public DateTime CreatedAt { get; set; }
		public string CreatedBy { get; set; }
		public DateTime UpdatedAt { get; set; }
		public string UpdatedBy { get; set; }
	}

	public class Duration
	{
		public int Hours { get; set; }
		public int Minutes { get; set; }
	}

	public class Consultant
	{
	}

	public class Customer
	{
	}

	public class TimeType
	{
	}
}