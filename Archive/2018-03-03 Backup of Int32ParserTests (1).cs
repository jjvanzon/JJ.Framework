//using System;
//using System.Globalization;
//using JJ.Framework.Common;
//using JJ.Framework.Testing;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace JJ.Framework.Conversion.Tests
//{
//	[TestClass]
//	public class Int32ParserTests
//	{
//		private static readonly CultureInfo _nlNLCulture = new CultureInfo("nl-NL");
//		private static readonly CultureInfo _enUSCulture = new CultureInfo("en-US");

//		[TestMethod]
//		public void Test_Int32Parser_TryParse_Nullable_HasValue()
//		{
//			WithEnUSCulture(() =>
//			{
//				Int32Parser.TryParse("1", out int? result);

//				AssertHelper.IsNotNull(() => result);
//				AssertHelper.AreEqual(1, () => result);
//			});
//		}

//		[TestMethod]
//		public void Test_Int32Parser_TryParse_Nullable_IsNull()
//		{
//			WithEnUSCulture(() =>
//			{
//				Int32Parser.TryParse(" ", out int? result);

//				AssertHelper.IsNull(() => result);
//			});
//		}

//		[TestMethod]
//		public void Test_Int32Parser_TryParse_Nullable_HasValue_WithNumberStyles()
//		{
//			WithEnUSCulture(() =>
//			{
//				Int32Parser.TryParse("1E1", NumberStyles.Any, out int? result);

//				AssertHelper.IsNotNull(() => result);
//				AssertHelper.AreEqual(10, () => result);
//			});
//		}

//		[TestMethod]
//		public void Test_Int32Parser_TryParse_Nullable_IsNull_WithNumberStyles()
//		{
//			WithEnUSCulture(() =>
//			{
//				Int32Parser.TryParse(" ", NumberStyles.Any, out int? result);

//				AssertHelper.IsNull(() => result);
//			});
//		}

//		[TestMethod]
//		public void Test_Int32Parser_TryParse_Nullable_HasValue_WithFormatProvider()
//		{
//			WithEnUSCulture(() =>
//			{
//				Int32Parser.TryParse("1", _nlNLCulture, out int? result);

//				AssertHelper.IsNotNull(() => result);
//				AssertHelper.AreEqual(1, () => result);
//			});
//		}

//		[TestMethod]
//		public void Test_Int32Parser_TryParse_Nullable_IsNull_WithFormatProvider()
//		{
//			WithEnUSCulture(() =>
//			{
//				Int32Parser.TryParse(" ", _nlNLCulture, out int? result);

//				AssertHelper.IsNull(() => result);
//			});
//		}

//		[TestMethod]
//		public void Test_Int32Parser_TryParse_Nullable_HasValue_WithNumberStyles_AndFormatProvider()
//		{
//			WithEnUSCulture(() =>
//			{
//				Int32Parser.TryParse("1E1", NumberStyles.Any, _nlNLCulture, out int? result);

//				AssertHelper.IsNotNull(() => result);
//				AssertHelper.AreEqual(10, () => result);
//			});
//		}

//		[TestMethod]
//		public void Test_Int32Parser_TryParse_Nullable_IsNull_WithNumberStyles_AndFormatProvider()
//		{
//			WithEnUSCulture(() =>
//			{
//				Int32Parser.TryParse(" ", NumberStyles.Any, _nlNLCulture, out int? result);

//				AssertHelper.IsNull(() => result);
//			});
//		}

//		[TestMethod]
//		public void Test_Int32Parser_ParseNullable_HasValue()
//		{
//			WithEnUSCulture(() =>
//			{
//				int? result = Int32Parser.ParseNullable("1");

//				AssertHelper.IsNotNull(() => result);
//				AssertHelper.AreEqual(1, () => result);
//			});
//		}

//		[TestMethod]
//		public void Test_Int32Parser_ParseNullable_IsNull()
//		{
//			WithEnUSCulture(() =>
//			{
//				int? result = Int32Parser.ParseNullable(" ");

//				AssertHelper.IsNull(() => result);
//			});
//		}

//		[TestMethod]
//		public void Test_Int32Parser_ParseNullable_HasValue_WithNumberStyles()
//		{
//			WithEnUSCulture(
//				() =>
//				{
//					int? result = Int32Parser.ParseNullable("1E1", NumberStyles.Any);

//					AssertHelper.IsNotNull(() => result);
//					AssertHelper.AreEqual(10, () => result);
//				});
//		}

//		[TestMethod]
//		public void Test_Int32Parser_ParseNullable_IsNull_WithNumberStyles()
//		{
//			WithEnUSCulture(
//				() =>
//				{
//					int? result = Int32Parser.ParseNullable(" ", NumberStyles.Any);

//					AssertHelper.IsNull(() => result);
//				});
//		}

//		[TestMethod]
//		public void Test_Int32Parser_ParseNullable_HasValue_WithFormatProvider()
//		{
//			WithEnUSCulture(() =>
//			{
//				int? result = Int32Parser.ParseNullable("1", _nlNLCulture);

//				AssertHelper.IsNotNull(() => result);
//				AssertHelper.AreEqual(1, () => result);
//			});
//		}

//		[TestMethod]
//		public void Test_Int32Parser_ParseNullable_IsNull_WithFormatProvider()
//		{
//			WithEnUSCulture(() =>
//			{
//				int? result = Int32Parser.ParseNullable(" ", _nlNLCulture);

//				AssertHelper.IsNull(() => result);
//			});
//		}

//		[TestMethod]
//		public void Test_Int32Parser_ParseNullable_HasValue_WithNumberStyles_WithFormatProvider()
//		{
//			WithEnUSCulture(() =>
//			{
//				int? result = Int32Parser.ParseNullable("1E1", NumberStyles.Any, _nlNLCulture);

//				AssertHelper.IsNotNull(() => result);
//				AssertHelper.AreEqual(10, () => result);
//			});
//		}

//		[TestMethod]
//		public void Test_Int32Parser_ParseNullable_IsNull_WithNumberStyles_WithFormatProvider()
//		{
//			WithEnUSCulture(() =>
//			{
//				int? result = Int32Parser.ParseNullable(" ", NumberStyles.Any, _nlNLCulture);

//				AssertHelper.IsNull(() => result);
//			});
//		}

//		private void WithEnUSCulture(Action action)
//		{
//			CultureInfo originalCulture = CultureHelper.GetCurrentCulture();
//			try
//			{
//				CultureHelper.SetCurrentCulture(_enUSCulture);

//				action();
//			}
//			finally
//			{
//				CultureHelper.SetCurrentCulture(originalCulture);
//			}
//		}
//	}
//}
