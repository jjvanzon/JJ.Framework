namespace JJ.Framework.VectorGraphics.Models.Elements
{
	public class Ellipse : Element
	{
		/// <inheritdoc />
		public Ellipse(Element parent) : base(parent) => Position = new RectanglePosition(this);

		public override ElementPosition Position { get; }

		public EllipseStyle Style { get; } = new EllipseStyle();
	}
}
