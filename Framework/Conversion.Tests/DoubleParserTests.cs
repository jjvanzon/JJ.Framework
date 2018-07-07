using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Conversion.Tests
{
	[TestClass]
	public partial class DoubleParserTests : NumericParserTestsBase<double>
	{
		protected override NumberStyles NormalNumberStyles => NumberStyles.Any;
		protected override string NormalNumberStringEnUS => "1.11E1";
		protected override string NormalNumberStringNlNL => "1,11E1";
		protected override double NormalNumber => 11.1;

		protected override NumberStyles SpecialNumberStyles => NumberStyles.Any ^ NumberStyles.AllowDecimalPoint;
		protected override string NumberWithSpecialNumberStylesStringEnUS => "111E1";
		protected override string NumberWithSpecialNumberStylesStringNlNL => "111E1";
		protected override double NumberWithSpecialNumberStyles => 1110;
	}
}