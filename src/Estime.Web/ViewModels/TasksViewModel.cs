using System.Collections.Generic;

namespace Estime.Web.ViewModels
{
	public class TasksViewModel
	{
		public IList<TaskListViewModel> StandardTasks { get; set; }
		public IList<TaskListViewModel> ProjectTasks { get; set; }
	}
}