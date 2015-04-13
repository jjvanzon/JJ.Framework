using JJ.Framework.Presentation.Svg;
using JJ.Framework.Reflection.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using JJ.Framework.Presentation.Svg.EventArg;
using JJ.Framework.Business;
using JJ.Framework.Presentation.Svg.Relationships;
using JJ.Framework.Presentation.Svg.Gestures;
using JJ.Framework.Presentation.Svg.SideEffects;

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

            Gestures = gestures;

            _parentRelationship = new ChildToParentRelationship(this);
            _diagramRelationship = new ElementToDiagramRelationship(this);

            Children = new ElementChildren(parent: this);
            Visible = true;
            MustBubble = true;
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

        public object Tag { get; set; }

        // Related Objects

        private ElementToDiagramRelationship _diagramRelationship;

        public Diagram Diagram
        {
            [DebuggerHidden]
            get { return _diagramRelationship.Parent; }
            set
            {
                if (_diagramRelationship.Parent == value) return;

                ISideEffect sideEffect = new SideEffect_VerifyNoParentChildRelationShips_WhenSettingDiagram(this);
                sideEffect.Execute();

                _diagramRelationship.Parent = value;
            }
        }

        private ChildToParentRelationship _parentRelationship;

        public Element Parent
        {
            [DebuggerHidden]
            get { return _parentRelationship.Parent; }
            set 
            {
                if (_parentRelationship.Parent == value) return;

                ISideEffect sideEffect = new SideEffect_VerifyDiagram_WhenSettingParentOrChild(this, value);
                sideEffect.Execute();

                _parentRelationship.Parent = value;
            }
        }

        public ElementChildren Children { get; private set; }

        // Calculated Values

        /// <summary>
        /// The calculated ZIndex, which is derived from both
        /// the ZIndex and the containment structure.
        /// </summary>
        public int CalculatedZIndex { get; internal set; }

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

        public bool MustBubble { get; set; }
    }
}
