using System.Collections;
using System.Collections.Generic;
using JJ.Framework.VectorGraphics.Relationships;
using JJ.Framework.VectorGraphics.SideEffects;

namespace JJ.Framework.VectorGraphics.Models.Elements
{
	public class DiagramElements : IEnumerable<Element>
	{
		private readonly IList<Element> _elements = new List<Element>();

		private readonly DiagramToElementsRelationship _relationship;

		internal DiagramElements(Diagram diagram)
		{
			_relationship = new DiagramToElementsRelationship(diagram, _elements);
		}

		public int Count => _elements.Count;

		internal void Add(Element element) => _relationship.Add(element);

		internal void Remove(Element element)
		{
			new SideEffect_AssertCannotRemoveBackgroundFromDiagram(element).Execute();
			_relationship.Remove(element);
		}

		public bool Contains(Element element) => _elements.Contains(element);

		// IEnumerable

		public IEnumerator<Element> GetEnumerator() => _elements.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => _elements.GetEnumerator();
	}
}
