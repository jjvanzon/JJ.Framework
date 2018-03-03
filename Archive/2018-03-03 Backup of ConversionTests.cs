//using System;
//using System.Globalization;
//using JJ.Framework.Common;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace JJ.Framework.Conversion.Tests
//{
//	[TestClass]
//	public class ConversionTests
//	{
//		[TestMethod]
//		public void Test_Int32Parser_TryParse_Nullable_HasValue()
//		{
//			WithCultureSwitch("en-US", () => Int32Parser.TryParse("1", out int? result));
//		}

//		[TestMethod]
//		public void Test_Int32Parser_TryParse_Nullable_IsNull()
//		{
//			WithCultureSwitch("en-US", () => Int32Parser.TryParse("1", out int? result));
//		}

//		[TestMethod]
//		public void Test_Int32Parser_TryParse_Nullable_HasValue_WithNumberStyles()
//		{
//			WithCultureSwitch("en-US", () => Int32Parser.TryParse("1.1", NumberStyles.Any, out int? result));
//		}

//		[TestMethod]
//		public void Test_Int32Parser_TryParse_Nullable_IsNull_WithNumberStyles()
//		{
//			WithCultureSwitch("en-US", () => Int32Parser.TryParse("1.1", NumberStyles.Any, out int? result));
//		}

//		[TestMethod]
//		public void Test_Int32Parser_TryParse_Nullable_HasValue_WithFormatProvider()
//		{
//			WithCultureSwitch("en-US", () => Int32Parser.TryParse("1", new CultureInfo("nl-NL"), out int? result));
//		}

//		[TestMethod]
//		public void Test_Int32Parser_TryParse_Nullable_IsNull_WithFormatProvider()
//		{
//			WithCultureSwitch("en-US", () => Int32Parser.TryParse("", new CultureInfo("nl-NL"), out int? result));
//		}

//		[TestMethod]
//		public void Test_Int32Parser_TryParse_Nullable_HasValue_WithNumberStyles_AndFormatProvider()
//		{
//			WithCultureSwitch("en-US", () => Int32Parser.TryParse("1,1", NumberStyles.Any, new CultureInfo("nl-NL"), out int? result));
//		}

//		[TestMethod]
//		public void Test_Int32Parser_TryParse_Nullable_IsNull_WithNumberStyles_AndFormatProvider()
//		{
//			WithCultureSwitch("en-US", () => Int32Parser.TryParse("1,1", NumberStyles.Any, new CultureInfo("nl-NL"), out int? result));
//		}

//		[TestMethod]
//		public void Test_Int32Parser_ParseNullable()
//		{
//			WithCultureSwitch("en-US", () =>
//			{
//				int? result = Int32Parser.ParseNullable("1");
//			});
//		}

//		[TestMethod]
//		public void Test_Int32Parser_ParseNullable_WithNumberStyles()
//		{
//			WithCultureSwitch(
//				"en-US",
//				() =>
//				{
//					int? result = Int32Parser.ParseNullable("1.1", NumberStyles.Any);
//				});
//		}

//		[TestMethod]
//		public void Test_Int32Parser_ParseNullable_WithFormatProvider()
//		{
//			WithCultureSwitch("en-US", () =>
//			{
//				int? result = Int32Parser.ParseNullable("1", new CultureInfo("nl-NL"));
//			});
//		}

//		[TestMethod]
//		public void Test_Int32Parser_ParseNullable_WithNumberStyles_WithFormatProvider()
//		{
//			WithCultureSwitch("en-US", () =>
//			{
//				int? result = Int32Parser.ParseNullable("1,1", NumberStyles.Any, new CultureInfo("nl-NL"));
//			});
//		}

//		private void WithCultureSwitch(string cultureName, Action action)
//		{
//			CultureInfo originalCulture = CultureHelper.GetCurrentCulture();
//			try
//			{
//				CultureHelper.SetCurrentCultureName(cultureName);

//				action();
//			}
//			finally
//			{
//				CultureHelper.SetCurrentCulture(originalCulture);
//			}
//		}
//	}
//}
