using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using J = JJ.Framework.Reflection;

namespace JJ.Framework.Presentation.AspNetMvc4
{
    public static partial class HtmlHelperExtensions
    {
        public static Qualifier BeginCollection(this HtmlHelper htmlHelper, Expression<Func<object>> expression)
        {
            Qualifier qualifier = GetQualifier(htmlHelper);

            string text = J.ExpressionHelper.GetName(expression);

            qualifier.Stack.Push(text);

            return qualifier;
        }

        public static Qualifier BeginCollectionItem(this HtmlHelper htmlHelper)
        {
            Qualifier qualifier = GetQualifier(htmlHelper);

            string text = String.Format("[{0}]", qualifier.CurrentIndex);

            qualifier.Stack.Push(text);

            qualifier.CurrentIndex++;

            return qualifier;
        }

        public static MvcHtmlString HiddenFor<T>(this HtmlHelper htmlHelper, Expression<Func<T>> expression, T value)
        {
            Qualifier qualifier = GetQualifier(htmlHelper);

            string qualifierText = qualifier.Format();

            string text = J.ExpressionHelper.GetName<T>(expression);

            return htmlHelper.Hidden(qualifierText + "." + text, Convert.ToString(value));
        }

        private static object _dictionaryLock = new object();

        private static Dictionary<object, Qualifier> _dictionary = new Dictionary<object, Qualifier>();

        private static Qualifier GetQualifier(HtmlHelper htmlHelper)
        {
            lock (_dictionaryLock)
            {
                object key = htmlHelper.ViewContext.HttpContext.Session.SessionID; // TODO: This key is probably not good enough.

                if (_dictionary.ContainsKey(key))
                {
                    return _dictionary[key];
                }

                _dictionary[key] = new Qualifier();

                return _dictionary[key];
            }
        }

        public class Qualifier : IDisposable
        {
            public Qualifier()
            {
                Stack = new Stack<string>();
            }

            public Stack<string> Stack { get; private set; }
            public int CurrentIndex { get; set; }

            public string Format()
            {
                string str = String.Join(".", Stack.Reverse());
                str = str.Replace(".[", "[");
                return str;
            }

            public void Dispose()
            {
                string value = Stack.Pop();

                if (value.StartsWith("[")) // TODO: This might be too creative.
                {
                    CurrentIndex--;
                }
            }
        }
    }
}
