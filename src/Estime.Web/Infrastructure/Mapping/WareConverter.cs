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
				Text = string.Format("{0}x{1}", source.Quantity, source.Name),
				Value = string.Format("{0}x{1}", source.Quantity, source.Name),
				Selected = false
			};
		}
	}
}