using JJ.Framework.Presentation.VectorGraphics.Gestures;
using JJ.Framework.Presentation.VectorGraphics.Models.Styling;
using JJ.Framework.Presentation.VectorGraphics.Visitors;
using System.Collections.Generic;

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

            Background = new Rectangle
            {
                Diagram = this,
                ZIndex = int.MinValue,
                Tag = "Background"
            };
            Background.Style.LineStyle = new LineStyle { Visible = false };
        }

        /// <summary> read-only, not nullable </summary>
        public Rectangle Background { get; }

        public DiagramElements Elements { get; }

        private IList<Element> _elementsOrderByZIndex = new Element[0];
        public IEnumerable<Element> EnumerateElementsByZIndex()
        {
            for (int i = 0; i < _elementsOrderByZIndex.Count; i++)
            {
                yield return _elementsOrderByZIndex[i];
            }
        }

        // Scaling

        public DiagramPosition Position { get; }

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
        public IList<GestureBase> Gestures { get; }

        /// <summary> For when you need to send primitive gestures to the diagram. </summary>
        public DiagramGestureHandling GestureHandling { get; }
    }
}