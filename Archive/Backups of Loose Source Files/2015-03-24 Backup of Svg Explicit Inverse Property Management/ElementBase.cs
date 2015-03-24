using JJ.Framework.Presentation.Svg;
using JJ.Framework.Presentation.Svg.LinkTo;
using JJ.Framework.Reflection;
using JJ.Framework.Common;
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
            _children = new SvgChildren();
            _children.Parent = this;

            Visible = true;
        }

        public abstract float X { get; set; }
        public abstract float Y { get; set; }

        public bool Visible { get; set; }

        public int ZIndex { get; set; }
        internal int Layer { get; set; }

        private SvgChildren _children;

        /// <summary> auto-instantiated </summary>
        public SvgChildren Children
        {
            get { return _children; }
            set
            {
                if (value == null) throw new NullException(() => value);

                if (_children != null)
                {
                    _children.Clear();
                }

                _children = value;

                for (int i = 0; i < _children.Count; i++)
                {
                    ElementBase child = _children[i];
                    child.LinkTo(this);
                }
            }
        }

        private ElementBase _parent;

        public ElementBase Parent
        {
            get { return _parent; }
            set
            {
                if (_parent == value) return;
                this.LinkTo(value);
            }
        }

        /// <summary>
        /// Only used for the clone-free test for now.
        /// Can be removed when it proves that is definitely not the way to go.
        /// </summary>
        /// 
        private float AbsoluteX { get; set; }
        /// <summary>
        /// Only used for the clone-free test for now.
        /// Can be removed when it proves that is definitely not the way to go.
        /// </summary>
        private float AbsoluteY { get; set; }
    }
}
