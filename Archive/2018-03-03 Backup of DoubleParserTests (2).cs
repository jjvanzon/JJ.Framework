//using System;
//using System.Globalization;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace JJ.Framework.Conversion.Tests
//{
//	[TestClass]
//	public class DoubleParserTests : NumericParserTestsBase<double>
//	{
//		protected override string NormalNumberStringEnUS => "1.11E1";
//		protected override string NormalNumberStringNlNL => "1,11E1";
//		protected override double NormalNumber => 11.1;

//		// Can't seem to think of number styles that double conversion wouldn't normally take.
//		protected override NumberStyles SpecialNumberStyles => NumberStyles.Any;
//		protected override string NumberWithSpecialNumberStylesStringEnUS => "1.11E1";
//		protected override string NumberWithSpecialNumberStylesStringNlNL => "1,11E1";
//		protected override double NumberWithSpecialNumberStyles => 11.1;

//		protected override bool TryParse(string str, out double? result) => DoubleParser.TryParse(str, out result);
//		protected override bool TryParse(string str, NumberStyles styles, out double? result) => DoubleParser.TryParse(str, styles, out result);
//		protected override bool TryParse(string str, IFormatProvider provider, out double? result) => DoubleParser.TryParse(str, provider, out result);
//		protected override bool TryParse(string str, NumberStyles styles, IFormatProvider provider, out double? result) => DoubleParser.TryParse(str, styles, provider, out result);
//		protected override double? ParseNullable(string str) => DoubleParser.ParseNullable(str);
//		protected override double? ParseNullable(string str, NumberStyles styles) => DoubleParser.ParseNullable(str, styles);
//		protected override double? ParseNullable(string str, IFormatProvider provider) => DoubleParser.ParseNullable(str, provider);
//		protected override double? ParseNullable(string str, NumberStyles styles, IFormatProvider provider) => DoubleParser.ParseNullable(str, styles, provider);

//		[TestMethod]
//		public void Test_DoubleParser_TryParse_Nullable_HasValue() => Test_TryParse_Nullable_HasValue();

//		[TestMethod]
//		public void Test_DoubleParser_TryParse_Nullable_IsNull() => Test_TryParse_Nullable_IsNull();

//		[TestMethod]
//		public void Test_DoubleParser_TryParse_Nullable_HasValue_WithNumberStyles() => Test_TryParse_Nullable_HasValue_WithNumberStyles();

//		[TestMethod]
//		public void Test_DoubleParser_TryParse_Nullable_IsNull_WithNumberStyles() => Test_TryParse_Nullable_IsNull_WithNumberStyles();

//		[TestMethod]
//		public void Test_DoubleParser_TryParse_Nullable_HasValue_WithFormatProvider() => Test_TryParse_Nullable_HasValue_WithFormatProvider();

//		[TestMethod]
//		public void Test_DoubleParser_TryParse_Nullable_IsNull_WithFormatProvider() => Test_TryParse_Nullable_IsNull_WithFormatProvider();

//		[TestMethod]
//		public void Test_DoubleParser_TryParse_Nullable_HasValue_WithNumberStyles_AndFormatProvider() =>
//			Test_TryParse_Nullable_HasValue_WithNumberStyles_AndFormatProvider();

//		[TestMethod]
//		public void Test_DoubleParser_TryParse_Nullable_IsNull_WithNumberStyles_AndFormatProvider() =>
//			Test_TryParse_Nullable_IsNull_WithNumberStyles_AndFormatProvider();

//		[TestMethod]
//		public void Test_DoubleParser_ParseNullable_HasValue() => Test_ParseNullable_HasValue();

//		[TestMethod]
//		public void Test_DoubleParser_ParseNullable_IsNull() => Test_ParseNullable_IsNull();

//		[TestMethod]
//		public void Test_DoubleParser_ParseNullable_HasValue_WithNumberStyles() => Test_ParseNullable_HasValue_WithNumberStyles();

//		[TestMethod]
//		public void Test_DoubleParser_ParseNullable_IsNull_WithNumberStyles() => Test_ParseNullable_IsNull_WithNumberStyles();

//		[TestMethod]
//		public void Test_DoubleParser_ParseNullable_HasValue_WithFormatProvider() => Test_ParseNullable_HasValue_WithFormatProvider();

//		[TestMethod]
//		public void Test_DoubleParser_ParseNullable_IsNull_WithFormatProvider() => Test_ParseNullable_IsNull_WithFormatProvider();

//		[TestMethod]
//		public void Test_DoubleParser_ParseNullable_HasValue_WithNumberStyles_WithFormatProvider() =>
//			Test_ParseNullable_HasValue_WithNumberStyles_WithFormatProvider();

//		[TestMethod]
//		public void Test_DoubleParser_ParseNullable_IsNull_WithNumberStyles_WithFormatProvider() =>
//			Test_ParseNullable_IsNull_WithNumberStyles_WithFormatProvider();
//	}
//}