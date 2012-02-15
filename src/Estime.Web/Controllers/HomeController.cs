using System.Linq;
using System.Web.Mvc;
using Estime.Web.Models;

namespace Estime.Web.Controllers
{
	public class HomeController : SessionController
	{
		public ActionResult Index()
		{
			return View(new TaskInput());
		}

		[HttpPost]
		public ActionResult Index(TaskInput input, FormCollection form)
		{
			var selectedWares = form["SelectedWares"];
			if( string.IsNullOrWhiteSpace(selectedWares)==false )
			{
				input.Wares = selectedWares.Split('¤').ToList();
			}

			return RedirectToAction("Index");
		}
	}
}