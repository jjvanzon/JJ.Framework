using System;
using System.Collections.Generic;

namespace JJ.Framework.VectorGraphics.Positioners
{
	public class FlowPositionerRightAligned : IPositioner
	{
		private readonly float _rowWidth;
		private readonly float _rowHeight;
		private readonly IList<float> _itemWidths;

		public FlowPositionerRightAligned(float rowWidth, float rowHeight, IList<float> itemWidths)
		{
			_rowWidth = rowWidth;
			_rowHeight = rowHeight;
			_itemWidths = itemWidths ?? throw new ArgumentNullException(nameof(itemWidths));
		}

		public IList<(float x, float y, float width, float height)> Calculate()
		{
			int count = _itemWidths.Count;

			var rectangles = new(float x, float y, float width, float height)[count];

			int firstIndexInRow = 0;

			float x = 0;
			float y = 0;

			for (int i = 0; i < count; i++)
			{
				float itemWidth = _itemWidths[i];

				if (x + itemWidth > _rowWidth)
				{
					// Correct the coordinates now that the used space has been determined.
					float rowWidthRemainder = _rowWidth - x;
					for (int j = firstIndexInRow; j < i; j++)
					{
						rectangles[j].x += rowWidthRemainder;
					}

					firstIndexInRow = i;
					x = 0;
					y += _rowHeight;
				}

				rectangles[i] = (x, y, itemWidth, _rowHeight);

				x += itemWidth;
			}

			// Correct the coordinates now that the used space has been determined.
			{
				float rowWidthRemainder = _rowWidth - x;
				for (int j = firstIndexInRow; j < count; j++)
				{
					rectangles[j].x += rowWidthRemainder;
				}
			}

			return rectangles;
		}
	}
}