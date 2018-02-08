using System;
using System.Diagnostics;
using JJ.Framework.VectorGraphics.Models.Styling;

namespace JJ.Framework.VectorGraphics.Models.Elements
{
	public class Picture : Element
	{
		public Picture() => Position = new RectanglePosition(this);

		public override ElementPosition Position { get; }

		private PictureStyle _style = new PictureStyle();

		/// <summary> not nullable, auto-instantiated </summary>
		public PictureStyle Style
		{
			[DebuggerHidden] get => _style;
			set => _style = value ?? throw new ArgumentNullException(nameof(Style));
		}

		private object _underlyingPicture;

		public object UnderlyingPicture
		{
			get => _underlyingPicture ?? throw new ArgumentNullException(nameof(UnderlyingPicture));
			set => _underlyingPicture = value ?? throw new ArgumentNullException(nameof(UnderlyingPicture));
		}
	}
}