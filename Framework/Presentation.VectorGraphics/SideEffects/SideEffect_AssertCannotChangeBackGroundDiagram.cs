using System;
using JJ.Framework.Business;
using JJ.Framework.Presentation.VectorGraphics.Models.Elements;
using JJ.Framework.Exceptions;

namespace JJ.Framework.Presentation.VectorGraphics.SideEffects
{
	internal class SideEffect_AssertCannotChangeBackGroundDiagram : ISideEffect
	{
		private readonly Diagram _diagram;
		private readonly Element _element;

		/// <param name="diagram">nullable</param>
		public SideEffect_AssertCannotChangeBackGroundDiagram(Element element, Diagram diagram)
		{
			if (element == null) throw new NullException(() => element);

			_diagram = diagram;
			_element = element;
		}

		public void Execute()
		{
			if (_diagram == null)
			{
				return;
			}

			bool isBackGroundElement = _element == _diagram.Background;
			if (isBackGroundElement)
			{
				// Can only set background element once in the Diagram's constructor.
				throw new Exception("Cannot change Background element's Diagram.");
			}
		}
	}
}