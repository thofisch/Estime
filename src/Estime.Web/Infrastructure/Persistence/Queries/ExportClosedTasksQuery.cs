using System.Collections.Generic;
using System.Linq;
using Estime.Web.Models;
using Estime.Web.ViewModels;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Dialect.Function;
using NHibernate.Transform;

namespace Estime.Web.Infrastructure.Persistence.Queries
{
	public class ExportClosedTasksQuery : Query<IEnumerable<TaskExportViewModel>>
	{
		public override IEnumerable<TaskExportViewModel> Execute()
		{
			Consultant consultantAlias = null;
			Project projectAlias = null;
			Client clientAlias = null;
			TaskExportViewModel alias = null;

			var clientSkuSubQuery = QueryOver.Of<Project>()
				.Where(x => x.Client.Id==clientAlias.Id)
				.And(x => x.StandardProject)
				.Select(x => x.Sku);

			ISQLFunction div = new VarArgsSQLFunction("(", "/", ")");
			var durationToQuantity = Projections.SqlFunction(div, NHibernateUtil.Double, Projections.Property<Task>(x => x.DurationInMinutes), Projections.Constant(60D, NHibernateUtil.Double));

			var tasks = Session.QueryOver<Task>()
				.JoinAlias(x => x.Consultant, () => consultantAlias)
				.JoinAlias(x => x.Project, () => projectAlias)
				.JoinAlias(x => x.Project.Client, () => clientAlias)
				.Where(x => x.Status==TaskStatus.Closed)
				.SelectList(list => list
					.Select(() => projectAlias.Name).WithAlias(() => alias.ProjectName)
					.Select(() => projectAlias.Sku).WithAlias(() => alias.ProjectSku)
					.Select(() => clientAlias.Name).WithAlias(() => alias.ClientName)
					.SelectSubQuery(clientSkuSubQuery).WithAlias(() => alias.ClientSku)
					.Select(x => x.Timestamp).WithAlias(() => alias.Timestamp)
					.Select(() => consultantAlias.Name).WithAlias(() => alias.Name)
					.Select(() => consultantAlias.Sku).WithAlias(() => alias.Sku)
					.Select(durationToQuantity).WithAlias(() => alias.Quantity)
					.Select(x => x.Mileage).WithAlias(() => alias.Mileage)
					.Select(x => x.Description).WithAlias(() => alias.Description)
					.Select(() => projectAlias.StandardProject).WithAlias(() => alias.StandardTask)
				)
				.TransformUsing(Transformers.AliasToBean<TaskExportViewModel>())
				.List<TaskExportViewModel>();

			TaskWare taskWareAlias = null;
			Ware wareAlias = null;
			var wares = Session.QueryOver<Task>()
				.Where(x => x.Status==TaskStatus.Closed)
				.JoinAlias(x => x.Project, () => projectAlias)
				.JoinAlias(x => x.Project.Client, () => clientAlias)
				.JoinAlias(x => x.Wares, () => taskWareAlias)
				.JoinAlias(() => taskWareAlias.Ware, () => wareAlias)
				.SelectList(list => list
					.Select(() => projectAlias.Name).WithAlias(() => alias.ProjectName)
					.Select(() => projectAlias.Sku).WithAlias(() => alias.ProjectSku)
					.Select(() => clientAlias.Name).WithAlias(() => alias.ClientName)
					.SelectSubQuery(clientSkuSubQuery).WithAlias(() => alias.ClientSku)
					.Select(x => x.Timestamp).WithAlias(() => alias.Timestamp)
					.Select(() => wareAlias.Sku).WithAlias(() => alias.Sku)
					.Select(() => taskWareAlias.Quantity).WithAlias(() => alias.Quantity)
					.Select(x => x.Mileage).WithAlias(() => alias.Mileage)
					.Select(() => wareAlias.Name).WithAlias(() => alias.Description)
					.Select(() => projectAlias.StandardProject).WithAlias(() => alias.StandardTask)
				)
				.TransformUsing(Transformers.AliasToBean<TaskExportViewModel>())
				.List<TaskExportViewModel>();

			var mileages = tasks.Where(x => x.Mileage)
				.Select(x => new TaskExportViewModel
				{
					Name = "",
					Sku = Ware.Mileage.Sku,
					ClientName = x.ClientName,
					ClientSku = x.ClientSku,
					ProjectName = x.ProjectName,
					ProjectSku = x.ProjectSku,
					Timestamp = x.Timestamp,
					Quantity = 1,
					Mileage = false,
					Description = Ware.Mileage.Name,
					StandardTask = x.StandardTask
				});

			return tasks.Concat(mileages).Concat(wares).OrderBy(x => x.ClientSku).ThenBy(x => x.ProjectSku).ThenByDescending(x => x.Timestamp);
		}
	}
}