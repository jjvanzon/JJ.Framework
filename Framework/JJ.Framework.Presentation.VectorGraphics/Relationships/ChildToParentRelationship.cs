using JJ.Framework.Business;
using JJ.Framework.Presentation.VectorGraphics.Models.Elements;

namespace JJ.Framework.Presentation.VectorGraphics.Relationships
{
    internal class ChildToParentRelationship : ManyToOneRelationship<Element, Element>
    {
        public ChildToParentRelationship(Element child)
            : base(child)
        { }

        protected override bool Contains(Element parent)
        {
            return parent.Children.Contains(_child);
        }

        protected override void Add(Element parent)
        {
            parent.Children.Add(_child);
        }

        protected override void Remove(Element parent)
        {
            parent.Children.Remove(_child);
        }
    }
}
