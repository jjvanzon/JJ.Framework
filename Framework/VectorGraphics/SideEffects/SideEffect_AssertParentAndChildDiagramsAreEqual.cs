using System;
using JJ.Framework.Business;
using JJ.Framework.VectorGraphics.Models.Elements;

namespace JJ.Framework.VectorGraphics.SideEffects
{
	public class SideEffect_AssertParentAndChildDiagramsAreEqual : ISideEffect
	{
		private readonly Element _parent;
		private readonly Element _child;

		public SideEffect_AssertParentAndChildDiagramsAreEqual(Element child, Element parent)
		{
			_parent = parent;
			_child = child ?? throw new ArgumentNullException(nameof(child));
		}

		public void Execute()
		{
			if (_parent == null) return;

			if (_parent.Diagram != _child.Diagram)
			{
				throw new Exception("Parent child must have the same diagram.");
			}
		}
	}
}
