using System.Collections.Generic;
using JJ.Framework.VectorGraphics.Gestures;
using JJ.Framework.VectorGraphics.Models.Styling;
using JJ.Framework.VectorGraphics.Visitors;

namespace JJ.Framework.VectorGraphics.Models.Elements
{
    public class Diagram
    {
        public Diagram()
        {
            Elements = new DiagramElements(this);
            Position = new DiagramPosition(this);
            GestureHandling = new DiagramGestureHandling(this);

            Background = new Rectangle(this)
            {
                ZIndex = int.MinValue,
                Tag = "Background",
                Style = { LineStyle = new LineStyle { Visible = false } }
            };
        }

        private readonly CalculationVisitor _calculationVisitor = new CalculationVisitor();

        /// <summary>
        /// Might be not much use setting coordinates of this element,
        /// since the scaled coordinates are taken over from the Diagram
        /// upon recalculation.
        /// This property may be used to style the back ground.
        /// It also could serve as the parent element for elements that might otherwise not have one.
        /// Also, gestures might be set to operate on this background element.
        /// </summary>
        public Rectangle Background { get; }
        public DiagramElements Elements { get; }

        /// <inheritdoc cref="DiagramPosition"/>
        public DiagramPosition Position { get; }
        public IList<Element> ElementsOrderedByZIndex { get; private set; } = new Element[0];

        public void Recalculate() => ElementsOrderedByZIndex = _calculationVisitor.Execute(this);

        /// <summary>
        /// The gestures on the diagram always go off regardless of bubbling.
        /// It gives us a means to tap in on events at a more basic level.
        /// </summary>
        public IList<GestureBase> Gestures { get; } = new List<GestureBase>();

        /// <summary> For when you need to send primitive gestures to the diagram. </summary>
        public DiagramGestureHandling GestureHandling { get; }
    }
}