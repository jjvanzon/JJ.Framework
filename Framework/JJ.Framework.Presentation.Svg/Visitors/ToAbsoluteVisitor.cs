using JJ.Framework.Presentation.Svg.Models;
using JJ.Framework.Presentation.Svg.Models.Elements;
using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg.Visitors
{
    /// <summary>
    /// Takes a set of SVG elements that can have a hierarchy of child elements
    /// with relative positions and converts it to a flat list of objects
    /// with absolute positions
    /// </summary>
    public class ToAbsoluteVisitor : ElementVisitorBase
    {
        // TODO: Give this class a more specific name?

        private IList<ElementBase> _destElements;
        private Dictionary<Point, Point> _convertedPoints;
        private Dictionary<Rectangle, Rectangle> _convertedRectangles;
        private float _currentParentCenterX;
        private float _currentParentCenterY;
        private int _layer;

        public IList<ElementBase> Execute(ElementBase element)
        {
            if (element == null) throw new NullException(() => element);

            _destElements = new List<ElementBase>();
            _convertedPoints = new Dictionary<Point, Point>();
            _convertedRectangles = new Dictionary<Rectangle, Rectangle>();
            _currentParentCenterX = 0;
            _currentParentCenterY = 0;
            _layer = 0;

            VisitPolymorphic(element);

            _destElements = _destElements.OrderBy(x => x.ZIndex)
                                         .ThenBy(x => x.Layer)
                                         .ToArray();
            return _destElements;
        }

        protected override void VisitChildren(ElementBase parentElement)
        {
            _currentParentCenterX += parentElement.X;
            _currentParentCenterY += parentElement.Y;
            _layer++;

            base.VisitChildren(parentElement);

            _currentParentCenterX -= parentElement.X;
            _currentParentCenterY -= parentElement.Y;
            _layer--;
        }

        protected override void VisitPoint(Point point)
        {
            Point destPoint = ConvertPoint(point);

            _destElements.Add(destPoint);

            base.VisitPoint(point);
        }

        protected override void VisitLine(Line line)
        {
            Line destLine = ConvertLine(line);

            _destElements.Add(destLine);

            base.VisitLine(line);
        }

        protected override void VisitRectangle(Rectangle rectangle)
        {
            var destRectangle = ConvertRectangle(rectangle);

            _destElements.Add(destRectangle);

            base.VisitRectangle(rectangle);
        }

        protected override void VisitLabel(Label label)
        {
            Label destLabel = ConvertLabel(label);

            _destElements.Add(destLabel);

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
                Y = sourcePoint.Y + _currentParentCenterY,
                ZIndex = sourcePoint.ZIndex,
                PointStyle = sourcePoint.PointStyle,
                Layer = _layer
            };

            _convertedPoints.Add(sourcePoint, destPoint);

            return destPoint;
        }

        private Line ConvertLine(Line sourceLine)
        {
            var destLine = new Line
            {
                // TODO: These points should not be converted here.
                // They should be converted by the container, and then used here.
                // However, you cannot guarantee the order in which the points are converted.
                PointA = ConvertPoint(sourceLine.PointA),
                PointB = ConvertPoint(sourceLine.PointB),
                LineStyle = sourceLine.LineStyle,
                ZIndex = sourceLine.ZIndex,
                Layer = _layer
            };
            return destLine;
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
                X = sourceRectangle.X + _currentParentCenterX,
                Y = sourceRectangle.Y + _currentParentCenterY,
                Width = sourceRectangle.Width,
                Height = sourceRectangle.Height,
                ZIndex = sourceRectangle.ZIndex,
                BackStyle = sourceRectangle.BackStyle,
                BottomLineStyle = sourceRectangle.BottomLineStyle,
                LeftLineStyle = sourceRectangle.LeftLineStyle,
                RightLineStyle = sourceRectangle.RightLineStyle,
                TopLineStyle = sourceRectangle.TopLineStyle,
                Layer = _layer
            };

            _convertedRectangles.Add(sourceRectangle, destRectangle);

            return destRectangle;
        }

        private Label ConvertLabel(Label sourceLabel)
        {
            var destLabel = new Label
            {
                Rectangle = ConvertRectangle(sourceLabel.Rectangle),
                Text = sourceLabel.Text,
                TextStyle = sourceLabel.TextStyle,
                ZIndex = sourceLabel.ZIndex,
                Layer = _layer
            };
            return destLabel;
        }
    }
}
