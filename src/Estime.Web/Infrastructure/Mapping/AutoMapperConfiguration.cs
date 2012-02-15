using AutoMapper;

namespace Estime.Web.Infrastructure.Mapping
{
	public static class AutoMapperConfiguration
	{
		public static void Configure()
		{
			Mapper.Initialize(x => x.AddProfile<ViewModelProfile>());
		}
	}
}