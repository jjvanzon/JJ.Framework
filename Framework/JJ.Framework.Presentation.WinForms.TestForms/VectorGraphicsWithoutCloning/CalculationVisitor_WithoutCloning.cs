using JJ.Framework.Presentation.VectorGraphics.Models.Elements;
using JJ.Framework.Presentation.VectorGraphics.Visitors;
using JJ.Framework.Presentation.WinForms.TestForms.Helpers;
using JJ.Framework.Reflection.Exceptions;
using System.Collections.Generic;
using JJ.Framework.Presentation.WinForms.TestForms.Helpers;

namespace JJ.Framework.Presentation.WinForms.TestForms.VectorGraphicsWithoutCloning
{
    /// <summary>
    /// Takes a set of VectorGraphics elements that can have a hierarchy of child elements
    /// with relative positions and fills in the absolute positions.
    /// </summary>
    internal class CalculationVisitor_WithoutCloning : ElementVisitorBase
    {
        private float _currentParentCenterX;
        private float _currentParentCenterY;

        private HashSet<Point> _convertedPoints;
        private HashSet<Rectangle> _convertedRectangles;

        public void Execute(Element element)
        {
            if (element == null) throw new NullException(() => element);

            _currentParentCenterX = 0;
            _currentParentCenterY = 0;
            _convertedPoints = new HashSet<Point>();
            _convertedRectangles = new HashSet<Rectangle>();

            VisitPolymorphic(element);
        }

        protected override void VisitChildren(Element parentElement)
        {
            _currentParentCenterX += parentElement.X;
            _currentParentCenterY += parentElement.Y;

            base.VisitChildren(parentElement);

            _currentParentCenterX -= parentElement.X;
            _currentParentCenterY -= parentElement.Y;
        }

        protected override void VisitPoint(Point point)
        {
            ConvertPoint(point);

            base.VisitPoint(point);
        }

        protected override void VisitLine(Line line)
        {
            // Do not convert points here. The points of a line can be the child of another object,
            // so that it moves along with the other object.
            //ConvertPoint(line.PointA);
            //ConvertPoint(line.PointB);

            base.VisitLine(line);
        }

        protected override void VisitRectangle(Rectangle rectangle)
        {
            ConvertRectangle(rectangle);

            base.VisitRectangle(rectangle);
        }

        protected override void VisitLabel(Label label)
        {
            var label_Accessor = new Element_Accessor(label);

            label_Accessor.CalculatedX = label.X + _currentParentCenterX;
            label_Accessor.CalculatedY = label.Y + _currentParentCenterY;

            base.VisitLabel(label);
        }

        private void ConvertPoint(Point point)
        {
            if (_convertedPoints.Contains(point))
            {
                return;
            }

            var point_Accessor = new Element_Accessor(point);

            point_Accessor.CalculatedX = point.X + _currentParentCenterX;
            point_Accessor.CalculatedY = point.Y + _currentParentCenterY;

            _convertedPoints.Add(point);
        }
        
        private void ConvertRectangle(Rectangle rectangle)
        {
            if (_convertedRectangles.Contains(rectangle))
            {
                return;
            }

            var rectangle_Accessor = new Element_Accessor(rectangle);

            rectangle_Accessor.CalculatedX = rectangle.X + _currentParentCenterX;
            rectangle_Accessor.CalculatedY = rectangle.Y + _currentParentCenterY;

            _convertedRectangles.Add(rectangle);
        }
    }
}
