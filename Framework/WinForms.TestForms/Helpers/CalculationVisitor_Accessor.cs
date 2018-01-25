using System.Collections.Generic;
using JJ.Framework.Reflection;
using JJ.Framework.VectorGraphics.Models.Elements;

namespace JJ.Framework.WinForms.TestForms.Helpers
{
	internal class CalculationVisitor_Accessor
	{
		private readonly Accessor _accessor;

		public CalculationVisitor_Accessor()
		{
			_accessor = new Accessor("JJ.Framework.VectorGraphics.Visitors.CalculationVisitor, JJ.Framework.VectorGraphics");
		}

		public IList<Element> Execute(Diagram diagram)
		{
			return (IList<Element>)_accessor.InvokeMethod("Execute", diagram);
		}
	}
}
