using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JJ.Framework.Presentation.Svg.Models;
using JJ.Framework.Presentation.Svg.Visitors;
using JJ.Framework.Testing;

namespace JJ.Framework.Presentation.Svg.Tests
{
    [TestClass]
    public class SvgTests
    {
        [TestMethod]
        public void Test_Svg_RelativeCoordinate_ToAbsoluteVisitor()
        {
            var container = new Container
            {
                ChildPoints = new Point[]
                {
                    new Point
                    {
                        X = 1,
                        Y = 2,
                        ChildPoints = new Point[]
                        {
                            new Point { X = 10, Y = 20 },
                            new Point { X = 12, Y = 22 }
                        }
                    }
                }
            };

            var visitor = new ToAbsoluteVisitor();
            Container destContainer = visitor.Execute(container);

            AssertHelper.AreEqual(3, () => destContainer.ChildPoints.Count);
            AssertHelper.AreEqual(1, () => destContainer.ChildPoints[0].X);
            AssertHelper.AreEqual(2, () => destContainer.ChildPoints[0].Y);
            AssertHelper.AreEqual(11, () => destContainer.ChildPoints[1].X);
            AssertHelper.AreEqual(22, () => destContainer.ChildPoints[1].Y);
            AssertHelper.AreEqual(13, () => destContainer.ChildPoints[2].X);
            AssertHelper.AreEqual(24, () => destContainer.ChildPoints[2].Y);
        }
    }
}
