using JJ.Framework.Presentation.Svg;
using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using JJ.Framework.Presentation.Svg.EventArg;
using JJ.Framework.Business;
using JJ.Framework.Presentation.Svg.Relationships;
using JJ.Framework.Presentation.Svg.Elements;
using JJ.Framework.Presentation.Svg.Gestures;

namespace JJ.Framework.Presentation.Svg.Models.Elements
{
    /// <summary>
    /// A base class that can contain SVG child elements.
    /// </summary>
    public abstract class Element
    {
        internal Element(IList<IGesture> gestures)
        {
            if (gestures == null) throw new NullException(() => gestures);

            Gestures = gestures.ToList();

            _parentRelationship = new ChildToParentRelationship(this);
            _diagramRelationship = new ElementToDiagramRelationship(this);

            Children = new ElementChildren(parent: this);
            Visible = true;
            Bubble = true;
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

        private ElementToDiagramRelationship _diagramRelationship;

        public Diagram Diagram
        {
            [DebuggerHidden]
            get { return _diagramRelationship.Parent; }
            set
            {
                // Side-effect: when removed from Diagram, also remove relationship between parent and child.
                if (value == null)
                {
                    // TODO: This would go wrong if this side effect was executed at the end of this
                    // property setter, because after the Diagram has been nullified, 
                    // you cannot manage parent-child relations at all anymore.
                    // This order-dependence stinks.
                    Parent = null;
                }

                _diagramRelationship.Parent = value;
            }
        }

        private ChildToParentRelationship _parentRelationship;

        public Element Parent
        {
            get { return _parentRelationship.Parent; }
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

                _parentRelationship.Parent = value;

                // Side-Effect: add orphans to root rectangle of Diagram.
                if (Parent == null)
                {
                    if (this != Diagram.RootRectangle)
                    {
                        Diagram.RootRectangle.Children.Add(this);
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

        // Gestures

        public IList<IGesture> Gestures { get; private set; }

        /// <summary>
        /// When true, events that go off on a child element
        /// also go off on a parent element.
        /// </summary>
        public bool Bubble { get; set; }

        public event EventHandler<MouseEventArgs> OnMouseDown;
        public event EventHandler<MouseEventArgs> OnMouseUp;

        internal void MouseDown(object sender, MouseEventArgs e)
        {
            if (OnMouseDown != null) OnMouseDown(sender, e);
        }

        internal void MouseUp(object sender, MouseEventArgs e)
        {
            if (OnMouseUp != null) OnMouseUp(sender, e);
        }
    }
}
