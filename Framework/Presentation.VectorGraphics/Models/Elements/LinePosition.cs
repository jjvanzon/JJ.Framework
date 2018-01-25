using System;

namespace JJ.Framework.VectorGraphics.Models.Elements
{
	public class LinePosition : ElementPosition
	{
		private readonly Line _line;

		internal LinePosition(Line line)
			: base(line)
		{
			_line = line;
		}

		public override float X
		{
			get
			{
				if (_line.PointA == null) return 0f;
				if (_line.PointB == null) return 0f;

				return Math.Min(_line.PointA.Position.X, _line.PointB.Position.X);
			}
			set
			{
				if (_line.PointA == null) return;
				if (_line.PointB == null) return;

				float dx = _line.PointB.Position.X - _line.PointA.Position.X;
				_line.PointA.Position.X = value;
				_line.PointB.Position.X = _line.PointA.Position.X + dx;
			}
		}

		public override float Y
		{
			get
			{
				if (_line.PointA == null) return 0f;
				if (_line.PointB == null) return 0f;

				return Math.Min(_line.PointA.Position.Y, _line.PointB.Position.Y);
			}
			set
			{
				if (_line.PointA == null) return;
				if (_line.PointB == null) return;

				float dy = _line.PointB.Position.Y - _line.PointA.Position.Y;
				_line.PointA.Position.Y = value;
				_line.PointB.Position.Y = _line.PointA.Position.Y + dy;
			}
		}

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
