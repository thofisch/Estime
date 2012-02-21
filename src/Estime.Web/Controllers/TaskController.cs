using System;
using System.Web.Mvc;
using Estime.Web.Infrastructure.Commands;
using Estime.Web.Infrastructure.Persistence.Queries;
using Estime.Web.Models;
using Estime.Web.ViewModels;

namespace Estime.Web.Controllers
{
	public class TaskController : SessionController
	{
		public ActionResult New()
		{
			return AutoMapView<TaskInput>(View("Edit", new Task()));
		}

		public ActionResult Edit(Guid? id)
		{
			if( id.HasValue )
			{
				var task = Session.Get<Task>(id);
				if( task!=null )
				{
					return AutoMapView<TaskInput>(View(task));
				}
			}
			return RedirectToAction("New");
		}

		[HttpPost]
		public ActionResult Edit(TaskInput input)
		{
			Execute(new CreateTaskCommand(input));

			return RedirectToAction("New");
		}

		public ActionResult Open()
		{
			var tasks = Query(new TaskListQuery(TaskStatus.Open));

			return View("List", tasks);
		}

		public ActionResult Closed()
		{
			var tasks = Query(new TaskListQuery(TaskStatus.Closed));

			return View("List", tasks);
		}
	}
}