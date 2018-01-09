using System.Drawing;
using JJ.Framework.Exceptions;
using JJ.Framework.Presentation.VectorGraphics.Models.Styling;
using Font = System.Drawing.Font;
using VectorGraphicsElements = JJ.Framework.Presentation.VectorGraphics.Models.Elements;

namespace JJ.Framework.Presentation.Drawing
{
	public static class VectorGraphicsDrawer
	{
		public static void Draw(VectorGraphicsElements.Diagram diagram, Graphics destGraphics)
		{
			if (diagram == null) throw new NullException(() => diagram);
			if (destGraphics == null) throw new NullException(() => destGraphics);

			foreach (VectorGraphicsElements.Element element in diagram.EnumerateElementsByZIndex())
			{
				DrawPolymorphic(element, destGraphics);
			}
		}

		private static void DrawPolymorphic(VectorGraphicsElements.Element sourceElement, Graphics destGraphics)
		{
			switch (sourceElement)
			{
				case VectorGraphicsElements.Point sourcePoint:
					DrawPoint(sourcePoint, destGraphics);
					return;

				case VectorGraphicsElements.Line sourceLine:
					DrawLine(sourceLine, destGraphics);
					return;

				case VectorGraphicsElements.Rectangle sourceRectangle:
					DrawRectangle(sourceRectangle, destGraphics);
					return;

				case VectorGraphicsElements.Label sourceLabel:
					DrawLabel(sourceLabel, destGraphics);
					return;

				case VectorGraphicsElements.Curve sourceCurve:
					DrawCurve(sourceCurve, destGraphics);
					return;

				case VectorGraphicsElements.Ellipse sourceEllipse:
					DrawEllipse(sourceEllipse, destGraphics);
					return;

				default:
					throw new UnexpectedTypeException(() => sourceElement);
			}
		}

		private static void DrawPoint(VectorGraphicsElements.Point sourcePoint, Graphics destGraphics)
		{
			if (!sourcePoint.CalculatedValues.Visible || !sourcePoint.PointStyle.Visible)
			{
				return;
			}

			RectangleF destRectangle = sourcePoint.ToSystemDrawingRectangleF();
			using (Brush destBrush = sourcePoint.PointStyle.ToSystemDrawingBrush())
			{
				destGraphics.FillEllipse(destBrush, destRectangle);
			}
		}

		private static void DrawLine(VectorGraphicsElements.Line sourceLine, Graphics destGraphics)
		{
			if (!sourceLine.CalculatedValues.Visible || !sourceLine.LineStyle.Visible)
			{
				return;
			}

			if (sourceLine.PointA == null) throw new NullException(() => sourceLine.PointA);
			if (sourceLine.PointB == null) throw new NullException(() => sourceLine.PointB);

			float x1 = BoundsHelper.CorrectCoordinate(sourceLine.PointA.CalculatedValues.XInPixels);
			float y1 = BoundsHelper.CorrectCoordinate(sourceLine.PointA.CalculatedValues.YInPixels);
			float x2 = BoundsHelper.CorrectCoordinate(sourceLine.PointB.CalculatedValues.XInPixels);
			float y2 = BoundsHelper.CorrectCoordinate(sourceLine.PointB.CalculatedValues.YInPixels);

			using (Pen destPen = sourceLine.LineStyle.ToSystemDrawing())
			{
				destGraphics.DrawLine(destPen, x1, y1, x2, y2);
			}
		}

		private static void DrawRectangle(VectorGraphicsElements.Rectangle sourceRectangle, Graphics destGraphics)
		{
			if (!sourceRectangle.CalculatedValues.Visible)
			{
				return;
			}

			// Draw Back
			if (sourceRectangle.Style.BackStyle.Visible)
			{
				RectangleF destRectangle = sourceRectangle.ToSystemDrawingRectangleF();

				using (Brush destBrush = sourceRectangle.Style.BackStyle.ToSystemDrawing())
				{
					destGraphics.FillRectangle(destBrush, destRectangle);
				}
			}

			// Draw Rectangle
			float left = BoundsHelper.CorrectCoordinate(sourceRectangle.CalculatedValues.XInPixels);
			float top = BoundsHelper.CorrectCoordinate(sourceRectangle.CalculatedValues.YInPixels);
			float width = BoundsHelper.CorrectLength(sourceRectangle.CalculatedValues.WidthInPixels);
			float height = BoundsHelper.CorrectLength(sourceRectangle.CalculatedValues.HeightInPixels);

			LineStyle lineStyle = sourceRectangle.Style.LineStyle;
			if (lineStyle != null)
			{
				if (lineStyle.Visible)
				{
					using (Pen destPen = lineStyle.ToSystemDrawing())
					{
						destGraphics.DrawRectangle(destPen, left, top, width, height);
					}
				}
			}
			else
			{
				// Draw 4 Border Lines (with different styles)

				// TODO: You would think that bounds check is unnecessary here.
				float right = left + width;
				float bottom = top + height;

				var destTopLeftPointF = new PointF(left, top);
				var destTopRightPointF = new PointF(right, top);
				var destBottomRightPointF = new PointF(right, bottom);
				var destBottomLeftPointF = new PointF(left, bottom);

				using (Pen destTopPen = sourceRectangle.Style.TopLineStyle.ToSystemDrawing())
				{
					destGraphics.DrawLine(destTopPen, destTopLeftPointF, destTopRightPointF);
				}

				using (Pen destRightPen = sourceRectangle.Style.RightLineStyle.ToSystemDrawing())
				{
					destGraphics.DrawLine(destRightPen, destTopRightPointF, destBottomRightPointF);
				}

				using (Pen destBottomPen = sourceRectangle.Style.BottomLineStyle.ToSystemDrawing())
				{
					destGraphics.DrawLine(destBottomPen, destBottomRightPointF, destBottomLeftPointF);
				}

				using (Pen destLeftPen = sourceRectangle.Style.LeftLineStyle.ToSystemDrawing())
				{
					destGraphics.DrawLine(destLeftPen, destBottomLeftPointF, destTopLeftPointF);
				}
			}
		}

		private static void DrawLabel(VectorGraphicsElements.Label sourceLabel, Graphics destGraphics)
		{
			if (!sourceLabel.CalculatedValues.Visible)
			{
				return;
			}

			float x = BoundsHelper.CorrectCoordinate(sourceLabel.CalculatedValues.XInPixels);
			float y = BoundsHelper.CorrectCoordinate(sourceLabel.CalculatedValues.YInPixels);

			// Calling CorrectCoordinate instead of CorrectLength,
			// because apparently System.Drawing hates it when I correct 0 to 1E-9f.
			float width = BoundsHelper.CorrectCoordinate(sourceLabel.CalculatedValues.WidthInPixels);
			float height = BoundsHelper.CorrectCoordinate(sourceLabel.CalculatedValues.HeightInPixels);

			var destRectangle = new RectangleF(x, y, width, height);

			using (Font destFont = sourceLabel.TextStyle.Font.ToSystemDrawing(destGraphics.DpiX))
			{
				using (Brush destBrush = sourceLabel.TextStyle.ToSystemDrawingBrush())
				{
					using (StringFormat destStringFormat = sourceLabel.TextStyle.ToSystemDrawingStringFormat())
					{
						destGraphics.DrawString(sourceLabel.Text, destFont, destBrush, destRectangle, destStringFormat);
					}
				}
			}
		}

		private static void DrawCurve(VectorGraphicsElements.Curve sourceCurve, Graphics destGraphics)
		{
			foreach (VectorGraphicsElements.Line calculatedLine in sourceCurve.CalculatedLines)
			{
				DrawLine(calculatedLine, destGraphics);
			}
		}

		private static void DrawEllipse(VectorGraphicsElements.Ellipse sourceEllipse, Graphics destGraphics)
		{
			if (!sourceEllipse.CalculatedValues.Visible)
			{
				return;
			}

			RectangleF destRectangle = sourceEllipse.ToSystemDrawingRectangleF();

			using (Brush destBrush = sourceEllipse.Style.BackStyle.ToSystemDrawing())
			{
				destGraphics.FillEllipse(destBrush, destRectangle);
			}

			using (Pen destPen = sourceEllipse.Style.LineStyle.ToSystemDrawing())
			{
				destGraphics.DrawEllipse(destPen, destRectangle);
			}
		}
	}
}