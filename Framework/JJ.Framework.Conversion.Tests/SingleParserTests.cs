using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Conversion.Tests
{
	[TestClass]
	public partial class SingleParserTests : NumericParserTestsBase<float>
	{
		protected override NumberStyles NormalNumberStyles => NumberStyles.Any;
		protected override string NormalNumberStringEnUS => "1.11E1";
		protected override string NormalNumberStringNlNL => "1,11E1";
		protected override float NormalNumber => 11.1f;

		protected override NumberStyles SpecialNumberStyles => NumberStyles.Any ^ NumberStyles.AllowDecimalPoint;
		protected override string NumberWithSpecialNumberStylesStringEnUS => "111E1";
		protected override string NumberWithSpecialNumberStylesStringNlNL => "111E1";
		protected override float NumberWithSpecialNumberStyles => 1110f;
	}
}