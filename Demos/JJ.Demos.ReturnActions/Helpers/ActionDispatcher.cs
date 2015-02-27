using JJ.Demos.ReturnActions.Presenters;
using JJ.Framework.Presentation;
using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Demos.ReturnActions.Helpers
{
    internal static class ActionDispatcher
    {
        /// <summary>
        /// Gets a view model dynamically from the described presenter and action.
        /// Overloaded action methods are not supported.
        /// Also: only simple parameter types are supported.
        /// </summary>
        /// <param name="authenticatedUserName">nullable</param>
        public static object GetViewModel(ActionInfo actionInfo, string authenticatedUserName)
        {
            if (actionInfo == null) throw new NullException(() => actionInfo);

            object presenter = CreatePresenter(actionInfo.PresenterName, authenticatedUserName);
            object viewModel = ActionHelper.DispatchAction(presenter, actionInfo);
            return viewModel;
        }

        private static object CreatePresenter(string presenterName, string authenticatedUserName)
        {
            Type presenterType = GetPresenterType(presenterName);
            
            if (presenterType == typeof(DetailsPresenter))
            {
                return new DetailsPresenter();
            }
            else if (presenterType == typeof(EditPresenter))
            {
                return new EditPresenter(authenticatedUserName);
            }
            else if (presenterType == typeof(ListPresenter))
            {
                return new ListPresenter();
            }
            else if (presenterType == typeof(LoginPresenter))
            {
                return new LoginPresenter();
            }
            else
            {
                throw new Exception(String.Format("Presenter type '{0}' is not supported.", presenterType.FullName));
            }
        }

        private static Type GetPresenterType(string presenterName)
        {
            Type templateType = typeof(ListPresenter);
            string typeName = String.Format("{0}.{1}", templateType.Namespace, presenterName);
            Type type = templateType.Assembly.GetType(typeName);
            if (type == null)
            {
                throw new Exception(String.Format("Type '{0}' not found.", typeName));
            }
            return type;
        }
    }
}
