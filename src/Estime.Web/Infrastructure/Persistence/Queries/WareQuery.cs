using System;
using System.Collections.Generic;
using System.Linq;
using Estime.Web.Models;
using NHibernate.Criterion;

namespace Estime.Web.Infrastructure.Persistence.Queries
{
	public class WareQuery : Query<IEnumerable<string>>
	{
		private readonly Tuple<int, string> _quantityAndName;

		public WareQuery(Tuple<int, string> quantityAndName)
		{
			_quantityAndName = quantityAndName;
		}

		public override IEnumerable<string> Execute()
		{
			Ware wareAlias = null;

			return Session.QueryOver<Task>()
				.Inner.JoinAlias(x => x.Wares, () => wareAlias)
				.WhereRestrictionOn(() => wareAlias.Name).IsInsensitiveLike(_quantityAndName.Item2, MatchMode.Anywhere)
				.SelectList(list => list.SelectGroup(() => wareAlias.Name))
				.List<string>()
				.Select(name => string.Format("{0}x{1}", _quantityAndName.Item1, name));
		}
	}
}