using System.Drawing;
using System.Drawing.Drawing2D;
using JJ.Framework.Exceptions;
using JJ.Framework.VectorGraphics.Drawing;
using JJ.Framework.VectorGraphics.Enums;
using JJ.Framework.VectorGraphics.Models.Styling;
using Font = System.Drawing.Font;

namespace JJ.Framework.Drawing
{
	public static class ConversionExtensions
	{
		// Style Values

		public static Color ToSystemDrawing(this int color) => Color.FromArgb(color);

		public static StringAlignment ToSystemDrawing(this HorizontalAlignmentEnum horizontalAlignmentEnum)
		{
			switch (horizontalAlignmentEnum)
			{
				case HorizontalAlignmentEnum.Center:
					return StringAlignment.Center;

				case HorizontalAlignmentEnum.Left:
					return StringAlignment.Near;

				case HorizontalAlignmentEnum.Right:
					return StringAlignment.Far;

				default:
					throw new InvalidValueException(horizontalAlignmentEnum);
			}
		}

		public static StringAlignment ToSystemDrawing(this VerticalAlignmentEnum verticalAlignmentEnum)
		{
			switch (verticalAlignmentEnum)
			{
				case VerticalAlignmentEnum.Center:
					return StringAlignment.Center;

				case VerticalAlignmentEnum.Top:
					return StringAlignment.Near;

				case VerticalAlignmentEnum.Bottom:
					return StringAlignment.Far;

				default:
					throw new InvalidValueException(verticalAlignmentEnum);
			}
		}

		// Style Objects

		public static Pen ToSystemDrawing(this LineStyle sourceLineStyle)
		{
			if (sourceLineStyle == null) throw new NullException(() => sourceLineStyle);

			float lineWidth = BoundsHelper.CorrectLength(sourceLineStyle.Width);

			Color destColor = sourceLineStyle.Color.ToSystemDrawing();
			var destPen = new Pen(destColor, lineWidth);

			switch (sourceLineStyle.DashStyleEnum)
			{
				case DashStyleEnum.Dotted:
					destPen.DashStyle = DashStyle.Dot;
					destPen.DashPattern = new[] { 1, 1.5f };
					break;

				case DashStyleEnum.Dashed:
					destPen.DashStyle = DashStyle.Dash;
					destPen.DashPattern = new float[] { 3, 1 };
					break;

				case DashStyleEnum.Solid:
					destPen.DashStyle = DashStyle.Solid;
					break;

				default:
					throw new InvalidValueException(sourceLineStyle.DashStyleEnum);
			}

			return destPen;
		}

		public static Brush ToSystemDrawing(this BackStyle sourceBackStyle)
		{
			if (sourceBackStyle == null) throw new NullException(() => sourceBackStyle);

			Color destColor = sourceBackStyle.Color.ToSystemDrawing();
			Brush destBrush = new SolidBrush(destColor);
			return destBrush;
		}

		public static StringFormat ToSystemDrawingStringFormat(this TextStyle sourceTextStyle)
		{
			if (sourceTextStyle == null) throw new NullException(() => sourceTextStyle);

			var destStringFormat = new StringFormat
			{
				Alignment = sourceTextStyle.HorizontalAlignmentEnum.ToSystemDrawing(),
				LineAlignment = sourceTextStyle.VerticalAlignmentEnum.ToSystemDrawing()
			};

			if (sourceTextStyle.Wrap == false)
			{
				destStringFormat.FormatFlags |= StringFormatFlags.NoWrap;
			}

			if (sourceTextStyle.Clip == false)
			{
				destStringFormat.FormatFlags |= StringFormatFlags.NoClip;
			}

			destStringFormat.Trimming = sourceTextStyle.Abbreviate ? StringTrimming.EllipsisCharacter : StringTrimming.None;

			return destStringFormat;
		}

		public static Brush ToSystemDrawingBrush(this TextStyle sourceTextStyle)
		{
			if (sourceTextStyle == null) throw new NullException(() => sourceTextStyle);

			Color destColor = sourceTextStyle.Color.ToSystemDrawing();
			Brush destBrush = new SolidBrush(destColor);

			return destBrush;
		}

		public static Font ToSystemDrawing(this VectorGraphics.Models.Styling.Font sourceFont, float dpi)
		{
			if (sourceFont == null) throw new NullException(() => sourceFont);

			FontStyle destFontStyle = 0;

			if (sourceFont.Bold)
			{
				destFontStyle |= FontStyle.Bold;
			}

			if (sourceFont.Italic)
			{
				destFontStyle |= FontStyle.Italic;
			}

			float fontSize = BoundsHelper.CorrectLength(sourceFont.Size);

			// Get rid of Windows DPI scaling.
			float antiDpiFactor = DpiHelper.GetAntiDpiFactor(dpi);
			float destFontSize = fontSize * antiDpiFactor;

			var destFont = new Font(sourceFont.Name, destFontSize, destFontStyle);
			return destFont;
		}
	}
}