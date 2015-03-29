using JJ.Framework.Presentation.Svg;
using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace JJ.Framework.Presentation.Svg.Models.Elements
{
    /// <summary>
    /// A base class that can contain SVG child elements.
    /// </summary>
    public abstract class Element
    {
        internal Element()
        {
            Children = new ElementChildren(parent: this);
            Visible = true;
        }

        /// <summary>
        /// X-coordinate relative to the parent.
        /// </summary>
        public abstract float X { get; set; }

        /// <summary>
        /// X-coordinate relative to the parent.
        /// </summary>
        public abstract float Y { get; set; }

        public bool Visible { get; set; }
        public int ZIndex { get; set; }

        private Diagram _diagram;
        public Diagram Diagram
        {
            [DebuggerHidden]
            get { return _diagram; }
            set
            {
                if (_diagram == value) return;

                // Side-effect: when removed from Diagram, also remove relationship between parent and child.
                if (value == null)
                {
                    // TODO: This would go wrong if this side effect was executed at the end of this
                    // property setter, because after the Diagram has been nullified, 
                    // you cannot manage parent-child relations at all anymore.
                    // This order-dependence stinks.
                    Parent = null;
                }

                if (_diagram != null)
                {
                    if (_diagram.Elements.Contains(this))
                    {
                        _diagram.Elements.Remove(this);
                    }
                }

                _diagram = value;

                if (_diagram != null)
                {
                    if (!_diagram.Elements.Contains(this))
                    {
                        _diagram.Elements.Add(this);
                    }
                }
            }
        }

        private Element _parent;
        public Element Parent 
        {
            [DebuggerHidden]
            get { return _parent; }
            set 
            {
                if (_diagram == null) throw new Exception("To assign a parent to a child, the child must be part of a diagram.");

                if (_parent == value) return;

                if (_parent != null)
                {
                    if (_parent.Children.Contains(this))
                    {
                        _parent.Children.Remove(this);
                    }
                }

                _parent = value;

                if (_parent != null)
                {
                    if (!_parent.Children.Contains(this))
                    {
                        _parent.Children.Add(this);
                    }
                }

                // Side-Effect: add orphans to root rectangle of Diagram.
                if (_parent == null)
                {
                    if (this != _diagram.RootRectangle)
                    {
                        _diagram.RootRectangle.Children.Add(this);
                    }
                }
            }
        }

        public ElementChildren Children { get; private set; }

        public bool EventBubblingEnabled { get; set; }

        /// <summary>
        /// The calculated ZIndex, which is derived from both
        /// the ZIndex and the containment structure.
        /// </summary>
        public int CalculatedZIndex { get; internal set; }

        /// <summary>
        /// In the flat clone solution this was internal.
        /// </summary>
        public int CalculatedLayer { get; internal set; }

        /// <summary>
        /// Calculated, absolute X coordinate.
        /// </summary>
        public float CalculatedX { get; internal set; }

        /// <summary>
        /// Calculated, absolute Y coordinate.
        /// </summary>
        public float CalculatedY { get; internal set; }
    }
}
