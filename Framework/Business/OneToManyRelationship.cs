using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using JJ.Framework.Exceptions;
using JJ.Framework.Exceptions.Basic;

namespace JJ.Framework.Business
{
	/// <summary>
	/// Manages the inverse property in a one to n relation ship.
	/// Don't forget to use _parent in your method implementations.
	/// </summary>
	public abstract class OneToManyRelationship<TParent, TChild>
		where TParent : class
		where TChild : class
	{
		protected readonly TParent _parent;
		private readonly ICollection<TChild> _children;

		[DebuggerHidden]
		public OneToManyRelationship(TParent parent, ICollection<TChild> children)
		{
			_parent = parent ?? throw new NullException(() => parent);
			_children = children ?? throw new NullException(() => children);
		}

		protected abstract void SetParent(TChild child);
		protected abstract void NullifyParent(TChild child);

		public void Add(TChild child)
		{
			if (child == null) throw new NullException(() => child);

			if (_children.Contains(child)) return;

			_children.Add(child);

			SetParent(child);
		}

		public void Remove(TChild child)
		{
			if (child == null) throw new NullException(() => child);

			if (!_children.Contains(child)) return;

			_children.Remove(child);

			NullifyParent(child);
		}

		public void Clear()
		{
			foreach (TChild child in _children.ToArray())
			{
				Remove(child);
			}
		}
	}
}
