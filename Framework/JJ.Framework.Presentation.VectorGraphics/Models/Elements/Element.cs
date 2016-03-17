using JJ.Framework.Reflection.Exceptions;
using System.Collections.Generic;
using System.Diagnostics;
using JJ.Framework.Business;
using JJ.Framework.Presentation.VectorGraphics.Relationships;
using JJ.Framework.Presentation.VectorGraphics.Gestures;
using JJ.Framework.Presentation.VectorGraphics.SideEffects;
using System;
using JJ.Framework.Presentation.VectorGraphics.Helpers;

namespace JJ.Framework.Presentation.VectorGraphics.Models.Elements
{
    /// <summary> base class that can contain VectorGraphics child elements. </summary>
    public abstract partial class Element : ICalculatedValues
    {
        internal Element()
        {
            Gestures = new List<IGesture>();
            Scaling = new ElementScaling(this);

            _parentRelationship = new ChildToParentRelationship(this);
            _diagramRelationship = new ElementToDiagramRelationship(this);

            Children = new ElementChildren(parent: this);
            Visible = true;
            MustBubble = true;
            Enabled = true;
        }

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

                if (_diagramRelationship.Parent != null)
                {
                    bool isBackGroundElement = this == _diagramRelationship.Parent.Background;
                    if (isBackGroundElement)
                    {
                        // Can only set background element once in the Diagram's constructor.
                        throw new Exception("Cannot change Background element's Diagram.");
                    }
                }

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

        // Gestures

        public IList<IGesture> Gestures { get; private set; }

        public bool MustBubble { get; set; }

        /// <summary> Indicates whether the element will respond to mouse and keyboard gestures. </summary>
        public bool Enabled { get; set; }

        // Scaling

        /// <summary> X-coordinate relative to the parent. depending on Diagram.ScaleModeEnum. </summary>
        public abstract float X { get; set; }

        /// <summary> Y-coordinate relative to the parent. Scaled depending on Diagram.ScaleModeEnum. </summary>
        public abstract float Y { get; set; }

        public abstract float Width { get; set; }
        public abstract float Height { get; set; }

        public ElementScaling Scaling { get; private set; }

        // Calculated Values

        /// <summary> The calculated ZIndex, which is derived from both the ZIndex and the containment structure. </summary>
        internal int CalculatedZIndex { get; set; }
        internal float CalculatedXInPixels { get; set; }
        internal float CalculatedYInPixels { get; set; }
        internal float CalculatedWidthInPixels { get; set; }
        internal float CalculatedHeightInPixels { get; set; }
        internal int CalculatedLayer { get; set; }
        internal bool CalculatedVisible { get; set; }
        internal bool CalculatedEnabled { get; set; }

        int ICalculatedValues.CalculatedZIndex { get { return CalculatedZIndex; } }
        float ICalculatedValues.CalculatedXInPixels { get { return CalculatedXInPixels; } }
        float ICalculatedValues.CalculatedYInPixels { get { return CalculatedYInPixels; } }
        float ICalculatedValues.CalculatedWidthInPixels { get { return CalculatedWidthInPixels; } }
        float ICalculatedValues.CalculatedHeightInPixels { get { return CalculatedHeightInPixels; } }
        int ICalculatedValues.CalculatedLayer { get { return CalculatedLayer; } }
        bool ICalculatedValues.CalculatedVisible { get { return CalculatedVisible; } }
        bool ICalculatedValues.CalculatedEnabled { get { return CalculatedEnabled; } }
    }
}
