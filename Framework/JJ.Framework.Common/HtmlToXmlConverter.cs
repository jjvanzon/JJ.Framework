using Sgml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace JJ.Framework.Common
{
    public static class HtmlToXmlConverter
    {
        public static string Convert(string html)
        {
            using (StringReader stringReader = new StringReader(html))
            {
                using (SgmlReader sgmlReader = new SgmlReader { DocType = "HTML", InputStream = stringReader })
                {
                    using (StringWriter stringWriter = new StringWriter())
                    {
                        using (XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter))
                        {
                            xmlTextWriter.WriteStartDocument(); // Write XML header

                            sgmlReader.Read();

                            while (!sgmlReader.EOF)
                            {
                                xmlTextWriter.WriteNode(sgmlReader, true);
                            }
                        }

                        return stringWriter.ToString();
                    }
                }
            }
        }
    }
}