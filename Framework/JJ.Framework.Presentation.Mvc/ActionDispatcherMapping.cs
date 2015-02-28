using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Presentation.Mvc
{
    internal class ActionDispatcherMapping
    {
        /// <param name="controllerName">nullable</param>
        /// <param name="actionName">nullable</param>
        /// <param name="viewName"></param>
        /// <param name="getActionParametersDelegate">nullable</param>
        /// <param name="getValidationMesssagesDelegate">nullable</param>
        /// <param name="predicate">nullable</param>
        public ActionDispatcherMapping(
            string controllerName, string actionName, string viewName,
            Func<object, object> getActionParametersDelegate,
            Func<object, ICollection<KeyValuePair<string, string>>> getValidationMesssagesDelegate,
            Func<object, bool> predicate)
        {
            if (String.IsNullOrEmpty(viewName)) throw new Exception("viewName cannot be null or empty.");

            ControllerName = controllerName;
            ActionName = actionName;
            ViewName = viewName;
            GetActionParametersDelegate = getActionParametersDelegate;
            GetValidationMesssagesDelegate = getValidationMesssagesDelegate;
            Predicate = predicate;
        }

        public string ControllerName { get; private set; }
        public string ActionName { get; private set; }
        public string ViewName { get; private set; }
        public Func<object, object> GetActionParametersDelegate { get; private set; }
        public Func<object, ICollection<KeyValuePair<string, string>>> GetValidationMesssagesDelegate { get; private set; }
        public Func<object, bool> Predicate { get; private set; }
    }
}
