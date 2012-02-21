using NHibernate;

namespace Estime.Web.Infrastructure.Persistence.Queries
{
	public abstract class Query<TResult>
	{
		public ISession Session { get; set; }

		public abstract TResult Execute();
	}
}