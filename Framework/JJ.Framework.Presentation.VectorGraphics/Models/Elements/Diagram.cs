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
using JJ.Framework.Presentation.VectorGraphics.Helpers;

namespace JJ.Framework.Presentation.VectorGraphics.Models.Elements
{
    public class Diagram : IDiagramGestureHandling
    {
        public Diagram()
        {
            Elements = new DiagramElements(this);
            Scaling = new DiagramScaling(this);

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

        // Scaling

        public DiagramScaling Scaling { get; private set; }

        // Calculation

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

            //if (e.MouseButtonEnum != MouseButtonEnum.None)
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