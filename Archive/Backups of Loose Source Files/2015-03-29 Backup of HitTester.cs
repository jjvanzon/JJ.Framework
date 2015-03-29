using JJ.Framework.Mathematics;
using JJ.Framework.Presentation.Svg.Models.Elements;
using JJ.Framework.Presentation.Svg.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg
{
    internal static class HitTester
    {
        public static Element TryGetHitElement(IEnumerable<Element> zOrderedElements, float pointerX, float pointerY)
        {
            foreach (Element element in zOrderedElements)
            {
                var rectangle = element as Rectangle;
                if (rectangle != null)
                {
                    bool isInRectangle = GeometryCalculator.IsInRectangle(
                            pointerX, pointerY,
                            rectangle.X, rectangle.Y,
                            rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height);

                    if (isInRectangle)
                    {
                        return element;
                    }
                }
            }

            return null;
        }
    }
}
