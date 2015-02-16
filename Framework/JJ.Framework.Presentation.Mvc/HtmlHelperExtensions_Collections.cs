using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Web.Mvc;

namespace JJ.Framework.Presentation.Mvc
{
    public static class HtmlHelperExtensions_Collections
    {
        public static IDisposable BeginItem(this HtmlHelper htmlHelper, Expression<Func<object>> expression)
        {
            Qualifier qualifier = GetQualifierForCurrentThread();

            string identifier = JJ.Framework.Reflection.ExpressionHelper.GetName(expression);

            qualifier.AddItemNode(htmlHelper, identifier);

            return qualifier;
        }

        public static IDisposable BeginCollection(this HtmlHelper htmlHelper, Expression<Func<object>> expression)
        {
            Qualifier qualifier = GetQualifierForCurrentThread();

            string identifier = JJ.Framework.Reflection.ExpressionHelper.GetName(expression);

            qualifier.AddCollectionNode(identifier);

            return qualifier;
        }

        // TODO: You need an overload that takes an int index for when the structure in the viewmodel maps to a totally different structure in the view.

        public static IDisposable BeginCollectionItem(this HtmlHelper htmlHelper)
        {
            Qualifier qualifier = GetQualifierForCurrentThread();

            qualifier.IncrementIndex(htmlHelper);

            return new DummyDisposable(); 
        }

        private static object _qualifierDictionaryLock = new object();
        private static Dictionary<object, Qualifier> _qualifierDictionary = new Dictionary<object, Qualifier>();

        private static Qualifier GetQualifierForCurrentThread()
        {
            lock (_qualifierDictionaryLock)
            {
                object key = Thread.CurrentThread.ManagedThreadId;

                if (!_qualifierDictionary.ContainsKey(key))
                {
                    _qualifierDictionary[key] = new Qualifier();
                }

                return _qualifierDictionary[key];
            }
        }

        internal static void RemoveQualifierForCurrentThread()
        {
            lock (_qualifierDictionary)
            {
                object key = Thread.CurrentThread.ManagedThreadId;

                if (_qualifierDictionary.ContainsKey(key))
                {
                    _qualifierDictionary.Remove(key);
                }
            }
        }

        /// <summary>
        /// A qualifier to which you can add item nodes, collection nodes and indexes.
        /// Automatically assigns the HtmlFieldPrefix and adds hidden input elements that store the indexes.
        /// When Dispose is called, the last node of the qualifier is removed.
        /// If no nodes are left, Dispose resets the original HtmlFieldPrefix.
        /// </summary>
        private class Qualifier : IDisposable
        {
            // You cannot use the HtmlHelper in the constructor,
            // because the HtmlHelper can change when you go from one partial view to another.
            private readonly IList<HtmlHelper> _htmlHelpers = new List<HtmlHelper>();
            private readonly Stack<Node> _nodes = new Stack<Node>();

            public void AddItemNode(HtmlHelper htmlHelper, string identifier)
            {
                if (!_htmlHelpers.Contains(htmlHelper))
                {
                    _htmlHelpers.Add(htmlHelper);
                }

                _nodes.Push(new ItemNode(identifier));

                htmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix = FormatText();
            }

            public void AddCollectionNode(string identifier)
            {
                _nodes.Push(new CollectionNode(identifier));
            }

            public void IncrementIndex(HtmlHelper htmlHelper)
            {
                if (!_htmlHelpers.Contains(htmlHelper))
                {
                    _htmlHelpers.Add(htmlHelper);
                }

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

                // TODO: Check if you have already added the hidden field with this name and value. You can get duplicates if you do not use straightforeward nested loops.

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
                
                if (_nodes.Count == 0)
                {
                    // We cannot restore the original HtmlFieldPrefix,
                    // because the _originalHtmlHelper is not always the HtmlHelper you get after closing the last using, 
                    // even if you only use one view and no partials.
                    // So we just clear the HtmlFieldPrefix of each HtmlHelper we encountered.
                    // TODO: Find a solution to actually restore the previous HtmlHelper prefixes.

                    for (int i = 0; i < _htmlHelpers.Count; i++)
			        {
			            HtmlHelper htmlHelper = _htmlHelpers[i];
                        htmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix = "";
			        }

                    // Make sure the next time the thread is reused, we start with a fresh qualifier.
                    HtmlHelperExtensions_Collections.RemoveQualifierForCurrentThread();
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
