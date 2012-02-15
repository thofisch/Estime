using System;
using System.Web.Mvc;
using AutoMapper;

namespace Estime.Web.Infrastructure.Mapping
{
	public class AutoMapViewResult : ActionResult
	{
		private readonly Type _sourceType;
		private readonly Type _destinationType;
		private readonly ViewResult _view;

		public AutoMapViewResult(Type sourceType, Type destinationType, ViewResult view)
		{
			_sourceType = sourceType;
			_destinationType = destinationType;
			_view = view;
		}

		public override void ExecuteResult(ControllerContext context)
		{
			var model = Mapper.Map(_view.ViewData.Model, _sourceType, _destinationType);
			_view.ViewData.Model = model;
			_view.ExecuteResult(context);
		}
	}
}