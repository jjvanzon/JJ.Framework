using System;
using System.Collections;
using Puzzle.NAspect.Framework.Aop;
using Puzzle.NPersist.Framework;

namespace NAspectProxyFactory
{

	public class NPersistAspect : IAspect
	{
		private IContext context;
		public NPersistAspect(IContext context)
		{
			this.context = context;
		}		

		public string Name
		{
			get { return "NPersistAspect"; }
			set { throw new NotImplementedException(); }
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
				arr.Add(typeof( Puzzle.NPersist.Framework.Proxy.Mixins.NullValueHelperMixin ));
				arr.Add(typeof( Puzzle.NPersist.Framework.Proxy.Mixins.ObjectStatusHelperMixin ));
				arr.Add(typeof( Puzzle.NPersist.Framework.Proxy.Mixins.CloneHelperMixin ));
				arr.Add(typeof( Puzzle.NPersist.Framework.Proxy.Mixins.OriginalValueHelperMixin ));
				arr.Add(typeof( Puzzle.NPersist.Framework.Proxy.Mixins.UpdatedPropertyTrackerMixin ));
				return arr;
			}
		}

		public IList Pointcuts
		{
			get 
			{
				IList arr = new ArrayList();
				arr.Add(new NPersistCtorPointcut(context));
				arr.Add(new NPersistPropertyPointcut(context));
				return arr;
			}
		}
	}
}
