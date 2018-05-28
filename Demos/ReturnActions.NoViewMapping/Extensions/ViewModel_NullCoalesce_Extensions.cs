using JJ.Demos.ReturnActions.NoViewMapping.ViewModels;
using JJ.Demos.ReturnActions.NoViewMapping.ViewModels.Entities;

// ReSharper disable TailRecursiveCall

namespace JJ.Demos.ReturnActions.NoViewMapping.Extensions
{
	internal static class ViewModel_NullCoalesce_Extensions
	{
		public static void NullCoalesce(this EditViewModel viewModel) => viewModel.Entity = viewModel.Entity ?? new EntityViewModel();
	}
}
