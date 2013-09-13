//// *
//// * Copyright (C) 2008 Mats Helander : http://www.puzzleframework.com
//// *
//// * This library is free software; you can redistribute it and/or modify it
//// * under the terms of the GNU Lesser General Public License 2.1 or later, as
//// * published by the Free Software Foundation. See the included license.txt
//// * or http://www.gnu.org/copyleft/lesser.html for details.
//// *
//// *
//using System;
//using Puzzle.NAspect.Framework;
//using Puzzle.NAspect.Framework.Interception;
//using Puzzle.NPersist.Framework.Interfaces;


//namespace Puzzle.NPersist.Framework.Aop
//{
//    public class NPersistListCountInterceptor : IAroundInterceptor
//    {
//        public NPersistListCountInterceptor()
//        {
//        }

//        public object HandleCall(MethodInvocation call)
//        {	
//            IInterceptableListState list = (IInterceptableListState)call.Target;

//            int count = 0;
//            if (!list.Interceptor.BeforeCount(ref count))
//                count = (int) call.Proceed() ;

//            list.Interceptor.AfterCount(ref count) ;
			
//            return count;
//        }
//    }
//}
