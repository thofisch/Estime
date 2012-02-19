using System;
using System.Linq;
using System.Web.Mvc;
using Estime.Web.Models;
using Estime.Web.Util;

namespace Estime.Web.Controllers
{
	public class ConsultantController : SessionController
	{
		public ActionResult New()
		{
			return View("Edit", new Consultant());
		}

		public ActionResult Edit(Guid id)
		{
			var consultant = Session.Get<Consultant>(id);

			return View(consultant);
		}

		[HttpPost]
		public ActionResult Edit(Consultant consultant)
		{
			Session.SaveOrUpdate(consultant);
		
			return RedirectToAction("New");
		}

		public ActionResult List()
		{
			var consultants = Session.QueryOver<Consultant>().OrderBy(x => x.Name).Desc.List();

			return View(consultants);
		}

		public ActionResult Find(string term)
		{
			term = term.ToLower();

			var consultants = Session.QueryOver<Consultant>().OrderBy(x => x.Name).Desc.List();

			var projections = from consultant in consultants
				let name = consultant.Name.ToLower()
				let initials = name.GetInitials()
				where name.Contains(term) || initials==term
				select new
				{
					label = consultant.Name,
					value = consultant.Name
				};

			return Json(projections.ToList(), JsonRequestBehavior.AllowGet);
		}
	}
}