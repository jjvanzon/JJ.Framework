//using System.Collections.Generic;

//namespace JJ.Framework.VectorGraphics.Positioners
//{
//	public class FlowPositionerLeftAligned
//	{
//		// TODO: Move parameters to constructor. Then make Calculate method part of interface.

//		public IList<(float x, float y, float width, float height)> Calculate(
//			float rowWidth, 
//			float rowHeight,
//			IList<float> itemWidths)
//		{
//			int count = itemWidths.Count;

//			var resultRectangles = new (float x, float y, float width, float height)[count];

//			float x = 0;
//			float y = 0;

//			for (int i = 0; i < count; i++)
//			{
//				float itemWidth = itemWidths[i];

//				if (x + itemWidth > rowWidth)
//				{
//					x = 0;
//					y += rowHeight;
//				}

//				resultRectangles[i] = (x, y, itemWidth, rowHeight);

//				x += itemWidth;
//			}

//			return resultRectangles;
//		}
//	}
//}
