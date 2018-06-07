using JJ.Demos.ReturnActions.Mvc.Names;
using JJ.Framework.Exceptions;

namespace JJ.Demos.ReturnActions.WithViewMapping.Mvc.PostData.Names
{
	public abstract class ActionNames : ActionNamesBase
	{
		public static void EditFromIndex() => throw new NameOfOnlyException();
		public static void EditFromDetails() => throw new NameOfOnlyException();
	}
}