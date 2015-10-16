using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using JJ.Framework.Testing;
using JJ.Framework.Presentation.VectorGraphics.Visitors;
using JJ.Framework.Presentation.VectorGraphics.Enums;
using JJ.Framework.Presentation.VectorGraphics.Models.Elements;

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

            var visitor = new CalculationVisitor();
            IList<Element> elements = visitor.Execute(diagram);

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

            actualAbsolute = diagram.PixelsToAbsoluteX(expectedPixels);
            Assert.AreEqual(expectedAbsolute, actualAbsolute);

            actualPixels = diagram.AbsoluteToPixelsX(expectedAbsolute);
            Assert.AreEqual(expectedPixels, actualPixels);

            actualAbsolute = child.RelativeToAbsoluteX(expectedRelative);
            Assert.AreEqual(expectedAbsolute, actualAbsolute);

            actualRelative = child.AbsoluteToRelativeX(expectedAbsolute);
            Assert.AreEqual(expectedRelative, actualRelative);

            actualRelative = child.PixelsToRelativeX(expectedPixels);
            Assert.AreEqual(expectedRelative, actualRelative);

            actualPixels = child.RelativeToPixelsX(expectedRelative);
            Assert.AreEqual(expectedPixels, actualPixels);

            actualAbsolute = child.PixelsToAbsoluteX(expectedPixels);
            Assert.AreEqual(expectedAbsolute, actualAbsolute);

            actualPixels = child.AbsoluteToPixelsX(expectedAbsolute);
            Assert.AreEqual(expectedPixels, actualPixels);

            // Copy-paste-changed code for the Y axis
            expectedRelative = 0.75f * 2;
            expectedAbsolute = -0.25f * 2;
            expectedPixels = 17.5f * 2;

            actualAbsolute = diagram.PixelsToAbsoluteY(expectedPixels);
            Assert.AreEqual(expectedAbsolute, actualAbsolute);

            actualPixels = diagram.AbsoluteToPixelsY(expectedAbsolute);
            Assert.AreEqual(expectedPixels, actualPixels);

            actualAbsolute = child.RelativeToAbsoluteY(expectedRelative);
            Assert.AreEqual(expectedAbsolute, actualAbsolute);

            actualRelative = child.AbsoluteToRelativeY(expectedAbsolute);
            Assert.AreEqual(expectedRelative, actualRelative);

            actualRelative = child.PixelsToRelativeY(expectedPixels);
            Assert.AreEqual(expectedRelative, actualRelative);

            actualPixels = child.RelativeToPixelsY(expectedRelative);
            Assert.AreEqual(expectedPixels, actualPixels);

            actualAbsolute = child.PixelsToAbsoluteY(expectedPixels);
            Assert.AreEqual(expectedAbsolute, actualAbsolute);

            actualPixels = child.AbsoluteToPixelsY(expectedAbsolute);
            Assert.AreEqual(expectedPixels, actualPixels);

            // Test Properties
            Assert.AreEqual(10, child.XInPixels);
            Assert.AreEqual(-1, child.AbsoluteX);

            Assert.AreEqual(20, child.YInPixels);
            Assert.AreEqual(-2, child.AbsoluteY);
        }
    }
}
