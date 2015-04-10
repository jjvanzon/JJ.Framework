using JJ.Framework.Presentation.Svg.Enums;
using JJ.Framework.Presentation.Svg.EventArg;
using JJ.Framework.Presentation.Svg.Gestures;
using JJ.Framework.Presentation.Svg.Models.Elements;
using JJ.Framework.Presentation.Svg.Visitors;
using JJ.Framework.Reflection.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg.Models.Elements
{
    public class Diagram
    {
        public event EventHandler PaintRequested;

        public Diagram()
        {
            Elements = new DiagramElements(this);

            _canvas = new Rectangle();
            _canvas.Diagram = this;
            _canvas.ZIndex = Int32.MinValue;
            _canvas.Tag = "Canvas";

            _gestureHandler = new GestureHandler(this);
        }

        private Rectangle _canvas;
        /// <summary> read-only. TODO: Rename to Canvas? </summary>
        [DebuggerHidden]
        public Rectangle Canvas
        {
            get { return _canvas; }
        }

        public DiagramElements Elements { get; private set; }

        public void Recalculate()
        {
             var visitor = new CalculationVisitor();
             _elementsOrderByZIndex = visitor.Execute(this);

             //if (PaintRequested != null)
             //{
             //    PaintRequested(this, EventArgs.Empty);
             //}
        }

        private IList<Element> _elementsOrderByZIndex = new Element[0];
        public IEnumerable<Element> EnumerateElementsByZIndex()
        {
            for (int i = 0; i < _elementsOrderByZIndex.Count; i++)
            {
                yield return _elementsOrderByZIndex[i];
            }
        }

        // Gestures

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
