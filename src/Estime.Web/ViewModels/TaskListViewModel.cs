using System;

namespace Estime.Web.ViewModels
{
	public class TaskListViewModel
	{
		public Guid Id { get; set; }
		public string ConsultantName { get; set; }
		public string ClientName { get; set; }
		public string ProjectName { get; set; }
		public DateTime Timestamp { get; set; }
		public int DurationInMinutes { get; set; }
		public bool Mileage { get; set; }
		public string Description { get; set; }
		public int WaresCount { get; set; }
		public bool StandardTask { get; set; }
	}
}