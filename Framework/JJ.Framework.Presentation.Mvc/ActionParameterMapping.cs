using JJ.Framework.Reflection.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Presentation.Mvc
{
    public class ActionParameterMapping
    {
        public string PresenterActionParameter { get; private set; }
        public string ControllerActionParameter { get; private set; }

        public ActionParameterMapping(string presenterActionParameter, string controllerActionParameter)
        {
            if (String.IsNullOrEmpty(presenterActionParameter)) throw new NullOrEmptyException(() => presenterActionParameter);
            if (String.IsNullOrEmpty(controllerActionParameter)) throw new NullOrEmptyException(() => controllerActionParameter);

            PresenterActionParameter = presenterActionParameter;
            ControllerActionParameter = controllerActionParameter;
        }
    }
}
