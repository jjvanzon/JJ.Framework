using System.Reflection;
using ActionDispatcher = JJ.Framework.Mvc.ActionDispatcher;

namespace JJ.Demos.ReturnActions.MvcUrlParameterViewMappings
{
	internal static class DispatcherConfig
	{
		public static void AddMappings() => ActionDispatcher.RegisterAssembly(Assembly.GetExecutingAssembly());
	}
}