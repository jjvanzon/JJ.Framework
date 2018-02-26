//using System;
//using System.Collections.Generic;
//using JJ.Framework.Exceptions;
//using JJ.Framework.VectorGraphics.Models.Elements;

//namespace JJ.Framework.VectorGraphics.Positioners
//{
//	public abstract class PositionerBase : IPositioner
//	{
//		public abstract IList<(float x, float y, float width, float height)> Calculate();

//		public void Calculate(IList<Element> elements)
//		{
//			if (elements == null) throw new ArgumentNullException(nameof(elements));

//			IList<(float x, float y, float width, float height)> tuples = Calculate();

//			if (tuples.Count != elements.Count)
//			{
//				throw new NotEqualException(() => tuples.Count, elements.Count);
//			}

//			int count = elements.Count;

//			for (int i = 0; i < count; i++)
//			{
//				ElementPosition elementPosition = elements[i].Position;
//				(elementPosition.X, elementPosition.Y, elementPosition.Width, elementPosition.Height) = tuples[i];
//			}
//		}
//	}
//}
