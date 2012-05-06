using System;

namespace Estime.Web.Models
{
	public class Ware
	{
		public virtual Guid Id { get; set; }
		public virtual string Sku { get; set; }
		public virtual string Name { get; set; }
	}
}