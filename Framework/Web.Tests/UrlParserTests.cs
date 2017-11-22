using Microsoft.VisualStudio.TestTools.UnitTesting;
using JJ.Framework.Testing;

namespace JJ.Framework.Web.Tests
{
	[TestClass]
	public class UrlParserTests
	{
		[TestMethod]
		public void Test_UrlParser_Protocol_MultiplePathElements_Parameters()
		{
			string input = "http://www.jj.com/doc?param1=1&param2=2";

			var urlParser = new UrlParser();
			UrlInfo urlInfo = urlParser.Parse(input);

			AssertHelper.IsNotNull(() => urlInfo.Protocol);
			AssertHelper.AreEqual("http", () => urlInfo.Protocol);

			AssertHelper.AreEqual(2, () => urlInfo.PathElements.Count);
			AssertHelper.AreEqual("www.jj.com", () => urlInfo.PathElements[0]);
			AssertHelper.AreEqual("doc", () => urlInfo.PathElements[1]);

			AssertHelper.AreEqual(2, () => urlInfo.Parameters.Count);
			AssertHelper.AreEqual("param1", () => urlInfo.Parameters[0].Name);
			AssertHelper.AreEqual("1", () => urlInfo.Parameters[0].Value);
			AssertHelper.AreEqual("param2", () => urlInfo.Parameters[1].Name);
			AssertHelper.AreEqual("2", () => urlInfo.Parameters[1].Value);
		}

		[TestMethod]
		public void Test_UrlParser_Protocol_SinglePathElements_Parameters()
		{
			string input = "http://www.jj.com?param1=1&param2=2";

			var urlParser = new UrlParser();
			UrlInfo urlInfo = urlParser.Parse(input);

			AssertHelper.IsNotNull(() => urlInfo.Protocol);
			AssertHelper.AreEqual("http", () => urlInfo.Protocol);

			AssertHelper.AreEqual(1, () => urlInfo.PathElements.Count);
			AssertHelper.AreEqual("www.jj.com", () => urlInfo.PathElements[0]);

			AssertHelper.AreEqual(2, () => urlInfo.Parameters.Count);
			AssertHelper.AreEqual("param1", () => urlInfo.Parameters[0].Name);
			AssertHelper.AreEqual("1", () => urlInfo.Parameters[0].Value);
			AssertHelper.AreEqual("param2", () => urlInfo.Parameters[1].Name);
			AssertHelper.AreEqual("2", () => urlInfo.Parameters[1].Value);
		}

		[TestMethod]
		public void Test_UrlParser_NoProtocol_SinglePathElements_NoParameters()
		{
			string input = "www.jj.com";

			var urlParser = new UrlParser();
			UrlInfo urlInfo = urlParser.Parse(input);

			AssertHelper.IsNullOrEmpty(() => urlInfo.Protocol);

			AssertHelper.AreEqual(1, () => urlInfo.PathElements.Count);
			AssertHelper.AreEqual("www.jj.com", () => urlInfo.PathElements[0]);

			AssertHelper.AreEqual(0, () => urlInfo.Parameters.Count);
		}

		[TestMethod]
		public void Test_UrlParser_NoProtocol_SinglePathElements_Parameters()
		{
			string input = "www.jj.com?param1=1&param2=2";

			var urlParser = new UrlParser();
			UrlInfo urlInfo = urlParser.Parse(input);

			AssertHelper.IsNullOrEmpty(() => urlInfo.Protocol);

			AssertHelper.AreEqual(1, () => urlInfo.PathElements.Count);
			AssertHelper.AreEqual("www.jj.com", () => urlInfo.PathElements[0]);

			AssertHelper.AreEqual(2, () => urlInfo.Parameters.Count);
			AssertHelper.AreEqual("param1", () => urlInfo.Parameters[0].Name);
			AssertHelper.AreEqual("1", () => urlInfo.Parameters[0].Value);
			AssertHelper.AreEqual("param2", () => urlInfo.Parameters[1].Name);
			AssertHelper.AreEqual("2", () => urlInfo.Parameters[1].Value);
		}

		[TestMethod]
		public void Test_UrlParser_NoProtocol_SinglePathElements_NullParameter()
		{
			string input = "www.jj.com?param1=";

			var urlParser = new UrlParser();
			UrlInfo urlInfo = urlParser.Parse(input);

			AssertHelper.IsNullOrEmpty(() => urlInfo.Protocol);

			AssertHelper.AreEqual(1, () => urlInfo.PathElements.Count);
			AssertHelper.AreEqual("www.jj.com", () => urlInfo.PathElements[0]);

			AssertHelper.AreEqual(1, () => urlInfo.Parameters.Count);
			AssertHelper.AreEqual("param1", () => urlInfo.Parameters[0].Name);
			AssertHelper.IsNullOrEmpty(() => urlInfo.Parameters[0].Value);
		}

		[TestMethod]
		public void Test_UrlParser_UrlDecoding()
		{
			string input = "http%26://www.jj.com%26/doc%26?param1%26=1%26&param2%26=2%26";

			var urlParser = new UrlParser();
			UrlInfo urlInfo = urlParser.Parse(input);

			AssertHelper.IsNotNull(() => urlInfo.Protocol);
			AssertHelper.AreEqual("http&", () => urlInfo.Protocol);

			AssertHelper.AreEqual(2, () => urlInfo.PathElements.Count);
			AssertHelper.AreEqual("www.jj.com&", () => urlInfo.PathElements[0]);
			AssertHelper.AreEqual("doc&", () => urlInfo.PathElements[1]);

			AssertHelper.AreEqual(2, () => urlInfo.Parameters.Count);
			AssertHelper.AreEqual("param1&", () => urlInfo.Parameters[0].Name);
			AssertHelper.AreEqual("1&", () => urlInfo.Parameters[0].Value);
			AssertHelper.AreEqual("param2&", () => urlInfo.Parameters[1].Name);
			AssertHelper.AreEqual("2&", () => urlInfo.Parameters[1].Value);
		}

		[TestMethod]
		public void Test_UrlParser_NoException_RepeatedAmpersands()
		{
			var urlParser = new UrlParser();
			string input = "www.jj.com?param1=1&&param2=2&&";
			UrlInfo urlInfo = urlParser.Parse(input);

			AssertHelper.AreEqual(2, () => urlInfo.Parameters.Count);
			AssertHelper.AreEqual("param1", () => urlInfo.Parameters[0].Name);
			AssertHelper.AreEqual("1", () => urlInfo.Parameters[0].Value);
			AssertHelper.AreEqual("param2", () => urlInfo.Parameters[1].Name);
			AssertHelper.AreEqual("2", () => urlInfo.Parameters[1].Value);
		}

		// Exception tests

		[TestMethod]
		public void Test_UrlParser_Exception_UrlNullOrEmpty()
		{
			var urlParser = new UrlParser();
			AssertHelper.ThrowsException(() => urlParser.Parse(null));
			AssertHelper.ThrowsException(() => urlParser.Parse(""));
		}

		[TestMethod]
		public void Test_UrlParser_Exception_MoreThanOneColon()
		{
			var urlParser = new UrlParser();
			string input = "http://http://";
			AssertHelper.ThrowsException(() => urlParser.Parse(input));
		}

		[TestMethod]
		public void Test_UrlParser_Exception_MoreThanOneQuestionMark()
		{
			var urlParser = new UrlParser();
			string input = "www.jj.com?param1=1?param2=2";
			AssertHelper.ThrowsException(() => urlParser.Parse(input));
		}

		[TestMethod]
		public void Test_UrlParser_Exception_Parameter_HasMoreThanOneEqualsSign()
		{
			var urlParser = new UrlParser();
			string input = "www.jj.com?param1==1";
			AssertHelper.ThrowsException(() => urlParser.Parse(input));
		}

		[TestMethod]
		public void Test_UrlParser_Exception_Parameter_HasNoEqualsSign()
		{
			var urlParser = new UrlParser();
			string input = "www.jj.com?param1";
			AssertHelper.ThrowsException(() => urlParser.Parse(input));
		}

		[TestMethod]
		public void Test_UrlParser_Exception_Parameter_HasNoName()
		{
			var urlParser = new UrlParser();
			string input = "www.jj.com?=1";
			AssertHelper.ThrowsException(() => urlParser.Parse(input));
		}
	}
}
