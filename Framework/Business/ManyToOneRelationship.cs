using JJ.Framework.Exceptions;
using System.Diagnostics;

namespace JJ.Framework.Business
{
	/// <summary>
	/// Manages the inverse property in a one to n relation ship.
	/// Don't forget to use _child in your method implementations.
	/// </summary>
	public abstract class ManyToOneRelationship<TChild, TParent>
	{
		protected TChild _child;
		private TParent _parent;

		[DebuggerHidden]
		public ManyToOneRelationship(TChild child)
		{
			if (child == null) throw new NullException(() => child);
			_child = child;
		}

		public TParent Parent 
		{
			[DebuggerHidden]
			get { return _parent; }
			set
			{
				if (ReferenceEquals(_parent, value)) return;

				if (_parent != null)
				{
					if (Contains(_parent))
					{
						Remove(_parent);
					}
				}

				_parent = value;

				if (_parent != null)
				{
					if (!Contains(_parent))
					{
						Add(_parent);
					}
				}
			}
		}

		protected abstract bool Contains(TParent parent);
		protected abstract void Add(TParent parent);
		protected abstract void Remove(TParent parent);
	}
}
