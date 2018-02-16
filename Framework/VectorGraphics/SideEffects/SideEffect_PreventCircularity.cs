using System;
using JJ.Framework.Business;
using JJ.Framework.VectorGraphics.Models.Elements;

namespace JJ.Framework.VectorGraphics.SideEffects
{
	internal class SideEffect_PreventCircularity : ISideEffect
	{
		private readonly Element _child;
		private readonly Element _parent;

		public SideEffect_PreventCircularity(Element child, Element parent)
		{
			_parent = parent;
			_child = child ?? throw new ArgumentNullException(nameof(child));
		}

		public void Execute()
		{
			Element ancestor = _parent;

			while (ancestor != null)
			{
				if (ancestor == _child)
				{
					throw new Exception("Child cannot be added or parent cannot set, because it would cause a circular reference.");
				}

				ancestor = ancestor.Parent;
			}
		}
	}
}
