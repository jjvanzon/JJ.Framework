using ActionDispatcher = JJ.Framework.Presentation.Mvc.ActionDispatcher;
using System.Reflection;

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