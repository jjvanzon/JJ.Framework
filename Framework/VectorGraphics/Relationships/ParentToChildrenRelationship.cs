using System.Collections.Generic;
using JJ.Framework.Business;
using JJ.Framework.VectorGraphics.Models.Elements;

namespace JJ.Framework.VectorGraphics.Relationships
{
	internal class ParentToChildrenRelationship : OneToManyRelationship<Element, Element>
	{
		public ParentToChildrenRelationship(Element parent, ICollection<Element> children)
			: base(parent, children)
		{ }

		protected override void SetParent(Element child) => child.Parent = _parent;
		protected override void NullifyParent(Element child) => child.NullifyParent();
	}
}
