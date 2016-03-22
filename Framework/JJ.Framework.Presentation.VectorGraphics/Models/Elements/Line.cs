using JJ.Framework.Presentation.VectorGraphics.Models.Styling;
using JJ.Framework.Reflection.Exceptions;
using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using JJ.Framework.Presentation.VectorGraphics.Helpers;

namespace JJ.Framework.Presentation.VectorGraphics.Models.Elements
{
    [DebuggerDisplay("{DebuggerDisplay}")]
    public class Line : Element
    {
        public Line()
        {
            _position = new LinePosition(this);
        }

        private ElementPosition _position;
        public override ElementPosition Position
        {
            get { return _position; }
        }

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

        private string DebuggerDisplay
        {
            get { return DebugHelper.GetDebuggerDisplay(this); }
        }
    }
}
