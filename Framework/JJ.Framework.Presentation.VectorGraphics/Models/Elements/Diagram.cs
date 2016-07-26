using JJ.Framework.Presentation.VectorGraphics.Gestures;
using JJ.Framework.Presentation.VectorGraphics.Models.Styling;
using JJ.Framework.Presentation.VectorGraphics.Visitors;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace JJ.Framework.Presentation.VectorGraphics.Models.Elements
{
    public class Diagram
    {
        public Diagram()
        {
            Elements = new DiagramElements(this);
            Position = new DiagramPosition(this);
            Gestures = new List<GestureBase>();
            GestureHandling = new DiagramGestureHandling(this);

            _background = new Rectangle();
            _background.Style.LineStyle = new LineStyle { Visible = false };
            _background.Diagram = this;
            _background.ZIndex = Int32.MinValue;
            _background.Tag = "Background";
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

        public DiagramPosition Position { get; private set; }

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
        public IList<GestureBase> Gestures { get; private set; }

        /// <summary> For when you need to send primitive gestures to the diagram. </summary>
        public DiagramGestureHandling GestureHandling { get; private set; }
    }
}