using System;

namespace Estime.Web.ViewModels
{
	public class OpenProjectListViewModel
	{
		public Guid ProjectId { get; set; }
		public string ProjectName { get; set; }
		public string ClientName { get; set; }
		public int TotalDurationInMinutes { get; set; }
		public int TotalNumberOfWares { get; set; }
	}
}