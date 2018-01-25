using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using JJ.Framework.Common;
using JJ.Framework.Reflection;

namespace JJ.Framework.Mvc
{
	public static partial class HtmlHelperExtensions
	{
		public static MvcHtmlString ActionLinkWithCollection<T>(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, string parameterName, IEnumerable<T> collection)
		{
			// First HTML-encode all elements of the url, for safety.
			linkText = htmlHelper.Encode(linkText);

			// Build the <a> tag.
			string url = UrlHelpers.ActionWithCollection(actionName, controllerName, parameterName, collection);
			string html = @"<a href=""" + url + @""">" + linkText + "</a>";

			return new MvcHtmlString(html);
		}

		public static MvcHtmlString ActionLinkWithParams(this HtmlHelper htmlHelper, string actionName, string controllerName, params object[] parameterNamesAndValues)
		{
			IDictionary<string, object> dictionary = KeyValuePairHelper.ConvertNamesAndValuesListToDictionary(parameterNamesAndValues);
			return htmlHelper.ActionLink(actionName, controllerName, new RouteValueDictionary(dictionary));
		}

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

			foreach (PropertyInfo property in StaticReflectionCache.GetProperties(model.GetType()))
			{
				string name = property.Name;
				object value = property.GetValue(model);
				string html = htmlHelper.Hidden(name, value).ToString();
				sb.AppendLine(html);
			}

			return new MvcHtmlString(sb.ToString());
		}

		/// <summary>
		/// Own version of Html.Hidden. The one from Microsoft can generate a value of false when you pass true to it.
		/// This only happens when you do not conform to the Post-Redirect-Get pattern.
		/// </summary>
		[Obsolete(@"
Consider using the standard MVC HiddenFor and conforming to the Post-Redirect-Get pattern.
Or rather: 
- At the end of your post action method store the necessary data / viewmodel in the TempData dictionary of the Controller base class.
- Then do a RedirectToAction to the Get action.
- In the Get action method, pick up the viewmodel out of the TempData dictionary if it is present there. Otherwise just create new one.")]
		public static MvcHtmlString HiddenFor<T>(this HtmlHelper htmlHelper, Expression<Func<T>> expression)
		{
			//string name = JJ.Framework.Reflection.ExpressionHelper.GetName(expression);
			string name = System.Web.Mvc.ExpressionHelper.GetExpressionText(expression); // The one from MVC will get the appropriate portion of a complex expression, for when you don't use BeginCollection().
			T value = JJ.Framework.Reflection.ExpressionHelper.GetValue(expression);
			return htmlHelper.Hidden(name, value);
		}

		/// <summary>
		/// Own version of Html.Hidden. The one from Microsoft can generate a value of false when you pass true to it.
		/// This only happens when you do not conform to the Post-Redirect-Get pattern.
		/// </summary>
		[Obsolete(@"
Consider using the standard MVC HiddenFor and conforming to the Post-Redirect-Get pattern.
Or rather: 
- At the end of your post action method store the necessary data / viewmodel in the TempData dictionary of the Controller base class.
- Then do a RedirectToAction to the Get action.
- In the Get action method, pick up the viewmodel out of the TempData dictionary if it is present there. Otherwise just create new one.")]
		public static MvcHtmlString Hidden(this HtmlHelper htmlHelper, string name, object value)
		{
			// Tip from original BeginCollectionItem author:
			// "	autocomplete="off" is needed to work around a very annoying Chrome behaviour
			//	  whereby it reuses old values after the user clicks "Back", which causes the
			//	  xyz.index and xyz[...] values to get out of sync.   "

			string fullName = htmlHelper.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
			string fullID = htmlHelper.ViewData.TemplateInfo.GetFullHtmlFieldId(name);

			string html = string.Format(@"<input name=""{0}"" id=""{1}"" type=""hidden"" value=""{2}"" autocomplete=""off""/>", htmlHelper.Encode(fullName), htmlHelper.Encode(fullID), htmlHelper.Encode(value));
			return new MvcHtmlString(html);
		}
	}
}
