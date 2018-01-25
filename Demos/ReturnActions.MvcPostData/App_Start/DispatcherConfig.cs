using System.Reflection;
using ActionDispatcher = JJ.Framework.Mvc.ActionDispatcher;

namespace JJ.Demos.ReturnActions.MvcPostData.App_Start
{
	internal static class DispatcherConfig
	{
		public static void AddMappings()
		{
			ActionDispatcher.RegisterAssembly(Assembly.GetExecutingAssembly());
		}
	}
}