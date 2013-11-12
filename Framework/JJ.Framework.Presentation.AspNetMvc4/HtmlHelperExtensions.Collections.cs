using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Web.Mvc;

namespace JJ.Framework.Presentation.AspNetMvc4
{
    public static partial class HtmlHelperExtensions_Collections
    {
        public static IDisposable BeginItem(this HtmlHelper htmlHelper, Expression<Func<object>> expression)
        {
            Qualifier qualifier = GetCurrentQualifier(htmlHelper);

            string identifier = ExpressionHelper.GetExpressionText(expression);

            qualifier.AddItemNode(htmlHelper, identifier);

            return qualifier;
        }

        public static IDisposable BeginCollection(this HtmlHelper htmlHelper, Expression<Func<object>> expression)
        {
            Qualifier qualifier = GetCurrentQualifier(htmlHelper);

            string identifier = ExpressionHelper.GetExpressionText(expression);

            qualifier.AddCollectionNode(htmlHelper, identifier);

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
        /// A qualifier to which you can add item nodes, collection nodes and indexes.
        /// Automatically assigns the HtmlFieldPrefix and adds hidden input elements that store the indexes.
        /// When Dispose is called, the last node of the qualifier is removed.
        /// </summary>
        private class Qualifier : IDisposable
        {
            private HtmlHelper _originalHtmlHelper;
            private string _originalHtmlFieldPrefix;
            private readonly Stack<Node> _nodes = new Stack<Node>();

            public Qualifier(HtmlHelper htmlHelper)
            {
                _originalHtmlHelper = htmlHelper;
                _originalHtmlFieldPrefix = _originalHtmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix;
            }

            public void AddItemNode(HtmlHelper htmlHelper, string identifier)
            {
                _nodes.Push(new ItemNode(identifier));

                htmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix = FormatText();
            }

            public void AddCollectionNode(HtmlHelper htmlHelper, string identifier)
            {
                _nodes.Push(new CollectionNode(identifier));
            }

            public void IncrementIndex(HtmlHelper htmlHelper)
            {
                // You cannot use the HtmlHelper from the constructor,
                // because the HtmlHelper can change when you go from one partial view to another.

                var node = _nodes.Peek() as CollectionNode;
                if (node == null)
                {
                    throw new Exception("Cannot call BeginCollectionItem, because you are not inside a BeginCollection scope.");
                }

                node.IncrementIndex();

                WriteHiddenIndexField(htmlHelper, node.Index);

                htmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix = FormatText();
            }

            private void WriteHiddenIndexField(HtmlHelper htmlHelper, int index)
            {
                // When indexes of collections are not consecutive, they do not bind it to the model. Unless you add a '{0}.index' hidden field.

                TextWriter writer = htmlHelper.ViewContext.Writer;

                string formattedText = FormatText();
                string collectionName = CutOffIndex(formattedText);
                string indexFieldName = String.Format("{0}.index", collectionName);

                // Tip from original BeginCollectionItem author:
                // "    autocomplete="off" is needed to work around a very annoying Chrome behaviour
                //      whereby it reuses old values after the user clicks "Back", which causes the
                //      xyz.index and xyz[...] values to get out of sync.   "

                // You cannot use HtmlHelper.Hidden, because it will use the wrong name prefix, and also generate a bad ID field with the wrong prefix.
                string html = String.Format(@"<input type=""hidden"" name=""{0}"" value=""{1}"" autocomplete=""off""/>", htmlHelper.Encode(indexFieldName), htmlHelper.Encode(index));

                writer.Write(html);
            }

            private string CutOffIndex(string input)
            {
                int pos = input.LastIndexOf('[');
                string output = input.Substring(0, pos);
                return output;
            }

            public string FormatText()
            {
                return String.Join(".", _nodes.Select(x => x.FormatText()).Reverse());
            }

            public void Dispose()
            {
                if (_nodes.Count > 0)
                {
                    _nodes.Pop();
                }
                else
                {
                    _originalHtmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix = _originalHtmlFieldPrefix;
                }
            }
        }

        private abstract class Node
        {
            public string Identifier { get; private set; }

            public Node(string identifier)
            {
                Identifier = identifier;
            }

            public abstract string FormatText();
        }

        private class ItemNode : Node
        {
            public ItemNode(string identifier)
                : base(identifier)
            { }

            public override string FormatText()
            {
                return Identifier;
            }
        }

        private class CollectionNode : Node
        {
            public CollectionNode(string identifier)
                : base(identifier)
            {
                Index = -1;
            }

            public int Index { get; private set; }

            public void IncrementIndex()
            {
                Index++;
            }

            public override string FormatText()
            {
                return Identifier + "[" + Index.ToString() + "]";
            }
        }

        private class DummyDisposable : IDisposable
        {
            public void Dispose()
            { }
        }
    }
}
