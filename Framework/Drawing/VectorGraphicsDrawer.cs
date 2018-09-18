using System;
using System.Drawing;
using System.Drawing.Imaging;
using JJ.Framework.VectorGraphics.Drawing;
using JJ.Framework.VectorGraphics.Models.Styling;
using Font = System.Drawing.Font;

namespace JJ.Framework.Drawing
{
	public class VectorGraphicsDrawer : DrawerBase
	{
		private readonly Graphics _destGraphics;

		public VectorGraphicsDrawer(Graphics destGraphics) => _destGraphics = destGraphics ?? throw new ArgumentNullException(nameof(destGraphics));

		protected override void DrawLine(float x1, float y1, float x2, float y2, LineStyle lineStyle)
		{
			using (Pen destPen = lineStyle.ToSystemDrawing())
			{
				_destGraphics.DrawLine(destPen, x1, y1, x2, y2);
			}
		}

		protected override void FillRectangle(float x, float y, float width, float height, BackStyle backStyle)
		{
			using (Brush destBrush = backStyle.ToSystemDrawing())
			{
				_destGraphics.FillRectangle(destBrush, x - 0.5f, y - 0.5f, width, height);
			}
		}

		protected override void DrawRectangle(float x, float y, float width, float height, LineStyle lineStyle)
		{
			using (Pen destPen = lineStyle.ToSystemDrawing())
			{
				_destGraphics.DrawRectangle(destPen, x - 0.5f, y - 0.5f, width, height);
			}
		}

		protected override void DrawLabel(string text, float x, float y, float width, float height, TextStyle textStyle)
		{
			using (Font destFont = textStyle.Font.ToSystemDrawing(DpiHelper.GetDpi(_destGraphics)))
			{
				using (Brush destBrush = textStyle.ToSystemDrawingBrush())
				{
					using (StringFormat destStringFormat = textStyle.ToSystemDrawingStringFormat())
					{
						_destGraphics.DrawString(text, destFont, destBrush, new RectangleF(x, y, width, height), destStringFormat);
					}
				}
			}
		}

		protected override void DrawEllipse(float x, float y, float width, float height, LineStyle lineStyle)
		{
			using (Pen destPen = lineStyle.ToSystemDrawing())
			{
				_destGraphics.DrawEllipse(destPen, x, y, width, height);
			}
		}

		protected override void FillEllipse(float x, float y, float width, float height, BackStyle backStyle)
		{
			using (Brush destBrush = backStyle.ToSystemDrawing())
			{
				_destGraphics.FillEllipse(destBrush, x, y, width, height);
			}
		}

		protected override void DrawPictureClipped(object picture, int x, int y, int width, int height)
		{
			var image = (Image)picture;
			var destRectangle = new Rectangle(x, y, width, height);
			_destGraphics.DrawImageUnscaledAndClipped(image, destRectangle);
		}

		protected override void DrawPictureUnscaledUnclipped(object picture, int x, int y)
		{
			var image = (Image)picture;
			_destGraphics.DrawImageUnscaled(image, x, y);
		}

		protected override void DrawPictureScaled(object picture, int x, int y, int width, int height)
		{
			var image = (Image)picture;
			_destGraphics.DrawImage(
				image,
				new Rectangle(x, y, width, height),
				0,
				0,
				image.Width,
				image.Height,
				GraphicsUnit.Pixel);
		}

		protected override void DrawPictureScaledWithColorMatrix(object picture, int x, int y, int width, int height, float[][] colorMatrix)
		{
			var image = (Image)picture;
			var imageAttributes = new ImageAttributes();
			imageAttributes.SetColorMatrix(new ColorMatrix(colorMatrix), ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

			_destGraphics.DrawImage(
				image,
				new Rectangle(x, y, width, height),
				0,
				0,
				image.Width,
				image.Height,
				GraphicsUnit.Pixel,
				imageAttributes);
		}

		protected override void DrawPictureClippedWithColorMatrix(object picture, int x, int y, int width, int height, float[][] colorMatrix)
		{
			var image = (Image)picture;
			var imageAttributes = new ImageAttributes();
			imageAttributes.SetColorMatrix(new ColorMatrix(colorMatrix), ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

			_destGraphics.DrawImage(
				image,
				new Rectangle(x, y, width, height),
				0,
				0,
				width,
				height,
				GraphicsUnit.Pixel,
				imageAttributes);
		}

		protected override void DrawPictureUnscaledUnclippedWithColorMatrix(object picture, int x, int y, float[][] colorMatrix)
		{
			var image = (Image)picture;
			var imageAttributes = new ImageAttributes();
			imageAttributes.SetColorMatrix(new ColorMatrix(colorMatrix), ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

			_destGraphics.DrawImage(
				image,
				new Rectangle(x, y, image.Width, image.Height),
				0,
				0,
				image.Width,
				image.Height,
				GraphicsUnit.Pixel,
				imageAttributes);
		}
	}
}