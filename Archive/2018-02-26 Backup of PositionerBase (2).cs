//using System;
//using System.Collections.Generic;
//using JJ.Framework.VectorGraphics.Models.Elements;

//namespace JJ.Framework.VectorGraphics.Positioners
//{
//	public abstract class PositionerBase : IPositioner
//	{
//		public abstract IList<(float x, float y, float width, float height)> Calculate();

//		public void Calculate(IEnumerable<Element> elements)
//		{
//			if (elements == null) throw new ArgumentNullException(nameof(elements));

//			IList<(float x, float y, float width, float height)> tuples = Calculate();

//			int i = 0;
//			foreach (Element element in elements)
//			{
//				ElementPosition elementPosition = element.Position;

//				(elementPosition.X, elementPosition.Y, elementPosition.Width, elementPosition.Height) = tuples[i];

//				i++;
//			}
//		}
//	}
//}
