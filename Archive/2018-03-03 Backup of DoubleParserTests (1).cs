//using System;
//using System.Globalization;
//using JJ.Framework.Common;
//using JJ.Framework.Testing;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace JJ.Framework.Conversion.Tests
//{
//	[TestClass]
//	public class DoubleParserTests
//	{
//		private const string WHITE_SPACE = " ";

//		private static readonly CultureInfo _nlNLCulture = new CultureInfo("nl-NL");
//		private static readonly CultureInfo _enUSCulture = new CultureInfo("en-US");

//		private string NormalNumberStringEnUS => "1.11E1";
//		private string NormalNumberStringNlNL => "1,11E1";
//		private decimal NormalNumber => 11.1m;

//		// Can't seem to think of number styles that double conversion woldn't normally take.
//		private NumberStyles SpecialNumberStyles => NumberStyles.Any;
//		private string NumberWithSpecialNumberStylesStringEnUS => "1.11E1";
//		private string NumberWithSpecialNumberStylesStringNlNL => "1,11E1";
//		private decimal NumberWithSpecialNumberStyles => 11.1m;

//		[TestMethod]
//		public void Test_DoubleParser_TryParse_Nullable_HasValue()
//		{
//			WithEnUSCulture(() =>
//			{
//				DoubleParser.TryParse(NormalNumberStringEnUS, out double? result);

//				AssertHelper.IsNotNull(() => result);
//				AssertHelper.AreEqual((double)NormalNumber, () => result);
//			});
//		}

//		[TestMethod]
//		public void Test_DoubleParser_TryParse_Nullable_IsNull()
//		{
//			WithEnUSCulture(() =>
//			{
//				DoubleParser.TryParse(WHITE_SPACE, out double? result);

//				AssertHelper.IsNull(() => result);
//			});
//		}

//		[TestMethod]
//		public void Test_DoubleParser_TryParse_Nullable_HasValue_WithNumberStyles()
//		{
//			WithEnUSCulture(() =>
//			{
//				DoubleParser.TryParse(NumberWithSpecialNumberStylesStringEnUS, SpecialNumberStyles, out double? result);

//				AssertHelper.IsNotNull(() => result);
//				AssertHelper.AreEqual((double)NumberWithSpecialNumberStyles, () => result);
//			});
//		}

//		[TestMethod]
//		public void Test_DoubleParser_TryParse_Nullable_IsNull_WithNumberStyles()
//		{
//			WithEnUSCulture(() =>
//			{
//				DoubleParser.TryParse(WHITE_SPACE, SpecialNumberStyles, out double? result);

//				AssertHelper.IsNull(() => result);
//			});
//		}

//		[TestMethod]
//		public void Test_DoubleParser_TryParse_Nullable_HasValue_WithFormatProvider()
//		{
//			WithEnUSCulture(() =>
//			{
//				DoubleParser.TryParse(NormalNumberStringNlNL, _nlNLCulture, out double? result);

//				AssertHelper.IsNotNull(() => result);
//				AssertHelper.AreEqual((double)NormalNumber, () => result);
//			});
//		}

//		[TestMethod]
//		public void Test_DoubleParser_TryParse_Nullable_IsNull_WithFormatProvider()
//		{
//			WithEnUSCulture(() =>
//			{
//				DoubleParser.TryParse(WHITE_SPACE, _nlNLCulture, out double? result);

//				AssertHelper.IsNull(() => result);
//			});
//		}

//		[TestMethod]
//		public void Test_DoubleParser_TryParse_Nullable_HasValue_WithNumberStyles_AndFormatProvider()
//		{
//			WithEnUSCulture(() =>
//			{
//				DoubleParser.TryParse(NumberWithSpecialNumberStylesStringNlNL, SpecialNumberStyles, _nlNLCulture, out double? result);

//				AssertHelper.IsNotNull(() => result);
//				AssertHelper.AreEqual((double)NumberWithSpecialNumberStyles, () => result);
//			});
//		}

//		[TestMethod]
//		public void Test_DoubleParser_TryParse_Nullable_IsNull_WithNumberStyles_AndFormatProvider()
//		{
//			WithEnUSCulture(() =>
//			{
//				DoubleParser.TryParse(WHITE_SPACE, SpecialNumberStyles, _nlNLCulture, out double? result);

//				AssertHelper.IsNull(() => result);
//			});
//		}

//		[TestMethod]
//		public void Test_DoubleParser_ParseNullable_HasValue()
//		{
//			WithEnUSCulture(() =>
//			{
//				double? result = DoubleParser.ParseNullable(NormalNumberStringEnUS);

//				AssertHelper.IsNotNull(() => result);
//				AssertHelper.AreEqual((double)NormalNumber, () => result);
//			});
//		}

//		[TestMethod]
//		public void Test_DoubleParser_ParseNullable_IsNull()
//		{
//			WithEnUSCulture(() =>
//			{
//				double? result = DoubleParser.ParseNullable(WHITE_SPACE);

//				AssertHelper.IsNull(() => result);
//			});
//		}

//		[TestMethod]
//		public void Test_DoubleParser_ParseNullable_HasValue_WithNumberStyles()
//		{
//			WithEnUSCulture(
//				() =>
//				{
//					double? result = DoubleParser.ParseNullable(NumberWithSpecialNumberStylesStringEnUS, SpecialNumberStyles);

//					AssertHelper.IsNotNull(() => result);
//					AssertHelper.AreEqual((double)NumberWithSpecialNumberStyles, () => result);
//				});
//		}

//		[TestMethod]
//		public void Test_DoubleParser_ParseNullable_IsNull_WithNumberStyles()
//		{
//			WithEnUSCulture(
//				() =>
//				{
//					double? result = DoubleParser.ParseNullable(WHITE_SPACE, SpecialNumberStyles);

//					AssertHelper.IsNull(() => result);
//				});
//		}

//		[TestMethod]
//		public void Test_DoubleParser_ParseNullable_HasValue_WithFormatProvider()
//		{
//			WithEnUSCulture(() =>
//			{
//				double? result = DoubleParser.ParseNullable(NormalNumberStringNlNL, _nlNLCulture);

//				AssertHelper.IsNotNull(() => result);
//				AssertHelper.AreEqual((double)NormalNumber, () => result);
//			});
//		}

//		[TestMethod]
//		public void Test_DoubleParser_ParseNullable_IsNull_WithFormatProvider()
//		{
//			WithEnUSCulture(() =>
//			{
//				double? result = DoubleParser.ParseNullable(WHITE_SPACE, _nlNLCulture);

//				AssertHelper.IsNull(() => result);
//			});
//		}

//		[TestMethod]
//		public void Test_DoubleParser_ParseNullable_HasValue_WithNumberStyles_WithFormatProvider()
//		{
//			WithEnUSCulture(() =>
//			{
//				double? result = DoubleParser.ParseNullable(NumberWithSpecialNumberStylesStringNlNL, SpecialNumberStyles, _nlNLCulture);

//				AssertHelper.IsNotNull(() => result);
//				AssertHelper.AreEqual((double)NumberWithSpecialNumberStyles, () => result);
//			});
//		}

//		[TestMethod]
//		public void Test_DoubleParser_ParseNullable_IsNull_WithNumberStyles_WithFormatProvider()
//		{
//			WithEnUSCulture(() =>
//			{
//				double? result = DoubleParser.ParseNullable(WHITE_SPACE, SpecialNumberStyles, _nlNLCulture);

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
