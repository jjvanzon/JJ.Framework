using System;
using JJ.Demos.ReturnActions.WithViewMapping.ViewModels.Entities;

namespace JJ.Demos.ReturnActions.WithViewMapping.Helpers
{
	/// <summary>
	/// For creating mock view models.
	/// </summary>
	internal static class MockViewModelFactory
	{
		private const int DEFAULT_ID = 1;
		private const int DEFAULT_ID_2 = 2;
		private const string DEFAULT_NAME = "My Name";
		private const string DEFAULT_NAME_2 = "My Name 2";

		public static EntityViewModel CreateEntityViewModel(int id)
		{
			switch (id)
			{
				case DEFAULT_ID:
					return CreateEntityViewModel();

				case DEFAULT_ID_2:
					return CreateEntityViewModel2();

				default:
					throw new Exception($"id '{id}' is not a supported value.");
			}
		}

		public static EntityViewModel CreateEntityViewModel()
		{
			var viewModel = new EntityViewModel
			{
				ID = DEFAULT_ID,
				Name = DEFAULT_NAME
			};
			return viewModel;
		}

		public static EntityViewModel CreateEntityViewModel2()
		{
			var viewModel = new EntityViewModel
			{
				ID = DEFAULT_ID_2,
				Name = DEFAULT_NAME_2
			};
			return viewModel;
		}
	}
}
