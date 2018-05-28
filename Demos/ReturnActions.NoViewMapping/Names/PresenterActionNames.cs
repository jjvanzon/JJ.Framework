// ReSharper disable InconsistentNaming

using JJ.Framework.Exceptions;

namespace JJ.Demos.ReturnActions.NoViewMapping.Names
{
	public static class PresenterActionNames
	{
		public static string Show => throw new NameOfOnlyException();
	}
}
