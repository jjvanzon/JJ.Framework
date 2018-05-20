using System;

namespace JJ.Framework.VectorGraphics.Models.Elements
{
	public class PointPosition : ElementPosition
	{
		internal PointPosition(Point point)
			: base(point) { }

		public override float X { get; set; }
		public override float Y { get; set; }

		public override float Width
		{
			get => 0;
			set => throw new NotSupportedException();
		}

		public override float Height
		{
			get => 0;
			set => throw new NotSupportedException();
		}
	}
}