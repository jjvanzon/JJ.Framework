using System;
using System.Collections.Generic;

// ReSharper disable once CompareOfFloatsByEqualityOperator

namespace JJ.Framework.VectorGraphics.Positioners
{
	public class FlowPositionerLeftAligned : PositionerBase
	{
		private readonly float _rowWidth;
		private readonly float _rowHeight;
		private readonly float _horizontalSpacing;
		private readonly float _verticalSpacing;
		private readonly IList<float> _itemWidths;

		public FlowPositionerLeftAligned(
			float rowWidth,
			float rowHeight,
			float horizontalSpacing,
			float verticalSpacing,
			IList<float> itemWidths)
		{
			_rowWidth = rowWidth;
			_rowHeight = rowHeight;
			_horizontalSpacing = horizontalSpacing;
			_verticalSpacing = verticalSpacing;
			_itemWidths = itemWidths ?? throw new ArgumentNullException(nameof(itemWidths));
		}

		public override IList<(float x, float y, float width, float height)> Calculate()
		{
			int count = _itemWidths.Count;

			var rectangles = new (float x, float y, float width, float height)[count];

			float x = 0;
			float y = 0;

			bool isFirstItem = true;

			for (int i = 0; i < count; i++)
			{
				float itemWidth = _itemWidths[i];

				if (MustAdvanceRow(x, itemWidth, isFirstItem))
				{
					x = 0;
					y += _rowHeight + _verticalSpacing;
				}

				rectangles[i] = (x, y, itemWidth, _rowHeight);
				x += itemWidth + _horizontalSpacing;

				isFirstItem = false;
			}

			return rectangles;
		}

		private bool MustAdvanceRow(float x, float itemWidth, bool isFirstItem)
		{
			if (isFirstItem)
			{
				return false;
			}

			return x + itemWidth > _rowWidth;
		}
	}
}