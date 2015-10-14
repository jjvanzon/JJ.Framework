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
    }
}
