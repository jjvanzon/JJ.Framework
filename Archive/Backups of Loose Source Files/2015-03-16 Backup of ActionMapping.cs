using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Presentation.Mvc
{
    public abstract class ActionMapping<TViewModel>
    {
        public string _presenterName;
        private string _presenterActionName;
        private string _controllerName;
        private string _controllerActionName;
        private string _viewName;

        /// <param name="presenterName">optional</param>
        /// <param name="presenterActionName">optional</param>
        /// <param name="controllerName">optional</param>
        /// <param name="controllerActionName">optional</param>
        /// <param name="viewName">required</param>
        public ActionMapping(
            string presenterName, 
            string presenterActionName,
            string controllerName,
            string controllerActionName,
            string viewName)
        {
            if (!String.IsNullOrEmpty(viewName)) throw new Exception("viewName cannot be null or empty.");

            _presenterName = presenterName;
            _presenterActionName = presenterActionName;
            _controllerName = controllerName;
            _controllerActionName = controllerActionName;
            _viewName = viewName;
        }

        protected virtual object GetControllerActionParameters(TViewModel viewModel)
        {
            return null;
        }

        protected virtual ICollection<KeyValuePair<string, string>> GetValidationMesssages(TViewModel viewModel)
        {
            return null;
        }

        protected virtual bool Predicate(TViewModel viewModel)
        {
            return true;
        }
    }
}