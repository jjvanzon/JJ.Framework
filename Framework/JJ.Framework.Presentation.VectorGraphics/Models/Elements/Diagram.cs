using JJ.Framework.Presentation.VectorGraphics.Enums;
using JJ.Framework.Presentation.VectorGraphics.EventArg;
using JJ.Framework.Presentation.VectorGraphics.Gestures;
using JJ.Framework.Presentation.VectorGraphics.Models.Styling;
using JJ.Framework.Presentation.VectorGraphics.Visitors;
using JJ.Framework.Reflection.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using JJ.Framework.Common;

namespace JJ.Framework.Presentation.VectorGraphics.Models.Elements
{
    public class Diagram
    {
        public Diagram()
        {
            Elements = new DiagramElements(this);

            _background = new Rectangle();
            _background.LineStyle = new LineStyle { Visible = false };
            _background.Diagram = this;
            _background.ZIndex = Int32.MinValue;
            _background.Tag = "Background";

            Gestures = new List<IGesture>();
            _gestureHandler = new GestureHandler(this);
        }

        private Rectangle _background;
        /// <summary> read-only, not nullable </summary>
        [DebuggerHidden]
        public Rectangle Background
        {
            get { return _background; }
        }

        public DiagramElements Elements { get; private set; }

        private IList<Element> _elementsOrderByZIndex = new Element[0];
        public IEnumerable<Element> EnumerateElementsByZIndex()
        {
            for (int i = 0; i < _elementsOrderByZIndex.Count; i++)
            {
                yield return _elementsOrderByZIndex[i];
            }
        }

        private float _absoluteWidth = 1;
        /// <summary> non-zero </summary>
        public float AbsoluteWidth
        {
            get { return _absoluteWidth; }
            set
            {
                if (value == 0) throw new ZeroException(() => AbsoluteWidth); // TODO: Float comparison to exactly 0 seems pointless. Figure out what to do.
                _absoluteWidth = value;
            }
        }

        private float _absoluteHeight = 1;
        /// <summary> non-zero </summary>
        public float AbsoluteHeight
        {
            get { return _absoluteHeight; }
            set
            {
                if (value == 0) throw new ZeroException(() => AbsoluteHeight);  // TODO: Float comparison to exactly 0 seems pointless. Figure out what to do.
                _absoluteHeight = value;
            }
        }

        public ScaleModeEnum ScaleModeEnum { get; set; }

        public float ScaleX { get; set; }
        public float ScaleY { get; set; }

        private float _scaleWidth = 1;
        /// <summary> non-zero </summary>
        public float ScaleWidth
        {
            get { return _scaleWidth; }
            set
            {
                if (value == 0) throw new ZeroException(() => ScaleWidth); // TODO: Float comparison to exactly 0 seems pointless. Figure out what to do.
                _scaleWidth = value;
            }
        }

        private float _scaleHeight = 1;
        /// <summary> non-zero </summary>
        public float ScaleHeight
        {
            get { return _scaleHeight; }
            set
            {
                if (value == 0) throw new ZeroException(() => ScaleHeight); // TODO: Float comparison to exactly 0 seems pointless. Figure out what to do.
                _scaleHeight = value;
            }
        }

        public float AbsoluteToScaledX(float absoluteX)
        {
            switch (ScaleModeEnum)
            {
                case ScaleModeEnum.None:
                    return absoluteX;

                case ScaleModeEnum.ViewPort:
                    float scaledX = ScaleX + absoluteX / AbsoluteWidth * ScaleWidth;
                    return scaledX;

                default:
                    throw new ValueNotSupportedException(ScaleModeEnum);
            }
        }

        public float AbsoluteToScaledY(float absoluteY)
        {
            switch (ScaleModeEnum)
            {
                case ScaleModeEnum.None:
                    return absoluteY;

                case ScaleModeEnum.ViewPort:

                    float scaledY = ScaleY + absoluteY / AbsoluteHeight * ScaleHeight;
                    return scaledY;

                default:
                    throw new ValueNotSupportedException(ScaleModeEnum);
            }
        }

        public void Recalculate()
        {
            var visitor = new CalculationVisitor();
            _elementsOrderByZIndex = visitor.Execute(this);
        }

        // Gestures

        /// <summary>
        /// The gestures on the diagram always go off regardless of bubbling.
        /// It gives us a means to tap in on events at a more basic level.
        /// </summary>
        public IList<IGesture> Gestures { get; private set; }

        private readonly GestureHandler _gestureHandler;

        public void HandleMouseDown(MouseEventArgs e)
        {
            _gestureHandler.HandleMouseDown(e);

            Recalculate();
        }

        public void HandleMouseMove(MouseEventArgs e)
        {
            _gestureHandler.HandleMouseMove(e);

            if (e.MouseButtonEnum != MouseButtonEnum.None)
            {
                Recalculate();
            }
        }

        public void HandleMouseUp(MouseEventArgs e)
        {
            _gestureHandler.HandleMouseUp(e);

            Recalculate();
        }

        public void HandleKeyDown(KeyEventArgs keyEventArgs)
        {
            _gestureHandler.HandleKeyDown(keyEventArgs);
        }

        public void HandleKeyUp(KeyEventArgs keyEventArgs)
        {
            _gestureHandler.HandleKeyUp(keyEventArgs);
        }
    }
}