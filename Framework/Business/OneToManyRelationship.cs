using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace JJ.Framework.Business
{
	/// <summary>
	/// Manages the inverse property in a one to n relation ship.
	/// Don't forget to use _parent in your method implementations.
	/// </summary>
	[PublicAPI]
	public abstract class OneToManyRelationship<TParent, TChild> : IEnumerable<TChild>
		where TParent : class
		where TChild : class
	{
		protected readonly TParent _parent;
		private readonly ICollection<TChild> _children;

	    public OneToManyRelationship(TParent parent) : this(parent, new List<TChild>()) { }

		public OneToManyRelationship(TParent parent, ICollection<TChild> children)
		{
			_parent = parent ?? throw new ArgumentNullException(nameof(parent));
			_children = children ?? throw new ArgumentNullException(nameof(children));
		}

		protected abstract void SetParent(TChild child);
		protected abstract void NullifyParent(TChild child);

		public void Add(TChild child)
		{
			if (child == null) throw new ArgumentNullException(nameof(child));

			if (_children.Contains(child)) return;

			_children.Add(child);

			SetParent(child);
		}

		public void Remove(TChild child)
		{
			if (child == null) throw new ArgumentNullException(nameof(child));

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

	    public int Count => _children.Count;
	    public bool Contains(TChild child) => _children.Contains(child);
	    public IEnumerator<TChild> GetEnumerator() => _children.GetEnumerator();
	    IEnumerator IEnumerable.GetEnumerator() => _children.GetEnumerator();
    }
}
