using System;
using System.Text;
using JJ.Framework.Presentation.VectorGraphics.Models.Elements;
using JJ.Framework.Exceptions;

namespace JJ.Framework.Presentation.VectorGraphics.Helpers
{
    internal static class DebugHelper
    {
        public static string GetDebuggerDisplay(Label label)
        {
            if (label == null) throw new NullException(() => label);

            var sb = new StringBuilder();

            sb.AppendFormat("{{{0}}} ", label.GetType().Name);
            sb.AppendFormat("'{0}', ", label.Text);

            string tag = Convert.ToString(label.Tag);
            if (!string.IsNullOrEmpty(tag))
            {
                sb.AppendFormat("Tag='{0}', ", label.Tag);
            }

            sb.AppendFormat("X={0}, Y={1} ", label.Position.X, label.Position.Y);
            sb.AppendFormat("(HashCode={0})", label.GetHashCode());

            return sb.ToString();
        }

        internal static string GetDebuggerDisplay(Line line)
        {
            if (line == null) throw new NullException(() => line);

            var sb = new StringBuilder();

            sb.AppendFormat("{{{0}}} ", line.GetType().Name);

            string tag = Convert.ToString(line.Tag);
            if (!string.IsNullOrEmpty(tag))
            {
                sb.AppendFormat("Tag='{0}', ", tag);
            }

            if (line.PointA == null)
            {
                sb.Append("<PointA is null> ");
            }

            if (line.PointB == null)
            {
                sb.Append("<PointB is null> ");
            }

            if (line.PointA != null && line.PointB != null)
            {
                sb.AppendFormat(
                    "({0}, {1}) - ({2}, {3}) ",
                    line.PointA.Position.X,
                    line.PointA.Position.Y,
                    line.PointB.Position.X,
                    line.PointB.Position.Y);
            }

            sb.AppendFormat("(HashCode={0})", line.GetHashCode());

            return sb.ToString();
        }

        internal static string GetDebuggerDisplay(Point point)
        {
            if (point == null) throw new NullException(() => point);

            var sb = new StringBuilder();

            sb.AppendFormat("{{{0}}} ", point.GetType().Name);

            string tag = Convert.ToString(point.Tag);
            if (!string.IsNullOrEmpty(tag))
            {
                sb.AppendFormat("Tag='{0}', ", point.Tag);
            }

            sb.AppendFormat("({0}, {1}) ", point.Position.X, point.Position.Y);

            sb.AppendFormat("(HashCode={0})", point.GetHashCode());

            return sb.ToString();
        }

        internal static string GetDebuggerDisplay(Rectangle rectangle)
        {
            if (rectangle == null) throw new NullException(() => rectangle);

            var sb = new StringBuilder();

            sb.AppendFormat("{{{0}}} ", rectangle.GetType().Name);

            string tag = Convert.ToString(rectangle.Tag);
            if (!string.IsNullOrEmpty(tag))
            {
                sb.AppendFormat("Tag='{0}', ", rectangle.Tag);
            }

            sb.AppendFormat(
                "X={0}, Y={1}, Width={2}, Height={3} ", 
                rectangle.Position.X,
                rectangle.Position.Y,
                rectangle.Position.Width,
                rectangle.Position.Height);

            sb.AppendFormat("(HashCode={0})", rectangle.GetHashCode());

            return sb.ToString();
        }
    }
}