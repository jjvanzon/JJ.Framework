using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Web.Tests
{
    [TestClass]
    public class UrlBuilderTests
    {
        [TestMethod]
        public void Test_UrlBuilder_BuildUrl()
        {
            // Success also depends on UrlParser.

            string[] inputs =
            {
                "http%26://www.jj.com%26/doc%26?param1%26=1%26&param2%26=2%26",
                "http://www.jj.com/doc?param1=1&param2=2",
                "http://www.jj.com?param1=1&param2=2",
                "www.jj.com",
                "www.jj.com?param1=1&param2=2",
                "www.jj.com?param1=1",
                "?param1=1",
            };

            foreach (string input in inputs)
            {
                var parser = new UrlParser();
                UrlInfo info = parser.Parse(input);
                string output = UrlBuilder.BuildUrl(info);
                Assert.AreEqual(input, output);
            }
        }

        [TestMethod]
        public void Test_UrlBuilder_BuildQueryString()
        {
            // Success also depends on UrlParser.

            string[] inputs =
            {
                "param1%26=%26",
                "param1=1&param2=2",
                "param1=1",
            };

            foreach (string input in inputs)
            {
                var parser = new UrlParser();
                IList<UrlParameterInfo> infos = parser.ParseQueryString(input);
                string output = UrlBuilder.BuildQueryString(infos);
                Assert.AreEqual(input, output);
            }
        }

        [TestMethod]
        public void Test_UrlBuilder_BuildParameter()
        {
            var info = new UrlParameterInfo { Name = "param1&", Value = "&" };
            string output = UrlBuilder.BuildParameter(info);
            Assert.AreEqual("param1%26=%26", output);
        }
    }
}
