using JJ.Framework.Presentation.VectorGraphics.Gestures;
using JJ.Framework.Presentation.VectorGraphics.Models.Styling;
using JJ.Framework.Reflection.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using JJ.Framework.Presentation.VectorGraphics.Helpers;

namespace JJ.Framework.Presentation.VectorGraphics.Models.Elements
{
    [DebuggerDisplay("{DebuggerDisplay}")]
    public class Point : Element
    {
        public Point()
        {
            _position = new PointPosition(this);
        }

        private ElementPosition _position;
        public override ElementPosition Position
        {
            get { return _position; }
        }

        private PointStyle _pointStyle = new PointStyle();
        /// <summary> not nullable, auto-instantiated </summary>
        public PointStyle PointStyle
        {
            [DebuggerHidden]
            get { return _pointStyle; }
            set
            {
                if (value == null) throw new NullException(() => value);
                _pointStyle = value;
            }
        }

        private string DebuggerDisplay
        {
            get { return DebugHelper.GetDebuggerDisplay(this); }
        }
    }
}