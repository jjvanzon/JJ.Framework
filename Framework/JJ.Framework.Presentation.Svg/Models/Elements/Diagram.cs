using JJ.Framework.Presentation.Svg.EventArg;
using JJ.Framework.Presentation.Svg.Gestures;
using JJ.Framework.Presentation.Svg.Models.Elements;
using JJ.Framework.Presentation.Svg.Visitors;
using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg.Elements
{
    public class Diagram
    {
        public Diagram(params IGesture[] gestures)
            : this((IList<IGesture>)gestures)
        { }

        public Diagram(IList<IGesture> gestures)
        {
            if (gestures == null) throw new NullException(() => gestures);

            Elements = new DiagramElements(this);

            _rootRectangle = new Rectangle();
            _rootRectangle.Diagram = this;

            _gestureHandler = new GestureHandler(this, gestures);
        }

        private Rectangle _rootRectangle;
        /// <summary> read-only </summary>
        [DebuggerHidden]
        public Rectangle RootRectangle
        {
            get { return _rootRectangle; }
        }

        public DiagramElements Elements { get; private set; }

        public void Recalculate()
        {
             var visitor = new CalculationVisitor();
             _elementsOrderByZIndex = visitor.Execute(_rootRectangle);
        }

        private IList<Element> _elementsOrderByZIndex = new Element[0];
        public IEnumerable<Element> EnumerateElementsByZIndex()
        {
            for (int i = 0; i < _elementsOrderByZIndex.Count; i++)
            {
                yield return _elementsOrderByZIndex[i];
            }
        }

        private readonly GestureHandler _gestureHandler;

        public void MouseDown(MouseEventArgs e)
        {
            _gestureHandler.MouseDown(e);

            Recalculate();
        }

        public void MouseMove(MouseEventArgs e)
        {
            _gestureHandler.MouseMove(e);

            Recalculate();
        }

        public void MouseUp(MouseEventArgs e)
        {
            _gestureHandler.MouseUp(e);

            Recalculate();
        }
    }
}
