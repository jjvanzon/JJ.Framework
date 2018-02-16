using System.Collections.Generic;
using System.Linq;
using JJ.Framework.Exceptions;
using JJ.Framework.Mathematics;
using JJ.Framework.VectorGraphics.Drawing;
using JJ.Framework.VectorGraphics.Enums;
using JJ.Framework.VectorGraphics.Models.Elements;
using JJ.Framework.VectorGraphics.Models.Styling;

namespace JJ.Framework.VectorGraphics.Visitors
{
	/// <summary>
	/// Takes a set of VectorGraphics elements that can have a hierarchy of child elements
	/// with relative positions and converts it to a flat list of objects
	/// with absolute positions and Z-index applied.
	/// </summary>
	internal class CalculationVisitor : ElementVisitorBase
	{
		private Diagram _diagram;
		private float _currentParentX;
		private float _currentParentY;
		private int _currentZIndex;
		private int _currentLayer;

		/// <summary> Returns elements ordered by calculated Z-Index. </summary>
		public IList<Element> Execute(Diagram diagram)
		{
			_diagram = diagram ?? throw new NullException(() => diagram);
			_currentParentX = 0;
			_currentParentY = 0;
			_currentZIndex = 0;
			_currentLayer = 0;

			switch (diagram.Position.ScaleModeEnum)
			{
				case ScaleModeEnum.Pixels:
				case ScaleModeEnum.ViewPort:
					diagram.Background.Position.X = diagram.Position.ScaledX;
					diagram.Background.Position.Y = diagram.Position.ScaledY;
					diagram.Background.Position.Width = diagram.Position.ScaledWidth;
					diagram.Background.Position.Height = diagram.Position.ScaledHeight;
					break;

				default:
					throw new ValueNotSupportedException(diagram.Position.ScaleModeEnum);

			}




			VisitPolymorphic(diagram.Background);

			IList<Element> orderedElements = ApplyExplicitZIndex(diagram);

			foreach (Element element in diagram.Elements.ToArray())
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
															 .ThenBy(x => x.CalculatedValues.ZIndex)
															 .ToArray();
			int i = 1;
			foreach (Element element in orderedElements)
			{
				element.CalculatedValues.ZIndex = i++;
			}

			return orderedElements;
		}

		// Visit

		protected override void VisitPolymorphic(Element element)
		{
			// It seems too coincidental that determining Visible and Enabled works this way. But it does.
			// I would think I would need to put variables on the call stack or work with a new virtual style on each stack frame,
			// but apparently this works too.

			element.CalculatedValues.Visible = element.Visible;
			if (element.Parent != null)
			{
				element.CalculatedValues.Visible &= element.Parent.CalculatedValues.Visible;
			}

			element.CalculatedValues.Enabled = element.Enabled;
			if (element.Parent != null)
			{
				element.CalculatedValues.Enabled &= element.Parent.CalculatedValues.Enabled;
			}

			element.CalculatedValues.Layer = _currentLayer;
			element.CalculatedValues.ZIndex = _currentZIndex++;

			// Relative to Absolute
			element.CalculatedValues.XInPixels = element.Position.X + _currentParentX;
			element.CalculatedValues.YInPixels = element.Position.Y + _currentParentY;
			element.CalculatedValues.WidthInPixels = element.Position.Width;
			element.CalculatedValues.HeightInPixels = element.Position.Height;

			// Scale to Pixels
			element.CalculatedValues.XInPixels = _diagram.Position.XToPixels(element.CalculatedValues.XInPixels);
			element.CalculatedValues.YInPixels = _diagram.Position.YToPixels(element.CalculatedValues.YInPixels);
			element.CalculatedValues.WidthInPixels = _diagram.Position.WidthToPixels(element.CalculatedValues.WidthInPixels);
			element.CalculatedValues.HeightInPixels = _diagram.Position.HeightToPixels(element.CalculatedValues.HeightInPixels);

			// Correct the Bounds
			element.CalculatedValues.XInPixels = BoundsHelper.CorrectCoordinate(element.CalculatedValues.XInPixels);
			element.CalculatedValues.YInPixels = BoundsHelper.CorrectCoordinate(element.CalculatedValues.YInPixels);
			element.CalculatedValues.WidthInPixels = BoundsHelper.CorrectLength(element.CalculatedValues.WidthInPixels);
			element.CalculatedValues.HeightInPixels = BoundsHelper.CorrectLength(element.CalculatedValues.HeightInPixels);

			base.VisitPolymorphic(element);
		}

		protected override void VisitChildren(Element parentElement)
		{
			_currentParentX += parentElement.Position.X;
			_currentParentY += parentElement.Position.Y;
			_currentLayer++;

			base.VisitChildren(parentElement);

			_currentParentX -= parentElement.Position.X;
			_currentParentY -= parentElement.Position.Y;
			_currentLayer--;
		}

		// Post Process

		private void PostProcessPolymorphic(Element element)
		{
			if (element is Curve curve)
			{
				PostProcessCurve(curve);
			}
		}

		private void PostProcessCurve(Curve sourceCurve)
		{
			if (sourceCurve.PointA == null) throw new NullException(() => sourceCurve.PointA);
			if (sourceCurve.PointB == null) throw new NullException(() => sourceCurve.PointB);
			if (sourceCurve.ControlPointA == null) throw new NullException(() => sourceCurve.ControlPointA);
			if (sourceCurve.ControlPointB == null) throw new NullException(() => sourceCurve.ControlPointB);

			foreach (Line calculatedLine in sourceCurve.CalculatedLines)
			{
				calculatedLine.PointA.Dispose();
				calculatedLine.PointB.Dispose();
				calculatedLine.Dispose();
			}

			var destPoints = new List<Point>(sourceCurve.SegmentCount + 1);

			float step = 1f / sourceCurve.SegmentCount;
			float t = 0;
			for (int i = 0; i < sourceCurve.SegmentCount + 1; i++)
			{
				Interpolator.Interpolate_Cubic_FromT(
					sourceCurve.PointA.CalculatedValues.XInPixels,
					sourceCurve.ControlPointA.CalculatedValues.XInPixels,
					sourceCurve.ControlPointB.CalculatedValues.XInPixels,
					sourceCurve.PointB.CalculatedValues.XInPixels,
					sourceCurve.PointA.CalculatedValues.YInPixels,
					sourceCurve.ControlPointA.CalculatedValues.YInPixels,
					sourceCurve.ControlPointB.CalculatedValues.YInPixels,
					sourceCurve.PointB.CalculatedValues.YInPixels,
					t,
					out float calculatedX,
					out float calculatedY);

				var destPoint = new Point(sourceCurve.Diagram.Background)
				{
					PointStyle = new PointStyle { Visible = false }
				};
				destPoint.Position.X = calculatedX;
				destPoint.Position.Y = calculatedY;
				destPoint.CalculatedValues.XInPixels = calculatedX;
				destPoint.CalculatedValues.YInPixels = calculatedY;
				// Fill in meaningful values for the other properties.
				destPoint.CalculatedValues.Visible = false;
				destPoint.CalculatedValues.Layer = sourceCurve.CalculatedValues.Layer;

				destPoints.Add(destPoint);

				t += step;
			}

			var destLines = new List<Line>(sourceCurve.SegmentCount);

			for (int i = 0; i < destPoints.Count - 1; i++)
			{
				Point destPointA = destPoints[i];
				Point destPointB = destPoints[i + 1];

				var destLine = new Line(sourceCurve.Diagram.Background)
				{
					PointA = destPointA,
					PointB = destPointB,
					LineStyle = sourceCurve.LineStyle
				};
				// Fill in meaningful values for the other properties.
				destLine.CalculatedValues.Visible = true;
				destLine.CalculatedValues.ZIndex = sourceCurve.CalculatedValues.ZIndex;
				destLine.CalculatedValues.Layer = sourceCurve.CalculatedValues.Layer;

				destLines.Add(destLine);
			}

			sourceCurve.CalculatedLines = destLines;

			// TODO: Low priority: Yield over gesture-related properties from curve to the points and lines?
		}
	}
}
