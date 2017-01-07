using System;
using JJ.Framework.Exceptions;

namespace JJ.Framework.Presentation.VectorGraphics.Models.Elements
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
                if (_line.PointA == null) throw new NullException(() => _line.PointA);
                if (_line.PointB == null) throw new NullException(() => _line.PointB);

                return Math.Min(_line.PointA.Position.X, _line.PointB.Position.X);
            }
            set
            {
                if (_line.PointA == null) throw new NullException(() => _line.PointA);
                if (_line.PointB == null) throw new NullException(() => _line.PointB);

                float dx = _line.PointB.Position.X - _line.PointA.Position.X;
                _line.PointA.Position.X = value;
                _line.PointB.Position.X = _line.PointA.Position.X + dx;
            }
        }

        public override float Y
        {
            get
            {
                if (_line.PointA == null) throw new NullException(() => _line.PointA);
                if (_line.PointB == null) throw new NullException(() => _line.PointB);

                return Math.Min(_line.PointA.Position.Y, _line.PointB.Position.Y);
            }
            set
            {
                if (_line.PointA == null) throw new NullException(() => _line.PointA);
                if (_line.PointB == null) throw new NullException(() => _line.PointB);

                float dy = _line.PointB.Position.Y - _line.PointA.Position.Y;
                _line.PointA.Position.Y = value;
                _line.PointB.Position.Y = _line.PointA.Position.Y + dy;
            }
        }

        public override float Width
        {
            get { return 0; }
            set { throw new NotSupportedException(); }
        }

        public override float Height
        {
            get { return 0; }
            set { throw new NotSupportedException(); }
        }
    }
}
