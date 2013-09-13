//// *
//// * Copyright (C) 2005 Roger Alsing : http://www.puzzleframework.com
//// *
//// * This library is free software; you can redistribute it and/or modify it
//// * under the terms of the GNU Lesser General Public License 2.1 or later, as
//// * published by the Free Software Foundation. See the included license.txt
//// * or http://www.gnu.org/copyleft/lesser.html for details.
//// *
//// *
//using System;
//using System.Collections;
//using Puzzle.NAspect.Framework;
//using Puzzle.NAspect.Framework.Aop;
//using Puzzle.NPersist.Framework.BaseClasses;
//using Puzzle.NPersist.Framework.Interfaces;

//namespace Puzzle.NPersist.Framework.Aop
//{
//    public class NPersistInterceptableListMixin : IInterceptableListState , IProxyAware
//    {
//        private IList targetList;
//        private IListInterceptor interceptor = new ListInterceptor();

//        public IListInterceptor Interceptor
//        {
//            get
//            {
//                return interceptor;	
//            }			
//        }

//        public virtual IInterceptable Interceptable
//        {
//            get { return interceptor.Interceptable; }
//            set { interceptor.Interceptable = value; }
//        }

//        public string PropertyName
//        {
//            get { return interceptor.PropertyName; }
//            set { interceptor.PropertyName = value; }
//        }

//        public bool MuteNotify
//        {
//            get { return interceptor.MuteNotify; }
//            set { interceptor.MuteNotify = value; }
//        }

//        //called when ctor of target is intercepted
//        public void SetProxy(IAopProxy target)
//        {
//            targetList = (IList)target;
//            interceptor.List = targetList;
//        }
//    }
//}
