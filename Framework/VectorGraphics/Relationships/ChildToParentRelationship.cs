using JJ.Framework.Business;
using JJ.Framework.VectorGraphics.Models.Elements;

namespace JJ.Framework.VectorGraphics.Relationships
{
	internal class ChildToParentRelationship : ManyToOneRelationship<Element, Element>
	{
		public ChildToParentRelationship(Element child)
			: base(child)
		{ }

		protected override bool Contains(Element parent) => parent.Children.Contains(_child);
		protected override void Add(Element parent) => parent.Children.Add(_child);
		protected override void Remove(Element parent) => parent.Children.Remove(_child);
	}
}
