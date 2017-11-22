using JJ.Framework.Presentation.VectorGraphics.Helpers;
using JJ.Framework.Exceptions;

namespace JJ.Framework.Presentation.VectorGraphics.Models.Elements
{
	public abstract class ElementPosition
	{
		private readonly Element _element;

		internal ElementPosition(Element element)
		{
			_element = element ?? throw new NullException(() => element);
		}

		/// <summary> X-coordinate relative to the parent. Scaled depending on Diagram.ScaleModeEnum. </summary>
		public abstract float X { get; set; }

		/// <summary> Y-coordinate relative to the parent. Scaled depending on Diagram.ScaleModeEnum. </summary>
		public abstract float Y { get; set; }

		public abstract float Width { get; set; }
		public abstract float Height { get; set; }

		public float AbsoluteX => ScaleHelper.RelativeToAbsoluteX(_element, 0);
		public float AbsoluteY => ScaleHelper.RelativeToAbsoluteY(_element, 0);
		public float XInPixels => ScaleHelper.RelativeToPixelsX(_element, 0);
		public float YInPixels => ScaleHelper.RelativeToPixelsY(_element, 0);

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

		public float RelativeRight
		{
			get => _element.Position.X + _element.Position.Width;
			set => _element.Position.X = value - _element.Position.Width;
		}

		public float RelativeBottom
		{
			get => _element.Position.Y + _element.Position.Height;
			set => _element.Position.Y = value - _element.Position.Height;
		}

		public float AbsoluteRight => AbsoluteX + _element.Position.Width;
		public float AbsoluteBottom => AbsoluteY + _element.Position.Height;
	}
}
