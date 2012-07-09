using System;

namespace Estime.Web.Models
{
	public class Consultant
	{
		public virtual Guid Id { get; set; }
		public virtual string Sku { get; set; }
		public virtual string Name { get; set; }
		public virtual string UserId { get; set; }
		public virtual Password Password { get; set; }
	}

	public class Password
	{
		public static readonly Password Empty = new Password();

		protected Password()
		{
		}

		public Password(string hash, string salt)
		{
			Hash = hash;
			Salt = salt;
		}

		public virtual string Hash { get; private set; }
		public virtual string Salt { get; private set; }
	}
}