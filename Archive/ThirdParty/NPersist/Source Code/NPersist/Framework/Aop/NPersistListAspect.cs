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
//using Puzzle.NAspect.Framework.Aop;
//using Puzzle.NCore.Framework.Exceptions;
//using Puzzle.NPersist.Framework.Exceptions;
//using Puzzle.NPersist.Framework.Interfaces;

//namespace Puzzle.NPersist.Framework.Aop
//{
//    /// <summary>
//    /// Summary description for NPersistAspect.
//    /// </summary>
//    public class NPersistListAspect : IGenericAspect
//    {
//        private IContext context;
//        public NPersistListAspect(IContext context)
//        {
//            this.context = context;
//        }		

//        public string Name
//        {
//            get { return "NPersistListAspect"; }
//            set { throw new IAmOpenSourcePleaseImplementMeException(); }
//        }

//        public bool IsMatch(Type type)
//        {
//            return (typeof(IList).IsAssignableFrom(type) );
//        }

//        public IList Mixins
//        {
//            get 
//            {
//                IList arr = new ArrayList();
//                arr.Add(typeof( IInterceptableList ));
//                arr.Add(typeof( NPersistInterceptableListMixin ));				
//                return arr;
//            }
//        }

//        public IList Pointcuts
//        {
//            get 
//            {
//                IList arr = new ArrayList();
//                arr.Add(new NPersistListPointcut());
//                arr.Add(new NPersistListCountPointcut());
//                return arr;
//            }
//        }

//        private IList targets = new ArrayList();
//        public IList Targets
//        {
//            get { return targets; }
//        }

//    }
//}