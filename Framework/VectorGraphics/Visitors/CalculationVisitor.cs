using System.Collections.Generic;
using System.Linq;
using JJ.Framework.Exceptions;
using JJ.Framework.Mathematics;
using JJ.Framework.VectorGraphics.Drawing;
using JJ.Framework.VectorGraphics.Enums;
using JJ.Framework.VectorGraphics.Models.Elements;

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
			Point sourceCurvePointA = sourceCurve.PointA;
			Point sourceCurvePointB = sourceCurve.PointB;
			Point sourceCurveControlPointA = sourceCurve.ControlPointA;
			Point sourceCurveControlPointB = sourceCurve.ControlPointB;

			if (sourceCurvePointA == null) throw new NullException(() => sourceCurve.PointA);
			if (sourceCurvePointB == null) throw new NullException(() => sourceCurve.PointB);
			if (sourceCurveControlPointA == null) throw new NullException(() => sourceCurve.ControlPointA);
			if (sourceCurveControlPointB == null) throw new NullException(() => sourceCurve.ControlPointB);

			IList<Line> destLines = sourceCurve.CalculatedLines;

			// TODO: Remove outcommented code.

			int newLineCount = sourceCurve.SegmentCount;
			//int newPointCount = newLineCount + 1;

			int oldLineCount = destLines.Count;
			//int oldPointCount = oldLineCount + 1;

			//int minLineCount = Math.Min(newLineCount, oldLineCount);
			//int minPointCount = minLineCount + 1;

			int oldLineLastIndex = oldLineCount - 1;
			int newLineLastIndex = newLineCount - 1;

			// Delete
			for (int i = oldLineCount - 1; i >= newLineCount; i--)
			{
				Line destLine = destLines[i];
				destLine.PointB.Dispose();
				destLine.Dispose();
			}

			// Create
			{
				Point destPointA;
				if (oldLineCount == 0)
				{
					destPointA = CreateCurvePoint(sourceCurve);
				}
				else
				{
					destPointA = destLines[oldLineLastIndex].PointA;
				}

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
			float sourceCurvePointA_XInPixels = sourceCurvePointA_CalculatedValues.XInPixels;
			float sourceCurveControlPointA_XInPixels = sourceCurveControlPointA_CalculatedValues.XInPixels;
			float sourceCurveControlPointB_XInPixels = sourceCurveControlPointB_CalculatedValues.XInPixels;
			float sourceCurvePointB_XInPixels = sourceCurvePointB_CalculatedValues.XInPixels;
			float sourceCurvePointA_YInPixels = sourceCurvePointA_CalculatedValues.YInPixels;
			float sourceCurveControlPointA_YInPixels = sourceCurveControlPointA_CalculatedValues.YInPixels;
			float sourceCurveControlPointB_YInPixels = sourceCurveControlPointB_CalculatedValues.YInPixels;
			float sourceCurvePointB_YInPixels = sourceCurvePointB_CalculatedValues.YInPixels;

			// Update
			float step = 1f / newLineCount;
			float t = 0;
			for (int i = 0; i < newLineCount; i++)
			{
				Interpolator.Interpolate_Cubic_FromT(
					sourceCurvePointA_XInPixels,
					sourceCurveControlPointA_XInPixels,
					sourceCurveControlPointB_XInPixels,
					sourceCurvePointB_XInPixels,
					sourceCurvePointA_YInPixels,
					sourceCurveControlPointA_YInPixels,
					sourceCurveControlPointB_YInPixels,
					sourceCurvePointB_YInPixels,
					t,
					out float calculatedX,
					out float calculatedY);

				CalculatedValues destPointCalculatedValues = destLines[i].PointA.CalculatedValues;
				destPointCalculatedValues.XInPixels = calculatedX;
				destPointCalculatedValues.YInPixels = calculatedY;

				//destPoint.Position.X = calculatedX;
				//destPoint.Position.Y = calculatedY;

				t += step;
			}

			// Last Point is not covered by the loop above.
			{
				Interpolator.Interpolate_Cubic_FromT(
					sourceCurvePointA_XInPixels,
					sourceCurveControlPointA_XInPixels,
					sourceCurveControlPointB_XInPixels,
					sourceCurvePointB_XInPixels,
					sourceCurvePointA_YInPixels,
					sourceCurveControlPointA_YInPixels,
					sourceCurveControlPointB_YInPixels,
					sourceCurvePointB_YInPixels,
					t,
					out float calculatedX,
					out float calculatedY);

				CalculatedValues pointCalculatedValues = destLines[newLineLastIndex].PointB.CalculatedValues;
				pointCalculatedValues.XInPixels = calculatedX;
				pointCalculatedValues.YInPixels = calculatedY;

				//destPoint.Position.X = calculatedX;
				//destPoint.Position.Y = calculatedY;
			}
		}

		private static Line CreateCurveLine(Curve sourceCurve, Point destPointA, Point destPointB)
		{
			var destLine = new Line(sourceCurve.Diagram.Background)
			{
				PointA = destPointA,
				PointB = destPointB,
				LineStyle = sourceCurve.LineStyle,
				Gestures = sourceCurve.Gestures
			};

			CalculatedValues destLineCalculatedValues = destLine.CalculatedValues;
			CalculatedValues sourceCurveCalculatedValues = sourceCurve.CalculatedValues;
			destLineCalculatedValues.Visible = sourceCurveCalculatedValues.Visible;
			destLineCalculatedValues.ZIndex = sourceCurveCalculatedValues.ZIndex;
			destLineCalculatedValues.Layer = sourceCurveCalculatedValues.Layer;
#if DEBUG
			destLine.Tag = "Curve Line";
#endif
			return destLine;
		}

		private Point CreateCurvePoint(Curve sourceCurve)
		{
			// ReSharper disable once UseObjectOrCollectionInitializer
			var destPoint = new Point(sourceCurve.Diagram.Background);

			destPoint.PointStyle.Visible = false;
			destPoint.CalculatedValues.Visible = false;
			destPoint.CalculatedValues.Layer = _diagram.Background.CalculatedValues.Layer + 1;
#if DEBUG
			destPoint.Tag = "Curve Point";
#endif
			return destPoint;
		}
	}
}
