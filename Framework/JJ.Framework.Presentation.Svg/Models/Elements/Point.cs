﻿using JJ.Framework.Presentation.Svg.Models.Styling;
using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg.Models.Elements
{
    [DebuggerDisplay("{DebuggerDisplay}")]
    public class Point : Element
    {
        public Point()
        { }

        public override float X { get; set; }
        public override float Y { get; set; }

        public override float Width
        {
            get { return 0; }
            set { throw new NotSupportedException(); }
        }

        public override float Height
        {
            get { return 0; }
            set { throw new NotSupportedException(); }
        }

        private PointStyle _pointStyle = new PointStyle();
        /// <summary> not nullable, auto-instantiated </summary>
        public PointStyle PointStyle
        {
            get { return _pointStyle; }
            set
            {
                if (value == null) throw new NullException(() => value);
                _pointStyle = value;
            }
        }

        private string DebuggerDisplay
        {
            get
            {
                return String.Format("{{{0}}} ({1}, {2}) (HashCode={3})", GetType().Name, X, Y, GetHashCode());
            }
        }
    }
}