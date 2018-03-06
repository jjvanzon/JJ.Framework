using JJ.Framework.Exceptions;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.VectorGraphics.Models.Styling;

namespace JJ.Framework.VectorGraphics.Helpers
{
	public static class CloneExtensions
	{
		public static BackStyle Clone(this BackStyle source)
		{
			if (source == null) throw new NullException(() => source);

			var dest = new BackStyle
			{
				Color = source.Color,
				Visible = source.Visible
			};

			return dest;
		}

		public static Font Clone(this Font source)
		{
			if (source == null) throw new NullException(() => source);

			var dest = new Font
			{
				Bold = source.Bold,
				Italic = source.Italic,
				Name = source.Name,
				Size = source.Size
			};

			return dest;
		}

		public static LineStyle Clone(this LineStyle source)
		{
			if (source == null) throw new NullException(() => source);

			var dest = new LineStyle
			{
				Visible = source.Visible,
				Width = source.Width,
				Color = source.Color,
				DashStyleEnum = source.DashStyleEnum
			};

			return dest;
		}

		public static PointStyle Clone(this PointStyle source)
		{
			if (source == null) throw new NullException(() => source);

			var dest = new PointStyle
			{
				Color = source.Color,
				Visible = source.Visible,
				Width = source.Width
			};

			return dest;
		}

		/// <summary> Will also clone TextStyle.Font. </summary>
		public static TextStyle Clone(this TextStyle source)
		{
			if (source == null) throw new NullException(() => source);

			var dest = new TextStyle
			{
				Color = source.Color,
				Abbreviate = source.Abbreviate,
				Wrap = source.Wrap,
				HorizontalAlignmentEnum = source.HorizontalAlignmentEnum,
				VerticalAlignmentEnum = source.VerticalAlignmentEnum,
				Font = source.Font.Clone()
			};

			return dest;
		}
	}
}
