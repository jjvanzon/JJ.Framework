using JJ.Framework.Mathematics;
using JJ.Framework.Presentation.Svg.Models;
using JJ.Framework.Presentation.Svg.Models.Elements;
using JJ.Framework.Presentation.Svg.Models.Styling;
using JJ.Framework.Reflection.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg.Visitors
{
    /// <summary>
    /// Takes a set of SVG elements that can have a hierarchy of child elements
    /// with relative positions and converts it to a flat list of objects
    /// with absolute positions and Z-index applied.
    /// </summary>
    public class CalculationVisitor : ElementVisitorBase
    {
        // Public for tests.

        private HashSet<Element> _calculatedElements;
        private float _currentParentX;
        private float _currentParentY;

        private Diagram _diagram;
        private int _currentZIndex;
        private int _currentLayer;

        /// <summary>
        /// Returns elements ordered by calculated Z-Index.
        /// </summary>
        public IList<Element> Execute(Diagram diagram)
        {
            if (diagram == null) throw new NullException(() => diagram);

            _diagram = diagram;
            _calculatedElements = new HashSet<Element>();
            _currentParentX = 0;
            _currentParentY = 0;
            _currentZIndex = 0;
            _currentLayer = 0;

            VisitPolymorphic(diagram.Canvas);

            IList<Element> orderedElements = ApplyExplicitZIndex(diagram);

            foreach (Element element in diagram.Elements)
            {
                PostProcessPolymorphic(element);
            }

            return orderedElements;
        }

        /// <summary>
        /// In the recursion the CalculatedZIndex is simply incremented as the parent-child structure is traversed.
        /// This method corrects this CalculatedZIndex making the explicit ZIndex more significant than the parent-child relationships.
        /// </summary>
        private IList<Element> ApplyExplicitZIndex(Diagram diagram)
        {
            IList<Element> orderedElements = diagram.Elements.OrderBy(x => x.ZIndex)
                                                             .ThenBy(x => x.CalculatedZIndex)
                                                             .ToArray();
            int i = 1;
            foreach (Element element in orderedElements)
            {
                element.CalculatedZIndex = i++;
            }

            return orderedElements;
        }

        // Visit

        // Beware that VisitPolymorphic can visit the same object multiple times.
        // That is why some repeated code cannot be put in VisitPolymorphic.

        protected override void VisitPolymorphic(Element element)
        {
            // TODO: It seems to coincidental that determining Visible and Enabled work this way.
            // I would much rather put variables on the call stack or work with a new virtual style
            // on each stack frame.
            element.CalculatedVisible = element.Visible;
            if (element.Parent != null)
            {
                element.CalculatedVisible &= element.Parent.CalculatedVisible;
            }

            element.CalculatedEnabled = element.Enabled;
            if (element.Parent != null)
            {
                element.CalculatedEnabled &= element.Parent.CalculatedEnabled;
            }

            element.CalculatedLayer = _currentLayer;
            element.CalculatedZIndex = _currentZIndex++;

            base.VisitPolymorphic(element);
        }

        protected override void VisitChildren(Element parentElement)
        {
            _currentParentX += parentElement.X;
            _currentParentY += parentElement.Y;
            _currentLayer++;

            base.VisitChildren(parentElement);

            _currentParentX -= parentElement.X;
            _currentParentY -= parentElement.Y;
            _currentLayer--;
        }

        protected override void VisitPoint(Point point)
        {
            // Do not check visibility, because invisible point must be recalculated,
            // because it must be absolutely positioned,
            // because it can be referenced by a line.

            CalculatePoint(point);

            base.VisitPoint(point);
        }

        protected override void VisitLine(Line line)
        {
            CalculateLine(line);

            base.VisitLine(line);
        }

        protected override void VisitRectangle(Rectangle rectangle)
        {
            CalculateRectangle(rectangle);

            base.VisitRectangle(rectangle);
        }

        protected override void VisitLabel(Label label)
        {
            CalculateLabel(label);

            base.VisitLabel(label);
        }

        // NOTE: For Curve there is nothing specific to calculate at this point. Curves are calculated in the post-processing.

        // Calculate

        private void CalculatePoint(Point point)
        {
            if (_calculatedElements.Contains(point))
            {
                return;
            }

            point.CalculatedX = point.X + _currentParentX;
            point.CalculatedY = point.Y + _currentParentY;

            _calculatedElements.Add(point);
        }

        private void CalculateLine(Line line)
        {
            if (_calculatedElements.Contains(line))
            {
                return;
            }

            _calculatedElements.Add(line);
        }
        
        private void CalculateRectangle(Rectangle rectangle)
        {
            if (_calculatedElements.Contains(rectangle))
            {
                return;
            }

            rectangle.CalculatedX = rectangle.X + _currentParentX;
            rectangle.CalculatedY = rectangle.Y + _currentParentY;

            _calculatedElements.Add(rectangle);
        }

        private void CalculateLabel(Label label)
        {
            if (_calculatedElements.Contains(label))
            {
                return;
            }

            label.CalculatedX = label.X + _currentParentX;
            label.CalculatedY = label.Y + _currentParentY;

            _calculatedElements.Add(label);
        }

        // Post Process

        private void PostProcessPolymorphic(Element element)
        {
            var line = element as Line;
            if (line != null)
            {
                PostProcessLine(line);
                return;
            }

            var curve = element as Curve;
            if (curve != null)
            {
                PostProcessCurve(curve);
                return;
            }

            // No more objects that require post-processing.
        }

        private void PostProcessLine(Line line)
        {
            // Calculate in case the line has points that are not owned by another container.
            // TODO: Low priority: This will probably become obsolete at one point (see rework in TODO document for Synthesizer project 2015-03).

            if (line.PointA.Parent == null)
            {
                line.PointA.CalculatedX = line.PointA.X + line.CalculatedX;
                line.PointA.CalculatedY = line.PointA.Y + line.CalculatedY;
            }

            if (line.PointB.Parent == null)
            {
                line.PointB.CalculatedX = line.PointB.X + line.CalculatedX;
                line.PointB.CalculatedY = line.PointB.Y + line.CalculatedY;
            }
        }

        private void PostProcessCurve(Curve sourceCurve)
        {
            // Calculate in case the curve has points that are not owned by another container.
            // TODO: Low priority: This will probably become obsolete at one point (see rework in TODO document for Synthesizer project 2015-03).

            if (sourceCurve.PointA.Parent == null)
            {
                sourceCurve.PointA.CalculatedX = sourceCurve.PointA.X + sourceCurve.CalculatedX;
                sourceCurve.PointA.CalculatedY = sourceCurve.PointA.Y + sourceCurve.CalculatedY;
            }

            if (sourceCurve.PointB.Parent == null)
            {
                sourceCurve.PointB.CalculatedX = sourceCurve.PointB.X + sourceCurve.CalculatedX;
                sourceCurve.PointB.CalculatedY = sourceCurve.PointB.Y + sourceCurve.CalculatedY;
            }

            var destPoints = new List<Point>(sourceCurve.LineCount + 1);

            float step = 1f / sourceCurve.LineCount;
            float t = 0;
            for (int i = 0; i < sourceCurve.LineCount + 1; i++)
            {
                float calculatedX;
                float calculatedY;

                Interpolator.Interpolate_Cubic_FromT(
                    sourceCurve.PointA.CalculatedX, sourceCurve.ControlPointA.CalculatedX, sourceCurve.ControlPointB.CalculatedX, sourceCurve.PointB.CalculatedX,
                    sourceCurve.PointA.CalculatedY, sourceCurve.ControlPointA.CalculatedY, sourceCurve.ControlPointB.CalculatedY, sourceCurve.PointB.CalculatedY,
                    t, out calculatedX, out calculatedY);

                var destPoint = new Point
                {
                    CalculatedX = calculatedX,
                    CalculatedY = calculatedY,
                    // Fill in meaningful values for the other properties.
                    X = calculatedX,
                    Y = calculatedY,
                    CalculatedVisible = false,
                    CalculatedLayer = sourceCurve.CalculatedLayer,
                    PointStyle = new PointStyle { Visible  = false }
                };

                destPoints.Add(destPoint);

                t += step;
            }

            var destLines = new List<Line>(sourceCurve.LineCount);

            for (int i = 0; i < destPoints.Count - 1; i++)
            {
                Point destPointA = destPoints[i];
                Point destPointB = destPoints[i + 1];

                var destLine = new Line
                {
                    PointA = destPointA,
                    PointB = destPointB,
                    // Fill in meaningful values for the other properties.
                    CalculatedVisible = true,
                    CalculatedZIndex = sourceCurve.CalculatedZIndex,
                    CalculatedLayer = sourceCurve.CalculatedLayer,
                    LineStyle = sourceCurve.LineStyle
                };

                destLines.Add(destLine);
            }

            sourceCurve.CalculatedLines = destLines;
            
            // TODO: Low priority: Yield over gesture-related properties from curve to the points and lines?
        }
    }
}
