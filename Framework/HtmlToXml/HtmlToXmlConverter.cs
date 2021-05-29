using System.IO;
using System.Xml;
using Sgml;

namespace JJ.Framework.HtmlToXml
{
    public static class HtmlToXmlConverter
    {
        // Disabled this HACK.
        // See further down for comment.
        // private const string HTML_OPEN_TAG = "<html>";
        // private const string HTML_CLOSE_TAG = "</html>";

        public static string Convert(string html, bool includeXmlHeader = true)
        {
            if (html == null)
            {
                return null;
            }

            html = html.Trim();

            // Disabling this HACK:
            // It seemed to mess up, when there might also be an HTML header first and only then an HTML tag.
            // The description of the hack below seems to explain it might not be needed anymore

            /*
            bool hadHtmlTag = html.StartsWith(HTML_OPEN_TAG) && html.EndsWith(HTML_CLOSE_TAG);

            if (!hadHtmlTag)
            {
                // HACK:
                // SgmlReader 1.8.11 at one point messed up with a crash, while adding a root tag helped.
                // (An older version 1.7 not available on NuGet did not have that problem.)
                // (The newer version 1.8.11 did not understand a non-closing <br> enclosed in a <p>, 
                // so... switched back to 1.7)
                html = $"{HTML_OPEN_TAG}{html}{HTML_CLOSE_TAG}";
            }
            */

            using (var stringReader = new StringReader(html))
            {
                using (var sgmlReader = new SgmlReader { DocType = "HTML", InputStream = stringReader })
                {
                    using (var stringWriter = new StringWriter())
                    {
                        using (var xmlTextWriter = new XmlTextWriter(stringWriter))
                        {
                            if (includeXmlHeader)
                            {
                                xmlTextWriter.WriteStartDocument(); // Write XML header
                            }

                            sgmlReader.Read();

                            while (!sgmlReader.EOF)
                            {
                                xmlTextWriter.WriteNode(sgmlReader, true);
                            }
                        }

                        string xml = stringWriter.ToString();

                        // Disabling this HACK:
                        /*
                        // HACK:
                        if (!hadHtmlTag)
                        {
                            xml = xml.TrimFirst(HTML_OPEN_TAG).TrimLast(HTML_CLOSE_TAG);
                        }
                        */

                        return xml;
                    }
                }
            }
        }
    }
}
