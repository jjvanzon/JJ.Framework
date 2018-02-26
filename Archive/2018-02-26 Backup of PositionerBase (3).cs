//using System;
//using System.Collections.Generic;
//using JJ.Framework.Exceptions;
//using JJ.Framework.VectorGraphics.Models.Elements;

//namespace JJ.Framework.VectorGraphics.Positioners
//{
//	public abstract class PositionerBase : IPositioner
//	{
//		public abstract IList<(float x, float y, float width, float height)> Calculate();

//		public void Calculate(IReadOnlyList<Element> elements)
//		{
//			if (elements == null) throw new ArgumentNullException(nameof(elements));

//			IList<(float x, float y, float width, float height)> tuples = Calculate();

//			int count = elements.Count;

//			if (tuples.Count != count)
//			{
//				throw new NotEqualException(() => tuples.Count, elements.Count);
//			}

//			for (int i = 0; i < count; i++)
//			{
//				ElementPosition elementPosition = elements[i].Position;
//				(elementPosition.X, elementPosition.Y, elementPosition.Width, elementPosition.Height) = tuples[i];
//			}
//		}
//	}
//}
