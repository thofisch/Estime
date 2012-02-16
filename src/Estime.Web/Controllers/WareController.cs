using System.Linq;
using System.Web.Mvc;
using Estime.Web.Models;
using Estime.Web.Util;
using NHibernate.Criterion;

namespace Estime.Web.Controllers
{
	public class WareController : SessionController
	{
		public ActionResult Find(string term)
		{
			var quantityAndName = term.GetQuantityAndName();

			Ware wareAlias = null;
			var wares = Session.QueryOver<Task>()
				.Inner.JoinAlias(x => x.Wares, () => wareAlias)
				.WhereRestrictionOn(() => wareAlias.Name).IsInsensitiveLike(quantityAndName.Item2, MatchMode.Anywhere)
				.SelectList(list => list.SelectGroup(() => wareAlias.Name))
				.List<string>();

			var projection = from ware in wares
				let w = string.Format("{0}x{1}", quantityAndName.Item1, ware)
				select new
				{
					label = w,
					value = w
				};

			return Json(projection.ToList(), JsonRequestBehavior.AllowGet);
		}
	}
}