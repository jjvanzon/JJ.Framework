using JJ.Demos.ReturnActions.WithViewMapping.Mvc.Names;
using JJ.Framework.Exceptions;

namespace JJ.Demos.ReturnActions.WithViewMapping.Mvc.PostData.Names
{
	public abstract class ViewNames : ViewNamesBase
	{
		public static void _ActionInfo() => throw new NameOfOnlyException();
		public static void _ActionParameterInfo() => throw new NameOfOnlyException();
	}
}