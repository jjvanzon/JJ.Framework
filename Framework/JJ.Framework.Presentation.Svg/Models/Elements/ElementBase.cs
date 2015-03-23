using JJ.Framework.Presentation.Svg;
using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg.Models.Elements
{
    /// <summary>
    /// A base class that can contain SVG child elements.
    /// </summary>
    public abstract class ElementBase
    {
        public ElementBase()
        {
            Visible = true;
        }

        public abstract float X { get; set; }
        public abstract float Y { get; set; }

        internal float AbsoluteX { get; set; }
        internal float AbsoluteY { get; set; }

        public bool Visible { get; set; }

        private IList<Point> _childPoints = new List<Point>();

        /// <summary> not nullable, auto-instantiated </summary>
        public IList<Point> ChildPoints
        {
            get { return _childPoints; }
            set 
            {
                if (value == null) throw new NullException(() => value);
                _childPoints = value;
            }
        }

        private IList<Line> _childLines = new List<Line>();

        /// <summary> not nullable, auto-instantiated </summary>
        public IList<Line> ChildLines
        {
            get { return _childLines; }
            set
            {
                if (value == null) throw new NullException(() => value);
                _childLines = value;
            }
        }

        private IList<Rectangle> _childRectangles = new List<Rectangle>();

        /// <summary> not nullable, auto-instantiated </summary>
        public IList<Rectangle> ChildRectangles
        {
            get { return _childRectangles; }
            set
            {
                if (value == null) throw new NullException(() => value);
                _childRectangles = value;
            }
        }

        private IList<Label> _childLabels = new List<Label>();

        /// <summary> not nullable, auto-instantiated </summary>
        public IList<Label> ChildLabels
        {
            get { return _childLabels; }
            set
            {
                if (value == null) throw new NullException(() => value);
                _childLabels = value;
            }
        }
    }
}
