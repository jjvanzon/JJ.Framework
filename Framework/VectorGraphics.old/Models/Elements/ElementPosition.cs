using System.Diagnostics;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.VectorGraphics.Helpers;

namespace JJ.Framework.VectorGraphics.Models.Elements
{
    /// <summary>
    /// Typically assign as follows in the constructor of a derived class:
    /// Position = new RectanglePosition(this);
    /// There are measurements in pixels. There are also scaled coordinates,
    /// further categorized into coordinates relative to the parent element and
    /// absolute coordinates related to the Diagram.
    /// The main coordinates would be those relative coordinates.
    /// X and Y would typically be the top-left corner.
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "}")]
    public abstract class ElementPosition
    {
        private readonly Element _element;

        internal ElementPosition(Element element) => _element = element ?? throw new NullException(() => element);

        /// <summary> Left X-coordinate relative to the parent. Scaled depending on Diagram.ScaleModeEnum. </summary>
        public abstract float X { get; set; }

        /// <summary> Top Y-coordinate relative to the parent. Scaled depending on Diagram.ScaleModeEnum. </summary>
        public abstract float Y { get; set; }

        /// <summary> Scaled width </summary>
        public abstract float Width { get; set; }
        /// <summary> Scaled height </summary>
        public abstract float Height { get; set; }

        /// <summary> Right X-coordinate relative to the parent. Scaled depending on Diagram.ScaleModeEnum. </summary>
        public float Right
        {
            get => X + Width;
            set => X = value - Width;
        }

        /// <summary> Bottom Y-coordinate relative to the parent. Scaled depending on Diagram.ScaleModeEnum. </summary>
        public float Bottom
        {
            get => Y + Height;
            set => Y = value - Height;
        }

        /// <summary> Center X-coordinate relative to the parent. Scaled depending on Diagram.ScaleModeEnum. </summary>
        public float CenterX
        {
            get => X + Width / 2f;
            set => X = value - Width / 2f;
        }

        /// <summary> Center Y-coordinate relative to the parent. Scaled depending on Diagram.ScaleModeEnum. </summary>
        public float CenterY
        {
            get => Y + Height / 2f;
            set => Y = value - Height / 2f;
        }

        /// <summary> Left X-coordinate in relation to the Diagram. </summary>
        public float AbsoluteX
        {
            get => ScaleHelper.RelativeToAbsoluteX(_element, 0);
            set => X = ScaleHelper.AbsoluteToRelativeX(_element, value);
        }

        /// <summary> Top Y-coordinate in relation to the Diagram. </summary>
        public float AbsoluteY
        {
            get => ScaleHelper.RelativeToAbsoluteY(_element, 0);
            set => Y = ScaleHelper.AbsoluteToRelativeY(_element, value);
        }

        /// <summary> Right X-coordinate in relation to the Diagram. </summary>
        public float AbsoluteRight => AbsoluteX + Width;
        /// <summary> Bottom Y-coordinate in relation to the Diagram. </summary>
        public float AbsoluteBottom => AbsoluteY + Height;
        /// <summary> Center X-coordinate in relation to the Diagram. </summary>
        public float AbsoluteCenterX => AbsoluteX + Width / 2f;
        /// <summary> Center Y-coordinate in relation to the Diagram. </summary>
        public float AbsoluteCenterY => AbsoluteY + Height / 2f;

        /// <summary> Left X-coordinate in pixels from the edge of the diagram. </summary>
        public float XInPixels
        {
            get => ScaleHelper.RelativeToPixelsX(_element, 0);
            // TODO: Test this setter.
            set => X = ScaleHelper.PixelsToX(_element.Diagram, value);
        }

        /// <summary> Top Y-coordinate in pixels from the edge of the diagram. </summary>
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
