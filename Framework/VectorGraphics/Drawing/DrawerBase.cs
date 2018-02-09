using System;
using JJ.Framework.Exceptions;
using JJ.Framework.VectorGraphics.Models.Elements;
using JJ.Framework.VectorGraphics.Models.Styling;

namespace JJ.Framework.VectorGraphics.Drawing
{
	/// <summary>
	/// The base will corect coordinates and sizes to be within
	/// certain bounds and sizes to be a minimum positive value.
	/// Coordinates minimally -1 x 10^9 and maximally 1 x 10^9
	/// Sizes at least 1 x 10^-9.
	/// </summary>
	public abstract class DrawerBase : IDrawer
	{
		protected abstract void DrawLine(float x1, float y1, float x2, float y2, LineStyle lineStyle);
		protected abstract void FillRectangle(float x, float y, float width, float height, BackStyle backStyle);
		protected abstract void DrawRectangle(float x, float y, float width, float height, LineStyle lineStyle);
		protected abstract void DrawLabel(string text, float x, float y, float width, float height, TextStyle textStyle);
		protected abstract void DrawEllipse(float x, float y, float width, float height, LineStyle lineStyle);
		protected abstract void FillEllipse(float x, float y, float width, float height, BackStyle backStyle);
		protected abstract void DrawPictureUnscaledUnclipped(object picture, int x, int y);
		protected abstract void DrawPictureClipped(object picture, int x, int y, int width, int height);
		protected abstract void DrawPictureScaled(object picture, int x, int y, int width, int height);
		protected abstract void DrawPictureScaledWithColorMatrix(object picture, int x, int y, int width, int height, float[][] colorMatrix);
		protected abstract void DrawPictureClippedWithColorMatrix(object picture, int x, int y, int width, int height, float[][] colorMatrix);
		protected abstract void DrawPictureUnscaledUnclippedWithColorMatrix(object picture, int x, int y, float[][] colorMatrix);

		public void Draw(Diagram diagram)
		{
			if (diagram == null) throw new ArgumentNullException(nameof(diagram));

			foreach (Element element in diagram.EnumerateElementsByZIndex())
			{
				DrawPolymorphic(element);
			}
		}

		private void DrawPolymorphic(Element sourceElement)
		{
			switch (sourceElement)
			{
				case Curve sourceCurve:
					DrawCurve(sourceCurve);
					break;

				case Point sourcePoint:
					DrawPoint(sourcePoint);
					break;

				case Line sourceLine:
					DrawLine(sourceLine);
					break;

				case Rectangle sourceRectangle:
					DrawRectangle(sourceRectangle);
					break;

				case Label sourceLabel:
					DrawLabel(sourceLabel);
					break;

				case Ellipse sourceEllipse:
					DrawEllipse(sourceEllipse);
					break;

				case Picture sourcePicture:
					DrawPicture(sourcePicture);
					break;

				default:
					throw new UnexpectedTypeException(() => sourceElement);
			}
		}

		private void DrawCurve(Curve sourceCurve)
		{
			foreach (Line calculatedLine in sourceCurve.CalculatedLines)
			{
				DrawLine(calculatedLine);
			}
		}

		private void DrawPoint(Point sourcePoint)
		{
			if (!sourcePoint.CalculatedValues.Visible || !sourcePoint.PointStyle.Visible)
			{
				return;
			}

			float pointWidth = BoundsHelper.CorrectLength(sourcePoint.PointStyle.Width);
			float x = BoundsHelper.CorrectCoordinate(sourcePoint.CalculatedValues.XInPixels - pointWidth / 2f);
			float y = BoundsHelper.CorrectCoordinate(sourcePoint.CalculatedValues.YInPixels - pointWidth / 2f);

			var backStyle = new BackStyle { Color = sourcePoint.PointStyle.Color };

			FillEllipse(x, y, pointWidth, pointWidth, backStyle);
		}

		private void DrawLine(Line sourceLine)
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

			DrawLine(x1, y1, x2, y2, sourceLine.LineStyle);
		}

		private void DrawRectangle(Rectangle sourceRectangle)
		{
			if (!sourceRectangle.CalculatedValues.Visible)
			{
				return;
			}

			CalculatedValues calculatedValues = sourceRectangle.CalculatedValues;

			float x = BoundsHelper.CorrectCoordinate(calculatedValues.XInPixels);
			float y = BoundsHelper.CorrectCoordinate(calculatedValues.YInPixels);
			float width = BoundsHelper.CorrectLength(calculatedValues.WidthInPixels);
			float height = BoundsHelper.CorrectLength(calculatedValues.HeightInPixels);

			// Draw Back
			if (sourceRectangle.Style.BackStyle.Visible)
			{

				FillRectangle(x, y, width, height, sourceRectangle.Style.BackStyle);
			}

			// Draw Rectangle
			LineStyle lineStyle = sourceRectangle.Style.LineStyle;
			if (lineStyle != null)
			{
				if (lineStyle.Visible)
				{
					DrawRectangle(x, y, width, height, lineStyle);
				}
			}
			else
			{
				// Draw 4 Border Lines (with different styles)
				float left = x;
				float top = y;
				float right = left + width;
				float bottom = top + height;

				LineStyle topLineStyle = sourceRectangle.Style.TopLineStyle;
				if (topLineStyle.Visible)
				{
					DrawLine(left, top, right, top, topLineStyle);
				}

				LineStyle rightLineStyle = sourceRectangle.Style.RightLineStyle;
				if (rightLineStyle.Visible)
				{
					DrawLine(right, top, right, bottom, rightLineStyle);
				}

				LineStyle bottomLineStyle = sourceRectangle.Style.BottomLineStyle;
				if (bottomLineStyle.Visible)
				{
					DrawLine(right, bottom, left, bottom, bottomLineStyle);
				}

				LineStyle leftLineStyle = sourceRectangle.Style.LeftLineStyle;
				if (leftLineStyle.Visible)
				{
					DrawLine(left, bottom, left, top, leftLineStyle);
				}
			}
		}

		private void DrawLabel(Label sourceLabel)
		{
			if (!sourceLabel.CalculatedValues.Visible)
			{
				return;
			}

			float x = BoundsHelper.CorrectCoordinate(sourceLabel.CalculatedValues.XInPixels);
			float y = BoundsHelper.CorrectCoordinate(sourceLabel.CalculatedValues.YInPixels);

			// HACK:
			// Calling CorrectCoordinate instead of CorrectLength,
			// because apparently System.Drawing hates it when I correct 0 to 1E-9f.
			// TODO: See if the new clipping options take away the problem.
			float width = BoundsHelper.CorrectCoordinate(sourceLabel.CalculatedValues.WidthInPixels);
			float height = BoundsHelper.CorrectCoordinate(sourceLabel.CalculatedValues.HeightInPixels);

			DrawLabel(sourceLabel.Text, x, y, width, height, sourceLabel.TextStyle);
		}

		private void DrawEllipse(Ellipse sourceEllipse)
		{
			CalculatedValues calculatedValues = sourceEllipse.CalculatedValues;

			if (!calculatedValues.Visible)
			{
				return;
			}

			float x = BoundsHelper.CorrectCoordinate(calculatedValues.XInPixels);
			float y = BoundsHelper.CorrectCoordinate(calculatedValues.YInPixels);
			float width = BoundsHelper.CorrectLength(calculatedValues.WidthInPixels);
			float height = BoundsHelper.CorrectLength(calculatedValues.HeightInPixels);

			DrawEllipse(x, y, width, height, sourceEllipse.Style.LineStyle);
			FillEllipse(x, y, width, height, sourceEllipse.Style.BackStyle);
		}

		private void DrawPicture(Picture sourcePicture)
		{
			if (!sourcePicture.CalculatedValues.Visible)
			{
				return;
			}

			int x = BoundsHelper.CorrectCoordinateToInt32(sourcePicture.CalculatedValues.XInPixels);
			int y = BoundsHelper.CorrectCoordinateToInt32(sourcePicture.CalculatedValues.YInPixels);
			int width = BoundsHelper.CorrectLengthToInt32(sourcePicture.CalculatedValues.WidthInPixels);
			int height = BoundsHelper.CorrectLengthToInt32(sourcePicture.CalculatedValues.HeightInPixels);

			// NOTE: A picture cannot be scaled and clipped at the same time. 
			// (That would be cropped, which is different.)

			bool needsColorMatrix = Math.Abs(sourcePicture.Style.Opacity - 1f) > 0.00001;
			if (needsColorMatrix)
			{
				float[][] colorMatrix = GetOpacityColorMatrix(sourcePicture.Style.Opacity);

				if (sourcePicture.Style.Scale)
				{
					DrawPictureScaledWithColorMatrix(sourcePicture.UnderlyingPicture, x, y, width, height, colorMatrix);
				}
				else if (sourcePicture.Style.Clip)
				{
					DrawPictureClippedWithColorMatrix(sourcePicture.UnderlyingPicture, x, y, width, height, colorMatrix);
				}
				else
				{
					DrawPictureUnscaledUnclippedWithColorMatrix(sourcePicture.UnderlyingPicture, x, y, colorMatrix);
				}
			}
			else
			{
				if (sourcePicture.Style.Scale)
				{
					DrawPictureScaled(sourcePicture.UnderlyingPicture, x, y, width, height);
				}
				else if (sourcePicture.Style.Clip)
				{
					DrawPictureClipped(sourcePicture.UnderlyingPicture, x, y, width, height);
				}
				else
				{
					DrawPictureUnscaledUnclipped(sourcePicture.UnderlyingPicture, x, y);
				}
			}
		}


		private float[][] GetOpacityColorMatrix(float opacity) =>
			new[]
			{
				new float[] { 1, 0, 0, 0, 0 },
				new float[] { 0, 1, 0, 0, 0 },
				new float[] { 0, 0, 1, 0, 0 },
				new float[] { 0, 0, 0, opacity, 0 },
				new float[] { 0, 0, 0, 0, 1 }
			};

	}
}