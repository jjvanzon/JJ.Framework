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
    public class Diagram : IDiagramGestureHandling
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

        private float _widthInPixels = 1;
        /// <summary> non-zero </summary>
        public float WidthInPixels
        {
            get { return _widthInPixels; }
            set
            {
                if (value == 0) throw new ZeroException(() => WidthInPixels); // TODO: Float comparison to exactly 0 seems pointless. Figure out what to do.
                _widthInPixels = value;
            }
        }

        private float _heightInPixels = 1;
        /// <summary> non-zero </summary>
        public float HeightInPixels
        {
            get { return _heightInPixels; }
            set
            {
                if (value == 0) throw new ZeroException(() => HeightInPixels);  // TODO: Float comparison to exactly 0 seems pointless. Figure out what to do.
                _heightInPixels = value;
            }
        }

        public ScaleModeEnum ScaleModeEnum { get; set; }

        public float ScaledX { get; set; }
        public float ScaledY { get; set; }

        private float _scaledWidth = 1;
        /// <summary> non-zero </summary>
        public float ScaledWidth
        {
            get { return _scaledWidth; }
            set
            {
                if (value == 0) throw new ZeroException(() => ScaledWidth); // TODO: Float comparison to exactly 0 seems pointless. Figure out what to do.
                _scaledWidth = value;
            }
        }

        private float _scaledHeight = 1;
        /// <summary> non-zero </summary>
        public float ScaledHeight
        {
            get { return _scaledHeight; }
            set
            {
                if (value == 0) throw new ZeroException(() => ScaledHeight); // TODO: Float comparison to exactly 0 seems pointless. Figure out what to do.
                _scaledHeight = value;
            }
        }
        
        public float PixelsToX(float xInPixels)
        {
            switch (ScaleModeEnum)
            {
                case ScaleModeEnum.None:
                    return xInPixels;

                case ScaleModeEnum.ViewPort:
                    float scaledX = ScaledX + xInPixels / WidthInPixels * ScaledWidth;
                    return scaledX;

                default:
                    throw new ValueNotSupportedException(ScaleModeEnum);
            }
        }

        public float PixelsToY(float yInPixels)
        {
            switch (ScaleModeEnum)
            {
                case ScaleModeEnum.None:
                    return yInPixels;

                case ScaleModeEnum.ViewPort:
                    float scaledY = ScaledY + yInPixels / HeightInPixels * ScaledHeight;
                    return scaledY;

                default:
                    throw new ValueNotSupportedException(ScaleModeEnum);
            }
        }

        public float XToPixels(float scaledX)
        {
            switch (ScaleModeEnum)
            {
                case ScaleModeEnum.None:
                    return scaledX;

                case ScaleModeEnum.ViewPort:
                    float xInPixels = (scaledX - ScaledX) / ScaledWidth * WidthInPixels;
                    return xInPixels;

                default:
                    throw new ValueNotSupportedException(ScaleModeEnum);
            }
        }

        public float YToPixels(float scaledY)
        {
            switch (ScaleModeEnum)
            {
                case ScaleModeEnum.None:
                    return scaledY;

                case ScaleModeEnum.ViewPort:
                    float yInPixels = (scaledY - ScaledY) / ScaledHeight * HeightInPixels;
                    return yInPixels;

                default:
                    throw new ValueNotSupportedException(ScaleModeEnum);
            }
        }

        public float PixelsToWidth(float widthInPixels)
        {
            switch (ScaleModeEnum)
            {
                case ScaleModeEnum.None:
                    return widthInPixels;

                case ScaleModeEnum.ViewPort:
                    float result = widthInPixels / WidthInPixels * ScaledWidth;
                    return result;

                default:
                    throw new ValueNotSupportedException(ScaleModeEnum);
            }
        }

        public float PixelsToHeight(float heightInPixels)
        {
            switch (ScaleModeEnum)
            {
                case ScaleModeEnum.None:
                    return heightInPixels;

                case ScaleModeEnum.ViewPort:
                    float result = heightInPixels / HeightInPixels * ScaledHeight;
                    return result;

                default:
                    throw new ValueNotSupportedException(ScaleModeEnum);
            }
        }

        public float WidthToPixels(float scaledWidth)
        {
            switch (ScaleModeEnum)
            {
                case ScaleModeEnum.None:
                    return scaledWidth;

                case ScaleModeEnum.ViewPort:
                    float result = scaledWidth / ScaledWidth * WidthInPixels;
                    return result;

                default:
                    throw new ValueNotSupportedException(ScaleModeEnum);
            }
        }

        public float HeightToPixels(float scaledHeight)
        {
            switch (ScaleModeEnum)
            {
                case ScaleModeEnum.None:
                    return scaledHeight;

                case ScaleModeEnum.ViewPort:
                    float result = scaledHeight / ScaledHeight * HeightInPixels;
                    return result;

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

        void IDiagramGestureHandling.HandleMouseDown(MouseEventArgs e)
        {
            _gestureHandler.HandleMouseDown(e);

            Recalculate();
        }

        void IDiagramGestureHandling.HandleMouseMove(MouseEventArgs e)
        {
            _gestureHandler.HandleMouseMove(e);

            if (e.MouseButtonEnum != MouseButtonEnum.None)
            {
                Recalculate();
            }
        }

        void IDiagramGestureHandling.HandleMouseUp(MouseEventArgs e)
        {
            _gestureHandler.HandleMouseUp(e);

            Recalculate();
        }

        void IDiagramGestureHandling.HandleKeyDown(KeyEventArgs keyEventArgs)
        {
            _gestureHandler.HandleKeyDown(keyEventArgs);
        }

        void IDiagramGestureHandling.HandleKeyUp(KeyEventArgs keyEventArgs)
        {
            _gestureHandler.HandleKeyUp(keyEventArgs);
        }
    }
}