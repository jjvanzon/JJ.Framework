using System.Diagnostics;
using JJ.Framework.Exceptions;
using JJ.Framework.Presentation.VectorGraphics.Models.Styling;

namespace JJ.Framework.Presentation.VectorGraphics.Models.Elements
{
	public class RectangleStyle
	{
		internal RectangleStyle()
		{ }

		private BackStyle _backStyle = new BackStyle();
		/// <summary> not nullable, auto-instantiated </summary>
		public BackStyle BackStyle
		{
			[DebuggerHidden]
			get => _backStyle;
			set => _backStyle = value ?? throw new NullException(() => value);
		}

		private LineStyle _topLineStyle = new LineStyle();
		/// <summary> not nullable, auto-instantiated </summary>
		public LineStyle TopLineStyle
		{
			[DebuggerHidden]
			get => _topLineStyle;
			set => _topLineStyle = value ?? throw new NullException(() => value);
		}

		private LineStyle _rightLineStyle = new LineStyle();
		/// <summary> not nullable, auto-instantiated </summary>
		public LineStyle RightLineStyle
		{
			[DebuggerHidden]
			get => _rightLineStyle;
			set => _rightLineStyle = value ?? throw new NullException(() => value);
		}

		private LineStyle _bottomLineStyle = new LineStyle();
		/// <summary> not nullable, auto-instantiated </summary>
		public LineStyle BottomLineStyle
		{
			[DebuggerHidden]
			get => _bottomLineStyle;
			set => _bottomLineStyle = value ?? throw new NullException(() => value);
		}

		private LineStyle _leftLineStyle = new LineStyle();
		/// <summary> not nullable, auto-instantiated </summary>
		public LineStyle LeftLineStyle
		{
			[DebuggerHidden]
			get => _leftLineStyle;
			set => _leftLineStyle = value ?? throw new NullException(() => value);
		}

		/// <summary>
		/// Sets the style of all 4 lines at the same time.
		/// Returns a single LineStyle in case all border lines have the same style.
		/// Otherwise returns null.
		/// </summary>
		public LineStyle LineStyle
		{
			get
			{
				if (TopLineStyle == RightLineStyle &&
					RightLineStyle == BottomLineStyle &&
					BottomLineStyle == LeftLineStyle)
				{
					return TopLineStyle;
				}

				return null;
			}
			set
			{
				TopLineStyle = value;
				RightLineStyle = value;
				BottomLineStyle = value;
				LeftLineStyle = value;
			}
		}
	}
}