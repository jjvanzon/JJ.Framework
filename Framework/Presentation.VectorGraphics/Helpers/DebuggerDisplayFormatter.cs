using System;
using System.Text;
using JJ.Framework.Exceptions;
using JJ.Framework.Presentation.VectorGraphics.Models.Elements;

namespace JJ.Framework.Presentation.VectorGraphics.Helpers
{
	internal static class DebuggerDisplayFormatter
	{
		public static string GetDebuggerDisplay(Ellipse circle)
		{
			if (circle == null) throw new NullException(() => circle);

			var sb = new StringBuilder();

			sb.Append($"{{{circle.GetType().Name}}} ");

			string tag = Convert.ToString(circle.Tag);
			if (!string.IsNullOrEmpty(tag))
			{
				sb.Append($"Tag='{circle.Tag}', ");
			}

			if (circle.Position != null)
			{
				sb.Append($"{GetDebuggerDisplay(circle.Position)} ");
			}

			sb.Append($"(HashCode={circle.GetHashCode()})");

			return sb.ToString();
		}

		public static string GetDebuggerDisplay(Label label)
		{
			if (label == null) throw new NullException(() => label);

			var sb = new StringBuilder();

			sb.Append($"{{{label.GetType().Name}}} ");
			sb.Append($"'{label.Text}', ");

			string tag = Convert.ToString(label.Tag);
			if (!string.IsNullOrEmpty(tag))
			{
				sb.Append($"Tag='{label.Tag}', ");
			}

			if (label.Position != null)
			{
				sb.Append($"{GetDebuggerDisplay(label.Position)} ");
			}

			sb.Append($"(HashCode={label.GetHashCode()})");

			return sb.ToString();
		}

		internal static string GetDebuggerDisplay(Line line)
		{
			if (line == null) throw new NullException(() => line);

			var sb = new StringBuilder();

			sb.Append($"{{{line.GetType().Name}}} ");

			string tag = Convert.ToString(line.Tag);
			if (!string.IsNullOrEmpty(tag))
			{
				sb.Append($"Tag='{tag}', ");
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
				sb.Append($"({line.PointA.Position.X}, {line.PointA.Position.Y}) - ({line.PointB.Position.X}, {line.PointB.Position.Y}) ");
			}

			sb.Append($"(HashCode={line.GetHashCode()})");

			return sb.ToString();
		}

		internal static string GetDebuggerDisplay(Point point)
		{
			if (point == null) throw new NullException(() => point);

			var sb = new StringBuilder();

			sb.Append($"{{{point.GetType().Name}}} ");

			string tag = Convert.ToString(point.Tag);
			if (!string.IsNullOrEmpty(tag))
			{
				sb.Append($"Tag='{point.Tag}', ");
			}

			sb.Append($"({point.Position.X}, {point.Position.Y}) ");

			sb.Append($"(HashCode={point.GetHashCode()})");

			return sb.ToString();
		}

		internal static string GetDebuggerDisplay(Rectangle rectangle)
		{
			if (rectangle == null) throw new NullException(() => rectangle);

			var sb = new StringBuilder();

			sb.Append($"{{{rectangle.GetType().Name}}} ");

			string tag = Convert.ToString(rectangle.Tag);
			if (!string.IsNullOrEmpty(tag))
			{
				sb.Append($"Tag='{rectangle.Tag}', ");
			}

			if (rectangle.Position != null)
			{
				sb.Append($"{GetDebuggerDisplay(rectangle.Position)} ");
			}

			sb.Append($"(HashCode={rectangle.GetHashCode()})");

			return sb.ToString();
		}

		internal static string GetDebuggerDisplay(ElementPosition elementPosition)
		{
			return $"X={elementPosition.X}, Y={elementPosition.Y}, Width={elementPosition.Width}, Height={elementPosition.Height}";
		}
	}
}