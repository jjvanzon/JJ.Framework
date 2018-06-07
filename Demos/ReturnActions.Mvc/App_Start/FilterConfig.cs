using System.Web.Mvc;
using JJ.Demos.ReturnActions.Mvc.Attributes;

namespace JJ.Demos.ReturnActions.Mvc
{
	public static class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
	    {
	        filters.Add(new ErrorFilterAttribute());
	    }
	}
}