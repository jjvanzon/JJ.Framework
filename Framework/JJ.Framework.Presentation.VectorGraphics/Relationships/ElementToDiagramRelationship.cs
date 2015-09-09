using JJ.Framework.Business;
using JJ.Framework.Presentation.VectorGraphics.Models.Elements;

namespace JJ.Framework.Presentation.VectorGraphics.Relationships
{
    internal class ElementToDiagramRelationship : ManyToOneRelationship<Element, Diagram>
    {
        public ElementToDiagramRelationship(Element element)
            : base(element)
        { }

        protected override bool Contains(Diagram diagram)
        {
            return diagram.Elements.Contains(_child);
        }

        protected override void Add(Diagram diagram)
        {
            diagram.Elements.Add(_child);
        }

        protected override void Remove(Diagram diagram)
        {
            diagram.Elements.Remove(_child);
        }
    }
}
