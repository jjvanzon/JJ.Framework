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
//using System.Collections;
//using System.Reflection;
//using Puzzle.NAspect.Framework.Aop;
//using Puzzle.NPersist.Framework.Mapping;

//namespace Puzzle.NPersist.Framework.Aop

//{
//    /// <summary>
//    /// Summary description for NPersistPropertyPointcut.
//    /// </summary>
//    public class NPersistListCountPointcut : IPointcut
//    {
//        //private IContext context; 
//        private static volatile IList interceptors = CreateInterceptors();

//        private static IList CreateInterceptors()
//        {
//            IList arr = new ArrayList();
//            arr.Add(new NPersistListCountInterceptor());
//            return arr;
//        }

//        public NPersistListCountPointcut()
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

//            if (methodName == "get_Count")
//                return true;            
			
//            return false;
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
