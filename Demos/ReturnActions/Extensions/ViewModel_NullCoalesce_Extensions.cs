using JJ.Demos.ReturnActions.ViewModels;
using JJ.Demos.ReturnActions.ViewModels.Entities;
using JJ.Framework.Presentation;
using System.Collections.Generic;

namespace JJ.Demos.ReturnActions.Extensions
{
	internal static class ViewModel_NullCoalesce_Extensions
	{
		public static void NullCoalesce(this EditViewModel viewModel)
		{
			viewModel.Entity = viewModel.Entity ?? new EntityViewModel();

			if (viewModel.ReturnAction != null)
			{
				viewModel.ReturnAction.NullCoalesce();
			}
		}

		public static void NullCoalesce(this LoginViewModel viewModel)
		{
			if (viewModel.ReturnAction != null)
			{
				viewModel.ReturnAction.NullCoalesce();
			}
		}

		private static void NullCoalesce(this ActionInfo actionInfo)
		{
			actionInfo.Parameters = actionInfo.Parameters ?? new List<ActionParameterInfo>();

			if (actionInfo.ReturnAction != null)
			{
				// Recursive call
				actionInfo.ReturnAction.NullCoalesce();
			}
		}
	}
}
