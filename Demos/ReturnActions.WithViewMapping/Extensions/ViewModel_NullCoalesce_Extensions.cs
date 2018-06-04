using System.Collections.Generic;
using JJ.Demos.ReturnActions.ViewModels;
using JJ.Demos.ReturnActions.WithViewMapping.ViewModels;
using JJ.Framework.Presentation;

// ReSharper disable TailRecursiveCall

namespace JJ.Demos.ReturnActions.WithViewMapping.Extensions
{
	internal static class ViewModel_NullCoalesce_Extensions
	{
		public static void NullCoalesce(this EditViewModel viewModel)
		{
			viewModel.Entity = viewModel.Entity ?? new EntityViewModel();

			viewModel.ReturnAction?.NullCoalesce();
		}

		public static void NullCoalesce(this LoginViewModel viewModel) => viewModel.ReturnAction?.NullCoalesce();

		private static void NullCoalesce(this ActionInfo actionInfo)
		{
			actionInfo.Parameters = actionInfo.Parameters ?? new List<ActionParameterInfo>();

			// Recursive call
			actionInfo.ReturnAction?.NullCoalesce();
		}
	}
}
