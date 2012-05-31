using System;
using Estime.Web.Models;

namespace Estime.Web.Infrastructure.Commands
{
	public class CloseOpenProjectTasks : Command
	{
		private readonly Guid _projectId;

		public CloseOpenProjectTasks(Guid projectId)
		{
			_projectId = projectId;
		}

		public override void Execute()
		{
			Session.CreateSQLQuery("update Task set Status = :newStatus where ProjectId = :projectId and Status = :oldStatus")
				.SetEnum("newStatus", TaskStatus.Closed)
				.SetEnum("oldStatus", TaskStatus.Open)
				.SetGuid("projectId", _projectId)
				.ExecuteUpdate();
		}
	}
}