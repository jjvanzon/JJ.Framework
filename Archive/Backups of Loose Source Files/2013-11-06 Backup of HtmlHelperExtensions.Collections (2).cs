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
using System.IO;

namespace JJ.Framework.Presentation.AspNetMvc4
{
    public static partial class HtmlHelperExtensions_Collections
    {
        public static IDisposable BeginItem(this HtmlHelper htmlHelper, Expression<Func<object>> expression)
        {
            Qualifier qualifier = GetCurrentQualifier(htmlHelper);

            string identifier = ExpressionHelper.GetExpressionText(expression);

            qualifier.AddPart(htmlHelper, identifier);

            return qualifier;
        }

        public static IDisposable BeginCollection(this HtmlHelper htmlHelper, Expression<Func<object>> expression)
        {
            Qualifier qualifier = GetCurrentQualifier(htmlHelper);

            string identifier = ExpressionHelper.GetExpressionText(expression);

            qualifier.AddPart(htmlHelper, identifier);

            return qualifier;
        }

        public static IDisposable BeginCollectionItem(this HtmlHelper htmlHelper)
        {
            Qualifier qualifier = GetCurrentQualifier(htmlHelper);

            qualifier.IncrementIndex(htmlHelper);

            return new DummyDisposable(); 
        }

        private static object _dictionaryLock = new object();

        private static Dictionary<object, Qualifier> _dictionary = new Dictionary<object, Qualifier>();

        private static Qualifier GetCurrentQualifier(HtmlHelper htmlHelper)
        {
            lock (_dictionaryLock)
            {
                object key = Thread.CurrentThread.ManagedThreadId;

                if (!_dictionary.ContainsKey(key))
                {
                    _dictionary[key] = new Qualifier(htmlHelper);
                }

                return _dictionary[key];
            }
        }

        /// <summary>
        /// A qualifier to which you can add parts and indexes,
        /// that automatically assigns the HtmlFieldPrefix and adds hidden input elements that store the indexes.
        /// When Dispose is called, the last part of the qualifier is removed.
        /// </summary>
        private class Qualifier : IDisposable
        {
            private HtmlHelper _originalHtmlHelper;
            private string _originalHtmlFieldPrefix;
            private readonly Stack<QualifierPart> _parts = new Stack<QualifierPart>();

            public Qualifier(HtmlHelper htmlHelper)
            {
                _originalHtmlHelper = htmlHelper;
                _originalHtmlFieldPrefix = _originalHtmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix;
            }

            public void AddPart(HtmlHelper htmlHelper, string identifier)
            {
                _parts.Push(new QualifierPart(identifier));

                htmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix = Text;
            }

            public void IncrementIndex(HtmlHelper htmlHelper)
            {
                // You cannot use the HtmlHelper from the constructor,
                // because the HtmlHelper can change when you go from one partial view to another.

                _parts.Peek().IncrementIndex();

                WriteHiddenIndexField(htmlHelper);

                htmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix = Text;
            }

            private void WriteHiddenIndexField(HtmlHelper htmlHelper)
            {
                // When indexes of collections are not consecutive, they do not bind it to the model. Unless you add a '{0}.index' hidden field.

                TextWriter writer = htmlHelper.ViewContext.Writer;

                string collectionName = Text.CutRightUntil("[").CutRight("[");
                string indexFieldName = String.Format("{0}.index", collectionName);
                int index = _parts.Peek().Index;

                // Tip from original BeginCollectionItem author:
                // "    autocomplete="off" is needed to work around a very annoying Chrome behaviour
                //      whereby it reuses old values after the user clicks "Back", which causes the
                //      xyz.index and xyz[...] values to get out of sync.   "

                // You cannot use HtmlHelper.Hidden, because it will use the wrong name prefix, and also generate a bad ID field with the wrong prefix.
                string html = String.Format(@"<input type=""hidden"" name=""{0}"" value=""{1}"" autocomplete=""off""/>", htmlHelper.Encode(indexFieldName), htmlHelper.Encode(index));

                writer.Write(html);
            }

            public string Text
            {
                get { return String.Join(".", _parts.Select(x => x.Text).Reverse()); }
            }

            public void Dispose()
            {
                if (_parts.Count > 0)
                {
                    _parts.Pop();
                }
                else
                {
                    _originalHtmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix = _originalHtmlFieldPrefix;
                }
            }
        }

        private class QualifierPart
        {
            public QualifierPart(string identifier)
            {
                Identifier = identifier;
                Index = -1;
            }

            public string Identifier { get; private set; }

            public int Index { get; private set; }

            public void IncrementIndex()
            {
                Index++;
            }

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
