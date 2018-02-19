using System.Collections.Generic;
using JJ.Framework.Business;
using JJ.Framework.VectorGraphics.Models.Elements;

namespace JJ.Framework.VectorGraphics.Relationships
{
	internal class DiagramToElementsRelationship : OneToManyRelationship<Diagram, Element>
	{
		public DiagramToElementsRelationship(Diagram diagram, IList<Element> elements)
			: base(diagram, elements)
		{ }

		protected override void SetParent(Element element) => element.Diagram = _parent;
		protected override void NullifyParent(Element element) => element.NullifyDiagram();
	}
}
