using System;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.VectorGraphics.Models.Elements;
using JJ.Framework.VectorGraphics.Models.Styling;

namespace JJ.Framework.VectorGraphics.Drawing
{
	/// <summary>
	/// The base will corect coordinates and sizes to be within
	/// certain bounds and sizes to be a minimum positive value.
	/// Coordinates minimally -100,000 and maximally 100,000
	/// Sizes at least 0.0001.
	/// </summary>
	public abstract class DrawerBase
	{
		protected abstract void DrawLine(float x1, float y1, float x2, float y2, LineStyle lineStyle);
		protected internal abstract void FillRectangle(float x, float y, float width, float height, BackStyle backStyle);
		protected internal abstract void DrawRectangle(float x, float y, float width, float height, LineStyle lineStyle);
		protected abstract void DrawLabel(string text, float x, float y, float width, float height, TextStyle textStyle);
		protected abstract void DrawEllipse(float x, float y, float width, float height, LineStyle lineStyle);
		protected internal abstract void FillEllipse(float x, float y, float width, float height, BackStyle backStyle);
		protected abstract void DrawPictureUnscaledUnclipped(object picture, int x, int y);
		protected abstract void DrawPictureClipped(object picture, int x, int y, int width, int height);
		protected abstract void DrawPictureScaled(object picture, int x, int y, int width, int height);
		protected abstract void DrawPictureScaledWithColorMatrix(object picture, int x, int y, int width, int height, float[][] colorMatrix);
		protected abstract void DrawPictureClippedWithColorMatrix(object picture, int x, int y, int width, int height, float[][] colorMatrix);
		protected abstract void DrawPictureUnscaledUnclippedWithColorMatrix(object picture, int x, int y, float[][] colorMatrix);

		public static bool MustDrawCoordinateIndicatorsForPrimitives
		{
			get => CoordinateIndicatorHelper.MustDrawCoordinateIndicatorsForPrimitives;
			set => CoordinateIndicatorHelper.MustDrawCoordinateIndicatorsForPrimitives = value;
		}

		public static bool MustDrawCoordinateIndicatorsForComposites
		{
			get => CoordinateIndicatorHelper.MustDrawCoordinateIndicatorsForComposites;
			set => CoordinateIndicatorHelper.MustDrawCoordinateIndicatorsForComposites = value;
		}

		public void Draw(Diagram diagram)
		{
			if (diagram == null) throw new ArgumentNullException(nameof(diagram));
			foreach (Element element in diagram.ElementsOrderedByZIndex)
			{
				DrawPolymorphic(element);
			}
		}

		private void DrawPolymorphic(Element sourceElement)
		{
#if DEBUG
			CoordinateIndicatorHelper.DrawCoordinateIndicatorsIfNeeded(this, sourceElement);
#endif
			switch (sourceElement)
			{
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

				// Curves are not drawn explitly: only indirectly through their generated segement lines.
				// Another element type can be just a custom programmed composite element.
			}
		}


		private void DrawPoint(Point sourcePoint)
		{
			if (!sourcePoint.CalculatedValues.Visible)
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
			if (!sourceLine.CalculatedValues.Visible)
			{
				return;
			}

			if (sourceLine.PointA == null) throw new NullException(() => sourceLine.PointA);
			if (sourceLine.PointB == null) throw new NullException(() => sourceLine.PointB);

			float x1 = sourceLine.PointA.CalculatedValues.XInPixels;
			float y1 = sourceLine.PointA.CalculatedValues.YInPixels;
			float x2 = sourceLine.PointB.CalculatedValues.XInPixels;
			float y2 = sourceLine.PointB.CalculatedValues.YInPixels;

			DrawLine(x1, y1, x2, y2, sourceLine.LineStyle);
		}

		private void DrawRectangle(Rectangle sourceRectangle)
		{
			if (!sourceRectangle.CalculatedValues.Visible)
			{
				return;
			}

			CalculatedValues calculatedValues = sourceRectangle.CalculatedValues;

			float x = calculatedValues.XInPixels;
			float y = calculatedValues.YInPixels;
			float width = calculatedValues.WidthInPixels;
			float height = calculatedValues.HeightInPixels;

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

			float x = sourceLabel.CalculatedValues.XInPixels;
			float y = sourceLabel.CalculatedValues.YInPixels;

			// NOTE: Used to call CorrectCoordinate here
			// because apparently System.Drawing hates it when I correct 0 to 1E-9f.
			// But now they are correcte to 1E-5. Not sure if that helps. Also not sure anymore at what precise point System.Drawing hated it.
			float width = sourceLabel.CalculatedValues.WidthInPixels;
			float height = sourceLabel.CalculatedValues.HeightInPixels;

			DrawLabel(sourceLabel.Text, x, y, width, height, sourceLabel.TextStyle);
		}

		private void DrawEllipse(Ellipse sourceEllipse)
		{
			CalculatedValues calculatedValues = sourceEllipse.CalculatedValues;

			if (!calculatedValues.Visible)
			{
				return;
			}

			float x = calculatedValues.XInPixels;
			float y = calculatedValues.YInPixels;
			float width = calculatedValues.WidthInPixels;
			float height = calculatedValues.HeightInPixels;

			FillEllipse(x, y, width, height, sourceEllipse.Style.BackStyle);
			DrawEllipse(x, y, width, height, sourceEllipse.Style.LineStyle);
		}

		private void DrawPicture(Picture sourcePicture)
		{
			CalculatedValues calculatedValues = sourcePicture.CalculatedValues;

			if (!calculatedValues.Visible)
			{
				return;
			}

			int x = BoundsHelper.CorrectToInt32(calculatedValues.XInPixels);
			int y = BoundsHelper.CorrectToInt32(calculatedValues.YInPixels);
			int width = BoundsHelper.CorrectToInt32(calculatedValues.WidthInPixels);
			int height = BoundsHelper.CorrectToInt32(calculatedValues.HeightInPixels);

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

		// ReSharper disable once RedundantExplicitArrayCreation
		private static float[][] GetOpacityColorMatrix(float opacity) =>
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