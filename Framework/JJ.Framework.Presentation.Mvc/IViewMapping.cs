using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Presentation.Mvc
{
    /// <summary>
    /// We need this interface to have a mutual type, because the ViewMapping base class is generic.
    /// </summary>
    public interface IViewMapping
    {
        Type ViewModelType { get; }
        string ViewName { get; }
        string PresenterName { get; }
        string PresenterActionName { get; }
        string ControllerName { get; }
        string ControllerGetActionName { get; }

        object GetRouteValues(object viewModel);
        ICollection<KeyValuePair<string, string>> GetValidationMesssages(object viewModel);
        bool Predicate(object viewModel);
    }
}
