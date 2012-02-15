namespace Estime.Web.Models
{
	public class Ware
	{
		public Ware(string name)
		{
			Name = name;
		}

		protected Ware()
		{
		}

		public virtual string Name { get; protected set; }

		public bool Equals(Ware other)
		{
			if( ReferenceEquals(null, other) )
			{
				return false;
			}
			if( ReferenceEquals(this, other) )
			{
				return true;
			}
			return Equals(other.Name, Name);
		}

		public override bool Equals(object obj)
		{
			if( ReferenceEquals(null, obj) )
			{
				return false;
			}
			if( ReferenceEquals(this, obj) )
			{
				return true;
			}
			if( obj.GetType()!=typeof(Ware) )
			{
				return false;
			}
			return Equals((Ware) obj);
		}

		public override int GetHashCode()
		{
			return (Name!=null ? Name.GetHashCode() : 0);
		}
	}
}