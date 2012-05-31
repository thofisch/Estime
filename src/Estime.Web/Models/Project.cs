using System;
using Estime.Web.Util;

namespace Estime.Web.Models
{
	public class Project
	{
		public static Project CreateStandardProject(Client client)
		{
			return new Project(client, string.Empty, true, TaskStatus.Closed);
		}

		public static Project CreateProject(Client client, string name)
		{
			return new Project(client, name, false, TaskStatus.Open);
		}

		private Project(Client client, string name, bool standardProject, TaskStatus defaultTaskStatus)
		{
			Client = client;
			Sku = new UniqueSkuGenerator().Generate();
			Name = name;
			StandardProject = standardProject;
			DefaultTaskStatus = defaultTaskStatus;
		}

		protected Project()
		{
		}

		public virtual Guid Id { get; set; }
		public virtual string Sku { get; private set; }
		public virtual Client Client { get; private set; }
		public virtual string Name { get; private set; }
		public virtual bool StandardProject { get; private set; }
		public virtual TaskStatus DefaultTaskStatus { get; private set; }

		public virtual void ChangeName(string name)
		{
			Name = name;
		}
	}
}