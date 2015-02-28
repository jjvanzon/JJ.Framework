using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Presentation.Mvc
{
    internal class MvcActionDispatcherMapping<TViewModel> : IMvcActionDispatcherMapping
    {
        private string _controllerName;
        private string _actionName;
        private string _viewName;
        private Func<object, bool> _predicate;
        private Func<object, KeyValuePair<string, string>> _getValidationMesssagesDelegate;
        private Func<object, object> _getActionParametersDelegate;

        /// <param name="controllerName">nullable</param>
        /// <param name="actionName">nullable</param>
        /// <param name="viewName"></param>
        /// <param name="predicate">nullable</param>
        /// <param name="getValidationMesssagesDelegate">nullable</param>
        /// <param name="getActionParametersDelegate">nullable</param>
        public MvcActionDispatcherMapping(
            string controllerName, string actionName, string viewName,
            Func<object, bool> predicate,
            Func<object, KeyValuePair<string, string>> getValidationMesssagesDelegate,
            Func<object, object> getActionParametersDelegate)
        {
            if (String.IsNullOrEmpty(viewName)) throw new Exception("viewName cannot be null or empty.");

            _controllerName = controllerName;
            _actionName = actionName;
            _viewName = viewName;
            _predicate = predicate;
            _getValidationMesssagesDelegate = getValidationMesssagesDelegate;
            _getActionParametersDelegate = getActionParametersDelegate;
        }

        public string ControllerName { get { return _controllerName; } }
        public string ActionName { get { return _actionName; } }
        public string ViewName { get { return _viewName; } }
        public Func<object, bool> Predicate { get { return _predicate; } }
        public Func<object, KeyValuePair<string, string>> GetValidationMesssagesDelegate { get { return _getValidationMesssagesDelegate; } }
        public Func<object, object> GetActionParametersDelegate { get { return _getActionParametersDelegate; } }

        Func<object, bool> IMvcActionDispatcherMapping.Predicate
        {
            get { return x => Predicate((TViewModel)x); }
        }

        Func<object, KeyValuePair<string, string>> IMvcActionDispatcherMapping.GetValidationMesssagesDelegate
        {
            get { throw new NotImplementedException(); }
        }

        Func<object, object> IMvcActionDispatcherMapping.GetActionParametersDelegate
        {
            get { throw new NotImplementedException(); }
        }
    }
}
