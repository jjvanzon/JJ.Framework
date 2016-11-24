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
//using System.Reflection;
//using Puzzle.NAspect.Framework.Aop;
//using Puzzle.NPersist.Framework.Mapping;

//namespace Puzzle.NPersist.Framework.Aop

//{
//    /// <summary>
//    /// Summary description for NPersistPropertyPointcut.
//    /// </summary>
//    public class NPersistListPointcut : IPointcut
//    {
//        //private IContext context; 
//        private static volatile IList interceptors = CreateInterceptors();

//        private static IList CreateInterceptors()
//        {
//            IList arr = new ArrayList();
//            arr.Add(new NPersistListInterceptor ());
//            return arr;
//        }

//        public NPersistListPointcut()
//        {
//        }

//        public IList Interceptors
//        {
//            get 
//            {
//                return interceptors;
//            }
//        }

//        public bool IsMatch(MethodBase method, Type type)
//        {
//            if (method is ConstructorInfo)
//                return false;

//            string methodName = method.Name;

//            if (method.IsPrivate && methodName.IndexOf(".") >= 0)
//            {
//                int index = methodName.LastIndexOf(".") + 1;
//                methodName = methodName.Substring(index);               
//            }


//            if (methodName == "ToString")
//                return false;

//            if (methodName == "Equals")
//                return false;

//            if (methodName == "GetHashCode")
//                return false;

//            if (methodName == "GetEnumerator")
//                return false;

//            if (methodName == "Clone")
//                return false;

//            if (methodName == "Contains")
//                return false;

//            if (methodName == "CopyTo")
//                return false;

//            if (methodName == "Finalize")
//                return false;

//            if (methodName == "get_Interceptor")
//                return false;

//            if (methodName == "get_Interceptable")
//                return false;

//            if (methodName == "set_Interceptable")
//                return false;

//            if (methodName == "get_PropertyName")
//                return false;

//            if (methodName == "set_PropertyName")
//                return false;

//            if (methodName == "get_MuteNotify")
//                return false;

//            if (methodName == "set_MuteNotify")
//                return false;

//            if (methodName == "get_Count")
//                return false;            
			
//            return true;
//        }

//        private IList targets = new ArrayList();
//        public IList Targets
//        {
//            get
//            {
//                return targets; ;
//            }
//            set
//            {
//                targets = value ;
//            }
//        }

//        public string Name
//        {
//            get
//            {
//                return "";
//            }
//            set
//            {
//                ;
//            }
//        }
//    }
//}
