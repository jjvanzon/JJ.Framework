using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace JJ.Framework.Presentation.AspNetMvc4
{
    public static partial class HtmlHelperExtensions
    {
        /// <summary>
        /// Adds a hidden input element for every model property (to keep the view model in tact between posts).
        /// </summary>
        [Obsolete("Instead use HiddenFor for specific view model elements that must be posted back. This is more efficient and less error prone, and HiddenForAllProperties would not cover complex view models.")]
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
                //string html = String.Format(@"<input name=""{0}"" id=""{0}"" type=""hidden"" value=""{1}""/>", htmlHelper.Encode(name), htmlHelper.Encode(value));
                string html = htmlHelper.Hidden(name, value).ToString();
                sb.AppendLine(html);
            }

            return new MvcHtmlString(sb.ToString());
        }

        /// <summary>
        /// Own version of Html.Hidden. The one from Microsoft can generate false when you pass true to it, and also generates more attributes than required.
        /// </summary>
        /// <returns></returns>
        public static MvcHtmlString Hidden(this HtmlHelper htmlHelper, object name, object value)
        {
            // Tip from original BeginCollectionItem author:
            //
            // "    autocomplete="off" is needed to work around a very annoying Chrome behaviour
            //      whereby it reuses old values after the user clicks "Back", which causes the
            //      xyz.index and xyz[...] values to get out of sync.   "

            string html = String.Format(@"<input name=""{0}"" id=""{0}"" type=""hidden"" value=""{1}"" autocomplete=""off""/>", htmlHelper.Encode(name), htmlHelper.Encode(value));
            return new MvcHtmlString(html);
        }

        public static MvcHtmlString ActionLinkWithCollection<T>(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, string parameterName, IEnumerable<T> collection)
        {
            // First HTML-encode all elements of the url, for safety.
            linkText = htmlHelper.Encode(linkText);

            // Build the <a> tag.
            string url = UrlHelpers.GetUrlWithCollectionParameter(actionName, controllerName, parameterName, collection);
            string html = @"<a href=""" + url + @""">" + linkText + "</a>";

            return new MvcHtmlString(html);
        }
    }
}
