using System.IO;
using System.Xml;
using Sgml;

namespace JJ.Framework.Xml
{
	public static class HtmlToXmlConverter
	{
		public static string Convert(string html)
		{
			using (var stringReader = new StringReader(html))
			{
				using (var sgmlReader = new SgmlReader { DocType = "HTML", InputStream = stringReader })
				{
					using (var stringWriter = new StringWriter())
					{
						using (var xmlTextWriter = new XmlTextWriter(stringWriter))
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