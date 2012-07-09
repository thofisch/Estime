using System;

namespace Estime.Web.ViewModels
{
	public class TaskExportViewModel
	{
		public string Name { get; set; }
		public string Sku { get; set; }
		public string ClientName { get; set; }
		public string ClientSku { get; set; }
		public string ProjectName { get; set; }
		public string ProjectSku { get; set; }
		public DateTime Timestamp { get; set; }
		public double Quantity { get; set; }
		public double Price { get; set; }
		public bool Mileage { get; set; }
		public string Description { get; set; }
		public bool StandardTask { get; set; }
	}
}