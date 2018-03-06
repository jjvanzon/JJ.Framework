using System.Collections;
using System.Collections.Generic;
using JJ.Framework.Exceptions;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.VectorGraphics.Relationships;
using JJ.Framework.VectorGraphics.SideEffects;

namespace JJ.Framework.VectorGraphics.Models.Elements
{
	/// <summary>
	/// Note that there is no Remove method, because this would orphan the child.
	/// To remove a child, change its parent instead.
	/// </summary>
	public class ElementChildren : IEnumerable<Element>
	{
		private readonly Element _parent;
		private readonly IList<Element> _list;
		private readonly ParentToChildrenRelationship _childrenRelationship;

		internal ElementChildren(Element parent)
		{
			_parent = parent ?? throw new NullException(() => parent);
			_list = new List<Element>();

			_childrenRelationship = new ParentToChildrenRelationship(_parent, _list);
		}

		public int Count => _list.Count;

		public void Add(Element child)
		{
			if (child == null) throw new NullException(() => child);

			new SideEffect_PreventCircularity(child, _parent).Execute();
			new SideEffect_AssertParentAndChildDiagramsAreEqual(child, _parent).Execute();

			_childrenRelationship.Add(child);
		}

		internal void Remove(Element child) => _childrenRelationship.Remove(child);

		public bool Contains(Element child) => _list.Contains(child);

		public Element this[int i] => _list[i];

		// IEnumerable

		public IEnumerator<Element> GetEnumerator() => _list.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => _list.GetEnumerator();
	}
}
