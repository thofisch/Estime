using System.Web.Mvc;
using AutoMapper;
using Estime.Web.Models;

namespace Estime.Web.Infrastructure.Mapping
{
	public class WareConverter : TypeConverter<TaskWare, SelectListItem>
	{
		protected override SelectListItem ConvertCore(TaskWare source)
		{
			return new SelectListItem
			{
				Text = string.Format("{0}x{1}", source.Quantity, source.Ware.Name),
				Value = source.Ware.Id.ToString(),
				Selected = false
			};
		}
	}
}