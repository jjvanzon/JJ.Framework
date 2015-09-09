using Microsoft.VisualStudio.TestTools.UnitTesting;
using JJ.Framework.Presentation.VectorGraphics.Visitors;
using JJ.Framework.Testing;
using JJ.Framework.Presentation.VectorGraphics.Models.Elements;
using System.Collections.Generic;

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
                Parent = diagram.Canvas,
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
            AssertHelper.AreEqual(1, () => elements[1].CalculatedX);
            AssertHelper.AreEqual(2, () => elements[1].CalculatedY);
            AssertHelper.AreEqual(11, () => elements[2].CalculatedX);
            AssertHelper.AreEqual(22, () => elements[2].CalculatedY);
            AssertHelper.AreEqual(13, () => elements[3].CalculatedX);
            AssertHelper.AreEqual(24, () => elements[3].CalculatedY);
        }
    }
}
