using System.Collections.Generic;
using JJ.Framework.Testing;
using JJ.Framework.VectorGraphics.Enums;
using JJ.Framework.VectorGraphics.Helpers;
using JJ.Framework.VectorGraphics.Models.Elements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable RedundantAssignment

namespace JJ.Framework.VectorGraphics.Tests
{
	[TestClass]
	public class VectorGraphicsTests
	{
		[TestMethod]
		public void Test_ColorHelper_GetAlpha_GetRed_GetGreen_GetBlue_SetBrightness()
		{
			int color = ColorHelper.GetColor(2, 4, 6, 8);

			int alpha = ColorHelper.GetOpacity(color);
			AssertHelper.AreEqual(2, () => alpha);

			int red = ColorHelper.GetRed(color);
			AssertHelper.AreEqual(4, () => red);

			int green = ColorHelper.GetGreen(color);
			AssertHelper.AreEqual(6, () => green);

			int blue = ColorHelper.GetBlue(color);
			AssertHelper.AreEqual(8, () => blue);

			int darkerColor = ColorHelper.SetBrightness(color, 0.5);
			int expectedDarkerColor = ColorHelper.GetColor(2, 2, 3, 4);
			AssertHelper.AreEqual(expectedDarkerColor, () => darkerColor);

			int actualMaxedOutColor = ColorHelper.SetBrightness(color, 255);
			const int expectedMaxedOutColor = 0x027fbfff;
			AssertHelper.AreEqual(expectedMaxedOutColor, () => actualMaxedOutColor);

			int whiteWithAlpha = ColorHelper.GetColor(255, 255, 255, 255);
			int probablyGreyColor = ColorHelper.SetBrightness(whiteWithAlpha, 0.5);
			int expectedGreyColor = ColorHelper.GetColor(255, 127, 127, 127);
			AssertHelper.AreEqual(expectedGreyColor, () => probablyGreyColor);
		}
	}
}
