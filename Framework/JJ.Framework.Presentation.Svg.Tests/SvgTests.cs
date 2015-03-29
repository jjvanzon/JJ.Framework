using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JJ.Framework.Presentation.Svg.Models;
using JJ.Framework.Presentation.Svg.Visitors;
using JJ.Framework.Testing;
using JJ.Framework.Presentation.Svg.Models.Elements;
using System.Collections.Generic;

namespace JJ.Framework.Presentation.Svg.Tests
{
    [TestClass]
    public class SvgTests
    {
        [TestMethod]
        public void Test_Svg_RelativeCoordinate_ToAbsoluteVisitor()
        {
            var svgManager = new Diagram();

            Point point = new svgManager.CreatePoint(svgManager.RootRectangle);
            point.X = 1;
            point.Y = 2;

            Point childPoint1 = svgManager.CreatePoint(point);
            childPoint1.X = 10;
            childPoint1.Y = 20;

            Point childPoint2 = svgManager.CreatePoint(point);
            childPoint2.X = 12;
            childPoint2.Y = 22;

            var visitor = new CalculationVisitor();
            IList<Element> destElements = visitor.Execute(svgManager.RootRectangle);

            AssertHelper.AreEqual(3, () => destElements.Count);
            AssertHelper.AreEqual(1, () => destElements[0].X);
            AssertHelper.AreEqual(2, () => destElements[0].Y);
            AssertHelper.AreEqual(11, () => destElements[1].X);
            AssertHelper.AreEqual(22, () => destElements[1].Y);
            AssertHelper.AreEqual(13, () => destElements[2].X);
            AssertHelper.AreEqual(24, () => destElements[2].Y);
        }
    }
}
