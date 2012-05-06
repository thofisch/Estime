namespace Estime.Web.Models
{
	public class TaskWare
	{
		public TaskWare(Ware ware, int quantity)
		{
			Ware = ware;
			Quantity = quantity;
		}

		protected TaskWare()
		{
		}

		public virtual Ware Ware { get; private set; }
		public virtual int Quantity { get; private set; }
	}
}