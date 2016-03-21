using System;
using System.Collections.Generic;
using System.Linq;

namespace JJ.Framework.Presentation.VectorGraphics.Models.Elements
{
    public class LinePosition : ElementPosition
    {
        private Line _line;

        internal LinePosition(Line line)
            : base(line)
        {
            _line = line;
        }

        public override float X
        {
            get { return Math.Min(_line.PointA.Position.X, _line.PointB.Position.X); }
            set
            {
                float dx = _line.PointB.Position.X - _line.PointA.Position.X;
                _line.PointA.Position.X = value;
                _line.PointB.Position.X = _line.PointA.Position.X + dx;
            }
        }

        public override float Y
        {
            get { return Math.Min(_line.PointA.Position.Y, _line.PointB.Position.Y); }
            set
            {
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
