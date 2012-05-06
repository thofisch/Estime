using System;
using System.Collections.Generic;

namespace Estime.Web.Models
{
	public class Client
	{
		public virtual Guid Id { get; set; }
		public virtual string Name { get; set; }
		public virtual IList<Project> Projects { get; set; }
	}
}