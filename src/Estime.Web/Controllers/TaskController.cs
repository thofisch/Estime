using System;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Estime.Web.Infrastructure.Commands;
using Estime.Web.Infrastructure.Persistence.Queries;
using Estime.Web.Models;
using Estime.Web.Util;
using Estime.Web.ViewModels;
using FileHelpers;
using NHibernate.Transform;

namespace Estime.Web.Controllers
{
	public class TaskController : SessionController
	{
		public ActionResult New(Guid? consultantId)
		{
			prepareViewData("Ny opgave");

			var task = new Task();

			if( consultantId.HasValue )
			{
				var consultant = Session.Get<Consultant>(consultantId.Value);
				if( consultant!=null )
				{
					task.Consultant = consultant;
				}
			}

			return AutoMapView<TaskInput>(View("Edit", task));
		}

		private void prepareViewData(string title)
		{
			var consultants = Session.QueryOver<Consultant>().OrderBy(x => x.Name).Asc.List();
			var projects = Session.QueryOver<Project>().Fetch(x => x.Client).Eager.TransformUsing(Transformers.DistinctRootEntity).List();
			var wares = Session.QueryOver<Ware>().OrderBy(x => x.Name).Asc.List();

			var projectViewModels = projects
				.Select(project => new
				{
					project.Id,
					Name = project.Client.Name + (project.StandardProject ? "" : " - " + project.Name)
				})
				.OrderBy(x => x.Name);

			var projectStatusHash = projects.ToDictionary(x => x.Id, x => x.DefaultTaskStatus==TaskStatus.Closed);

			ViewBag.Title = title;
			ViewBag.Consultants = new SelectList(consultants, "Id", "Name");
			ViewBag.Clients = new SelectList(projectViewModels, "Id", "Name");
			ViewBag.Wares = new SelectList(wares, "Id", "Name");
			ViewBag.WareList = "{ }";
			ViewBag.ProjectStatusHash = projectStatusHash.ToJson();
		}

		public ActionResult Edit(Guid? id)
		{
			prepareViewData("Rediger opgave");

			if( id.HasValue )
			{
				var task = Session.QueryOver<Task>()
					.Where(x => x.Id==id)
					.Fetch(x => x.Wares).Eager
					.SingleOrDefault();

				if( task!=null )
				{
					var wareHash = task.Wares.ToDictionary(x => x.Ware.Id, x => new
					{
						quantity = x.Quantity,
						name = x.Ware.Name
					});

					ViewBag.WareList = wareHash.ToJson();

					return AutoMapView<TaskInput>(View(task));
				}
			}
			return RedirectToAction("New");
		}

		[HttpPost]
		public ActionResult Edit(TaskInput input)
		{
			Execute(new CreateTaskCommand(input));

			var cookie = new HttpCookie("consultantId", input.ConsultantId.ToString())
			{
				Expires = DateTime.UtcNow.AddDays(365)
			};

			Response.Cookies.Add(cookie);

			return RedirectToAction("New");
		}

		public ActionResult Open()
		{
			ViewBag.Title = "Åbne";

			var standardTasks = Query(new TaskListQuery(TaskStatus.Open, true));
			var projectTasks = Query(new TaskListQuery(TaskStatus.Open, false));

			return View("List", new TasksViewModel
			{
				StandardTasks = standardTasks.ToList(),
				ProjectTasks = projectTasks.ToList()
			});
		}

		public ActionResult Closed()
		{
			ViewBag.Title = "Lukkede";

			var standardTasks = Query(new TaskListQuery(TaskStatus.Closed, true));
			var projectTasks = Query(new TaskListQuery(TaskStatus.Closed, false));

			return View("List", new TasksViewModel
			{
				StandardTasks = standardTasks.ToList(),
				ProjectTasks = projectTasks.ToList()
			});
		}

		public ActionResult Delete(Guid id)
		{
			var task = Session.Load<Task>(id);
			Session.Delete(task);

			return RedirectToAction("New");
		}

		public ActionResult Export()
		{
			var tasks = Query(new ExportClosedTasksQuery());

			return View(tasks);
		}

		public ActionResult ExportToFile()
		{
			var tasks = Query(new ExportClosedTasksQuery());
			var taskDtos = tasks.Select(x => new TaskDto
			{
				ProjectSku = x.ProjectSku,
				ClientSku = x.ClientSku,
				Timestamp = x.Timestamp,
				Sku = x.Sku,
				Quantity = x.Quantity,
				Description = x.Description.Replace('\n', ' ').Replace("\r", "")
			});

			var encoding = Encoding.GetEncoding(1252);
			var engine = new DelimitedFileEngine<TaskDto>(encoding);
			var result = engine.WriteString(taskDtos);
			var data = encoding.GetBytes(result);

			return File(data, "application/vnd.ms-excel", string.Format("export-{0:yyyyMMddHHmmss}.csv", DateTime.Now));
		}
	}

	[DelimitedRecord(";")]
	public class TaskDto
	{
		public string ProjectSku;
		public string ClientSku;

		[FieldConverter(ConverterKind.Date, "yyyy-MM-dd")]
		public DateTime Timestamp;

		public string Sku;
		public double Quantity;
		public string Description;
	}
}