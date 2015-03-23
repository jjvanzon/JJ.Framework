using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JJ.Framework.Presentation.Svg.Models;
using JJ.Framework.Presentation.Svg.Visitors;
using JJ.Framework.Testing;
using JJ.Framework.Presentation.Svg.Models.Elements;

namespace JJ.Framework.Presentation.Svg.Tests
{
    [TestClass]
    public class SvgTests
    {
        [TestMethod]
        public void Test_Svg_RelativeCoordinate_ToAbsoluteVisitor()
        {
            var rootRectangle = new Rectangle
            {
                Children = new Point[]
                {
                    new Point
                    {
                        X = 1,
                        Y = 2,
                        Children = new Point[]
                        {
                            new Point { X = 10, Y = 20 },
                            new Point { X = 12, Y = 22 }
                        }
                    }
                }
            };

            var visitor = new ToAbsoluteVisitor();
            Rectangle destRectangle = visitor.Execute(rootRectangle);

            AssertHelper.AreEqual(3, () => destRectangle.Children.Count);
            AssertHelper.AreEqual(1, () => destRectangle.Children[0].X);
            AssertHelper.AreEqual(2, () => destRectangle.Children[0].Y);
            AssertHelper.AreEqual(11, () => destRectangle.Children[1].X);
            AssertHelper.AreEqual(22, () => destRectangle.Children[1].Y);
            AssertHelper.AreEqual(13, () => destRectangle.Children[2].X);
            AssertHelper.AreEqual(24, () => destRectangle.Children[2].Y);
        }
    }
}
