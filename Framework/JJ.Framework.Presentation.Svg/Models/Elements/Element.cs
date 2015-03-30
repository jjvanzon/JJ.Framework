using JJ.Framework.Presentation.Svg;
using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using JJ.Framework.Presentation.Svg.EventArg;
using JJ.Framework.Presentation.Svg.Business;
using JJ.Framework.Business;

namespace JJ.Framework.Presentation.Svg.Models.Elements
{
    /// <summary>
    /// A base class that can contain SVG child elements.
    /// </summary>
    public abstract class Element
    {
        internal Element()
        {
            _childToParentRelationship = new ChildToParentRelationship(this);

            Children = new ElementChildren(parent: this);
            Visible = true;
        }

        // Values

        /// <summary>
        /// X-coordinate relative to the parent.
        /// </summary>
        public abstract float X { get; set; }

        /// <summary>
        /// X-coordinate relative to the parent.
        /// </summary>
        public abstract float Y { get; set; }

        public abstract float Width { get; set; }
        public abstract float Height { get; set; }

        public bool Visible { get; set; }
        public int ZIndex { get; set; }

        // Related Objects

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

        private ChildToParentRelationship _childToParentRelationship;

        //private Element _parent;

        public Element Parent
        {
            //[DebuggerHidden]
            get { return _childToParentRelationship.Parent; }
            set 
            {
                // Side-effect: equate parent's and child's diagram.
                if (value != null)
                {
                    if (value.Diagram == null && this.Diagram == null)
                    {
                        throw new Exception("To assign a parent to a child, one of them must be part of a diagram.");
                    }
                    else if (value.Diagram == null && this.Diagram != null)
                    {
                        value.Diagram = this.Diagram;
                    }
                    else if (value.Diagram != null && this.Diagram == null)
                    {
                        this.Diagram = value.Diagram;
                    }
                    else if (value.Diagram != null && this.Diagram != null)
                    {
                        if (value.Diagram != this.Diagram)
                        {
                            throw new Exception("Diagram of parent and child must be the same.");
                        }
                    }
                }

                //var relationshipHandler = new ParentToChildrenHandler2();
                //relationshipHandler.SetParent(this, _parent, value);

                _childToParentRelationship.SetParent(value);

                //if (_parent == value) return;

                //if (_parent != null)
                //{
                //    if (_parent.Children.Contains(this))
                //    {
                //        _parent.Children.Remove(this);
                //    }
                //}

                //_parent = value;

                //if (_parent != null)
                //{
                //    if (!_parent.Children.Contains(this))
                //    {
                //        _parent.Children.Add(this);
                //    }
                //}

                // Side-Effect: add orphans to root rectangle of Diagram.
                if (_childToParentRelationship.Parent == null)
                {
                    if (this != _diagram.RootRectangle)
                    {
                        _diagram.RootRectangle.Children.Add(this);
                    }
                }
            }
        }

        public ElementChildren Children { get; private set; }

        // Calculated Values

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

        // Events

        public bool EventBubblingEnabled { get; set; }

        public event EventHandler<MouseEventArgs> OnMouseDown;
        public event EventHandler<MouseEventArgs> OnMouseMove;
        public event EventHandler<MouseEventArgs> OnMouseUp;

        internal void MouseDown(object sender, MouseEventArgs e)
        {
            if (OnMouseDown != null) OnMouseDown(sender, e);
        }

        internal void MouseUp(object sender, MouseEventArgs e)
        {
            if (OnMouseUp != null) OnMouseUp(sender, e);
        }

        internal void MouseMove(object sender, MouseEventArgs e)
        {
            if (OnMouseMove != null) OnMouseMove(sender, e);
        }
    }
}
