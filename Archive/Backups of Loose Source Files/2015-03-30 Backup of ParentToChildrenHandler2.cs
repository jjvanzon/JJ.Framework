//using JJ.Framework.Business;
//using JJ.Framework.Presentation.Svg.Models.Elements;
//using JJ.Framework.Reflection;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace JJ.Framework.Presentation.Svg.Business
//{
//    internal class ParentToChildrenHandler2 : OneToManyHandler2<Element, Element>
//    {
//        private Element _parent;
//        private IList<Element> _children;

//        /// <param name="parent">Nullable depending on what you are going to do with it.</param>
//        /// <param name="children">Nullable depending on what you are going to do with it.</param>
//        public ParentToChildrenHandler2(Element parent, IList<Element> children)
//        {
//            _parent = parent;
//            _children = children;
//        }

//        protected override Element OnGetParent(Element child)
//        {
//            return child.Parent;
//        }

//        protected override void OnSetParent(Element child, Element parent)
//        {
//            child.Parent = parent;
//        }

//        protected override void OnAddChild(Element parent, Element child)
//        {
//            parent.Children.Add(child);
//        }

//        protected override void OnRemoveChild(Element parent, Element child)
//        {
//            parent.Children.Remove(child);
//        }

//        protected override bool OnContainsChild(Element parent, Element child)
//        {
//            return parent.Children.Contains(child);
//        }
//    }
//}
