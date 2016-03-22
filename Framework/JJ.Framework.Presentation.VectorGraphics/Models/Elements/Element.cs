using System.Collections.Generic;
using System.Diagnostics;
using JJ.Framework.Business;
using JJ.Framework.Presentation.VectorGraphics.Relationships;
using JJ.Framework.Presentation.VectorGraphics.Gestures;
using JJ.Framework.Presentation.VectorGraphics.SideEffects;
using System;

namespace JJ.Framework.Presentation.VectorGraphics.Models.Elements
{
    /// <summary> base class that can contain VectorGraphics child elements. </summary>
    public abstract partial class Element
    {
        internal Element()
        {
            Gestures = new List<IGesture>();
            CalculatedValues = new CalculatedValues();

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
        public abstract ElementPosition Position { get; }
        public CalculatedValues CalculatedValues { get; }

        // Gestures

        public IList<IGesture> Gestures { get; private set; }
        public bool MustBubble { get; set; }
        /// <summary> Indicates whether the element will respond to mouse and keyboard gestures. </summary>
        public bool Enabled { get; set; }

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
    }
}
