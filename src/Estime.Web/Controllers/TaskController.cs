using System;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Estime.Web.Models;
using Estime.Web.ViewModels;
using NHibernate.Transform;

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
		public ActionResult Edit(Guid? id, TaskInput input)
		{
			var consultant = Session.QueryOver<Consultant>().Where(x => x.Name==input.ConsultantName).SingleOrDefault();
			if( consultant==null )
			{
				consultant = new Consultant {Name = input.ConsultantName};
				Session.Save(consultant);
			}
			var client = Session.QueryOver<Client>().Where(x => x.Name==input.ClientName).SingleOrDefault();
			if( client==null )
			{
				client = new Client {Name = input.ClientName};
				Session.Save(client);
			}

			var task = id.HasValue ? Session.Get<Task>(id.Value) : new Task();
			task.Consultant = consultant;
			task.Client = client;
			task.Timestamp = input.Timestamp;
			task.DurationInMinutes = input.DurationInMinutes;
			task.Type = TimeType.Default;
			task.Description = input.Description;
			task.Mileage = input.Mileage;
			task.Status = TaskStatus.Open;
			task.CreatedAt = DateTime.Now;
			task.CreatedBy = "Me";
			task.UpdatedAt = DateTime.Now;
			task.UpdatedBy = "Me";

			var quantityRegex = new Regex(@"^(\d+)x", RegexOptions.IgnoreCase | RegexOptions.Compiled);

			task.Wares.Clear();

			if( !string.IsNullOrWhiteSpace(input.SelectedWares) )
			{
				foreach(var name in input.SelectedWares.Split('¤'))
				{
					var ware = HttpUtility.HtmlDecode(name);
					var quantity = 1;
					var match = quantityRegex.Match(ware);
					if( match.Success )
					{
						var value = match.Groups[0].Value;
						var x = value.TrimEnd("xX".ToCharArray());
						quantity = int.Parse(x);
						ware = ware.Substring(value.Length).Trim();
					}

					task.AddWare(ware, quantity);
				}
			}

			Session.Save(task);

			return RedirectToAction("New");
		}

		public class ClientListViewModel
		{
			public Guid Id { get; set; }
			public string ConsultantName { get; set; }
			public string ClientName { get; set; }
			public DateTime Timestamp { get; set; }
			public int DurationInMinutes { get; set; }
			public TimeType Type { get; set; }
			public bool Mileage { get; set; }
			public string Description { get; set; }
			public int WaresCount { get; set; }
		}

		public ActionResult Open()
		{
			Consultant consultantAlias = null;
			Client clientAlias = null;
			ClientListViewModel alias = null;

			var tasks = Session.QueryOver<Task>()
				.JoinAlias(x => x.Consultant, () => consultantAlias)
				.JoinAlias(x => x.Client, () => clientAlias)
				.Where(x => x.Status==TaskStatus.Open)
				.SelectList(list => list
					.Select(x => x.Id).WithAlias(() => alias.Id)
					.Select(() => consultantAlias.Name).WithAlias(() => alias.ConsultantName)
					.Select(() => clientAlias.Name).WithAlias(() => alias.ClientName)
					.Select(x => x.Timestamp).WithAlias(() => alias.Timestamp)
					.Select(x => x.DurationInMinutes).WithAlias(() => alias.DurationInMinutes)
					.Select(x => x.Type).WithAlias(() => alias.Type)
					.Select(x => x.Mileage).WithAlias(() => alias.Mileage)
					.Select(x => x.Description).WithAlias(() => alias.Description)
				)
				.OrderBy(x => x.Timestamp).Desc
				.TransformUsing(Transformers.AliasToBean<ClientListViewModel>())
				.List<ClientListViewModel>();

			return View("List", tasks);
		}

		public ActionResult Closed()
		{
			Consultant consultantAlias = null;
			Client clientAlias = null;
			ClientListViewModel alias = null;

			var tasks = Session.QueryOver<Task>()
				.JoinAlias(x => x.Consultant, () => consultantAlias)
				.JoinAlias(x => x.Client, () => clientAlias)
				.Where(x => x.Status==TaskStatus.Closed)
				.SelectList(list => list
					.Select(x => x.Id).WithAlias(() => alias.Id)
					.Select(() => consultantAlias.Name).WithAlias(() => alias.ConsultantName)
					.Select(() => clientAlias.Name).WithAlias(() => alias.ClientName)
					.Select(x => x.Timestamp).WithAlias(() => alias.Timestamp)
					.Select(x => x.DurationInMinutes).WithAlias(() => alias.DurationInMinutes)
					.Select(x => x.Type).WithAlias(() => alias.Type)
					.Select(x => x.Mileage).WithAlias(() => alias.Mileage)
					.Select(x => x.Description).WithAlias(() => alias.Description)
				)
				.OrderBy(x => x.Timestamp).Desc
				.TransformUsing(Transformers.AliasToBean<ClientListViewModel>())
				.List<ClientListViewModel>();

			return View("List", tasks);
		}
	}
}