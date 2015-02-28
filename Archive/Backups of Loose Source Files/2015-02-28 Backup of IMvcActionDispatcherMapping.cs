using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Presentation.Mvc
{
    internal interface IMvcActionDispatcherMapping
    {
        string ControllerName { get; }
        string ActionName { get; }
        string ViewName { get; }
        Func<object, bool> Predicate { get; }
        Func<object, KeyValuePair<string, string>> GetValidationMesssagesDelegate { get; }
        Func<object, object> GetActionParametersDelegate { get; }
    }
}
