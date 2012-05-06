using System;
using System.Web.Mvc;
using Estime.Web.Models;
using Estime.Web.ViewModels;

namespace Estime.Web.Controllers
{
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
				ClientId = project.Client.Id,
				Sku = project.Sku,
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
				project.ChangeSku(input.Sku);
			}
			else
			{
				var project = Project.CreateProject(client, input.Sku, input.Name);
				
				Session.Save(project);
			}

			return RedirectToAction("Edit", "Client", new {id = client.Id});
		}
	}
}