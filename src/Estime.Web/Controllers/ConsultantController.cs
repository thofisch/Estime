using System.Linq;
using System.Web.Mvc;

namespace Estime.Web.Controllers
{
	public class ConsultantController : SessionController
	{
		public ActionResult Find(string term)
		{
			term = term.ToLower();

			var consultants = new[]
			{
				new Consultant {Id = 1, Name = "Anders Vedel"},
				new Consultant {Id = 2, Name = "Thomas Fischer"},
				new Consultant {Id = 3, Name = "Rasmus Burkal"},
			};

			var projection = from consultant in consultants
				where consultant.Name.ToLower().Contains(term)
				select new
				{
					id = consultant.Id,
					label = consultant.Name,
					value = consultant.Name
				};

			return Json(projection.ToList(), JsonRequestBehavior.AllowGet);
		}
	}

	public class Consultant
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}