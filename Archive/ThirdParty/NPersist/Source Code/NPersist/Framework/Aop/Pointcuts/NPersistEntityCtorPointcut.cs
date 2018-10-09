// *
// * Copyright (C) 2005 Roger Alsing : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *
using System;
using System.Collections;
using System.Reflection;
using Puzzle.NAspect.Framework.Aop;

namespace Puzzle.NPersist.Framework.Aop

{
	/// <summary>
	/// Summary description for NPersistCtorPointcut.
	/// </summary>
	public class NPersistEntityCtorPointcut : IPointcut
	{
	//	private IContext context; 
		private static volatile IList interceptors = CreateInterceptors();
		private static IList CreateInterceptors()
		{
			IList arr = new ArrayList();
			arr.Add(new NPersistCtorInterceptor ());
			return arr;
		}

		public NPersistEntityCtorPointcut(IContext context)
		{
		//	this.context = context;
		}

		public IList Interceptors => interceptors;

	    public bool IsMatch(MethodBase method, Type type) => (method.Name.StartsWith(".ctor"));

	    private IList targets = new ArrayList();
        public IList Targets
        {
            get => targets;
            set => targets = value;
        }

        public string Name
        {
            get => "";
            set
            {
                ;
            }
        }
    }
}
