using System.Web.Mvc;

namespace JJ.Demos.ReturnActions.MvcPostData
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}