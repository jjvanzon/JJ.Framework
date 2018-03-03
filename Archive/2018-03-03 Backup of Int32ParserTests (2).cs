//using System;
//using System.Globalization;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace JJ.Framework.Conversion.Tests
//{
//	[TestClass]
//	public class Int32ParserTests : NumericParserTestsBase<int>
//	{
//		// Can't think of an integer number notation that is normal in Dutch, that is not normal in English.

//		protected override string NormalNumberStringEnUS => "1";
//		protected override string NormalNumberStringNlNL => "1"; 
//		protected override int NormalNumber => 1;

//		protected override NumberStyles SpecialNumberStyles => NumberStyles.Any;
//		protected override string NumberWithSpecialNumberStylesStringEnUS => "1E1";
//		protected override string NumberWithSpecialNumberStylesStringNlNL => "1E1";
//		protected override int NumberWithSpecialNumberStyles => 10;

//		protected override bool TryParse(string str, out int? result) => Int32Parser.TryParse(str, out result);
//		protected override bool TryParse(string str, NumberStyles styles, out int? result) => Int32Parser.TryParse(str, styles, out result);
//		protected override bool TryParse(string str, IFormatProvider provider, out int? result) => Int32Parser.TryParse(str, provider, out result);
//		protected override bool TryParse(string str, NumberStyles styles, IFormatProvider provider, out int? result) => Int32Parser.TryParse(str, styles, provider, out result);
//		protected override int? ParseNullable(string str) => Int32Parser.ParseNullable(str);
//		protected override int? ParseNullable(string str, NumberStyles styles) => Int32Parser.ParseNullable(str, styles);
//		protected override int? ParseNullable(string str, IFormatProvider provider) => Int32Parser.ParseNullable(str, provider);
//		protected override int? ParseNullable(string str, NumberStyles styles, IFormatProvider provider) => Int32Parser.ParseNullable(str, styles, provider);

//		[TestMethod]
//		public void Test_StringParser_TryParse_Nullable_HasValue() => Test_TryParse_Nullable_HasValue();

//		[TestMethod]
//		public void Test_StringParser_TryParse_Nullable_IsNull() => Test_TryParse_Nullable_IsNull();

//		[TestMethod]
//		public void Test_StringParser_TryParse_Nullable_HasValue_WithNumberStyles() => Test_TryParse_Nullable_HasValue_WithNumberStyles();

//		[TestMethod]
//		public void Test_StringParser_TryParse_Nullable_IsNull_WithNumberStyles() => Test_TryParse_Nullable_IsNull_WithNumberStyles();

//		[TestMethod]
//		public void Test_StringParser_TryParse_Nullable_HasValue_WithFormatProvider() => Test_TryParse_Nullable_HasValue_WithFormatProvider();

//		[TestMethod]
//		public void Test_StringParser_TryParse_Nullable_IsNull_WithFormatProvider() => Test_TryParse_Nullable_IsNull_WithFormatProvider();

//		[TestMethod]
//		public void Test_StringParser_TryParse_Nullable_HasValue_WithNumberStyles_AndFormatProvider() =>
//			Test_TryParse_Nullable_HasValue_WithNumberStyles_AndFormatProvider();

//		[TestMethod]
//		public void Test_StringParser_TryParse_Nullable_IsNull_WithNumberStyles_AndFormatProvider() =>
//			Test_TryParse_Nullable_IsNull_WithNumberStyles_AndFormatProvider();

//		[TestMethod]
//		public void Test_StringParser_ParseNullable_HasValue() => Test_ParseNullable_HasValue();

//		[TestMethod]
//		public void Test_StringParser_ParseNullable_IsNull() => Test_ParseNullable_IsNull();

//		[TestMethod]
//		public void Test_StringParser_ParseNullable_HasValue_WithNumberStyles() => Test_ParseNullable_HasValue_WithNumberStyles();

//		[TestMethod]
//		public void Test_StringParser_ParseNullable_IsNull_WithNumberStyles() => Test_ParseNullable_IsNull_WithNumberStyles();

//		[TestMethod]
//		public void Test_StringParser_ParseNullable_HasValue_WithFormatProvider() => Test_ParseNullable_HasValue_WithFormatProvider();

//		[TestMethod]
//		public void Test_StringParser_ParseNullable_IsNull_WithFormatProvider() => Test_ParseNullable_IsNull_WithFormatProvider();

//		[TestMethod]
//		public void Test_StringParser_ParseNullable_HasValue_WithNumberStyles_WithFormatProvider() =>
//			Test_ParseNullable_HasValue_WithNumberStyles_WithFormatProvider();

//		[TestMethod]
//		public void Test_StringParser_ParseNullable_IsNull_WithNumberStyles_WithFormatProvider() =>
//			Test_ParseNullable_IsNull_WithNumberStyles_WithFormatProvider();
//	}
//}
