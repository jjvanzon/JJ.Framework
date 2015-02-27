using JJ.Demos.ReturnActions.Helpers;
using JJ.Demos.ReturnActions.ViewModels;
using JJ.Demos.ReturnActions.ViewModels.Entities;
using JJ.Framework.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Demos.ReturnActions.Presenters
{
    public class ListPresenter
    {
        public ListViewModel Show()
        {
            return new ListViewModel
            {
                List = new EntityViewModel[]
                {
                    ViewModelFactory.CreateEntityViewModel(),
                    ViewModelFactory.CreateEntityViewModel2()
                }
            };
        }

        public DetailsViewModel Details(int id)
        {
            var presenter = new DetailsPresenter();
            return presenter.Show(id);
        }

        public object Edit(int id, string authenticatedUserName)
        {
            var presenter = new EditPresenter(authenticatedUserName);
            return presenter.Show(id, returnAction: ActionHelper.CreateActionInfo<ListPresenter>(x => x.Show()));
        }

        public LoginViewModel Logout()
        {
            var presenter2 = new LoginPresenter();
            return presenter2.Show();
        }
    }
}
