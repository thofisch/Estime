using System;

namespace Estime.Web.Models
{
	public class Ware
	{
		public static Ware Mileage = new Ware {Id = Guid.Empty, Name = "Kørsel", Sku = "Kørsel"};

		public virtual Guid Id { get; set; }
		public virtual string Sku { get; set; }
		public virtual string Name { get; set; }
	}
}