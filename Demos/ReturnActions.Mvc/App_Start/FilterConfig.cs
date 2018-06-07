using System.Web.Mvc;
using JJ.Framework.Mvc;

namespace JJ.Demos.ReturnActions.Mvc
{
	public static class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
	    {
	        filters.Add(new BasicHandleErrorAttribute());
	    }
	}
}