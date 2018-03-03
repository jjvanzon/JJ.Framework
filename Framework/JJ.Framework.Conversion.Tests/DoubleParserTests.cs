using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Conversion.Tests
{
	[TestClass]
	public partial class DoubleParserTests : NumericParserTestsBase<double>
	{
		protected override string NormalNumberStringEnUS => "1.11E1";
		protected override string NormalNumberStringNlNL => "1,11E1";
		protected override double NormalNumber => 11.1;

		// Can't seem to think of number styles that double conversion wouldn't normally take.
		protected override NumberStyles SpecialNumberStyles => NumberStyles.Any;
		protected override string NumberWithSpecialNumberStylesStringEnUS => "1.11E1";
		protected override string NumberWithSpecialNumberStylesStringNlNL => "1,11E1";
		protected override double NumberWithSpecialNumberStyles => 11.1;
	}
}