using JJ.Framework.Exceptions;
using JJ.Framework.VectorGraphics.Enums;
using JJ.Framework.VectorGraphics.Helpers;

namespace JJ.Framework.VectorGraphics.Models.Elements
{
	public class DiagramPosition
	{
		private readonly Diagram _diagram;

		internal DiagramPosition(Diagram diagram)
		{
			_diagram = diagram ?? throw new NullException(() => diagram);
		}

		private float _widthInPixels = 1;
		/// <summary> non-zero </summary>
		public float WidthInPixels
		{
			get => _widthInPixels;
			set
			{
				// ReSharper disable once CompareOfFloatsByEqualityOperator
				if (value == 0.0) throw new ZeroException(() => WidthInPixels);
				_widthInPixels = value;
			}
		}

		private float _heightInPixels = 1;
		/// <summary> non-zero </summary>
		public float HeightInPixels
		{
			get => _heightInPixels;
			set
			{
				// ReSharper disable once CompareOfFloatsByEqualityOperator
				if (value == 0.0) throw new ZeroException(() => HeightInPixels);
				_heightInPixels = value;
			}
		}

		public ScaleModeEnum ScaleModeEnum { get; set; }

		private float _scaledX;
		/// <summary> Note that it might not return what you assign, depending on the ScaleModeEnum. </summary>
		public float ScaledX
		{
			get
			{
				switch (ScaleModeEnum)
				{
					case ScaleModeEnum.Pixels:
						return 0;

					case ScaleModeEnum.ViewPort:
						return _scaledX;

					default:
						throw new ValueNotSupportedException(ScaleModeEnum);
				}
			}
			set { _scaledX = value; }
		}

		private float _scaledY;
		/// <summary> Note that it might not return what you assign, depending on the ScaleModeEnum. </summary>
		public float ScaledY
		{
			get
			{
				switch (ScaleModeEnum)
				{
					case ScaleModeEnum.Pixels:
						return 0;

					case ScaleModeEnum.ViewPort:
						return _scaledY;

					default:
						throw new ValueNotSupportedException(ScaleModeEnum);
				}
			}
			set { _scaledY = value; }
		}

		private float _scaledWidth = 1;
		/// <summary> Non-zero. Note that it might not return what you assign, depending on the ScaleModeEnum. </summary>
		public float ScaledWidth
		{
			get
			{
				switch (ScaleModeEnum)
				{
					case ScaleModeEnum.Pixels:
						return _widthInPixels;

					case ScaleModeEnum.ViewPort:
						return _scaledWidth;

					default:
						throw new ValueNotSupportedException(ScaleModeEnum);
				}
			}
			set
			{
				// ReSharper disable once CompareOfFloatsByEqualityOperator
				if (value == 0f) throw new ZeroException(() => ScaledWidth); // TODO: Float comparison to exactly 0 seems pointless. Figure out what to do.
				_scaledWidth = value;
			}
		}

		private float _scaledHeight = 1;
		/// <summary> Non-zero. Note that it might not return what you assign, depending on the ScaleModeEnum. </summary>
		public float ScaledHeight
		{
			get
			{
				switch (ScaleModeEnum)
				{
					case ScaleModeEnum.Pixels:
						return _heightInPixels;

					case ScaleModeEnum.ViewPort:
						return _scaledHeight;

					default:
						throw new ValueNotSupportedException(ScaleModeEnum);
				}
			}
			set
			{
				// ReSharper disable once CompareOfFloatsByEqualityOperator
				if (value == 0f) throw new ZeroException(() => ScaledHeight); // TODO: Float comparison to exactly 0 seems pointless. Figure out what to do.
				_scaledHeight = value;
			}
		}

		public float ScaledRight => ScaledX + ScaledWidth;
		public float ScaledBottom => ScaledY + ScaledHeight;
		public bool XAxisIsFlipped => ScaledWidth < 0f;
		public bool YAxisIsFlipped => ScaledHeight < 0f;

		public float PixelsToX(float xInPixels) => ScaleHelper.PixelsToX(_diagram, xInPixels);
		public float PixelsToY(float yInPixels) => ScaleHelper.PixelsToY(_diagram, yInPixels);
		public float XToPixels(float scaledX) => ScaleHelper.XToPixels(_diagram, scaledX);
		public float YToPixels(float scaledY) => ScaleHelper.YToPixels(_diagram, scaledY);
		public float PixelsToWidth(float widthInPixels) => ScaleHelper.PixelsToWidth(_diagram, widthInPixels);
		public float PixelsToHeight(float heightInPixels) => ScaleHelper.PixelsToHeight(_diagram, heightInPixels);
		public float WidthToPixels(float scaledWidth) => ScaleHelper.WidthToPixels(_diagram, scaledWidth);
		public float HeightToPixels(float scaledHeight) => ScaleHelper.HeightToPixels(_diagram, scaledHeight);
	}
}
