using System;
using System.Diagnostics;
using JJ.Framework.VectorGraphics.Helpers;
using JJ.Framework.VectorGraphics.Models.Styling;

namespace JJ.Framework.VectorGraphics.Models.Elements
{
	public class Picture : Element
	{
		public Picture()
		{
			Position = new RectanglePosition(this);
		}

		public override ElementPosition Position { get; }

		private PictureStyle _style = new PictureStyle();
		/// <summary> not nullable, auto-instantiated </summary>
		public PictureStyle Style
		{
			[DebuggerHidden]
			get => _style;
			set => _style = value ?? throw new ArgumentNullException(nameof(Style));
		}

		private IUnderlyingPictureWrapper _underlyingPictureWrapper;

		/// <see cref="IUnderlyingPictureWrapper" />
		public T GetUnderlyingPictureWrapper<T>() where T : IUnderlyingPictureWrapper
		{
			if (_underlyingPictureWrapper == null) throw new ArgumentNullException(nameof(IUnderlyingPictureWrapper));
			return (T)_underlyingPictureWrapper;
		}

		public void SetUnderlyingPictureWrapper(IUnderlyingPictureWrapper underlyingPictureWrapper)
		{
			_underlyingPictureWrapper = underlyingPictureWrapper ?? throw new ArgumentNullException(nameof(underlyingPictureWrapper));
		}
	}
}
