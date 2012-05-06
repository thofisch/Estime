using System;

namespace Estime.Web.ViewModels
{
	public class ClientListViewModel
	{
		public Guid Id { get; set; }
		public string Sku { get; set; }
		public string Name { get; set; }
		public int NumberOfProjects { get; set; }
	}
}