using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Conversion.Tests
{
	[TestClass]
	public partial class DecimalParserTests : NumericParserTestsBase<decimal>
	{
		protected override NumberStyles NormalNumberStyles => NumberStyles.Number;
		protected override string NormalNumberStringEnUS => "11.1";
		protected override string NormalNumberStringNlNL => "11,1";
		protected override decimal NormalNumber => 11.1m;

		protected override NumberStyles SpecialNumberStyles => NumberStyles.Any;
		protected override string NumberWithSpecialNumberStylesStringEnUS => "1.11E1";
		protected override string NumberWithSpecialNumberStylesStringNlNL => "1,11E1";
		protected override decimal NumberWithSpecialNumberStyles => 11.1m;
	}
}