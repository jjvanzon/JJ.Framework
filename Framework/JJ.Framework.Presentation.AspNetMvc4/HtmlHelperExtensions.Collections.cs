using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using JJ.Framework.Common;

namespace JJ.Framework.Presentation.AspNetMvc4
{
    public static partial class HtmlHelperExtensions
    {
        public static IDisposable BeginCollection(this HtmlHelper htmlHelper, Expression<Func<object>> expression)
        {
            Qualifier qualifier = GetCurrentQualifier(htmlHelper);

            string identifier = ExpressionHelper.GetExpressionText(expression);

            qualifier.AddPart(identifier);

            return qualifier;
        }

        public static IDisposable BeginCollectionItem(this HtmlHelper htmlHelper)
        {
            Qualifier qualifier = GetCurrentQualifier(htmlHelper);

            qualifier.IncrementIndex();

            return new DummyDisposable(); // Just for consistent 'using' syntax.
        }

        public static MvcHtmlString HiddenFor<T>(this HtmlHelper htmlHelper, Expression<Func<T>> expression, T value)
        {
            Qualifier qualifier = GetCurrentQualifier(htmlHelper);
            string qualifierText = qualifier.Text;

            string html = "";

            // When indexes of collections are not consecutive, they do not bind it to the model. Unless you speficy a '{0}.index' hidden field.
            if (!qualifier.IndexWasAdded)
            {
                string collectionName = qualifierText.CutRightUntil("[").CutRight("[");
                string hiddenIndexFieldName = String.Format("{0}.index", collectionName);
                string hiddenIndexField = htmlHelper.Hidden(hiddenIndexFieldName, qualifier.Index).ToString();
                html += hiddenIndexField;

                qualifier.SetIndexWasAdded();
            }

            string identifier = ExpressionHelper.GetExpressionText(expression);
            string hiddenFieldName = qualifierText + "." + identifier;
            string hiddenField = htmlHelper.Hidden(hiddenFieldName, value).ToString();
            html += hiddenField;

            return new MvcHtmlString(html);
        }

        private static object _dictionaryLock = new object();

        private static Dictionary<object, Qualifier> _dictionary = new Dictionary<object, Qualifier>();

        private static Qualifier GetCurrentQualifier(HtmlHelper htmlHelper)
        {
            lock (_dictionaryLock)
            {
                object key = Thread.CurrentThread.ManagedThreadId;

                if (_dictionary.ContainsKey(key))
                {
                    return _dictionary[key];
                }

                _dictionary[key] = new Qualifier();

                return _dictionary[key];
            }
        }

        private class Qualifier : IDisposable
        {
            private readonly Stack<QualifierPart> _parts = new Stack<QualifierPart>();

            public bool IndexWasAdded { get; private set; }

            public void SetIndexWasAdded()
            {
                IndexWasAdded = true;
            }

            public void AddPart(string identifier)
            {
                var part = new QualifierPart { Identifier = identifier };

                _parts.Push(part);
            }

            public void IncrementIndex()
            {
                QualifierPart part = _parts.Peek();
                part.Index++;
                IndexWasAdded = false;
            }
            
            public int Index
            {
                get
                {
                    QualifierPart part = _parts.Peek();
                    return part.Index;
                }
            }

            public string Text
            {
                get { return String.Join(".", _parts.Select(x => x.Text).Reverse()); }
            }

            // This is not really a dispose. It is called multiple times.
            public void Dispose()
            {
                if (_parts.Count > 0)
                {
                    _parts.Pop();
                }
            }
        }

        private class QualifierPart
        {
            public QualifierPart()
            {
                Index = -1;
            }

            public string Identifier { get; set; }

            public int Index { get; set; }

            public string Text
            {
                get 
                {
                    if (Index == -1)
                    {
                        return Identifier;
                    }
                    else
                    {
                        return Identifier + "[" + Index.ToString() + "]";
                    }
                }
            }
        }

        private class DummyDisposable : IDisposable
        {
            public void Dispose()
            { }
        }
    }
}
