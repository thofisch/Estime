using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using Estime.Web.Infrastructure.Commands;
using Estime.Web.Infrastructure.Persistence.Queries;
using Estime.Web.Models;
using Estime.Web.ViewModels;

namespace Estime.Web.Controllers
{
	[Authorize]
	public class ClientController : SessionController
	{
		public ActionResult New()
		{
			ViewBag.Title = "Opret ny kunde";
			ViewBag.IsNew = true;

			return View("Edit", new ClientInput());
		}

		public ActionResult Edit(Guid id)
		{
			ViewBag.Title = "Rediger kunde";
			ViewBag.IsNew = false;

			var client = Session
				.QueryOver<Client>()
				.Where(x => x.Id==id)
				.Fetch(x => x.Projects).Eager
				.SingleOrDefault();

			ViewBag.Projects = client.Projects.Where(x => !x.StandardProject).ToList();

			var clientInput = new ClientInput
			{
				Id = client.Id,
				Name = client.Name,
			};

			return View(clientInput);
		}

		[HttpPost]
		public ActionResult Edit(Guid? id, ClientInput input)
		{
			if( !ModelState.IsValid )
			{
				return View("Edit", input);
			}

			if( id.HasValue )
			{
				var client = Session.Get<Client>(id.Value);
				client.Name = input.Name;
			}
			else
			{
				var client = new Client
				{
					Name = input.Name
				};

				var project = Project.CreateStandardProject(client);

				Session.Save(client);
				Session.Save(project);
			}

			return RedirectToAction("List");
		}

		public ActionResult List()
		{
			var clients = Query(new ClientListQuery());

			return View(clients);
		}

		public ActionResult Close(Guid id)
		{
			var project = Session.QueryOver<Project>()
				.Where(x => x.Client.Id==id)
				.And(x => x.StandardProject)
				.SingleOrDefault();

			Execute(new CloseOpenProjectTasks(project.Id));

			return RedirectToAction("Edit", new {id});
		}
	}

	/// <summary>
	/// Adapted from: http://davidhayden.com/blog/dave/archive/2004/02/16/157.aspx
	/// </summary>
	public static class Cryptographer
	{
		public static string CreateSalt()
		{
			const int size = 64;

			// generate a cryptographic random number.
			var buffer = new byte[size];
			var rng = new RNGCryptoServiceProvider();
			rng.GetBytes(buffer);

			return Convert.ToBase64String(buffer);
		}

		public static string ComputeHash(string valueToHash)
		{
			HashAlgorithm algorithm = SHA512.Create();
			var hash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(valueToHash));

			return Convert.ToBase64String(hash);
		}

		public static string GetPasswordHash(string password, string salt)
		{
			return ComputeHash(password + salt);
		}
	}
}