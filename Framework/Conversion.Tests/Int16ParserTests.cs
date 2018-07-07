using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Conversion.Tests
{
	[TestClass]
	public partial class Int16ParserTests : NumericParserTestsBase<short>
	{
		// Can't think of an integer number notation that is normal in Dutch, that is not normal in English.
		protected override NumberStyles NormalNumberStyles => NumberStyles.Integer;
		protected override string NormalNumberStringEnUS => "1";
		protected override string NormalNumberStringNlNL => "1"; 
		protected override short NormalNumber => 1;

		protected override NumberStyles SpecialNumberStyles => NumberStyles.Any;
		protected override string NumberWithSpecialNumberStylesStringEnUS => "1E1";
		protected override string NumberWithSpecialNumberStylesStringNlNL => "1E1";
		protected override short NumberWithSpecialNumberStyles => 10;
	}
}
