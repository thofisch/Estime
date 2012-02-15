using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Estime.Web.Models;
using Estime.Web.ViewModels;

namespace Estime.Web.Infrastructure.Mapping
{
	public class ViewModelProfile : Profile
	{
		protected override void Configure()
		{
			CreateMap<Task, TaskInput>()
				.AfterMap((src, dst) =>
				{
					dst.SelectedWares = string.Join("¤", dst.Wares.Select(x => x.Text));
				});
			CreateMap<Ware, SelectListItem>().ConvertUsing<WareConverter>();
		}
	}
}