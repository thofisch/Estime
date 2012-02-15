using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Estime.Web.Infrastructure;
using Estime.Web.Infrastructure.Mapping;
using Estime.Web.Models;
using Estime.Web.ViewModels;

namespace Estime.Web.Controllers
{
	public class HomeController : SessionController
	{
		public ActionResult Index(Guid? id)
		{
			Task model = null;

			if( id.HasValue )
			{
				model = Session.Get<Task>(id);
			}

			return AutoMapView<TaskInput>(View(model ?? new Task()));
		}

		protected AutoMapViewResult AutoMapView<TDestination>(ViewResult viewResult)
		{
			return new AutoMapViewResult(viewResult.ViewData.Model.GetType(), typeof(TDestination), viewResult);
		}

		[HttpPost]
		public ActionResult Index(Guid? id, TaskInput input)
		{
			var consultant = Session.QueryOver<Models.Consultant>().Where(x => x.Name==input.ConsultantName).SingleOrDefault();
			if( consultant==null )
			{
				consultant = new Models.Consultant {Name = input.ConsultantName};
				Session.Save(consultant);
			}
			var client = Session.QueryOver<Models.Client>().Where(x => x.Name==input.ClientName).SingleOrDefault();
			if( client==null )
			{
				client = new Models.Client {Name = input.ClientName};
				Session.Save(client);
			}

			var task = new Task
			{
				Consultant = consultant,
				Client = client,
				Timestamp = input.Timestamp,
				DurationInMinutes = input.DurationInMinutes,
				Type = TimeType.Default,
				Description = input.Description,
				Mileage = input.Mileage,
				Status = TaskStatus.Open,
				CreatedAt = DateTime.Now,
				CreatedBy = "Me",
				UpdatedAt = DateTime.Now,
				UpdatedBy = "Me",
			};

			foreach(var name in input.SelectedWares.Split('¤'))
			{
				task.AddWare(HttpUtility.HtmlDecode(name));
			}

			Session.Save(task);

			return RedirectToAction("Index");
		}
	}
}