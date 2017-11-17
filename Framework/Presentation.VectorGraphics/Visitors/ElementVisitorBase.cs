using JJ.Framework.Exceptions;
using JJ.Framework.Presentation.VectorGraphics.Models.Elements;

namespace JJ.Framework.Presentation.VectorGraphics.Visitors
{
    internal abstract class ElementVisitorBase
    {
        protected virtual void VisitPolymorphic(Element element)
        {
            if (element == null) throw new NullException(() => element);

            if (element is Point point)
            {
                VisitPoint(point);
                return;
            }

            if (element is Line line)
            {
                VisitLine(line);
                return;
            }

            if (element is Rectangle rectangle)
            {
                VisitRectangle(rectangle);
                return;
            }

            if (element is Label label)
            {
                VisitLabel(label);
                return;
            }

            if (element is Curve curve)
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
