using System.Linq;
using JJ.Framework.Collections;
using JJ.Framework.VectorGraphics.Enums;
using JJ.Framework.VectorGraphics.Helpers;
using JJ.Framework.VectorGraphics.Models.Elements;
using JJ.Framework.VectorGraphics.Models.Styling;

namespace JJ.Framework.VectorGraphics.Drawing
{
	internal static class CoordinateIndicatorHelper
	{
		public static bool MustDrawCoordinateIndicatorsForPrimitives { get; set; }
		public static bool MustDrawCoordinateIndicatorsForComposites { get; set; }

		private static readonly PointStyle _pointStyle = new PointStyle
		{
			Visible = true,
			Color = ColorHelper.GetColor(128, 40, 128, 192),
			Width = 5
		};

		private static readonly BackStyle _pointBackStyle = new BackStyle { Color = _pointStyle.Color };

		private static readonly BackStyle _backStyle = new BackStyle
		{
			Visible = true,
			Color = ColorHelper.GetColor(64, 40, 128, 192)
		};

		private static readonly LineStyle _lineStyle = new LineStyle
		{
			Visible = true,
			Color = ColorHelper.GetColor(196, 40, 128, 192),
			Width = 2,
			DashStyleEnum = DashStyleEnum.Dashed
		};

		public static void DrawCoordinateIndicatorsIfNeeded(DrawerBase drawer, Element element)
		{
			if (element.SelfAndAncestors(x => x.Parent).Any(x => !x.Visible))
			{
				return;
			}

			switch (element)
			{
				case Point point:
					if (MustDrawCoordinateIndicatorsForPrimitives)
					{
						float pointWidth = BoundsHelper.CorrectLength(_pointStyle.Width);
						float x = BoundsHelper.CorrectCoordinate(point.CalculatedValues.XInPixels - pointWidth / 2f);
						float y = BoundsHelper.CorrectCoordinate(point.CalculatedValues.YInPixels - pointWidth / 2f);
						drawer.FillEllipse(x, y, pointWidth, pointWidth, _pointBackStyle);
					}
					break;

				case Curve _:
				case Ellipse _:
				case Label _:
				case Line _:
				case Picture _:
				case Rectangle _:
					if (MustDrawCoordinateIndicatorsForPrimitives)
					{
						DrawRectangularCoordinateIndicator(drawer, element.CalculatedValues);
					}
					break;

				default:
					if (MustDrawCoordinateIndicatorsForComposites)
					{
						DrawRectangularCoordinateIndicator(drawer, element.CalculatedValues);
					}
					break;
			}
		}

		private static void DrawRectangularCoordinateIndicator(DrawerBase drawer, CalculatedValues calculatedValues)
		{
			drawer.FillRectangle(
				calculatedValues.XInPixels,
				calculatedValues.YInPixels,
				calculatedValues.WidthInPixels,
				calculatedValues.HeightInPixels,
				_backStyle);

			drawer.DrawRectangle(
				calculatedValues.XInPixels,
				calculatedValues.YInPixels,
				calculatedValues.WidthInPixels,
				calculatedValues.HeightInPixels,
				_lineStyle);
		}
	}
}