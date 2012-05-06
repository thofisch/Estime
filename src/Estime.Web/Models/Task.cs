using System;
using System.Collections.Generic;
using Estime.Web.Util;

namespace Estime.Web.Models
{
	public class Task
	{
		public Task()
		{
			Timestamp = DateTime.Now.GetNearestMinute();
			Wares = new List<TaskWare>();
		}

		public virtual Guid Id { get; set; }
		public virtual Project Project { get; set; }
		public virtual Consultant Consultant { get; set; }
		public virtual DateTime Timestamp { get; set; }
		public virtual int DurationInMinutes { get; set; }
		public virtual string Description { get; set; }
		public virtual bool Mileage { get; set; }
		public virtual TaskStatus Status { get; set; }
		public virtual IList<TaskWare> Wares { get; set; }
		public virtual DateTime CreatedAt { get; set; }
		public virtual string CreatedBy { get; set; }
		public virtual DateTime UpdatedAt { get; set; }
		public virtual string UpdatedBy { get; set; }

		public virtual void AddWare(Ware ware, int quantity)
		{
			Wares.Add(new TaskWare(ware, quantity));
		}
	}
}