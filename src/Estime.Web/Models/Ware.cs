namespace Estime.Web.Models
{
	public class Ware
	{
		public Ware(string name, int quantity)
		{
			Name = name;
			Quantity = quantity;
		}

		protected Ware()
		{
		}

		public virtual string Name { get; protected set; }
		public virtual int Quantity { get; protected set; }

		public virtual void UpdateQuantity(int quantity)
		{
			Quantity = quantity;
		}
	}
}