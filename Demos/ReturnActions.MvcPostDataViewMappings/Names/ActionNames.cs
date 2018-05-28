using JJ.Demos.ReturnActions.WithViewMapping.Mvc.Names;
using JJ.Demos.ReturnActions.WithViewMappings.MvcBase.Names;
using JJ.Framework.Exceptions;

namespace JJ.Demos.ReturnActions.MvcPostDataViewMappings.Names
{
	public abstract class ActionNames : ActionNamesBase
	{
		public static void EditFromIndex() => throw new NameOfOnlyException();
		public static void EditFromDetails() => throw new NameOfOnlyException();
	}
}