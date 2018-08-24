using System;
using JJ.Framework.VectorGraphics.Enums;
using JJ.Framework.VectorGraphics.Models.Elements;

namespace JJ.Framework.VectorGraphics.EventArg
{
	public class MouseEventArgs : EventArgs
	{
        /// <summary> nullable </summary>
		public Element Element { get; }
		public float XInPixels { get; }
		public float YInPixels { get; }
		public MouseButtonEnum MouseButtonEnum { get; }

		/// <param name="element">nullable</param>
		public MouseEventArgs(Element element, float xInPixels, float yInPixels, MouseButtonEnum mouseButtonEnum)
		{
			Element = element;
			XInPixels = xInPixels;
			YInPixels = yInPixels;
			MouseButtonEnum = mouseButtonEnum;
		}
	}
}
