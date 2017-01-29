using System.Collections.Generic;
using System.Diagnostics;
using JJ.Framework.Business;
using JJ.Framework.Presentation.VectorGraphics.Relationships;
using JJ.Framework.Presentation.VectorGraphics.Gestures;
using JJ.Framework.Presentation.VectorGraphics.SideEffects;

namespace JJ.Framework.Presentation.VectorGraphics.Models.Elements
{
    /// <summary> base class that can contain VectorGraphics child elements. </summary>
    public abstract partial class Element
    {
        internal Element()
        {
            Gestures = new List<GestureBase>();
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

        public IList<GestureBase> Gestures { get; }
        public bool MustBubble { get; set; }
        /// <summary> Indicates whether the element will respond to mouse and keyboard gestures. </summary>
        public bool Enabled { get; set; }

        // Related Objects

        private readonly ElementToDiagramRelationship _diagramRelationship;

        public Diagram Diagram
        {
            [DebuggerHidden]
            get { return _diagramRelationship.Parent; }
            set
            {
                if (_diagramRelationship.Parent == value) return;

                ISideEffect sideEffect1 = new SideEffect_AssertCannotChangeBackGroundDiagram(this, _diagramRelationship.Parent);
                sideEffect1.Execute();

                ISideEffect sideEffect2 = new SideEffect_AssertNoParentChildRelationShips_UponSettingDiagram(this);
                sideEffect2.Execute();

                _diagramRelationship.Parent = value;
            }
        }

        private readonly ChildToParentRelationship _parentRelationship;

        public Element Parent
        {
            [DebuggerHidden]
            get { return _parentRelationship.Parent; }
            set
            {
                if (_parentRelationship.Parent == value) return;

                ISideEffect sideEffect1 = new SideEffect_AssertDiagram_UponSettingParentOrChild(this, value);
                sideEffect1.Execute();

                ISideEffect sideEffect2 = new SideEffect_PreventCircularity(this, value);
                sideEffect2.Execute();

                _parentRelationship.Parent = value;
            }
        }

        public ElementChildren Children { get; }
    }
}
