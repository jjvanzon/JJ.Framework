using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace JJ.Framework.Presentation.AspNetMvc4
{
    public static class HtmlExtensions
    {
        /// <summary>
        /// Adds a hidden input element for every model property (to keep the view model in tact between posts).
        /// </summary>
        public static MvcHtmlString HiddenForAllProperties(this HtmlHelper htmlHelper, object model)
        {
            if (model == null)
            {
                return new MvcHtmlString(null);
            }

            var sb = new StringBuilder();

            foreach (PropertyInfo property in model.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                string name = property.Name;
                object value = property.GetValue(model);
                //string html = htmlHelper.Hidden(name, value).ToString(); // Generates more attributes than I want.
                string html = String.Format(@"<input name=""{0}"" id=""{0}"" type=""hidden"" value=""{1}""/>", htmlHelper.Encode(name), htmlHelper.Encode(value));
                sb.AppendLine(html);
            }

            return new MvcHtmlString(sb.ToString());
        }
    }
}
