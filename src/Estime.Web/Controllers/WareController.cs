using System.Linq;
using System.Web.Mvc;
using Estime.Web.Infrastructure.Persistence.Queries;
using Estime.Web.Util;

namespace Estime.Web.Controllers
{
	public class WareController : SessionController
	{
		public ActionResult Find(string term)
		{
			var quantityAndName = term.GetQuantityAndName();
			var wares = Query(new WareQuery(quantityAndName));
			var models = from ware in wares select new {label = ware, value = ware};

			return Json(models.ToList(), JsonRequestBehavior.AllowGet);
		}
	}
}