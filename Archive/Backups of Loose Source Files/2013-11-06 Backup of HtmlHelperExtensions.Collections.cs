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
            QualifierWithFieldPrefixAssignment qualifier = GetCurrentQualifier(htmlHelper);

            string identifier = ExpressionHelper.GetExpressionText(expression);

            qualifier.AddPart(identifier);

            return qualifier;
        }

        public static IDisposable BeginCollection(this HtmlHelper htmlHelper, Expression<Func<object>> expression)
        {
            QualifierWithFieldPrefixAssignment qualifier = GetCurrentQualifier(htmlHelper);

            string identifier = ExpressionHelper.GetExpressionText(expression);

            qualifier.AddPart(identifier);

            return qualifier;
        }

        public static IDisposable BeginCollectionItem(this HtmlHelper htmlHelper)
        {
            QualifierWithFieldPrefixAssignment qualifier = GetCurrentQualifier(htmlHelper);

            qualifier.IncrementIndex(htmlHelper);

            return new DummyDisposable(); 
        }

        private static object _dictionaryLock = new object();

        private static Dictionary<object, QualifierWithFieldPrefixAssignment> _dictionary = new Dictionary<object, QualifierWithFieldPrefixAssignment>();

        private static QualifierWithFieldPrefixAssignment GetCurrentQualifier(HtmlHelper htmlHelper)
        {
            object key = Thread.CurrentThread.ManagedThreadId;

            QualifierWithFieldPrefixAssignment qualifier;

            lock (_dictionaryLock)
            {
                if (_dictionary.ContainsKey(key))
                {
                    qualifier = _dictionary[key];
                }
                else
                {
                    qualifier = new QualifierWithFieldPrefixAssignment(htmlHelper);
                    _dictionary[key] = qualifier;
                }
            }

            return qualifier;
        }

        /// <summary>
        /// A qualifier to which you can add parts and indexes,
        /// that automatically assigns the HtmlFieldPrefix and hidden fields for indexes.
        /// that you can use with the using construct.
        /// When Dispose is called, the last part of the qualifier is removed.
        /// </summary>
        private class QualifierWithFieldPrefixAssignment : IDisposable
        {
            private Qualifier _base = new Qualifier();
            private HtmlHelper _originalHtmlHelper;
            private string _originalHtmlFieldPrefix;

            public QualifierWithFieldPrefixAssignment(HtmlHelper htmlHelper)
            {
                _originalHtmlHelper = htmlHelper;
                _originalHtmlFieldPrefix = _originalHtmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix;
            }

            public void AddPart(string identifier)
            {
                _base.AddPart(identifier);
            }

            public void IncrementIndex(HtmlHelper htmlHelper)
            {
                _base.IncrementIndex();

                HiddenIndexForQualifier(htmlHelper);

                htmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix = Text;
            }

            private void HiddenIndexForQualifier(HtmlHelper htmlHelper)
            {
                QualifierWithFieldPrefixAssignment qualifier = this;

                // When indexes of collections are not consecutive, they do not bind it to the model. Unless you add a '{0}.index' hidden field.

                TextWriter writer = htmlHelper.ViewContext.Writer;

                string collectionName = qualifier.Text.CutRightUntil("[").CutRight("[");
                string indexFieldName = String.Format("{0}.index", collectionName);

                // You cannot use the original or your own HtmlHelper.Hidden, because not only will it add the prefix, it will add a bad ID field.

                // Tip from original BeginCollectionItem author:
                // "    autocomplete="off" is needed to work around a very annoying Chrome behaviour
                //      whereby it reuses old values after the user clicks "Back", which causes the
                //      xyz.index and xyz[...] values to get out of sync.   "

                string html = String.Format(@"<input type=""hidden"" name=""{0}"" value=""{1}"" autocomplete=""off""/>", htmlHelper.Encode(indexFieldName), htmlHelper.Encode(qualifier.Index));

                writer.Write(html);
            }

            public int Index { get { return _base.Index; } }

            public string Text { get { return _base.Text; } }

            public void Dispose() // This is not really a dispose. It is called multiple times.
            {
                _base.Dispose();

                // If qualifier has no parts anymore, revert to original HtmlFieldPrefix.
                if (String.IsNullOrEmpty(Text))
                {
                    _originalHtmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix = _originalHtmlFieldPrefix;
                }
            }
        }

        /// <summary>
        /// A qualifier to which you can add parts and indexes,
        /// that you can use with the using construct.
        /// When Dispose is called, the last part of the qualifier is removed.
        /// </summary>
        private class Qualifier : IDisposable
        {
            private readonly Stack<QualifierPart> _parts = new Stack<QualifierPart>();

            public void AddPart(string identifier)
            {
                _parts.Push(new QualifierPart { Identifier = identifier });
            }

            public void IncrementIndex()
            {
                _parts.Peek().IncrementIndex();
            }

            public int Index
            {
                get { return _parts.Peek().Index; }
            }

            public string Text
            {
                get { return String.Join(".", _parts.Select(x => x.Text).Reverse()); }
            }

            public  void Dispose() // This is not really a dispose. It is called multiple times.
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
