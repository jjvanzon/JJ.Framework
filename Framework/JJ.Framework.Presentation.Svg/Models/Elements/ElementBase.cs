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

        public bool Visible { get; set; }

        public int ZIndex { get; set; }
        internal int Layer { get; set; }

        private IList<ElementBase> _children = new List<ElementBase>();

        /// <summary> not nullable, auto-instantiated </summary>
        public IList<ElementBase> Children
        {
            get { return _children; }
            set 
            {
                if (value == null) throw new NullException(() => value);
                _children = value;
            }
        }

        /// <summary>
        /// Only used for the clone-free test for now.
        /// Can be removed when it proves that is definitely not the way to go.
        /// </summary>
        private float AbsoluteX { get; set; }
        /// <summary>
        /// Only used for the clone-free test for now.
        /// Can be removed when it proves that is definitely not the way to go.
        /// </summary>
        private float AbsoluteY { get; set; }
    }
}
