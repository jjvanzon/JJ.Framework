using JJ.Framework.Presentation.VectorGraphics.Models.Elements;
using JJ.Framework.Reflection.Exceptions;
using System;

namespace JJ.Framework.Presentation.VectorGraphics.Visitors
{
    internal abstract class ElementVisitorBase
    {
        protected virtual void VisitPolymorphic(Element element)
        {
            if (element == null) throw new NullException(() => element);

            var point = element as Point;
            if (point != null)
            {
                VisitPoint(point);
                return;
            }

            var line = element as Line;
            if (line != null)
            {
                VisitLine(line);
                return;
            }

            var rectangle = element as Rectangle;
            if (rectangle != null)
            {
                VisitRectangle(rectangle);
                return;
            }

            var label = element as Label;
            if (label != null)
            {
                VisitLabel(label);
                return;
            }

            var curve = element as Curve;
            if (curve != null)
            {
                VisitCurve(curve);
                return;
            }

            throw new UnexpectedTypeException(() => element);
        }

        protected virtual void VisitPoint(Point point)
        {
            VisitChildren(point);
        }

        protected virtual void VisitLine(Line line)
        {
            VisitChildren(line);
        }

        protected virtual void VisitRectangle(Rectangle rectangle)
        {
            VisitChildren(rectangle);
        }

        protected virtual void VisitLabel(Label label)
        {
            VisitChildren(label);
        }

        protected virtual void VisitCurve(Curve curve)
        {
            VisitChildren(curve);
        }

        protected virtual void VisitChildren(Element parentElement)
        {
            foreach (Element child in parentElement.Children)
            {
                VisitPolymorphic(child);
            }
        }
    }
}
