using System.Linq;
using System.Web.Mvc;

namespace Estime.Web.Controllers
{
	public class WareController : SessionController
	{
		public ActionResult Find(string term)
		{
			term = term.ToLower();

			var wares = new[]
			{
				new Ware {Id = 1, Name = "skærm"},
				new Ware {Id = 2, Name = "tastatur"},
				new Ware {Id = 3, Name = "windows 7"},
			};

			var projection = from ware in wares
				where ware.Name.Contains(term)
				select new
				{
					id = ware.Id,
					label = ware.Name,
					value = ware.Name
				};

			return Json(projection.ToList(), JsonRequestBehavior.AllowGet);
		}
	}

	public class Ware
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}