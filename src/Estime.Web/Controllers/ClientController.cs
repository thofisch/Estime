using System;
using System.Linq;
using System.Web.Mvc;
using Estime.Web.Models;
using NHibernate.Criterion;

namespace Estime.Web.Controllers
{
	public class ClientController : SessionController
	{
		public ActionResult New()
		{
			return View("Edit", new Client());
		}

		public ActionResult Edit(Guid id)
		{
			var client = Session.Get<Client>(id);

			return View(client);
		}

		[HttpPost]
		public ActionResult Edit(Client client)
		{
			Session.SaveOrUpdate(client);
		
			return RedirectToAction("New");
		}

		public ActionResult List()
		{
			var clients = Session.QueryOver<Client>().OrderBy(x => x.Name).Desc.List();

			return View(clients);
		}
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