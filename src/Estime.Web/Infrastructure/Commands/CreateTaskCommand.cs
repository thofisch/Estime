using System;
using System.Text.RegularExpressions;
using System.Web;
using Estime.Web.Models;
using Estime.Web.ViewModels;

namespace Estime.Web.Infrastructure.Commands
{
	public class CreateTaskCommand : Command
	{
		private readonly TaskInput _taskInput;

		public CreateTaskCommand(TaskInput taskInput)
		{
			_taskInput = taskInput;
		}

		public override void Execute()
		{
			var consultant = Session.QueryOver<Consultant>().Where(x => x.Name==_taskInput.ConsultantName).SingleOrDefault();
			if( consultant==null )
			{
				consultant = new Consultant {Name = _taskInput.ConsultantName};
				Session.Save(consultant);
			}
			var client = Session.QueryOver<Client>().Where(x => x.Name==_taskInput.ClientName).SingleOrDefault();
			if( client==null )
			{
				client = new Client {Name = _taskInput.ClientName};
				Session.Save(client);
			}

			var task = _taskInput.Id.HasValue ? Session.Get<Task>(_taskInput.Id.Value) : new Task();
			task.Consultant = consultant;
			task.Client = client;
			task.Timestamp = _taskInput.Timestamp;
			task.DurationInMinutes = _taskInput.DurationInMinutes;
			task.Type = TimeType.Default;
			task.Description = _taskInput.Description;
			task.Mileage = _taskInput.Mileage;
			task.Status = TaskStatus.Open;
			task.CreatedAt = DateTime.Now;
			task.CreatedBy = "Me";
			task.UpdatedAt = DateTime.Now;
			task.UpdatedBy = "Me";

			var quantityRegex = new Regex(@"^(\d+)x", RegexOptions.IgnoreCase | RegexOptions.Compiled);

			task.Wares.Clear();

			if( !string.IsNullOrWhiteSpace(_taskInput.SelectedWares) )
			{
				foreach(var name in _taskInput.SelectedWares.Split('¤'))
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

			if( _taskInput.Id.HasValue==false )
			{
				Session.Save(task);
			}
		}
	}
}