using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.HtmlToXml.Tests
{
    [TestClass]
    public class HtmlToXmlConverterTests
    {
        [TestMethod]
        public void Test_HtmlToXmlConverter()
        {
            const string input = @"<input type=""text"" disabled /> <p>Hello<crap bla tralala /> <br> Stuff after br </p> <p>Thingy";
            const string expected = @"<input type=""text"" disabled="""" /> <p>Hello<crap bla="""" tralala="""" /> <br /> Stuff after br </p> <p>Thingy</p>";
            string actual = HtmlToXmlConverter.Convert(input, false);
            Assert.AreEqual(expected, actual);
        }
    }
}