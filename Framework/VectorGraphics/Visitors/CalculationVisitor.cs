using System.Collections.Generic;
using System.Linq;
using JJ.Framework.Exceptions;
using JJ.Framework.Mathematics;
using JJ.Framework.VectorGraphics.Drawing;
using JJ.Framework.VectorGraphics.Enums;
using JJ.Framework.VectorGraphics.Models.Elements;
// ReSharper disable SuggestBaseTypeForParameter

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

		private readonly HashSet<object> _generatedElements = new HashSet<object>();

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

			foreach (Element element in diagram.Elements.ToArray())
			{
				PostProcessPolymorphic(element);
			}

			IList<Element> orderedElements = ApplyExplicitZIndex(diagram);

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
			if (_generatedElements.Contains(element))
			{
				return;
			}

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
			Point sourceCurvePointA = sourceCurve.PointA;
			Point sourceCurvePointB = sourceCurve.PointB;
			Point sourceCurveControlPointA = sourceCurve.ControlPointA;
			Point sourceCurveControlPointB = sourceCurve.ControlPointB;

			if (sourceCurvePointA == null) throw new NullException(() => sourceCurve.PointA);
			if (sourceCurvePointB == null) throw new NullException(() => sourceCurve.PointB);
			if (sourceCurveControlPointA == null) throw new NullException(() => sourceCurve.ControlPointA);
			if (sourceCurveControlPointB == null) throw new NullException(() => sourceCurve.ControlPointB);

			IList<Line> destLines = sourceCurve.CalculatedLines;

			int newLineCount = sourceCurve.SegmentCount;
			int oldLineCount = destLines.Count;

			int oldLineLastIndex = oldLineCount - 1;
			int newLineLastIndex = newLineCount - 1;

			// Delete
			for (int i = oldLineCount - 1; i >= newLineCount; i--)
			{
				Line destLine = destLines[i];
				destLine.PointB.Dispose();
				destLine.Dispose();

				_generatedElements.Remove(destLine.PointB);
				_generatedElements.Remove(destLine);
			}

			// Create
			if (oldLineCount != newLineCount)
			{
				Point destPointA = oldLineCount == 0 ? CreateCurvePoint(sourceCurve) : destLines[oldLineLastIndex].PointA;

				for (int i = oldLineCount; i < newLineCount; i++)
				{
					Point destPointB = CreateCurvePoint(sourceCurve);
					Line destLine = CreateCurveLine(sourceCurve, destPointA, destPointB);
					destLines.Add(destLine);
					destPointA = destPointB;
				}
			}

			CalculatedValues sourceCurvePointA_CalculatedValues = sourceCurvePointA.CalculatedValues;
			CalculatedValues sourceCurvePointB_CalculatedValues = sourceCurvePointB.CalculatedValues;
			CalculatedValues sourceCurveControlPointA_CalculatedValues = sourceCurveControlPointA.CalculatedValues;
			CalculatedValues sourceCurveControlPointB_CalculatedValues = sourceCurveControlPointB.CalculatedValues;
			float ax = sourceCurvePointA_CalculatedValues.XInPixels;
			float acx = sourceCurveControlPointA_CalculatedValues.XInPixels;
			float bcx = sourceCurveControlPointB_CalculatedValues.XInPixels;
			float bx = sourceCurvePointB_CalculatedValues.XInPixels;
			float ay = sourceCurvePointA_CalculatedValues.YInPixels;
			float acy = sourceCurveControlPointA_CalculatedValues.YInPixels;
			float bcy = sourceCurveControlPointB_CalculatedValues.YInPixels;
			float by = sourceCurvePointB_CalculatedValues.YInPixels;

			// Update
			float step = 1f / newLineCount;
			float t = 0;
			for (int i = 0; i < newLineCount; i++)
			{
				Line destLine = destLines[i];
				UpdateCurveLine(sourceCurve, destLine);
				UpdateCurvePoint(destLine.PointA, ax, acx, bcx, bx, ay, acy, bcy, by, t);

				t += step;
			}

			// Last Point is not covered by the loop above.
			{
				Line destLine = destLines[newLineLastIndex];
				UpdateCurvePoint(destLine.PointB, ax, acx, bcx, bx, ay, acy, bcy, by, t);
			}
		}

		private void UpdateCurvePoint(Point destPoint, float ax, float acx, float bcx, float bx, float ay, float acy, float bcy, float by, float t)
		{
			Interpolator.Interpolate_Cubic_FromT(ax, acx, bcx, bx, ay, acy, bcy, by, t, out float x, out float y);

			CalculatedValues destPointCalculatedValues = destPoint.CalculatedValues;
			destPointCalculatedValues.XInPixels = x;
			destPointCalculatedValues.YInPixels = y;
		}

		private void UpdateCurveLine(Curve sourceCurve, Line destLine)
		{
			destLine.LineStyle = sourceCurve.LineStyle;
			destLine.Gestures = sourceCurve.Gestures;

			CalculatedValues sourceCalculatedValues = sourceCurve.CalculatedValues;
			CalculatedValues destCalculatedValues = destLine.CalculatedValues;

			destCalculatedValues.Visible = sourceCalculatedValues.Visible;
			destCalculatedValues.Enabled = sourceCalculatedValues.Enabled;
			destCalculatedValues.Layer = sourceCalculatedValues.Layer;

			// ZIndex is the exception to the rule when it comes to 
			// optimizing the value assignments of the generated elements.
			// Otherwise there would be a chicken and egg situation that we need to apply ZIndex before post processing,
			// and also afterwards, because it generates the output list (with the generated elements in it).
			destLine.ZIndex = sourceCurve.ZIndex;
		}

		private Line CreateCurveLine(Curve sourceCurve, Point destPointA, Point destPointB)
		{
			var destLine = new Line(sourceCurve.Diagram.Background)
			{
				PointA = destPointA,
				PointB = destPointB,
				Tag = "Curve Line",
			};
			_generatedElements.Add(destLine);

			return destLine;
		}

		private Point CreateCurvePoint(Curve sourceCurve)
		{
			var destPoint = new Point(sourceCurve.Diagram.Background)
			{
				Tag = "Curve Point"
			};

			destPoint.CalculatedValues.Visible = false;
			_generatedElements.Add(destPoint);

			return destPoint;
		}
	}
}
