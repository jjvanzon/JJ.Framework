using JJ.Framework.Business;
using JJ.Framework.VectorGraphics.Models.Elements;

namespace JJ.Framework.VectorGraphics.Relationships
{
	internal class ElementToDiagramRelationship : ManyToOneRelationship<Element, Diagram>
	{
		public ElementToDiagramRelationship(Element element)
			: base(element)
		{ }

		protected override bool Contains(Diagram diagram) => diagram.Elements.Contains(_child);
		protected override void Add(Diagram diagram) => diagram.Elements.Add(_child);
		protected override void Remove(Diagram diagram) => diagram.Elements.Remove(_child);
	}
}
