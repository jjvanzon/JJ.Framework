using JJ.Framework.Exceptions;
using JJ.Framework.Exceptions.Basic;

namespace JJ.Framework.Mvc
{
	public class ActionParameterMapping
	{
		public string PresenterParameterName { get; }
		public string ControllerParameterName { get; }

		public ActionParameterMapping(string presenterParameterName, string controllerParameterName)
		{
			if (string.IsNullOrEmpty(presenterParameterName)) throw new NullOrEmptyException(() => presenterParameterName);
			if (string.IsNullOrEmpty(controllerParameterName)) throw new NullOrEmptyException(() => controllerParameterName);

			PresenterParameterName = presenterParameterName;
			ControllerParameterName = controllerParameterName;
		}
	}
}
