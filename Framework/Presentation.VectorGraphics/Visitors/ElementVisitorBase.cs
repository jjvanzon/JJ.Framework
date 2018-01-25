using JJ.Framework.Exceptions;
using JJ.Framework.VectorGraphics.Models.Elements;

namespace JJ.Framework.VectorGraphics.Visitors
{
	internal abstract class ElementVisitorBase
	{
		protected virtual void VisitPolymorphic(Element element)
		{
			if (element == null) throw new NullException(() => element);

			switch (element)
			{
				case Point point:
					VisitPoint(point);
					return;

				case Line line:
					VisitLine(line);
					return;

				case Rectangle rectangle:
					VisitRectangle(rectangle);
					return;

				case Label label:
					VisitLabel(label);
					return;

				case Curve curve:
					VisitCurve(curve);
					return;

				case Ellipse ellipse:
					VisitEllipse(ellipse);
					return;

				default:
					throw new UnexpectedTypeException(() => element);
			}
		}

		protected virtual void VisitPoint(Point point) => VisitElementBase(point);
		protected virtual void VisitLine(Line line) => VisitElementBase(line);
		protected virtual void VisitRectangle(Rectangle rectangle) => VisitElementBase(rectangle);
		protected virtual void VisitLabel(Label label) => VisitElementBase(label);
		protected virtual void VisitCurve(Curve curve) => VisitElementBase(curve);
		protected virtual void VisitEllipse(Ellipse ellipse) => VisitElementBase(ellipse);

		protected virtual void VisitElementBase(Element element) => VisitChildren(element);

		protected virtual void VisitChildren(Element parentElement)
		{
			foreach (Element child in parentElement.Children)
			{
				VisitPolymorphic(child);
			}
		}
	}
}