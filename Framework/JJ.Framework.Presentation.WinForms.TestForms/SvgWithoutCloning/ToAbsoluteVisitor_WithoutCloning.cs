using JJ.Framework.Presentation.Svg.Models;
using JJ.Framework.Presentation.Svg.Models.Elements;
using JJ.Framework.Presentation.Svg.Visitors;
using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.WinForms.TestForms.SvgWithoutCloning
{
    /// <summary>
    /// Takes a set of SVG elements that can have a hierarchy of child elements
    /// with relative positions and fills in the absolute positions.
    /// </summary>
    internal class ToAbsoluteVisitor_WithoutCloning : ElementVisitorBase
    {
        // TODO: Give this class a more specific name?

        private float _currentParentCenterX;
        private float _currentParentCenterY;

        private HashSet<Point> _convertedPoints;
        private HashSet<Rectangle> _convertedRectangles;

        public void Execute(ElementBase element)
        {
            if (element == null) throw new NullException(() => element);

            _currentParentCenterX = 0;
            _currentParentCenterY = 0;
            _convertedPoints = new HashSet<Point>();
            _convertedRectangles = new HashSet<Rectangle>();

            VisitPolymorphic(element);
        }

        protected override void VisitChildren(ElementBase parentElement)
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
            ConvertRectangle(label.Rectangle);

            base.VisitLabel(label);
        }

        private void ConvertPoint(Point point)
        {
            if (_convertedPoints.Contains(point))
            {
                return;
            }

            point.AbsoluteX = point.X + _currentParentCenterX;
            point.AbsoluteY = point.Y + _currentParentCenterY;

            _convertedPoints.Add(point);
        }
        
        private void ConvertRectangle(Rectangle rectangle)
        {
            if (_convertedRectangles.Contains(rectangle))
            {
                return;
            }

            rectangle.AbsoluteX = rectangle.X + _currentParentCenterX;
            rectangle.AbsoluteY = rectangle.Y + _currentParentCenterY;

            _convertedRectangles.Add(rectangle);
        }
    }
}
