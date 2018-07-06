using System.Reflection;
using ActionDispatcher = JJ.Demos.ReturnActions.Framework.Mvc.ActionDispatcher;

namespace JJ.Demos.ReturnActions.WithViewMapping.Mvc
{
	public static class DispatcherConfig
	{
		public static void AddMappings() => ActionDispatcher.RegisterAssembly(Assembly.GetCallingAssembly());
	}
}