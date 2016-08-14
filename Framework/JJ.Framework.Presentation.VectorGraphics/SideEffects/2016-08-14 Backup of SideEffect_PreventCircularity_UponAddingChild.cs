//using System;
//using System.Collections.Generic;
//using System.Linq;
//using JJ.Framework.Business;
//using JJ.Framework.Presentation.VectorGraphics.Models.Elements;
//using JJ.Framework.Reflection.Exceptions;

//namespace JJ.Framework.Presentation.VectorGraphics.SideEffects
//{
//    internal class SideEffect_PreventCircularity_UponAddingChild : ISideEffect
//    {
//        private readonly Element _parent;
//        private readonly Element _newChild;

//        public SideEffect_PreventCircularity_UponAddingChild(Element parent, Element newChild)
//        {
//            if (parent == null) throw new NullException(() => parent);
//            if (newChild == null) throw new NullException(() => newChild);

//            _parent = parent;
//            _newChild = newChild;
//        }

//        public void Execute()
//        {
//            Element ancestor = _parent;

//            while (ancestor != null)
//            {
//                if (ancestor == _newChild)
//                {
//                    throw new Exception("Child cannot be added, because it would cause a circular reference.");
//                }

//                ancestor = ancestor.Parent;
//            }
//        }
//    }
//}
