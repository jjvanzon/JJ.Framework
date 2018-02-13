using JJ.Framework.Exceptions;
using JJ.Framework.VectorGraphics.Models.Elements;

namespace JJ.Framework.VectorGraphics.Visitors
{
	public abstract class ElementVisitorBase
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

				case Picture picture:
					VisitPicture(picture);
					return;

				default:
					VisitComposite(element);
					break;
			}
		}

		protected virtual void VisitPoint(Point element) => VisitElementBase(element);
		protected virtual void VisitLine(Line element) => VisitElementBase(element);
		protected virtual void VisitRectangle(Rectangle element) => VisitElementBase(element);
		protected virtual void VisitLabel(Label element) => VisitElementBase(element);
		protected virtual void VisitCurve(Curve element) => VisitElementBase(element);
		protected virtual void VisitEllipse(Ellipse element) => VisitElementBase(element);
		protected virtual void VisitPicture(Picture element) => VisitElementBase(element);
		protected virtual void VisitComposite(Element element) => VisitElementBase(element);

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