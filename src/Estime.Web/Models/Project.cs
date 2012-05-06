using System;

namespace Estime.Web.Models
{
	public class Project
	{
		public static Project CreateStandardProject(Client client, string sku)
		{
			return new Project(client, sku, string.Empty, true, TaskStatus.Closed);
		}

		public static Project CreateProject(Client client, string sku, string name)
		{
			return new Project(client, sku, name, false, TaskStatus.Open);
		}

		private Project(Client client, string sku, string name, bool standardProject, TaskStatus defaultTaskStatus)
		{
			Client = client;
			Sku = sku;
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

		public virtual void ChangeSku(string sku)
		{
			Sku = sku;
		}

		public virtual void ChangeName(string name)
		{
			Name = name;
		}
	}
}