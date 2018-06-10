using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
// ReSharper disable MemberCanBePrivate.Global

namespace JJ.Framework.Mvc.TestViews.Helpers
{
    public static class HtmlPrefixScopeExtensions
    {
        private const string IDS_TO_REUSE_KEY = "__htmlPrefixScopeExtensions_IdsToReuse_";

        public static IDisposable BeginCollectionItem(this HtmlHelper html, string collectionName)
            => BeginCollectionItem(html, collectionName, html.ViewContext.Writer);

        public static IDisposable BeginCollectionItem(this HtmlHelper html, string collectionName, TextWriter writer)
        {
            Queue<string> idsToReuse = GetIdsToReuse(html.ViewContext.HttpContext, collectionName);
            string itemIndex = idsToReuse.Count > 0 ? idsToReuse.Dequeue() : Guid.NewGuid().ToString();

            // autocomplete="off" is needed to work around a very annoying Chrome behaviour
            // whereby it reuses old values after the user clicks "Back", which causes the
            // xyz.index and xyz[...] values to get out of sync.
            writer.WriteLine(
                "<input type=\"hidden\" name=\"{0}.index\" autocomplete=\"off\" value=\"{1}\" />",
                collectionName,
                html.Encode(itemIndex));

            return BeginHtmlFieldPrefixScope(html, $"{collectionName}[{itemIndex}]");
        }

        public static IDisposable BeginHtmlFieldPrefixScope(this HtmlHelper html, string htmlFieldPrefix)
            => new HtmlFieldPrefixScope(html.ViewData.TemplateInfo, htmlFieldPrefix);

        private static Queue<string> GetIdsToReuse(HttpContextBase httpContext, string collectionName)
        {
            // We need to use the same sequence of IDs following a server-side validation failure,
            // otherwise the framework won't render the validation error messages next to each item.
            string key = IDS_TO_REUSE_KEY + collectionName;
            var queue = (Queue<string>)httpContext.Items[key];

            if (queue == null)
            {
                httpContext.Items[key] = queue = new Queue<string>();
                string previouslyUsedIds = httpContext.Request[collectionName + ".index"];

                if (!string.IsNullOrEmpty(previouslyUsedIds))
                {
                    foreach (string previouslyUsedId in previouslyUsedIds.Split(','))
                    {
                        queue.Enqueue(previouslyUsedId);
                    }
                }
            }

            return queue;
        }

        internal class HtmlFieldPrefixScope : IDisposable
        {
            internal readonly TemplateInfo _templateInfo;
            internal readonly string _previousHtmlFieldPrefix;

            public HtmlFieldPrefixScope(TemplateInfo templateInfo, string htmlFieldPrefix)
            {
                _templateInfo = templateInfo;

                _previousHtmlFieldPrefix = _templateInfo.HtmlFieldPrefix;
                _templateInfo.HtmlFieldPrefix = htmlFieldPrefix;
            }

            public void Dispose() => _templateInfo.HtmlFieldPrefix = _previousHtmlFieldPrefix;
        }
    }
}