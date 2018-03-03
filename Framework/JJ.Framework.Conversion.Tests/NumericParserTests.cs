

using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Conversion.Tests
{
	
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

	
}