

using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
#pragma warning disable IDE0012 // Simplify Names
// ReSharper disable BuiltInTypeReferenceStyle

namespace JJ.Framework.Conversion.Tests
{
	
		public partial class DecimalParserTests
		{
			protected override bool TryParse(string str, out Decimal? result) 
				=> DecimalParser.TryParse(str, out result);

			protected override bool TryParse(string str, NumberStyles styles, out Decimal? result) 
				=> DecimalParser.TryParse(str, styles, out result);

			protected override bool TryParse(string str, IFormatProvider provider, out Decimal? result) 
				=> DecimalParser.TryParse(str, provider, out result);

			protected override bool TryParse(string str, IFormatProvider provider, out Decimal result) 
				=> DecimalParser.TryParse(str, provider, out result);

			protected override bool TryParse(string str, NumberStyles styles, IFormatProvider provider, out Decimal? result) 
				=> DecimalParser.TryParse(str, styles, provider, out result);

			protected override Decimal? ParseNullable(string str) 
				=> DecimalParser.ParseNullable(str);

			protected override Decimal? ParseNullable(string str, NumberStyles styles) 
				=> DecimalParser.ParseNullable(str, styles);

			protected override Decimal? ParseNullable(string str, IFormatProvider provider) 
				=> DecimalParser.ParseNullable(str, provider);

			protected override Decimal? ParseNullable(string str, NumberStyles styles, IFormatProvider provider) 
				=> DecimalParser.ParseNullable(str, styles, provider);
				
			protected override NumberStyles GetDefaultNumberStyles() => DecimalParser.DEFAULT_NUMBER_STYLES;

			[TestMethod]
			public void Test_DecimalParser_DEFAULT_NUMBER_STYLES() => Test_DEFAULT_NUMBER_STYLES();
				
			[TestMethod]
			public void Test_DecimalParser_TryParse_NotNullable_HasValue_WithFormatProvider() => Test_TryParse_NotNullable_HasValue_WithFormatProvider();
				
			[TestMethod]
			public void Test_DecimalParser_TryParse_NotNullable_IsWhiteSpace_WithFormatProvider() => Test_TryParse_NotNullable_IsWhiteSpace_WithFormatProvider();
				
			[TestMethod]
			public void Test_DecimalParser_TryParse_NotNullable_IsInvalidNumber_WithFormatProvider() => Test_TryParse_NotNullable_IsInvalidNumber_WithFormatProvider();

			[TestMethod]
			public void Test_DecimalParser_TryParse_Nullable_HasValue() => Test_TryParse_Nullable_HasValue();

			[TestMethod]
			public void Test_DecimalParser_TryParse_Nullable_IsNull() => Test_TryParse_Nullable_IsNull();

			[TestMethod]
			public void Test_DecimalParser_TryParse_Nullable_IsInvalid() => Test_TryParse_Nullable_IsInvalid();

			[TestMethod]
			public void Test_DecimalParser_TryParse_Nullable_HasValue_WithNumberStyles() => Test_TryParse_Nullable_HasValue_WithNumberStyles();

			[TestMethod]
			public void Test_DecimalParser_TryParse_Nullable_IsNull_WithNumberStyles() => Test_TryParse_Nullable_IsNull_WithNumberStyles();

			[TestMethod]
			public void Test_DecimalParser_TryParse_Nullable_IsInvalid_WithNumberStyles() => Test_TryParse_Nullable_IsInvalid_WithNumberStyles();

			[TestMethod]
			public void Test_DecimalParser_TryParse_Nullable_HasValue_WithFormatProvider() 
				=> Test_TryParse_Nullable_HasValue_WithFormatProvider();

			[TestMethod]
			public void Test_DecimalParser_TryParse_Nullable_IsNull_WithFormatProvider() 
				=> Test_TryParse_Nullable_IsNull_WithFormatProvider();
				
			[TestMethod]
			public void Test_DecimalParser_TryParse_Nullable_IsInvalid_WithFormatProvider() 
				=> Test_TryParse_Nullable_IsInvalid_WithFormatProvider();

			[TestMethod]
			public void Test_DecimalParser_TryParse_Nullable_HasValue_WithNumberStyles_AndFormatProvider() 
				=> Test_TryParse_Nullable_HasValue_WithNumberStyles_AndFormatProvider();

			[TestMethod]
			public void Test_DecimalParser_TryParse_Nullable_IsNull_WithNumberStyles_AndFormatProvider() 
				=> Test_TryParse_Nullable_IsNull_WithNumberStyles_AndFormatProvider();

			[TestMethod]
			public void Test_DecimalParser_TryParse_Nullable_IsInvalid_WithNumberStyles_AndFormatProvider() 
				=> Test_TryParse_Nullable_IsInvalid_WithNumberStyles_AndFormatProvider();

			[TestMethod]
			public void Test_DecimalParser_ParseNullable_HasValue() => Test_ParseNullable_HasValue();

			[TestMethod]
			public void Test_DecimalParser_ParseNullable_IsNull() => Test_ParseNullable_IsNull();

			[TestMethod]
			public void Test_DecimalParser_ParseNullable_HasValue_WithNumberStyles() => Test_ParseNullable_HasValue_WithNumberStyles();

			[TestMethod]
			public void Test_DecimalParser_ParseNullable_IsNull_WithNumberStyles() => Test_ParseNullable_IsNull_WithNumberStyles();

			[TestMethod]
			public void Test_DecimalParser_ParseNullable_HasValue_WithFormatProvider() => Test_ParseNullable_HasValue_WithFormatProvider();

			[TestMethod]
			public void Test_DecimalParser_ParseNullable_IsNull_WithFormatProvider() => Test_ParseNullable_IsNull_WithFormatProvider();

			[TestMethod]
			public void Test_DecimalParser_ParseNullable_HasValue_WithNumberStyles_WithFormatProvider() 
				=> Test_ParseNullable_HasValue_WithNumberStyles_WithFormatProvider();

			[TestMethod]
			public void Test_DecimalParser_ParseNullable_IsNull_WithNumberStyles_WithFormatProvider() 
				=> Test_ParseNullable_IsNull_WithNumberStyles_WithFormatProvider();
		}

	
		public partial class DoubleParserTests
		{
			protected override bool TryParse(string str, out Double? result) 
				=> DoubleParser.TryParse(str, out result);

			protected override bool TryParse(string str, NumberStyles styles, out Double? result) 
				=> DoubleParser.TryParse(str, styles, out result);

			protected override bool TryParse(string str, IFormatProvider provider, out Double? result) 
				=> DoubleParser.TryParse(str, provider, out result);

			protected override bool TryParse(string str, IFormatProvider provider, out Double result) 
				=> DoubleParser.TryParse(str, provider, out result);

			protected override bool TryParse(string str, NumberStyles styles, IFormatProvider provider, out Double? result) 
				=> DoubleParser.TryParse(str, styles, provider, out result);

			protected override Double? ParseNullable(string str) 
				=> DoubleParser.ParseNullable(str);

			protected override Double? ParseNullable(string str, NumberStyles styles) 
				=> DoubleParser.ParseNullable(str, styles);

			protected override Double? ParseNullable(string str, IFormatProvider provider) 
				=> DoubleParser.ParseNullable(str, provider);

			protected override Double? ParseNullable(string str, NumberStyles styles, IFormatProvider provider) 
				=> DoubleParser.ParseNullable(str, styles, provider);
				
			protected override NumberStyles GetDefaultNumberStyles() => DoubleParser.DEFAULT_NUMBER_STYLES;

			[TestMethod]
			public void Test_DoubleParser_DEFAULT_NUMBER_STYLES() => Test_DEFAULT_NUMBER_STYLES();
				
			[TestMethod]
			public void Test_DoubleParser_TryParse_NotNullable_HasValue_WithFormatProvider() => Test_TryParse_NotNullable_HasValue_WithFormatProvider();
				
			[TestMethod]
			public void Test_DoubleParser_TryParse_NotNullable_IsWhiteSpace_WithFormatProvider() => Test_TryParse_NotNullable_IsWhiteSpace_WithFormatProvider();
				
			[TestMethod]
			public void Test_DoubleParser_TryParse_NotNullable_IsInvalidNumber_WithFormatProvider() => Test_TryParse_NotNullable_IsInvalidNumber_WithFormatProvider();

			[TestMethod]
			public void Test_DoubleParser_TryParse_Nullable_HasValue() => Test_TryParse_Nullable_HasValue();

			[TestMethod]
			public void Test_DoubleParser_TryParse_Nullable_IsNull() => Test_TryParse_Nullable_IsNull();

			[TestMethod]
			public void Test_DoubleParser_TryParse_Nullable_IsInvalid() => Test_TryParse_Nullable_IsInvalid();

			[TestMethod]
			public void Test_DoubleParser_TryParse_Nullable_HasValue_WithNumberStyles() => Test_TryParse_Nullable_HasValue_WithNumberStyles();

			[TestMethod]
			public void Test_DoubleParser_TryParse_Nullable_IsNull_WithNumberStyles() => Test_TryParse_Nullable_IsNull_WithNumberStyles();

			[TestMethod]
			public void Test_DoubleParser_TryParse_Nullable_IsInvalid_WithNumberStyles() => Test_TryParse_Nullable_IsInvalid_WithNumberStyles();

			[TestMethod]
			public void Test_DoubleParser_TryParse_Nullable_HasValue_WithFormatProvider() 
				=> Test_TryParse_Nullable_HasValue_WithFormatProvider();

			[TestMethod]
			public void Test_DoubleParser_TryParse_Nullable_IsNull_WithFormatProvider() 
				=> Test_TryParse_Nullable_IsNull_WithFormatProvider();
				
			[TestMethod]
			public void Test_DoubleParser_TryParse_Nullable_IsInvalid_WithFormatProvider() 
				=> Test_TryParse_Nullable_IsInvalid_WithFormatProvider();

			[TestMethod]
			public void Test_DoubleParser_TryParse_Nullable_HasValue_WithNumberStyles_AndFormatProvider() 
				=> Test_TryParse_Nullable_HasValue_WithNumberStyles_AndFormatProvider();

			[TestMethod]
			public void Test_DoubleParser_TryParse_Nullable_IsNull_WithNumberStyles_AndFormatProvider() 
				=> Test_TryParse_Nullable_IsNull_WithNumberStyles_AndFormatProvider();

			[TestMethod]
			public void Test_DoubleParser_TryParse_Nullable_IsInvalid_WithNumberStyles_AndFormatProvider() 
				=> Test_TryParse_Nullable_IsInvalid_WithNumberStyles_AndFormatProvider();

			[TestMethod]
			public void Test_DoubleParser_ParseNullable_HasValue() => Test_ParseNullable_HasValue();

			[TestMethod]
			public void Test_DoubleParser_ParseNullable_IsNull() => Test_ParseNullable_IsNull();

			[TestMethod]
			public void Test_DoubleParser_ParseNullable_HasValue_WithNumberStyles() => Test_ParseNullable_HasValue_WithNumberStyles();

			[TestMethod]
			public void Test_DoubleParser_ParseNullable_IsNull_WithNumberStyles() => Test_ParseNullable_IsNull_WithNumberStyles();

			[TestMethod]
			public void Test_DoubleParser_ParseNullable_HasValue_WithFormatProvider() => Test_ParseNullable_HasValue_WithFormatProvider();

			[TestMethod]
			public void Test_DoubleParser_ParseNullable_IsNull_WithFormatProvider() => Test_ParseNullable_IsNull_WithFormatProvider();

			[TestMethod]
			public void Test_DoubleParser_ParseNullable_HasValue_WithNumberStyles_WithFormatProvider() 
				=> Test_ParseNullable_HasValue_WithNumberStyles_WithFormatProvider();

			[TestMethod]
			public void Test_DoubleParser_ParseNullable_IsNull_WithNumberStyles_WithFormatProvider() 
				=> Test_ParseNullable_IsNull_WithNumberStyles_WithFormatProvider();
		}

	
		public partial class Int16ParserTests
		{
			protected override bool TryParse(string str, out Int16? result) 
				=> Int16Parser.TryParse(str, out result);

			protected override bool TryParse(string str, NumberStyles styles, out Int16? result) 
				=> Int16Parser.TryParse(str, styles, out result);

			protected override bool TryParse(string str, IFormatProvider provider, out Int16? result) 
				=> Int16Parser.TryParse(str, provider, out result);

			protected override bool TryParse(string str, IFormatProvider provider, out Int16 result) 
				=> Int16Parser.TryParse(str, provider, out result);

			protected override bool TryParse(string str, NumberStyles styles, IFormatProvider provider, out Int16? result) 
				=> Int16Parser.TryParse(str, styles, provider, out result);

			protected override Int16? ParseNullable(string str) 
				=> Int16Parser.ParseNullable(str);

			protected override Int16? ParseNullable(string str, NumberStyles styles) 
				=> Int16Parser.ParseNullable(str, styles);

			protected override Int16? ParseNullable(string str, IFormatProvider provider) 
				=> Int16Parser.ParseNullable(str, provider);

			protected override Int16? ParseNullable(string str, NumberStyles styles, IFormatProvider provider) 
				=> Int16Parser.ParseNullable(str, styles, provider);
				
			protected override NumberStyles GetDefaultNumberStyles() => Int16Parser.DEFAULT_NUMBER_STYLES;

			[TestMethod]
			public void Test_Int16Parser_DEFAULT_NUMBER_STYLES() => Test_DEFAULT_NUMBER_STYLES();
				
			[TestMethod]
			public void Test_Int16Parser_TryParse_NotNullable_HasValue_WithFormatProvider() => Test_TryParse_NotNullable_HasValue_WithFormatProvider();
				
			[TestMethod]
			public void Test_Int16Parser_TryParse_NotNullable_IsWhiteSpace_WithFormatProvider() => Test_TryParse_NotNullable_IsWhiteSpace_WithFormatProvider();
				
			[TestMethod]
			public void Test_Int16Parser_TryParse_NotNullable_IsInvalidNumber_WithFormatProvider() => Test_TryParse_NotNullable_IsInvalidNumber_WithFormatProvider();

			[TestMethod]
			public void Test_Int16Parser_TryParse_Nullable_HasValue() => Test_TryParse_Nullable_HasValue();

			[TestMethod]
			public void Test_Int16Parser_TryParse_Nullable_IsNull() => Test_TryParse_Nullable_IsNull();

			[TestMethod]
			public void Test_Int16Parser_TryParse_Nullable_IsInvalid() => Test_TryParse_Nullable_IsInvalid();

			[TestMethod]
			public void Test_Int16Parser_TryParse_Nullable_HasValue_WithNumberStyles() => Test_TryParse_Nullable_HasValue_WithNumberStyles();

			[TestMethod]
			public void Test_Int16Parser_TryParse_Nullable_IsNull_WithNumberStyles() => Test_TryParse_Nullable_IsNull_WithNumberStyles();

			[TestMethod]
			public void Test_Int16Parser_TryParse_Nullable_IsInvalid_WithNumberStyles() => Test_TryParse_Nullable_IsInvalid_WithNumberStyles();

			[TestMethod]
			public void Test_Int16Parser_TryParse_Nullable_HasValue_WithFormatProvider() 
				=> Test_TryParse_Nullable_HasValue_WithFormatProvider();

			[TestMethod]
			public void Test_Int16Parser_TryParse_Nullable_IsNull_WithFormatProvider() 
				=> Test_TryParse_Nullable_IsNull_WithFormatProvider();
				
			[TestMethod]
			public void Test_Int16Parser_TryParse_Nullable_IsInvalid_WithFormatProvider() 
				=> Test_TryParse_Nullable_IsInvalid_WithFormatProvider();

			[TestMethod]
			public void Test_Int16Parser_TryParse_Nullable_HasValue_WithNumberStyles_AndFormatProvider() 
				=> Test_TryParse_Nullable_HasValue_WithNumberStyles_AndFormatProvider();

			[TestMethod]
			public void Test_Int16Parser_TryParse_Nullable_IsNull_WithNumberStyles_AndFormatProvider() 
				=> Test_TryParse_Nullable_IsNull_WithNumberStyles_AndFormatProvider();

			[TestMethod]
			public void Test_Int16Parser_TryParse_Nullable_IsInvalid_WithNumberStyles_AndFormatProvider() 
				=> Test_TryParse_Nullable_IsInvalid_WithNumberStyles_AndFormatProvider();

			[TestMethod]
			public void Test_Int16Parser_ParseNullable_HasValue() => Test_ParseNullable_HasValue();

			[TestMethod]
			public void Test_Int16Parser_ParseNullable_IsNull() => Test_ParseNullable_IsNull();

			[TestMethod]
			public void Test_Int16Parser_ParseNullable_HasValue_WithNumberStyles() => Test_ParseNullable_HasValue_WithNumberStyles();

			[TestMethod]
			public void Test_Int16Parser_ParseNullable_IsNull_WithNumberStyles() => Test_ParseNullable_IsNull_WithNumberStyles();

			[TestMethod]
			public void Test_Int16Parser_ParseNullable_HasValue_WithFormatProvider() => Test_ParseNullable_HasValue_WithFormatProvider();

			[TestMethod]
			public void Test_Int16Parser_ParseNullable_IsNull_WithFormatProvider() => Test_ParseNullable_IsNull_WithFormatProvider();

			[TestMethod]
			public void Test_Int16Parser_ParseNullable_HasValue_WithNumberStyles_WithFormatProvider() 
				=> Test_ParseNullable_HasValue_WithNumberStyles_WithFormatProvider();

			[TestMethod]
			public void Test_Int16Parser_ParseNullable_IsNull_WithNumberStyles_WithFormatProvider() 
				=> Test_ParseNullable_IsNull_WithNumberStyles_WithFormatProvider();
		}

	
		public partial class Int32ParserTests
		{
			protected override bool TryParse(string str, out Int32? result) 
				=> Int32Parser.TryParse(str, out result);

			protected override bool TryParse(string str, NumberStyles styles, out Int32? result) 
				=> Int32Parser.TryParse(str, styles, out result);

			protected override bool TryParse(string str, IFormatProvider provider, out Int32? result) 
				=> Int32Parser.TryParse(str, provider, out result);

			protected override bool TryParse(string str, IFormatProvider provider, out Int32 result) 
				=> Int32Parser.TryParse(str, provider, out result);

			protected override bool TryParse(string str, NumberStyles styles, IFormatProvider provider, out Int32? result) 
				=> Int32Parser.TryParse(str, styles, provider, out result);

			protected override Int32? ParseNullable(string str) 
				=> Int32Parser.ParseNullable(str);

			protected override Int32? ParseNullable(string str, NumberStyles styles) 
				=> Int32Parser.ParseNullable(str, styles);

			protected override Int32? ParseNullable(string str, IFormatProvider provider) 
				=> Int32Parser.ParseNullable(str, provider);

			protected override Int32? ParseNullable(string str, NumberStyles styles, IFormatProvider provider) 
				=> Int32Parser.ParseNullable(str, styles, provider);
				
			protected override NumberStyles GetDefaultNumberStyles() => Int32Parser.DEFAULT_NUMBER_STYLES;

			[TestMethod]
			public void Test_Int32Parser_DEFAULT_NUMBER_STYLES() => Test_DEFAULT_NUMBER_STYLES();
				
			[TestMethod]
			public void Test_Int32Parser_TryParse_NotNullable_HasValue_WithFormatProvider() => Test_TryParse_NotNullable_HasValue_WithFormatProvider();
				
			[TestMethod]
			public void Test_Int32Parser_TryParse_NotNullable_IsWhiteSpace_WithFormatProvider() => Test_TryParse_NotNullable_IsWhiteSpace_WithFormatProvider();
				
			[TestMethod]
			public void Test_Int32Parser_TryParse_NotNullable_IsInvalidNumber_WithFormatProvider() => Test_TryParse_NotNullable_IsInvalidNumber_WithFormatProvider();

			[TestMethod]
			public void Test_Int32Parser_TryParse_Nullable_HasValue() => Test_TryParse_Nullable_HasValue();

			[TestMethod]
			public void Test_Int32Parser_TryParse_Nullable_IsNull() => Test_TryParse_Nullable_IsNull();

			[TestMethod]
			public void Test_Int32Parser_TryParse_Nullable_IsInvalid() => Test_TryParse_Nullable_IsInvalid();

			[TestMethod]
			public void Test_Int32Parser_TryParse_Nullable_HasValue_WithNumberStyles() => Test_TryParse_Nullable_HasValue_WithNumberStyles();

			[TestMethod]
			public void Test_Int32Parser_TryParse_Nullable_IsNull_WithNumberStyles() => Test_TryParse_Nullable_IsNull_WithNumberStyles();

			[TestMethod]
			public void Test_Int32Parser_TryParse_Nullable_IsInvalid_WithNumberStyles() => Test_TryParse_Nullable_IsInvalid_WithNumberStyles();

			[TestMethod]
			public void Test_Int32Parser_TryParse_Nullable_HasValue_WithFormatProvider() 
				=> Test_TryParse_Nullable_HasValue_WithFormatProvider();

			[TestMethod]
			public void Test_Int32Parser_TryParse_Nullable_IsNull_WithFormatProvider() 
				=> Test_TryParse_Nullable_IsNull_WithFormatProvider();
				
			[TestMethod]
			public void Test_Int32Parser_TryParse_Nullable_IsInvalid_WithFormatProvider() 
				=> Test_TryParse_Nullable_IsInvalid_WithFormatProvider();

			[TestMethod]
			public void Test_Int32Parser_TryParse_Nullable_HasValue_WithNumberStyles_AndFormatProvider() 
				=> Test_TryParse_Nullable_HasValue_WithNumberStyles_AndFormatProvider();

			[TestMethod]
			public void Test_Int32Parser_TryParse_Nullable_IsNull_WithNumberStyles_AndFormatProvider() 
				=> Test_TryParse_Nullable_IsNull_WithNumberStyles_AndFormatProvider();

			[TestMethod]
			public void Test_Int32Parser_TryParse_Nullable_IsInvalid_WithNumberStyles_AndFormatProvider() 
				=> Test_TryParse_Nullable_IsInvalid_WithNumberStyles_AndFormatProvider();

			[TestMethod]
			public void Test_Int32Parser_ParseNullable_HasValue() => Test_ParseNullable_HasValue();

			[TestMethod]
			public void Test_Int32Parser_ParseNullable_IsNull() => Test_ParseNullable_IsNull();

			[TestMethod]
			public void Test_Int32Parser_ParseNullable_HasValue_WithNumberStyles() => Test_ParseNullable_HasValue_WithNumberStyles();

			[TestMethod]
			public void Test_Int32Parser_ParseNullable_IsNull_WithNumberStyles() => Test_ParseNullable_IsNull_WithNumberStyles();

			[TestMethod]
			public void Test_Int32Parser_ParseNullable_HasValue_WithFormatProvider() => Test_ParseNullable_HasValue_WithFormatProvider();

			[TestMethod]
			public void Test_Int32Parser_ParseNullable_IsNull_WithFormatProvider() => Test_ParseNullable_IsNull_WithFormatProvider();

			[TestMethod]
			public void Test_Int32Parser_ParseNullable_HasValue_WithNumberStyles_WithFormatProvider() 
				=> Test_ParseNullable_HasValue_WithNumberStyles_WithFormatProvider();

			[TestMethod]
			public void Test_Int32Parser_ParseNullable_IsNull_WithNumberStyles_WithFormatProvider() 
				=> Test_ParseNullable_IsNull_WithNumberStyles_WithFormatProvider();
		}

	
		public partial class Int64ParserTests
		{
			protected override bool TryParse(string str, out Int64? result) 
				=> Int64Parser.TryParse(str, out result);

			protected override bool TryParse(string str, NumberStyles styles, out Int64? result) 
				=> Int64Parser.TryParse(str, styles, out result);

			protected override bool TryParse(string str, IFormatProvider provider, out Int64? result) 
				=> Int64Parser.TryParse(str, provider, out result);

			protected override bool TryParse(string str, IFormatProvider provider, out Int64 result) 
				=> Int64Parser.TryParse(str, provider, out result);

			protected override bool TryParse(string str, NumberStyles styles, IFormatProvider provider, out Int64? result) 
				=> Int64Parser.TryParse(str, styles, provider, out result);

			protected override Int64? ParseNullable(string str) 
				=> Int64Parser.ParseNullable(str);

			protected override Int64? ParseNullable(string str, NumberStyles styles) 
				=> Int64Parser.ParseNullable(str, styles);

			protected override Int64? ParseNullable(string str, IFormatProvider provider) 
				=> Int64Parser.ParseNullable(str, provider);

			protected override Int64? ParseNullable(string str, NumberStyles styles, IFormatProvider provider) 
				=> Int64Parser.ParseNullable(str, styles, provider);
				
			protected override NumberStyles GetDefaultNumberStyles() => Int64Parser.DEFAULT_NUMBER_STYLES;

			[TestMethod]
			public void Test_Int64Parser_DEFAULT_NUMBER_STYLES() => Test_DEFAULT_NUMBER_STYLES();
				
			[TestMethod]
			public void Test_Int64Parser_TryParse_NotNullable_HasValue_WithFormatProvider() => Test_TryParse_NotNullable_HasValue_WithFormatProvider();
				
			[TestMethod]
			public void Test_Int64Parser_TryParse_NotNullable_IsWhiteSpace_WithFormatProvider() => Test_TryParse_NotNullable_IsWhiteSpace_WithFormatProvider();
				
			[TestMethod]
			public void Test_Int64Parser_TryParse_NotNullable_IsInvalidNumber_WithFormatProvider() => Test_TryParse_NotNullable_IsInvalidNumber_WithFormatProvider();

			[TestMethod]
			public void Test_Int64Parser_TryParse_Nullable_HasValue() => Test_TryParse_Nullable_HasValue();

			[TestMethod]
			public void Test_Int64Parser_TryParse_Nullable_IsNull() => Test_TryParse_Nullable_IsNull();

			[TestMethod]
			public void Test_Int64Parser_TryParse_Nullable_IsInvalid() => Test_TryParse_Nullable_IsInvalid();

			[TestMethod]
			public void Test_Int64Parser_TryParse_Nullable_HasValue_WithNumberStyles() => Test_TryParse_Nullable_HasValue_WithNumberStyles();

			[TestMethod]
			public void Test_Int64Parser_TryParse_Nullable_IsNull_WithNumberStyles() => Test_TryParse_Nullable_IsNull_WithNumberStyles();

			[TestMethod]
			public void Test_Int64Parser_TryParse_Nullable_IsInvalid_WithNumberStyles() => Test_TryParse_Nullable_IsInvalid_WithNumberStyles();

			[TestMethod]
			public void Test_Int64Parser_TryParse_Nullable_HasValue_WithFormatProvider() 
				=> Test_TryParse_Nullable_HasValue_WithFormatProvider();

			[TestMethod]
			public void Test_Int64Parser_TryParse_Nullable_IsNull_WithFormatProvider() 
				=> Test_TryParse_Nullable_IsNull_WithFormatProvider();
				
			[TestMethod]
			public void Test_Int64Parser_TryParse_Nullable_IsInvalid_WithFormatProvider() 
				=> Test_TryParse_Nullable_IsInvalid_WithFormatProvider();

			[TestMethod]
			public void Test_Int64Parser_TryParse_Nullable_HasValue_WithNumberStyles_AndFormatProvider() 
				=> Test_TryParse_Nullable_HasValue_WithNumberStyles_AndFormatProvider();

			[TestMethod]
			public void Test_Int64Parser_TryParse_Nullable_IsNull_WithNumberStyles_AndFormatProvider() 
				=> Test_TryParse_Nullable_IsNull_WithNumberStyles_AndFormatProvider();

			[TestMethod]
			public void Test_Int64Parser_TryParse_Nullable_IsInvalid_WithNumberStyles_AndFormatProvider() 
				=> Test_TryParse_Nullable_IsInvalid_WithNumberStyles_AndFormatProvider();

			[TestMethod]
			public void Test_Int64Parser_ParseNullable_HasValue() => Test_ParseNullable_HasValue();

			[TestMethod]
			public void Test_Int64Parser_ParseNullable_IsNull() => Test_ParseNullable_IsNull();

			[TestMethod]
			public void Test_Int64Parser_ParseNullable_HasValue_WithNumberStyles() => Test_ParseNullable_HasValue_WithNumberStyles();

			[TestMethod]
			public void Test_Int64Parser_ParseNullable_IsNull_WithNumberStyles() => Test_ParseNullable_IsNull_WithNumberStyles();

			[TestMethod]
			public void Test_Int64Parser_ParseNullable_HasValue_WithFormatProvider() => Test_ParseNullable_HasValue_WithFormatProvider();

			[TestMethod]
			public void Test_Int64Parser_ParseNullable_IsNull_WithFormatProvider() => Test_ParseNullable_IsNull_WithFormatProvider();

			[TestMethod]
			public void Test_Int64Parser_ParseNullable_HasValue_WithNumberStyles_WithFormatProvider() 
				=> Test_ParseNullable_HasValue_WithNumberStyles_WithFormatProvider();

			[TestMethod]
			public void Test_Int64Parser_ParseNullable_IsNull_WithNumberStyles_WithFormatProvider() 
				=> Test_ParseNullable_IsNull_WithNumberStyles_WithFormatProvider();
		}

	
		public partial class SingleParserTests
		{
			protected override bool TryParse(string str, out Single? result) 
				=> SingleParser.TryParse(str, out result);

			protected override bool TryParse(string str, NumberStyles styles, out Single? result) 
				=> SingleParser.TryParse(str, styles, out result);

			protected override bool TryParse(string str, IFormatProvider provider, out Single? result) 
				=> SingleParser.TryParse(str, provider, out result);

			protected override bool TryParse(string str, IFormatProvider provider, out Single result) 
				=> SingleParser.TryParse(str, provider, out result);

			protected override bool TryParse(string str, NumberStyles styles, IFormatProvider provider, out Single? result) 
				=> SingleParser.TryParse(str, styles, provider, out result);

			protected override Single? ParseNullable(string str) 
				=> SingleParser.ParseNullable(str);

			protected override Single? ParseNullable(string str, NumberStyles styles) 
				=> SingleParser.ParseNullable(str, styles);

			protected override Single? ParseNullable(string str, IFormatProvider provider) 
				=> SingleParser.ParseNullable(str, provider);

			protected override Single? ParseNullable(string str, NumberStyles styles, IFormatProvider provider) 
				=> SingleParser.ParseNullable(str, styles, provider);
				
			protected override NumberStyles GetDefaultNumberStyles() => SingleParser.DEFAULT_NUMBER_STYLES;

			[TestMethod]
			public void Test_SingleParser_DEFAULT_NUMBER_STYLES() => Test_DEFAULT_NUMBER_STYLES();
				
			[TestMethod]
			public void Test_SingleParser_TryParse_NotNullable_HasValue_WithFormatProvider() => Test_TryParse_NotNullable_HasValue_WithFormatProvider();
				
			[TestMethod]
			public void Test_SingleParser_TryParse_NotNullable_IsWhiteSpace_WithFormatProvider() => Test_TryParse_NotNullable_IsWhiteSpace_WithFormatProvider();
				
			[TestMethod]
			public void Test_SingleParser_TryParse_NotNullable_IsInvalidNumber_WithFormatProvider() => Test_TryParse_NotNullable_IsInvalidNumber_WithFormatProvider();

			[TestMethod]
			public void Test_SingleParser_TryParse_Nullable_HasValue() => Test_TryParse_Nullable_HasValue();

			[TestMethod]
			public void Test_SingleParser_TryParse_Nullable_IsNull() => Test_TryParse_Nullable_IsNull();

			[TestMethod]
			public void Test_SingleParser_TryParse_Nullable_IsInvalid() => Test_TryParse_Nullable_IsInvalid();

			[TestMethod]
			public void Test_SingleParser_TryParse_Nullable_HasValue_WithNumberStyles() => Test_TryParse_Nullable_HasValue_WithNumberStyles();

			[TestMethod]
			public void Test_SingleParser_TryParse_Nullable_IsNull_WithNumberStyles() => Test_TryParse_Nullable_IsNull_WithNumberStyles();

			[TestMethod]
			public void Test_SingleParser_TryParse_Nullable_IsInvalid_WithNumberStyles() => Test_TryParse_Nullable_IsInvalid_WithNumberStyles();

			[TestMethod]
			public void Test_SingleParser_TryParse_Nullable_HasValue_WithFormatProvider() 
				=> Test_TryParse_Nullable_HasValue_WithFormatProvider();

			[TestMethod]
			public void Test_SingleParser_TryParse_Nullable_IsNull_WithFormatProvider() 
				=> Test_TryParse_Nullable_IsNull_WithFormatProvider();
				
			[TestMethod]
			public void Test_SingleParser_TryParse_Nullable_IsInvalid_WithFormatProvider() 
				=> Test_TryParse_Nullable_IsInvalid_WithFormatProvider();

			[TestMethod]
			public void Test_SingleParser_TryParse_Nullable_HasValue_WithNumberStyles_AndFormatProvider() 
				=> Test_TryParse_Nullable_HasValue_WithNumberStyles_AndFormatProvider();

			[TestMethod]
			public void Test_SingleParser_TryParse_Nullable_IsNull_WithNumberStyles_AndFormatProvider() 
				=> Test_TryParse_Nullable_IsNull_WithNumberStyles_AndFormatProvider();

			[TestMethod]
			public void Test_SingleParser_TryParse_Nullable_IsInvalid_WithNumberStyles_AndFormatProvider() 
				=> Test_TryParse_Nullable_IsInvalid_WithNumberStyles_AndFormatProvider();

			[TestMethod]
			public void Test_SingleParser_ParseNullable_HasValue() => Test_ParseNullable_HasValue();

			[TestMethod]
			public void Test_SingleParser_ParseNullable_IsNull() => Test_ParseNullable_IsNull();

			[TestMethod]
			public void Test_SingleParser_ParseNullable_HasValue_WithNumberStyles() => Test_ParseNullable_HasValue_WithNumberStyles();

			[TestMethod]
			public void Test_SingleParser_ParseNullable_IsNull_WithNumberStyles() => Test_ParseNullable_IsNull_WithNumberStyles();

			[TestMethod]
			public void Test_SingleParser_ParseNullable_HasValue_WithFormatProvider() => Test_ParseNullable_HasValue_WithFormatProvider();

			[TestMethod]
			public void Test_SingleParser_ParseNullable_IsNull_WithFormatProvider() => Test_ParseNullable_IsNull_WithFormatProvider();

			[TestMethod]
			public void Test_SingleParser_ParseNullable_HasValue_WithNumberStyles_WithFormatProvider() 
				=> Test_ParseNullable_HasValue_WithNumberStyles_WithFormatProvider();

			[TestMethod]
			public void Test_SingleParser_ParseNullable_IsNull_WithNumberStyles_WithFormatProvider() 
				=> Test_ParseNullable_IsNull_WithNumberStyles_WithFormatProvider();
		}

	
}