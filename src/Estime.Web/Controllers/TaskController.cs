using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Estime.Web.Models;

namespace Estime.Web.Controllers
{
	public class TaskController : SessionController
	{
		public ActionResult Opened()
		{
			return View();
		}

		public ActionResult Closed()
		{
			return View();
		}
	}
}