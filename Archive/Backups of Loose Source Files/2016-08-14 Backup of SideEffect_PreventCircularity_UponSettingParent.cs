//using System;
//using System.Collections.Generic;
//using System.Linq;
//using JJ.Framework.Business;
//using JJ.Framework.Presentation.VectorGraphics.Models.Elements;
//using JJ.Framework.Reflection.Exceptions;

//namespace JJ.Framework.Presentation.VectorGraphics.SideEffects
//{
//    internal class SideEffect_PreventCircularity_UponSettingParent : ISideEffect
//    {
//        private readonly Element _child;
//        private readonly Element _newParent;

//        /// <param name="child">not nullable</param>
//        /// <param name="newParent">nullable</param>
//        public SideEffect_PreventCircularity_UponSettingParent(Element child, Element newParent)
//        {
//            if (child == null) throw new NullException(() => child);

//            _child = child;
//            _newParent = newParent;
//        }

//        public void Execute()
//        {
//            Element newAncestor = _newParent;

//            while (newAncestor != null)
//            {
//                if (newAncestor == _child)
//                {
//                    throw new Exception("Parent cannot be set, because it would cause a circular reference.");
//                }

//                newAncestor = newAncestor.Parent;
//            }
//        }
//    }
//}
