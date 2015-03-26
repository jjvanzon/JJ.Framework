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
    /// with absolute positions and Z-index applied.
    /// </summary>
    public class CalculationVisitor : ElementVisitorBase
    {
        // Public for tests.

        private HashSet<ElementBase> _calculatedElements;
        private float _currentParentX;
        private float _currentParentY;
        private int _layer;

        /// <summary>
        /// Returns elements ordered by calculated Z-Index.
        /// </summary>
        public IList<ElementBase> Execute(ElementBase element)
        {
            if (element == null) throw new NullException(() => element);

            _calculatedElements = new HashSet<ElementBase>();
            _currentParentX = 0;
            _currentParentY = 0;
            _layer = 0;

            VisitPolymorphic(element);


            // Apply z-index.
            IList<ElementBase> orderedElements = _calculatedElements.OrderBy(x => x.ZIndex).ThenBy(x => x.CalculatedLayer).ToArray();
            for (int i = 0; i < orderedElements.Count; i++)
			{
                ElementBase element2 = orderedElements[i];

                // Also: calculate references. Why loop twice?
                CalculateReferencesPolymorphic(element2);

                element2.CalculatedZIndex = i;
			}

            return orderedElements;
        }

        // Visit

        protected override void VisitChildren(ElementBase parentElement)
        {
            _currentParentX += parentElement.X;
            _currentParentY += parentElement.Y;
            _layer++;

            base.VisitChildren(parentElement);

            _currentParentX -= parentElement.X;
            _currentParentY -= parentElement.Y;
            _layer--;
        }

        protected override void VisitPoint(Point sourcePoint)
        {
            // Do not check visibility, because invisible point must be recalculated,
            // because it must be absolutely positioned,
            // because it can be referenced by a line.

            CalculatePoint(sourcePoint);

            base.VisitPoint(sourcePoint);
        }

        protected override void VisitLine(Line sourceLine)
        {
            if (!sourceLine.Visible || !sourceLine.LineStyle.Visible)
            {
                return;
            }

            CalculateLine(sourceLine);

            base.VisitLine(sourceLine);
        }

        protected override void VisitRectangle(Rectangle sourceRectangle)
        {
            if (!sourceRectangle.Visible)
            {
                return;
            }

            CalculateRectangle(sourceRectangle);

            base.VisitRectangle(sourceRectangle);
        }

        protected override void VisitLabel(Label sourceLabel)
        {
            if (!sourceLabel.Visible)
            {
                return;
            }

            CalculateLabel(sourceLabel);

            base.VisitLabel(sourceLabel);
        }

        // Calculate

        private void CalculatePoint(Point point)
        {
            if (_calculatedElements.Contains(point))
            {
                return;
            }

            point.CalculatedX = point.X + _currentParentX;
            point.CalculatedY = point.Y + _currentParentY;
            point.CalculatedLayer = _layer;

            _calculatedElements.Add(point);
        }

        private void CalculateLine(Line line)
        {
            if (_calculatedElements.Contains(line))
            {
                return;
            }

            line.CalculatedLayer = _layer;

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
            rectangle.CalculatedLayer = _layer;

            _calculatedElements.Add(rectangle);
        }

        private void CalculateLabel(Label label)
        {
            if (_calculatedElements.Contains(label))
            {
                return;
            }

            // TODO: Strange: there is ambiguity about label.X and label.Y and the label's rectangle X and Y.
            label.CalculatedX = label.X + _currentParentX;
            label.CalculatedY = label.Y + _currentParentY;
            label.CalculatedLayer = _layer;

            _calculatedElements.Add(label);
        }

        // CalculateReferences

        private void CalculateReferencesPolymorphic(ElementBase element)
        {
            var line = element as Line;
            if (line != null)
            {
                CalculateReferencesForLine(line);
            }

            var label = element as Label;
            if (label != null)
            {
                CalculateReferencesForLabel(label);
            }

            // No more object with references to convert (yet).
        }

        private void CalculateReferencesForLine(Line line)
        {
            // Calculate in case the line has points that are not owned by another container.

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

        private void CalculateReferencesForLabel(Label label)
        {
            // Calculate, do not just get, in case the label has a rectangel that is not owned by another container.
            //CalculateRectangle(label.Rectangle);

            if (label.Rectangle.Parent == null)
            {
                // TODO: Strange: there is ambiguity about label.X and label.Y and the label's rectangle X and Y.
                label.Rectangle.CalculatedX = label.Rectangle.X + label.CalculatedX;
                label.Rectangle.CalculatedY = label.Rectangle.Y + label.CalculatedY;
            }
        }
    }
}
