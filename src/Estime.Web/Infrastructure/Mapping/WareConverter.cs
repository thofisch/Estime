using System.Web.Mvc;
using AutoMapper;
using Estime.Web.Models;

namespace Estime.Web.Infrastructure.Mapping
{
	public class WareConverter : TypeConverter<Ware, SelectListItem>
	{
		protected override SelectListItem ConvertCore(Ware source)
		{
			return new SelectListItem
			{
				Text = source.Name,
				Value = source.Name,
				Selected = false
			};
		}
	}
}