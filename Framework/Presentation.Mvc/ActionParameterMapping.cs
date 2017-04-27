using JJ.Framework.Exceptions;
using System;

namespace JJ.Framework.Presentation.Mvc
{
    public class ActionParameterMapping
    {
        public string PresenterParameterName { get; }
        public string ControllerParameterName { get; }

        public ActionParameterMapping(string presenterParameterName, string controllerParameterName)
        {
            if (String.IsNullOrEmpty(presenterParameterName)) throw new NullOrEmptyException(() => presenterParameterName);
            if (String.IsNullOrEmpty(controllerParameterName)) throw new NullOrEmptyException(() => controllerParameterName);

            PresenterParameterName = presenterParameterName;
            ControllerParameterName = controllerParameterName;
        }
    }
}
