using System.Diagnostics;
using JJ.Framework.Presentation.VectorGraphics.Helpers;

namespace JJ.Framework.Presentation.VectorGraphics.Models.Elements
{
    [DebuggerDisplay("{DebuggerDisplay}")]
    public class Rectangle : Element
    {
        public Rectangle()
        {
            Position = new RectanglePosition(this);
            Style = new RectangleStyle();
        }

        public override ElementPosition Position { get; }

        public RectangleStyle Style { get; }

        private string DebuggerDisplay => DebugHelper.GetDebuggerDisplay(this);
    }
}
