using JJ.Framework.Presentation.VectorGraphics.Models.Styling;
using JJ.Framework.Exceptions;
using System.Diagnostics;
using JJ.Framework.Presentation.VectorGraphics.Helpers;

namespace JJ.Framework.Presentation.VectorGraphics.Models.Elements
{
    [DebuggerDisplay("{DebuggerDisplay}")]
    public class Line : Element
    {
        public Line()
        {
            Position = new LinePosition(this);
        }

        public override ElementPosition Position { get; }

        /// <summary> Nullable. Coordinates of the point are related to the Point's parent. </summary>
        public Point PointA { get; set; }

        /// <summary> Nullable. Coordinates of the point are related to the Point's parent. </summary>
        public Point PointB { get; set; }

        private LineStyle _lineStyle = new LineStyle();
        /// <summary> not nullable, auto-instantiated </summary>
        public LineStyle LineStyle
        {
            [DebuggerHidden]
            get { return _lineStyle; }
            set
            {
                if (value == null) throw new NullException(() => value);
                _lineStyle = value;
            }
        }

        private string DebuggerDisplay => DebugHelper.GetDebuggerDisplay(this);
    }
}
