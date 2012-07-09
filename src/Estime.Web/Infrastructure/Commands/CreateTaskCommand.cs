using System;
using System.Globalization;
using System.Linq;
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
			var task = _taskInput.Id.HasValue ? Session.Get<Task>(_taskInput.Id.Value) : new Task();
			task.Consultant = Session.Load<Consultant>(_taskInput.ConsultantId);
			task.Project = Session.Get<Project>(_taskInput.ProjectId);
			task.Timestamp = _taskInput.Timestamp;
			task.DurationInMinutes = _taskInput.DurationInMinutes;
			task.Description = _taskInput.Description ?? string.Empty;
			task.Mileage = _taskInput.Mileage;
			task.Status = _taskInput.Closed ? TaskStatus.Closed : TaskStatus.Open;
			task.CreatedAt = DateTime.Now;
			task.CreatedBy = "Me";
			task.UpdatedAt = DateTime.Now;
			task.UpdatedBy = "Me";

			task.Wares.Clear();

			var wareMap = Session.QueryOver<Ware>().List().ToDictionary(x => x.Id);

			if( !string.IsNullOrWhiteSpace(_taskInput.SelectedWares) )
			{
				foreach(var wareData in _taskInput.SelectedWares.Split('¤'))
				{
					var wareParts = wareData.Split('|');
					if( wareParts.Length!=3 )
					{
						continue;
					}

					var id = Guid.Parse(wareParts[0]);
					var quantity = int.Parse(wareParts[1]);
					var price = double.Parse(wareParts[2], CultureInfo.GetCultureInfo("en-US"));

					task.AddWare(wareMap[id], quantity, price);
				}
			}

			if( _taskInput.Id.HasValue==false )
			{
				Session.Save(task);
			}
		}
	}
}