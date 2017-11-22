namespace JJ.Framework.Presentation.VectorGraphics.Models.Elements
{
	public class RectanglePosition : ElementPosition
	{
		internal RectanglePosition(Rectangle point)
			: base(point)
		{ }

		public override float X { get; set; }
		public override float Y { get; set; }

		public override float Width { get; set; }
		public override float Height { get; set; }
	}
}
