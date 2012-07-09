namespace Estime.Web.Models
{
	public class TaskWare
	{
		public TaskWare(Ware ware, int quantity, double price)
		{
			Ware = ware;
			Quantity = quantity;
			Price = price;
		}

		protected TaskWare()
		{
		}

		public virtual Ware Ware { get; private set; }
		public virtual int Quantity { get; private set; }
		public virtual double Price { get; private set; }
	}
}