using System.Web.Mvc;

namespace JJ.Demos.ReturnActions.MvcUrlParameter
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}