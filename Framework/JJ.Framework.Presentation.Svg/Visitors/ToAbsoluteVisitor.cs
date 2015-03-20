using JJ.Framework.Presentation.Svg.Models;
using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Presentation.Svg.Visitors
{
    /// <summary>
    /// Takes a set of SVG elements that can have a hierarchy of child elements
    /// with relative positions and converts it to a flat list of objects
    /// with absolute positions
    /// </summary>
    public class ToAbsoluteVisitor : ElementVisitorBase
    {
        private Container _destContainer;
        private float _currentParentCenterX;
        private float _currentParentCenterY;

        private Dictionary<Point, Point> _convertedPoints;
        private Dictionary<Rectangle, Rectangle> _convertedRectangles;

        public Container Execute(ElementBase element)
        {
            if (element == null) throw new NullException(() => element);

            _destContainer = new Container();
            _convertedPoints = new Dictionary<Point, Point>();
            _convertedRectangles = new Dictionary<Rectangle, Rectangle>();
            _currentParentCenterX = 0;
            _currentParentCenterY = 0;

            VisitPolymorphic(element);

            return _destContainer;
        }

        protected override void VisitChildren(ElementBase parentElement)
        {
            _currentParentCenterX += parentElement.CenterX;
            _currentParentCenterY += parentElement.CenterY;

            base.VisitChildren(parentElement);

            _currentParentCenterX -= parentElement.CenterX;
            _currentParentCenterY -= parentElement.CenterY;
        }

        protected override void VisitPoint(Point point)
        {
            Point destPoint = ConvertPoint(point);

            _destContainer.ChildPoints.Add(destPoint);

            base.VisitPoint(point);
        }

        protected override void VisitLine(Line line)
        {
            var destLine = new Line
            {
                PointA = ConvertPoint(line.PointA),
                PointB = ConvertPoint(line.PointB),
            };
            
            _destContainer.ChildLines.Add(destLine);

            base.VisitLine(line);
        }

        protected override void VisitRectangle(Rectangle rectangle)
        {
            var destRectangle = ConvertRectangle(rectangle);

            _destContainer.ChildRectangles.Add(destRectangle);

            base.VisitRectangle(rectangle);
        }

        protected override void VisitLabel(Label label)
        {
            var destLabel = new Label
            {
                Rectangle = ConvertRectangle(label.Rectangle),
                Text = label.Text,
                Font = label.Font,
                HorizontalAlignment = label.HorizontalAlignment,
                VerticalAlignment = label.VerticalAlignment
            };

            _destContainer.ChildLabels.Add(destLabel);

            base.VisitLabel(label);
        }

        private Point ConvertPoint(Point sourcePoint)
        {
            Point destPoint;
            if (_convertedPoints.TryGetValue(sourcePoint, out destPoint))
            {
                return destPoint;
            }

            destPoint = new Point
            {
                X = sourcePoint.X + _currentParentCenterX,
                Y = sourcePoint.Y + _currentParentCenterY
            };

            _convertedPoints.Add(sourcePoint, destPoint);

            return destPoint;
        }
        
        private Rectangle ConvertRectangle(Rectangle sourceRectangle)
        {
            Rectangle destRectangle;
            if (_convertedRectangles.TryGetValue(sourceRectangle, out destRectangle))
            {
                return destRectangle;
            }

            destRectangle = new Rectangle
            {
                X = sourceRectangle.CenterX + _currentParentCenterX,
                Y = sourceRectangle.CenterY + _currentParentCenterY,
                Width = sourceRectangle.Width,
                Height = sourceRectangle.Height
            };

            _convertedRectangles.Add(sourceRectangle, destRectangle);

            return destRectangle;
        }
    }
}
