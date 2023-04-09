using System;
using JetBrains.Annotations;
using JJ.Framework.VectorGraphics.Enums;
using JJ.Framework.VectorGraphics.Models.Elements;
// ReSharper disable InconsistentNaming

namespace JJ.Framework.VectorGraphics.EventArg
{
    /// <summary> Would contain properties that might be passed along with mouse events. </summary>
    public class MouseEventArgs : EventArgs
    {
        /// <summary>
        /// Nullable.
        /// Indicates the Element that might be involved with a mouse gesture,
        /// for example the Element that would have been clicked on.
        /// </summary>
        public Element Element { get; }

        /// <summary>
        /// Indicates the current position of the (mouse) cursor in pixels.
        /// Those would be the amount of pixels from to the top left corner from the Diagram.
        /// When you might need scaled coordinates for instance,
        /// you might use Diagram.Position members which may allow you to convert.
        /// </summary>
        [PublicAPI]
        public float XInPixels { get; }

        /// <inheritdoc cref="XInPixels" />
        [PublicAPI]
        public float YInPixels { get; }

        /// <inheritdoc cref="Enums.MouseButtonEnum" />
        [PublicAPI]
        public MouseButtonEnum MouseButtonEnum { get; }

        /// <inheritdoc cref="MouseEventArgs" />
        /// <param name="element"> nullable </param>
        /// <param name="xInPixels"> See XInPixels property. </param>
        /// <param name="yInPixels"> See YinPixels property. </param>
        /// <param name="mouseButtonEnum"> See MouseButtonEnum. </param>
        public MouseEventArgs(Element element, float xInPixels, float yInPixels, MouseButtonEnum mouseButtonEnum)
        {
            Element = element;
            XInPixels = xInPixels;
            YInPixels = yInPixels;
            MouseButtonEnum = mouseButtonEnum;
        }
    }
}