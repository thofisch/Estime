using NHibernate;

namespace Estime.Web.Infrastructure.Commands
{
	public abstract class Command
	{
		public ISession Session { get; set; }

		public abstract void Execute();
	}

	public abstract class Command<TResult> : Command
	{
		public TResult Result { get; set; }
	}
}