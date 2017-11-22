using JJ.Framework.Presentation.VectorGraphics.Models.Styling;
using JJ.Framework.Exceptions;
using System.Diagnostics;
using JJ.Framework.Presentation.VectorGraphics.Helpers;

namespace JJ.Framework.Presentation.VectorGraphics.Models.Elements
{
	[DebuggerDisplay("{" + nameof(DebuggerDisplay) + "}")]
	public class Label : Element
	{
		public Label()
		{
			Position = new LabelPosition(this);
		}

		public override ElementPosition Position { get; }

		public string Text { get; set; }

		private TextStyle _textStyle = new TextStyle();
		/// <summary> not nullable, auto-instantiated </summary>
		public TextStyle TextStyle
		{
			[DebuggerHidden]
			get { return _textStyle; }
			set
			{
				if (value == null) throw new NullException(() => value);
				_textStyle = value;
			}
		}

		private string DebuggerDisplay => DebugHelper.GetDebuggerDisplay(this);
	}
}
