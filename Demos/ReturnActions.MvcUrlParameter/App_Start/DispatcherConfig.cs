using ActionDispatcher = JJ.Framework.Presentation.Mvc.ActionDispatcher;
using System.Reflection;

namespace JJ.Demos.ReturnActions.MvcUrlParameter.App_Start
{
	internal static class DispatcherConfig
	{
		public static void AddMappings()
		{
			ActionDispatcher.RegisterAssembly(Assembly.GetExecutingAssembly());

			//ActionDispatcher.Map_Old<NotAuthorizedViewModel>(null, null, ViewNames.NotAuthorized);

			//ActionDispatcher.Map_Old<LoginViewModel>(ControllerNames.Login, ActionNames.Index, ViewNames.Index, x => new 
			//{
			//	ret = UrlHelpers.GetReturnUrl(x.ReturnAction) 
			//});

			//ActionDispatcher.Map_Old<ListViewModel>(ControllerNames.Demo, ActionNames.Index, ViewNames.Index);

			//ActionDispatcher.Map_Old<DetailsViewModel>(ControllerNames.Demo, ActionNames.Details, ViewNames.Details, x => new 
			//{
			//	id = x.Entity.ID 
			//});

			//ActionDispatcher.Map_Old<EditViewModel>(ControllerNames.Demo, ActionNames.Edit, ViewNames.Edit, x => new 
			//{
			//	id = x.Entity.ID, 
			//	ret = UrlHelpers.GetReturnUrl(x.ReturnAction) 
			//});
		}
	}
}