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
    public class DetailsPresenter
    {
        public DetailsViewModel Show(int id)
        {
            return new DetailsViewModel
            {
                Entity = ViewModelFactory.CreateEntityViewModel(id)
            };
        }

        public object Edit(int id, string authenticatedUserName)
        {
            var presenter2 = new EditPresenter(authenticatedUserName);
            return presenter2.Show(id, returnAction: ActionHelper.CreateActionInfo<DetailsPresenter>(x => x.Show(id)));
        }

        public LoginViewModel Logout()
        {
            var presenter2 = new LoginPresenter();
            return presenter2.Show();
        }
    }
}
