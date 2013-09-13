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
//using Puzzle.NPersist.Framework.Enumerations;
//using Puzzle.NPersist.Framework.Interfaces;

//namespace Puzzle.NPersist.Framework.Proxy
//{
//    public class ProxyHelper
//    {
//        private static object GetDefaultValue(Type dataType)
//        {
//            Array array = Array.CreateInstance(dataType, 1);
//            return array.GetValue(0);
//        }

//        public static object GetProperty(IProxy proxy, string propertyName, Type propertyType, object refValue)
//        {
//#if NPDEBUG
//            Console.Write(propertyType.ToString());
//#endif
//            bool cancel = false;
//            IInterceptor interceptor = proxy.GetInterceptor();
//            if (interceptor.Notification != Notification.Disabled)
//            {
//                if (interceptor != null)
//                {
//                    interceptor.NotifyPropertyGet(proxy, propertyName, ref refValue, ref cancel);
//                }
//                if (cancel)
//                {
//                    return GetDefaultValue(propertyType);
//                }
//                if (interceptor != null)
//                {
//                    interceptor.NotifyReadProperty(proxy, propertyName, refValue);
//                }
//            }
//            return refValue;
//        }
//    }
//}