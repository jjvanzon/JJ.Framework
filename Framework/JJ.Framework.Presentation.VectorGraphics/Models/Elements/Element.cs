using JJ.Framework.Reflection.Exceptions;
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
    public abstract class Element : ICalculatedValues
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
            Enabled = true;
        }

        // Coordinates & Values

        /// <summary> X-coordinate relative to the parent. depending on Diagram.ScaleModeEnum. </summary>
        public abstract float X { get; set; }

        /// <summary> Y-coordinate relative to the parent. Scaled depending on Diagram.ScaleModeEnum. </summary>
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

        public float RelativeToAbsoluteX(float relativeX)
        {
            float absoluteX = relativeX;

            Element element = this;
            while (element != null)
            {
                absoluteX += element.X;
                element = element.Parent;
            }

            return absoluteX;
        }

        public float RelativeToAbsoluteY(float relativeY)
        {
            float absoluteY = relativeY;

            Element element = this;
            while (element != null)
            {
                absoluteY += element.Y;
                element = element.Parent;
            }

            return absoluteY;
        }

        public float AbsoluteToRelativeX(float absoluteX)
        {
            float relativeX = absoluteX;

            Element element = this;
            while (element != null)
            {
                relativeX -= element.X;
                element = element.Parent;
            }

            return relativeX;
        }

        public float AbsoluteToRelativeY(float absoluteY)
        {
            float relativeY = absoluteY;

            Element element = this;
            while (element != null)
            {
                relativeY -= element.Y;
                element = element.Parent;
            }

            return relativeY;
        }

        // To and from pixels is derived from the conversions between relative and absolute,
        // and the diagram's conversions between pixels and scaled.

        public float PixelsToRelativeX(float xInPixels)
        {
            if (Diagram == null) throw new NullException(() => Diagram);

            float value = Diagram.PixelsToScaledX(xInPixels);
            value = AbsoluteToRelativeX(value);
            return value;
        }

        public float PixelsToRelativeY(float yInPixels)
        {
            if (Diagram == null) throw new NullException(() => Diagram);

            float value = Diagram.PixelsToScaledY(yInPixels);
            value = AbsoluteToRelativeY(value);
            return value;
        }

        public float RelativeToPixelsX(float relativeX)
        {
            if (Diagram == null) throw new NullException(() => Diagram);

            float value = RelativeToAbsoluteX(relativeX);
            value = Diagram.ScaledToPixelsX(value);
            return value;
        }

        public float RelativeToPixelsY(float relativeY)
        {
            if (Diagram == null) throw new NullException(() => Diagram);

            float value = RelativeToAbsoluteY(relativeY);
            value = Diagram.ScaledToPixelsY(value);
            return value;
        }

        public float PixelsToAbsoluteX(float xInPixels)
        {
            if (Diagram == null) throw new NullException(() => Diagram);

            // Just delegates to the Diagram method. These methods are here for syntactic sugar.
            float value = Diagram.PixelsToScaledX(xInPixels);
            return value;
        }

        public float PixelsToAbsoluteY(float yInPixels)
        {
            if (Diagram == null) throw new NullException(() => Diagram);

            // Just delegates to the Diagram method. These methods are here for syntactic sugar.
            float value = Diagram.PixelsToScaledY(yInPixels);
            return value;
        }

        public float AbsoluteToPixelsX(float absoluteX)
        {
            if (Diagram == null) throw new NullException(() => Diagram);

            // Just delegates to the Diagram method. These methods are here for syntactic sugar.
            float value = Diagram.ScaledToPixelsX(absoluteX);
            return value;
        }

        public float AbsoluteToPixelsY(float absoluteY)
        {
            if (Diagram == null) throw new NullException(() => Diagram);

            // Just delegates to the Diagram method. These methods are here for syntactic sugar.
            float value = Diagram.ScaledToPixelsY(absoluteY);
            return value;
        }

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
