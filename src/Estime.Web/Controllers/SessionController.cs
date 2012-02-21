using System.Web;
using System.Web.Mvc;
using Estime.Web.Infrastructure.Commands;
using Estime.Web.Infrastructure.Mapping;
using Estime.Web.Infrastructure.Persistence.Queries;
using NHibernate;

namespace Estime.Web.Controllers
{
	public abstract class SessionController : Controller
	{
		public new ISession Session { get; set; }

		public HttpSessionStateBase HttpSession
		{
			get
			{
				return base.Session;
			}
		}

		protected AutoMapViewResult AutoMapView<TDestination>(ViewResult viewResult)
		{
			return new AutoMapViewResult(viewResult.ViewData.Model.GetType(), typeof(TDestination), viewResult);
		}

		protected TResult Query<TResult>(Query<TResult> query)
		{
			query.Session = Session;
			return query.Execute();
		}

		protected void Execute(Command command)
		{
			command.Session = Session;
			command.Execute();
		}

		protected TResult Execute<TResult>(Command<TResult> command)
		{
			command.Session = Session;
			command.Execute();
			return command.Result;
		}
	}
}