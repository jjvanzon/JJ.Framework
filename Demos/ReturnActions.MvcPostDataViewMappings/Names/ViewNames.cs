using JJ.Demos.ReturnActions.WithViewMappings.MvcBase.Names;
using JJ.Framework.Exceptions;

namespace JJ.Demos.ReturnActions.MvcPostDataViewMappings.Names
{
	public abstract class ViewNames : ViewNamesBase
	{
		public static void _ActionInfo() => throw new NameOfOnlyException();
		public static void _ActionParameterInfo() => throw new NameOfOnlyException();
	}
}