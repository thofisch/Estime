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
			Wares = new List<Ware> {new Ware("PC"), new Ware("27\" Skærm")};
		}

		public virtual Guid Id { get; set; }
		public virtual Client Client { get; set; }
		public virtual Consultant Consultant { get; set; }
		public virtual DateTime Timestamp { get; set; }
		public virtual int DurationInMinutes { get; set; }
		public virtual TimeType Type { get; set; }
		public virtual string Description { get; set; }
		public virtual bool Mileage { get; set; }
		public virtual TaskStatus Status { get; set; }
		public virtual IList<Ware> Wares { get; set; }
		public virtual DateTime CreatedAt { get; set; }
		public virtual string CreatedBy { get; set; }
		public virtual DateTime UpdatedAt { get; set; }
		public virtual string UpdatedBy { get; set; }

		public virtual void AddWare(string name)
		{
			var ware = new Ware(name);

			if( !Wares.Contains(ware))
			{
				Wares.Add(ware);
			}
		}
	}
}