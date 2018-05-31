using System.Web.Mvc;

namespace JJ.Demos.ReturnActions.NoViewMapping.Mvc.UrlParameter
{
	public static class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}