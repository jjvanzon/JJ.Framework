﻿using System.Globalization;
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

		// Can't seem to think of number styles that float conversion wouldn't normally take.
		protected override NumberStyles SpecialNumberStyles => NumberStyles.Any;
		protected override string NumberWithSpecialNumberStylesStringEnUS => "1.11E1";
		protected override string NumberWithSpecialNumberStylesStringNlNL => "1,11E1";
		protected override float NumberWithSpecialNumberStyles => 11.1f;
	}
}