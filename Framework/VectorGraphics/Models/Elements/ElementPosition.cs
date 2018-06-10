using System.Diagnostics;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.VectorGraphics.Helpers;

namespace JJ.Framework.VectorGraphics.Models.Elements
{
	[DebuggerDisplay("{" + nameof(DebuggerDisplay) + "}")]
	public abstract class ElementPosition
	{
		private readonly Element _element;

		internal ElementPosition(Element element) => _element = element ?? throw new NullException(() => element);

	    /// <summary> X-coordinate relative to the parent. Scaled depending on Diagram.ScaleModeEnum. </summary>
		public abstract float X { get; set; }

		/// <summary> Y-coordinate relative to the parent. Scaled depending on Diagram.ScaleModeEnum. </summary>
		public abstract float Y { get; set; }

		public abstract float Width { get; set; }
		public abstract float Height { get; set; }

		public float Right
		{
			get => X + Width;
			set => X = value - Width;
		}

		public float Bottom
		{
			get => Y + Height;
			set => Y = value - Height;
		}

		public float CenterY
		{
			get => Y + Height / 2f;
			set => Y = value - Height / 2f;
		}

		public float CenterX
		{
			get => X + Width / 2f;
			set => X = value - Width / 2f;
		}

		public float AbsoluteX => ScaleHelper.RelativeToAbsoluteX(_element, 0);
		public float AbsoluteY => ScaleHelper.RelativeToAbsoluteY(_element, 0);
		public float AbsoluteRight => AbsoluteX + Width;
		public float AbsoluteBottom => AbsoluteY + Height;
		public float AbsoluteCenterX => AbsoluteX + Width / 2f;
		public float AbsoluteCenterY => AbsoluteY + Height / 2f;

		public float XInPixels
		{
			get => ScaleHelper.RelativeToPixelsX(_element, 0);
			// TODO: Test this setter.
			set => X = ScaleHelper.PixelsToX(_element.Diagram, value);
		}

		public float YInPixels
		{
			get => ScaleHelper.RelativeToPixelsY(_element, 0);
			// TODO: Test this setter.
			set => Y = ScaleHelper.PixelsToY(_element.Diagram, value);
		}

		public float WidthInPixels
		{
			get => ScaleHelper.WidthToPixels(_element.Diagram, Width);
			set => Width = ScaleHelper.PixelsToWidth(_element.Diagram, value);
		}

		public float HeightInPixels
		{
			get => ScaleHelper.HeightToPixels(_element.Diagram, Height);
			set => Height = ScaleHelper.PixelsToHeight(_element.Diagram, value);
		}

		public float RelativeToAbsoluteX(float relativeX) => ScaleHelper.RelativeToAbsoluteX(_element, relativeX);
		public float RelativeToAbsoluteY(float relativeY) => ScaleHelper.RelativeToAbsoluteY(_element, relativeY);
		public float AbsoluteToRelativeX(float absoluteX) => ScaleHelper.AbsoluteToRelativeX(_element, absoluteX);
		public float AbsoluteToRelativeY(float absoluteY) => ScaleHelper.AbsoluteToRelativeY(_element, absoluteY);
		public float PixelsToRelativeX(float xInPixels) => ScaleHelper.PixelsToRelativeX(_element, xInPixels);
		public float PixelsToRelativeY(float yInPixels) => ScaleHelper.PixelsToRelativeY(_element, yInPixels);
		public float RelativeToPixelsX(float relativeX) => ScaleHelper.RelativeToPixelsX(_element, relativeX);
		public float RelativeToPixelsY(float relativeY) => ScaleHelper.RelativeToPixelsY(_element, relativeY);
		public float PixelsToAbsoluteX(float xInPixels) => ScaleHelper.PixelsToAbsoluteX(_element, xInPixels);
		public float PixelsToAbsoluteY(float yInPixels) => ScaleHelper.PixelsToAbsoluteY(_element, yInPixels);
		public float AbsoluteToPixelsX(float absoluteX) => ScaleHelper.AbsoluteToPixelsX(_element, absoluteX);
		public float AbsoluteToPixelsY(float absoluteY) => ScaleHelper.AbsoluteToPixelsY(_element, absoluteY);

		private string DebuggerDisplay => DebuggerDisplayFormatter.GetDebuggerDisplay(this);
	}
}
