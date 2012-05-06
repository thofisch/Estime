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
			CreateMap<Client, ClientInput>();
			CreateMap<Consultant, ConsultantInput>();

			CreateMap<Task, TaskInput>()
				.ForMember(dst => dst.Closed, opt => opt.ResolveUsing(x => x.Status==TaskStatus.Closed))
				.AfterMap((src, dst) =>
				{
					dst.SelectedWares = string.Join("¤", dst.Wares.Select(x => x.Text));
				});
			CreateMap<TaskWare, SelectListItem>().ConvertUsing<WareConverter>();
		}
	}
}