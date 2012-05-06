using System;
using System.Web.Mvc;
using Estime.Web.Models;
using Estime.Web.ViewModels;

namespace Estime.Web.Controllers
{
	public class ConsultantController : SessionController
	{
		public ActionResult New()
		{
			ViewBag.Title = "Opret ny konsulent";

			return View("Edit", new ConsultantInput());
		}

		public ActionResult Edit(Guid id)
		{
			ViewBag.Title = "Rediger konsulent";

			var consultant = Session.Get<Consultant>(id);

			return AutoMapView<ConsultantInput>(View("Edit", consultant));
		}

		[HttpPost]
		public ActionResult Edit(Guid? id, ConsultantInput input)
		{
			if( !ModelState.IsValid )
			{
				return View("Edit", input);
			}

			if( id.HasValue )
			{
				var consultant = Session.Get<Consultant>(id.Value);
				consultant.Sku = input.Sku;
				consultant.Name = input.Name;
			}
			else
			{
				var consultant = new Consultant
				{
					Sku = input.Sku,
					Name = input.Name
				};

				Session.Save(consultant);
			}

			return RedirectToAction("List");
		}

		public ActionResult List()
		{
			var consultants = Session.QueryOver<Consultant>().OrderBy(x => x.Name).Asc.List();

			return View(consultants);
		}
	}
}