using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using JJ.Framework.Testing;
using JJ.Framework.Presentation.VectorGraphics.Visitors;
using JJ.Framework.Presentation.VectorGraphics.Enums;
using JJ.Framework.Presentation.VectorGraphics.Models.Elements;
using JJ.Framework.Presentation.VectorGraphics.Helpers;
using JJ.Framework.Reflection;

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
                X = 1,
                Y = 2,
                ZIndex = zindex++
            };

            var childPoint1 = new Point 
            {
                Diagram = diagram,
                Parent = point,
                X = 10, 
                Y = 20,
                ZIndex = zindex++
            };

            var childPoint2 = new Point
            { 
                Diagram = diagram,
                Parent = point,
                X = 12, 
                Y = 22,
                ZIndex = zindex++
            };

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
            var diagram = new Diagram
            {
                ScaleModeEnum = ScaleModeEnum.ViewPort,
                ScaledX = -2,
                ScaledY = -4,
                ScaledWidth = 4,
                ScaledHeight = 8,
                WidthInPixels = 40,
                HeightInPixels = 80
            };

            var child = new Rectangle
            {
                Diagram = diagram,
                Parent = diagram.Background,
                X = 1,
                Y = 2,
                Width = 2,
                Height = 4
            };

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

            actualAbsolute = ScaleHelper.PixelsToX(diagram, expectedPixels);
            Assert.AreEqual(expectedAbsolute, actualAbsolute);

            actualPixels = ScaleHelper.XToPixels(diagram, expectedAbsolute);
            Assert.AreEqual(expectedPixels, actualPixels);

            actualAbsolute = ScaleHelper.RelativeToAbsoluteX(child, expectedRelative);
            Assert.AreEqual(expectedAbsolute, actualAbsolute);

            actualRelative = ScaleHelper.AbsoluteToRelativeX(child, expectedAbsolute);
            Assert.AreEqual(expectedRelative, actualRelative);

            actualRelative = ScaleHelper.PixelsToRelativeX(child, expectedPixels);
            Assert.AreEqual(expectedRelative, actualRelative);

            actualPixels = ScaleHelper.RelativeToPixelsX(child, expectedRelative);
            Assert.AreEqual(expectedPixels, actualPixels);

            actualAbsolute = ScaleHelper.PixelsToAbsoluteX(child, expectedPixels);
            Assert.AreEqual(expectedAbsolute, actualAbsolute);

            actualPixels = ScaleHelper.AbsoluteToPixelsX(child, expectedAbsolute);
            Assert.AreEqual(expectedPixels, actualPixels);

            // Copy-paste-changed code for the Y axis
            expectedRelative = 0.75f * 2;
            expectedAbsolute = -0.25f * 2;
            expectedPixels = 17.5f * 2;

            actualAbsolute = ScaleHelper.PixelsToY(diagram, expectedPixels);
            Assert.AreEqual(expectedAbsolute, actualAbsolute);

            actualPixels = ScaleHelper.YToPixels(diagram, expectedAbsolute);
            Assert.AreEqual(expectedPixels, actualPixels);

            actualAbsolute = ScaleHelper.RelativeToAbsoluteY(child, expectedRelative);
            Assert.AreEqual(expectedAbsolute, actualAbsolute);

            actualRelative = ScaleHelper.AbsoluteToRelativeY(child, expectedAbsolute);
            Assert.AreEqual(expectedRelative, actualRelative);

            actualRelative = ScaleHelper.PixelsToRelativeY(child, expectedPixels);
            Assert.AreEqual(expectedRelative, actualRelative);

            actualPixels = ScaleHelper.RelativeToPixelsY(child, expectedRelative);
            Assert.AreEqual(expectedPixels, actualPixels);

            actualAbsolute = ScaleHelper.PixelsToAbsoluteY(child, expectedPixels);
            Assert.AreEqual(expectedAbsolute, actualAbsolute);

            actualPixels = ScaleHelper.AbsoluteToPixelsY(child, expectedAbsolute);
            Assert.AreEqual(expectedPixels, actualPixels);

            // Test Properties
            Assert.AreEqual(10, child.XInPixels);
            Assert.AreEqual(-1, child.AbsoluteX);

            Assert.AreEqual(20, child.YInPixels);
            Assert.AreEqual(-2, child.AbsoluteY);

            // Test Width and Height conversions
            Assert.AreEqual(20, ScaleHelper.WidthToPixels(diagram, 2));
            Assert.AreEqual(20, ScaleHelper.HeightToPixels(diagram, 2));

            Assert.AreEqual(2, ScaleHelper.PixelsToWidth(diagram, 20));
            Assert.AreEqual(2, ScaleHelper.PixelsToHeight(diagram, 20));
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
