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
            var diagram = new Diagram();

            //Point point = diagram.CreatePoint(diagram.RootRectangle)
            var point = new Point();
            point.X = 1;
            point.Y = 2;

            //Point childPoint1 = diagram.CreatePoint(point);
            var childPoint1 = new Point 
            {
                Diagram = diagram,
                X = 10, 
                Y = 20
            };

            //Point childPoint2 = diagram.CreatePoint(point);
            var childPoint2 = new Point
            { 
                Diagram = diagram,
                X = 12, 
                Y = 22
            };

            var visitor = new CalculationVisitor();
            IList<Element> elements = visitor.Execute(diagram.RootRectangle);

            AssertHelper.AreEqual(3, () => elements.Count);
            AssertHelper.AreEqual(1, () => elements[0].X);
            AssertHelper.AreEqual(2, () => elements[0].Y);
            AssertHelper.AreEqual(11, () => elements[1].X);
            AssertHelper.AreEqual(22, () => elements[1].Y);
            AssertHelper.AreEqual(13, () => elements[2].X);
            AssertHelper.AreEqual(24, () => elements[2].Y);
        }
    }
}
