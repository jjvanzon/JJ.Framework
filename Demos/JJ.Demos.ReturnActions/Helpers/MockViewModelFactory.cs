using JJ.Demos.ReturnActions.ViewModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Demos.ReturnActions.Helpers
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
                    throw new Exception(String.Format("id '{0}' is not a supported value.", id));
            }
        }

        public static EntityViewModel CreateEntityViewModel()
        {
            var viewModel = new EntityViewModel
            {
                ID = DEFAULT_ID,
                Name = MockViewModelFactory.DEFAULT_NAME
            };
            return viewModel;
        }

        public static EntityViewModel CreateEntityViewModel2()
        {
            var viewModel = new EntityViewModel
            {
                ID = DEFAULT_ID_2,
                Name = MockViewModelFactory.DEFAULT_NAME_2
            };
            return viewModel;
        }
    }
}
