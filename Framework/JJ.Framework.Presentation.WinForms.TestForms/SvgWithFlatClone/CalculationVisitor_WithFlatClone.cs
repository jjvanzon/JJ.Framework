using JJ.Framework.Presentation.Svg.Models;
using JJ.Framework.Presentation.Svg.Models.Elements;
using JJ.Framework.Presentation.Svg.Visitors;
using JJ.Framework.Reflection.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.WinForms.TestForms.SvgWithFlatClone
{
    /// <summary>
    /// Takes a set of SVG elements that can have a hierarchy of child elements
    /// with relative positions and converts it to a flat list of objects
    /// with absolute positions and Z-index applied.
    /// </summary>
    internal class CalculationVisitor_WithFlatClone : ElementVisitorBase
    {
        //private Dictionary<Element, Element> _convertedElementDictionary;
        //private float _currentParentCenterX;
        //private float _currentParentCenterY;
        //private int _layer;

        public IList<Element> Execute(Element element)
        {
            if (element == null) throw new NullException(() => element);

            return new Element[0];

            //_convertedElementDictionary = new Dictionary<Element, Element>();
            //_currentParentCenterX = 0;
            //_currentParentCenterY = 0;
            //_layer = 0;

            //// Build dest tree.
            //VisitPolymorphic(element);

            //// Convert secondary references.
            //foreach (var entry in _convertedElementDictionary.ToArray())
            //{
            //    ConvertReferencesPolymorphic(entry.Key, entry.Value);
            //}

            //// Apply z-index.
            //IList<Element> destElements = _convertedElementDictionary.Values
            //                                                         .OrderBy(x => x.ZIndex)
            //                                                         .ThenBy(x => x.CalculatedLayer)
            //                                                         .ToArray();
            //return destElements;
        }

        //protected override void VisitChildren(Element parentElement)
        //{
        //    _currentParentCenterX += parentElement.X;
        //    _currentParentCenterY += parentElement.Y;
        //    _layer++;

        //    base.VisitChildren(parentElement);

        //    _currentParentCenterX -= parentElement.X;
        //    _currentParentCenterY -= parentElement.Y;
        //    _layer--;
        //}

        //protected override void VisitPoint(Point sourcePoint)
        //{
        //    // Invisible point must be 'styled',
        //    // because it must be absolutely positioned,
        //    // because it can be referenced by a line.
        //    //if (!sourcePoint.Visible || !sourcePoint.PointStyle.Visible)
        //    //{
        //    //    return;
        //    //}

        //    Point destPoint = ConvertPoint(sourcePoint);

        //    base.VisitPoint(sourcePoint);
        //}

        //protected override void VisitLine(Line sourceLine)
        //{
        //    if (!sourceLine.Visible || !sourceLine.LineStyle.Visible)
        //    {
        //        return;
        //    }

        //    Line destLine = ConvertLine(sourceLine);

        //    base.VisitLine(sourceLine);
        //}

        //protected override void VisitRectangle(Rectangle sourceRectangle)
        //{
        //    if (!sourceRectangle.Visible)
        //    {
        //        return;
        //    }

        //    Rectangle destRectangle = ConvertRectangle(sourceRectangle);

        //    base.VisitRectangle(sourceRectangle);
        //}

        //protected override void VisitLabel(Label sourceLabel)
        //{
        //    if (!sourceLabel.Visible)
        //    {
        //        return;
        //    }

        //    Label destLabel = ConvertLabel(sourceLabel);

        //    base.VisitLabel(sourceLabel);
        //}

        //private Point ConvertPoint(Point sourcePoint)
        //{
        //    Element destElement;
        //    if (_convertedElementDictionary.TryGetValue(sourcePoint, out destElement))
        //    {
        //        return (Point)destElement;
        //    }

        //    var destPoint = new Point
        //    {
        //        X = sourcePoint.X + _currentParentCenterX,
        //        Y = sourcePoint.Y + _currentParentCenterY,
        //        ZIndex = sourcePoint.ZIndex,
        //        PointStyle = sourcePoint.PointStyle,
        //        CalculatedLayer = _layer
        //    };

        //    _convertedElementDictionary.Add(sourcePoint, destPoint);

        //    return destPoint;
        //}

        //private Line ConvertLine(Line sourceLine)
        //{
        //    Element destElement;
        //    if (_convertedElementDictionary.TryGetValue(sourceLine, out destElement))
        //    {
        //        return (Line)destElement;
        //    }

        //    var destLine = new Line
        //    {
        //        LineStyle = sourceLine.LineStyle,
        //        ZIndex = sourceLine.ZIndex,
        //        CalculatedLayer = _layer
        //    };

        //    _convertedElementDictionary.Add(sourceLine, destLine);

        //    return destLine;
        //}

        //private Rectangle ConvertRectangle(Rectangle sourceRectangle)
        //{
        //    Element destElement;
        //    if (_convertedElementDictionary.TryGetValue(sourceRectangle, out destElement))
        //    {
        //        return (Rectangle)destElement;
        //    }

        //    var destRectangle = new Rectangle
        //    {
        //        X = sourceRectangle.X + _currentParentCenterX,
        //        Y = sourceRectangle.Y + _currentParentCenterY,
        //        Width = sourceRectangle.Width,
        //        Height = sourceRectangle.Height,
        //        ZIndex = sourceRectangle.ZIndex,
        //        BackStyle = sourceRectangle.BackStyle,
        //        BottomLineStyle = sourceRectangle.BottomLineStyle,
        //        LeftLineStyle = sourceRectangle.LeftLineStyle,
        //        RightLineStyle = sourceRectangle.RightLineStyle,
        //        TopLineStyle = sourceRectangle.TopLineStyle,
        //        CalculatedLayer = _layer
        //    };

        //    _convertedElementDictionary.Add(sourceRectangle, destRectangle);

        //    return destRectangle;
        //}

        //private Label ConvertLabel(Label sourceLabel)
        //{
        //    Element destElement;
        //    if (_convertedElementDictionary.TryGetValue(sourceLabel, out destElement))
        //    {
        //        return (Label)destElement;
        //    }

        //    var destLabel = new Label
        //    {
        //        Rectangle = ConvertRectangle(sourceLabel.Rectangle),
        //        Text = sourceLabel.Text,
        //        TextStyle = sourceLabel.TextStyle,
        //        ZIndex = sourceLabel.ZIndex,
        //        CalculatedLayer = _layer
        //    };

        //    _convertedElementDictionary.Add(sourceLabel, destLabel);

        //    return destLabel;
        //}

        //private void ConvertReferencesPolymorphic(Element sourceElement, Element destElement)
        //{
        //    var sourceLine = sourceElement as Line;
        //    if (sourceLine != null)
        //    {
        //        var destLine = (Line)destElement;
        //        ConvertReferencesForLine(sourceLine, destLine);
        //    }

        //    // No more object with references to convert (yet).
        //}

        //private void ConvertReferencesForLine(Line sourceLine, Line destLine)
        //{
        //    // Convert, do not just get, in case the lines have points that are not owned by another container.
        //    destLine.PointA = ConvertPoint(sourceLine.PointA);
        //    destLine.PointB = ConvertPoint(sourceLine.PointB);
        //}
    }
}
