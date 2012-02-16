using System.Linq;
using System.Web.Mvc;
using Estime.Web.Models;
using Estime.Web.Util;

namespace Estime.Web.Controllers
{
	public class ConsultantController : SessionController
	{
		public ActionResult Find(string term)
		{
			term = term.ToLower();

			var consultants = Session.QueryOver<Consultant>().List();

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