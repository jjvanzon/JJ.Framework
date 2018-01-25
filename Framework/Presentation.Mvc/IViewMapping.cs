using System;
using System.Collections.Generic;

namespace JJ.Framework.Mvc
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

		IList<ActionParameterMapping> ParameterMappings { get; }

		object GetRouteValues(object viewModel);
		ICollection<string> GetValidationMesssages(object viewModel);
		bool Predicate(object viewModel);
	}
}
