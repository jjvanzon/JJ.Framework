using System.Web.Mvc;

namespace JJ.Framework.Mvc.TestViews
{
	public static class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters) => filters.Add(new HandleErrorAttribute());
	}
}