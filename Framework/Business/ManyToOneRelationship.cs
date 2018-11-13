using System;
using System.Diagnostics;

namespace JJ.Framework.Business
{
	/// <summary>
	/// Manages the inverse property in a one to n relation ship.
	/// Don't forget to use _child in your method implementations.
	/// </summary>
	public abstract class ManyToOneRelationship<TChild, TParent>
		where TChild : class 
	{
		protected readonly TChild _child;
		private TParent _parent;

		[DebuggerHidden]
		public ManyToOneRelationship(TChild child) => _child = child ?? throw new ArgumentNullException(nameof(child));

		public TParent Parent 
		{
			[DebuggerHidden]
			get => _parent;
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
