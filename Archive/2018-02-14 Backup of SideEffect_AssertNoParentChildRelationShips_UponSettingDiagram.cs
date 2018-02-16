//using System;
//using JJ.Framework.Business;
//using JJ.Framework.Exceptions;
//using JJ.Framework.VectorGraphics.Models.Elements;

//namespace JJ.Framework.VectorGraphics.SideEffects
//{
//	internal class SideEffect_AssertNoParentChildRelationShips_UponSettingDiagram : ISideEffect
//	{
//		private readonly Element _element;

//		public SideEffect_AssertNoParentChildRelationShips_UponSettingDiagram(Element element)
//		{
//			_element = element ?? throw new NullException(() => element);
//		}

//		public void Execute()
//		{
//			if (_element.Parent != null)
//			{
//				throw new Exception("An Element must have no parent-child relationships when you add or remove it from a Diagram. The element still has a parent.");
//			}

//			if (_element.Children.Count != 0)
//			{
//				throw new Exception("An Element must have no parent-child relationships when you add or remove it from a Diagram. the element still has children.");
//			}
//		}
//	}
//}
