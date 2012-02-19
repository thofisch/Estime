using System;
using System.Collections.Generic;
using System.Linq;
using Estime.Web.Util;

namespace Estime.Web.Models
{
	public class Task
	{
		public Task()
		{
			Timestamp = DateTime.Now.GetNearestMinute();
			Wares = new List<Ware>();
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

		public virtual void AddWare(string name, int quantity)
		{
			var ware = Wares.FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
			if( ware!=null )
			{
				ware.UpdateQuantity(ware.Quantity + quantity);
			}
			else
			{
				Wares.Add(new Ware(name, quantity));
			}
		}
	}
}