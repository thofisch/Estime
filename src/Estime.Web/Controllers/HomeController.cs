using System;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
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

		[HttpPost]
		public ActionResult Index(Guid? id, TaskInput input)
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

			var quantityRegex = new Regex(@"^(\d+)x", RegexOptions.IgnoreCase | RegexOptions.Compiled);

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

			Session.Save(task);

			return RedirectToAction("Index");
		}
	}
}