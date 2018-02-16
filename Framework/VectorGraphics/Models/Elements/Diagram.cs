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

		public DiagramPosition Position { get; }

		public void Recalculate() => _elementsOrderByZIndex = new CalculationVisitor().Execute(this);

		/// <summary>
		/// The gestures on the diagram always go off regardless of bubbling.
		/// It gives us a means to tap in on events at a more basic level.
		/// </summary>
		public IList<GestureBase> Gestures { get; } = new List<GestureBase>();

		/// <summary> For when you need to send primitive gestures to the diagram. </summary>
		public DiagramGestureHandling GestureHandling { get; }
	}
}