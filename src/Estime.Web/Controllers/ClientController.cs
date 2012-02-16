using System.Linq;
using System.Web.Mvc;
using Estime.Web.Models;
using NHibernate.Criterion;

namespace Estime.Web.Controllers
{
	public class ClientController : SessionController
	{
		public ActionResult Find(string term)
		{
			var clients = Session.QueryOver<Client>()
				.WhereRestrictionOn(x => x.Name).IsInsensitiveLike(term, MatchMode.Start)
				.List();

			var projections = from client in clients
				select new
				{
					label = client.Name,
					value = client.Name
				};

			return Json(projections.ToList(), JsonRequestBehavior.AllowGet);
		}
	}
}