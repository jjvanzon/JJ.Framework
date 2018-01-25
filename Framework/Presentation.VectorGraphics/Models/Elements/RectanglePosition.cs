namespace JJ.Framework.VectorGraphics.Models.Elements
{
	/// <summary>
	/// Not only used for Rectangles, but also used for Labels and Ellipses.
	/// </summary>
	public class RectanglePosition : ElementPosition
	{
		internal RectanglePosition(Element element)
			: base(element)
		{ }

		public override float X { get; set; }
		public override float Y { get; set; }

		public override float Width { get; set; }
		public override float Height { get; set; }
	}
}
