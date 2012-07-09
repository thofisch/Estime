using System;
using System.Web.Mvc;
using Estime.Web.Infrastructure.Commands;
using Estime.Web.Models;
using Estime.Web.ViewModels;

namespace Estime.Web.Controllers
{
	[Authorize]
	public class ProjectController : SessionController
	{
		public ActionResult New(Guid clientId)
		{
			ViewBag.Title = "Opret nyt project";

			var model = new ProjectInput
			{
				ClientId = clientId
			};
			return View("Edit", model);
		}

		public ActionResult Edit(Guid id)
		{
			ViewBag.Title = "Rediger projekt";

			var project = Session
				.QueryOver<Project>()
				.Where(x => x.Id==id)
				.Fetch(x => x.Client).Eager
				.SingleOrDefault();

			var clientInput = new ProjectInput
			{
				Id = project.Id,
				ClientId = project.Client.Id,
				Name = project.Name
			};

			return View(clientInput);
		}

		[HttpPost]
		public ActionResult Edit(Guid? id, ProjectInput input)
		{
			if( !ModelState.IsValid )
			{
				return View("Edit", input);
			}

			var client = Session.Get<Client>(input.ClientId);

			if( id.HasValue )
			{
				var project = Session.Get<Project>(id.Value);
				project.ChangeName(input.Name);
			}
			else
			{
				var project = Project.CreateProject(client, input.Name);

				Session.Save(project);
			}

			return RedirectToAction("Edit", "Client", new {id = client.Id});
		}

		public ActionResult Close(Guid id)
		{
			Execute(new CloseOpenProjectTasks(id));

			return RedirectToAction("Edit", new {id});
		}
	}
}