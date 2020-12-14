using System.Collections.Generic;
using JJ.Framework.Exceptions.Comparative;

namespace JJ.Framework.VectorGraphics.Positioners
{
	/// <summary>
	/// Lays out items vertically, spread equally over a specified space.
	/// </summary>
	public class VerticalPositioner : PositionerBase
	{
		private readonly float _leftX;
		private readonly float _topY;
		private readonly float _totalWidth;
		private readonly float _totalHeight;
		private readonly int _itemCount;

		/// <inheritdoc cref="VerticalPositioner" />
		/// <param name="leftX"> Left coordinate of the space to position items in. </param>
		/// <param name="topY"> Top coordinate of the space to position items in. </param>
		/// <param name="totalWidth"> Total width to position all the items in. </param>
		/// <param name="totalHeight"> Total height to position all the items in. </param>
		/// <param name="itemCount"> Amount of items. </param>
		public VerticalPositioner(
			float leftX,
			float topY,
			float totalWidth,
			float totalHeight,
			int itemCount)
		{
			if (itemCount <= 0) throw new LessThanOrEqualException(() => itemCount, 0);

			_leftX = leftX;
			_topY = topY;
			_totalWidth = totalWidth;
			_totalHeight = totalHeight;
			_itemCount = itemCount;
		}

		/// <inheritdoc />
		public override IList<(float x, float y, float width, float height)> Calculate()
		{
			float itemHeight = _totalHeight / _itemCount;

			float y = _topY;

			var rectangles = new (float x, float y, float width, float height)[_itemCount];

			for (int i = 0; i < _itemCount; i++)
			{
				rectangles[i] = (_leftX, y, _totalWidth, itemHeight);

				y += itemHeight;
			}

			return rectangles;
		}
	}
}
