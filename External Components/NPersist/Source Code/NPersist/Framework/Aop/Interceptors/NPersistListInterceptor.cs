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
//using Puzzle.NAspect.Framework;
//using Puzzle.NAspect.Framework.Interception;
//using Puzzle.NPersist.Framework.Interfaces;


//namespace Puzzle.NPersist.Framework.Aop

//{
//    /// <summary>
//    /// Summary description for NPersistPropertyInterceptor.
//    /// </summary>
//    public class NPersistListInterceptor : IAroundInterceptor
//    {
//        public NPersistListInterceptor()
//        {
//        }

//        public object HandleCall(MethodInvocation call)
//        {	
            
//        //	Console.WriteLine(call.ValueSignature) ;
//            IInterceptableListState list = (IInterceptableListState)call.Target;

//            list.Interceptor.BeforeCall() ;
//            object res = call.Proceed() ;
//            list.Interceptor.AfterCall() ;
			
//            return res;
//        }
//    }
//}
