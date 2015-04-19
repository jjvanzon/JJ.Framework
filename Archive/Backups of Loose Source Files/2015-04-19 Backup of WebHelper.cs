using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace JJ.Framework.Web
{
    // TODO: This is not a very creative name. Can I not be any more specific?
    public class WebHelper
    {
        /// <summary>
        /// Source: http://stackoverflow.com/questions/4277692/getentryassembly-for-web-applications
        /// Let's hope it works.
        /// </summary>
        public static Assembly GetWebEntryAssembly()
        {
            if (HttpContext.Current == null ||
                HttpContext.Current.ApplicationInstance == null)
            {
                return null;
            }

            var type = HttpContext.Current.ApplicationInstance.GetType();
            while (type != null && type.Namespace == "ASP")
            {
                type = type.BaseType;
            }

            return type == null ? null : type.Assembly;
        }
    }
}
