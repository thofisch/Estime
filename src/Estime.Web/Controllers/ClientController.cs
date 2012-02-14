using System;
using System.Linq;
using System.Web.Mvc;

namespace Estime.Web.Controllers
{
	public class ClientController : SessionController
	{
		public ActionResult Find(string term)
		{
			var clients = new[]
			{
				new Client {Id = 1, Name = "Dong"},
				new Client {Id = 1, Name = "Microsoft"},
				new Client {Id = 1, Name = "Mærsk"},
			};

			var projection = from client in clients
				where client.Name.StartsWith(term, StringComparison.OrdinalIgnoreCase)
				select new
				{
					id = client.Id,
					label = client.Name,
					value = client.Name
				};

			return Json(projection.ToList(), JsonRequestBehavior.AllowGet);
		}
	}

	public class Client
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}