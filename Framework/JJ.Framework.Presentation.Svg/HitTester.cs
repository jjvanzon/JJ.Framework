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
        public static ElementBase TryGetHitElement(ElementBase parent, float pointerX, float pointerY)
        {
            // TODO: Recalculating all the time might make it slower.
            var visitor = new StylerVisitor();
            IList<ElementBase> elements = visitor.Execute(parent);

            for (int i = 0; i < elements.Count; i++)
            {
                ElementBase element = elements[i];

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
