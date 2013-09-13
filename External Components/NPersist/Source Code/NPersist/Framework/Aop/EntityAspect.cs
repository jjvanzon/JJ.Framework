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
using Puzzle.NAspect.Framework.Aop;
using Puzzle.NCore.Framework.Exceptions;
using Puzzle.NPersist.Framework.Exceptions;
using Puzzle.NPersist.Framework.Interfaces;

namespace Puzzle.NPersist.Framework.Aop
{
	/// <summary>
	/// Summary description for NPersistAspect.
	/// </summary>
    public class EntityAspect : IGenericAspect
	{
		private IContext context;
		public EntityAspect(IContext context)
		{
			this.context = context;
		}		

		public string Name
		{
			get { return "NPersistEntityAspect"; }
			set { throw new IAmOpenSourcePleaseImplementMeException(); }
		}

		public bool IsMatch(Type type)
		{
			return (context.DomainMap.GetClassMap(type) != null);
		}

		public IList Mixins
		{
			get 
			{
				IList arr = new ArrayList();
				arr.Add(typeof( NPersistProxyMixin ));
				arr.Add(typeof( Puzzle.NPersist.Framework.Aop.Mixins.NullValueHelperMixin ));
				arr.Add(typeof( Puzzle.NPersist.Framework.Aop.Mixins.ObjectStatusHelperMixin ));
				arr.Add(typeof( Puzzle.NPersist.Framework.Aop.Mixins.CloneHelperMixin ));
				arr.Add(typeof( Puzzle.NPersist.Framework.Aop.Mixins.OriginalValueHelperMixin ));
				arr.Add(typeof( Puzzle.NPersist.Framework.Aop.Mixins.UpdatedPropertyTrackerMixin ));
                arr.Add(typeof(Puzzle.NPersist.Framework.Aop.Mixins.IdentityHelperMixin));
				arr.Add(typeof(Puzzle.NPersist.Framework.Aop.Mixins.ObservableMixin));
                arr.Add(typeof(Puzzle.NPersist.Framework.Aop.Mixins.ContextChildMixin));
                arr.Add(typeof(Puzzle.NPersist.Framework.Aop.Mixins.InverseHelperMixin));

                return arr;
			}
		}

		public IList Pointcuts
		{
			get 
			{
				IList arr = new ArrayList();
				arr.Add(new NPersistEntityCtorPointcut(context));
                arr.Add(new PropertySetPointcut(context));
                arr.Add(new PropertyGetPointcut(context));
				return arr;
			}
		}

        private IList targets = new ArrayList();
        public IList Targets
        {
            get { return targets; }
        }
    }
}
