using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using JJ.Framework.Exceptions;
using JJ.Framework.Presentation.VectorGraphics.Relationships;
using JJ.Framework.Presentation.VectorGraphics.SideEffects;

namespace JJ.Framework.Presentation.VectorGraphics.Models.Elements
{
	public class DiagramElements : IEnumerable<Element>
	{
		private readonly Diagram _diagram;
		private readonly IList<Element> _elements = new List<Element>();

		private readonly DiagramToElementsRelationship _relationship;

		internal DiagramElements(Diagram diagram)
		{
			_diagram = diagram ?? throw new NullException(() => diagram);

			_relationship = new DiagramToElementsRelationship(diagram, _elements);
		}

		[DebuggerHidden]
		public int Count => _elements.Count;

		public void Add(Element element)
		{
			new SideEffect_AssertNoParentChildRelationShips_UponSettingDiagram(element).Execute();

			_relationship.Add(element);
		}

		public void Remove(Element element)
		{
			new SideEffect_AssertCannotRemoveBackgroundFromDiagram(element).Execute();
			new SideEffect_AssertNoParentChildRelationShips_UponSettingDiagram(element).Execute();

			_relationship.Remove(element);
		}

		[DebuggerHidden]
		public bool Contains(Element element) => _elements.Contains(element);

		public void Clear()
		{
			foreach (Element element in _elements.ToArray())
			{
				if (element == _diagram.Background)
				{
					continue;
				}

				Remove(element);
			}
		}

		// IEnumerable

		[DebuggerHidden]
		public IEnumerator<Element> GetEnumerator() => _elements.GetEnumerator();

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator() => _elements.GetEnumerator();
	}
}
