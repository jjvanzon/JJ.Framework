using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using JJ.Framework.Testing;
using JJ.Framework.Presentation.VectorGraphics.Enums;
using JJ.Framework.Presentation.VectorGraphics.Models.Elements;
using JJ.Framework.Presentation.VectorGraphics.Helpers;

namespace JJ.Framework.Presentation.VectorGraphics.Tests
{
    [TestClass]
    public class VectorGraphicsTests
    {
        [TestMethod]
        public void Test_VectorGraphics_CalculationVisitor_RelativeCoordinate()
        {
            int zindex = 1;

            var diagram = new Diagram();

            var point = new Point
            {
                Diagram = diagram,
                Parent = diagram.Background,
                ZIndex = zindex++
            };
            point.Position.X = 1;
            point.Position.Y = 2;

            var childPoint1 = new Point
            {
                Diagram = diagram,
                Parent = point,
                ZIndex = zindex++
            };
            childPoint1.Position.X = 10;
            childPoint1.Position.Y = 20;

            var childPoint2 = new Point
            { 
                Diagram = diagram,
                Parent = point,
                ZIndex = zindex++
            };
            childPoint2.Position.X = 12;
            childPoint2.Position.Y = 22;

            var visitor_Accessor = new CalculationVisitor_Accessor();

            IList<Element> elements = visitor_Accessor.Execute(diagram);

            AssertHelper.AreEqual(4, () => elements.Count);
            AssertHelper.AreEqual(1, () => ((ICalculatedValues)elements[1]).CalculatedXInPixels);
            AssertHelper.AreEqual(2, () => ((ICalculatedValues)elements[1]).CalculatedYInPixels);
            AssertHelper.AreEqual(11, () => ((ICalculatedValues)elements[2]).CalculatedXInPixels);
            AssertHelper.AreEqual(22, () => ((ICalculatedValues)elements[2]).CalculatedYInPixels);
            AssertHelper.AreEqual(13, () => ((ICalculatedValues)elements[3]).CalculatedXInPixels);
            AssertHelper.AreEqual(24, () => ((ICalculatedValues)elements[3]).CalculatedYInPixels);
        }

        [TestMethod]
        public void Test_VectorGraphics_ScaleModeEnum_ViewPort()
        {
            // A diagram of 4x8 with a child of 2x4 in the middle with a center that is (0, 0)
            // and pixel values that are 10 times the scaled coordinates.
            var diagram = new Diagram();
            diagram.Position.WidthInPixels = 40;
            diagram.Position.HeightInPixels = 80;
            diagram.Position.ScaleModeEnum = ScaleModeEnum.ViewPort;
            diagram.Position.ScaledX = -2;
            diagram.Position.ScaledY = -4;
            diagram.Position.ScaledWidth = 4;
            diagram.Position.ScaledHeight = 8;

            var child = new Rectangle
            {
                Diagram = diagram,
                Parent = diagram.Background
            };

            child.Position.X = 1;
            child.Position.Y = 2;
            child.Position.Width = 2;
            child.Position.Height = 4;

            diagram.Recalculate();

            float expectedRelative;
            float expectedAbsolute;
            float expectedPixels;

            float actualRelative;
            float actualAbsolute;
            float actualPixels;

            expectedRelative = 0.75f;
            expectedAbsolute = -0.25f;
            expectedPixels = 17.5f;

            actualAbsolute = diagram.Position.PixelsToX(expectedPixels);
            Assert.AreEqual(expectedAbsolute, actualAbsolute);

            actualPixels = diagram.Position.XToPixels(expectedAbsolute);
            Assert.AreEqual(expectedPixels, actualPixels);

            actualAbsolute = child.Position.RelativeToAbsoluteX(expectedRelative);
            Assert.AreEqual(expectedAbsolute, actualAbsolute);

            actualRelative = child.Position.AbsoluteToRelativeX(expectedAbsolute);
            Assert.AreEqual(expectedRelative, actualRelative);

            actualRelative = child.Position.PixelsToRelativeX(expectedPixels);
            Assert.AreEqual(expectedRelative, actualRelative);

            actualPixels = child.Position.RelativeToPixelsX(expectedRelative);
            Assert.AreEqual(expectedPixels, actualPixels);

            actualAbsolute = child.Position.PixelsToAbsoluteX(expectedPixels);
            Assert.AreEqual(expectedAbsolute, actualAbsolute);

            actualPixels = child.Position.AbsoluteToPixelsX(expectedAbsolute);
            Assert.AreEqual(expectedPixels, actualPixels);

            // Copy-paste-changed code for the Y axis
            expectedRelative = 0.75f * 2;
            expectedAbsolute = -0.25f * 2;
            expectedPixels = 17.5f * 2;

            actualAbsolute = diagram.Position.PixelsToY(expectedPixels);
            Assert.AreEqual(expectedAbsolute, actualAbsolute);

            actualPixels = diagram.Position.YToPixels(expectedAbsolute);
            Assert.AreEqual(expectedPixels, actualPixels);

            actualAbsolute = child.Position.RelativeToAbsoluteY(expectedRelative);
            Assert.AreEqual(expectedAbsolute, actualAbsolute);

            actualRelative = child.Position.AbsoluteToRelativeY(expectedAbsolute);
            Assert.AreEqual(expectedRelative, actualRelative);

            actualRelative = child.Position.PixelsToRelativeY(expectedPixels);
            Assert.AreEqual(expectedRelative, actualRelative);

            actualPixels = child.Position.RelativeToPixelsY(expectedRelative);
            Assert.AreEqual(expectedPixels, actualPixels);

            actualAbsolute = child.Position.PixelsToAbsoluteY(expectedPixels);
            Assert.AreEqual(expectedAbsolute, actualAbsolute);

            actualPixels = child.Position.AbsoluteToPixelsY(expectedAbsolute);
            Assert.AreEqual(expectedPixels, actualPixels);

            // Test Properties
            Assert.AreEqual(10, child.Position.XInPixels);
            Assert.AreEqual(-1, child.Position.AbsoluteX);

            Assert.AreEqual(20, child.Position.YInPixels);
            Assert.AreEqual(-2, child.Position.AbsoluteY);

            // Test Width and Height conversions
            Assert.AreEqual(20, diagram.Position.WidthToPixels(2));
            Assert.AreEqual(20, diagram.Position.HeightToPixels(2));

            Assert.AreEqual(2, diagram.Position.PixelsToWidth(20));
            Assert.AreEqual(2, diagram.Position.PixelsToHeight(20));
        }

        [TestMethod]
        public void Test_ColorHelper_GetAlpha_GetRed_GetGreen_GetBlue_SetBrightness()
        {
            int color = ColorHelper.GetColor(2, 4, 6, 8);

            int alpha = ColorHelper.GetAlpha(color);
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
            int expectedMaxedOutColor = 0x027fbfff;
            AssertHelper.AreEqual(expectedMaxedOutColor, () => actualMaxedOutColor);

            int whiteWithAlpha = ColorHelper.GetColor(255, 255, 255, 255);
            int probablyGreyColor = ColorHelper.SetBrightness(whiteWithAlpha, 0.5);
            int expectedGreyColor = ColorHelper.GetColor(255, 127, 127, 127);
            AssertHelper.AreEqual(expectedGreyColor, () => probablyGreyColor);
        }
    }
}
