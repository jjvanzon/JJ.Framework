using System;
using System.Text;
using JJ.Framework.Exceptions;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.VectorGraphics.Models.Elements;

namespace JJ.Framework.VectorGraphics.Helpers
{
	internal static class DebuggerDisplayFormatter
	{
		public static string GetDebuggerDisplay(Element element)
		{
			if (element == null) throw new NullException(() => element);

			var sb = new StringBuilder();

			sb.Append($"{{{element.GetType().Name}}} ");

			string tag = Convert.ToString(element.Tag);
			if (!string.IsNullOrEmpty(tag))
			{
				sb.Append($"Tag='{element.Tag}', ");
			}

			if (element.Position != null)
			{
				sb.Append($"{GetDebuggerDisplay(element.Position)} ");
			}

			sb.Append($"(HashCode={element.GetHashCode()})");

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

		public static string GetDebuggerDisplay(Line line)
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

		public static string GetDebuggerDisplay(Point point)
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

		public static string GetDebuggerDisplay(ElementPosition elementPosition)
		{
			return $"X={elementPosition.X}, Y={elementPosition.Y}, Width={elementPosition.Width}, Height={elementPosition.Height}";
		}
	}
}