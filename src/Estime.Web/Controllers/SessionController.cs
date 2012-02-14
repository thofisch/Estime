using System.Web;
using System.Web.Mvc;
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
	}

	public class SessionActionFilterAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			var controller = filterContext.Controller as SessionController;
			if( controller==null )
			{
				return;
			}

			var session = MvcApplication.SessionFactory.OpenSession();
			session.BeginTransaction();
			controller.Session = session;
		}

		public override void OnResultExecuted(ResultExecutedContext filterContext)
		{
			var controller = filterContext.Controller as SessionController;
			if( controller==null )
			{
				return;
			}

			var session = controller.Session;
			if( session==null )
			{
				return;
			}

			var transaction = session.Transaction;
			if( transaction!=null && transaction.IsActive )
			{
				if( filterContext.Exception!=null )
				{
					transaction.Rollback();
				}
				else
				{
					transaction.Commit();
				}
				transaction.Dispose();
			}

			session.Dispose();
		}
	}
}