﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using JJ.Framework.Exceptions;
using JJ.Framework.VectorGraphics.Relationships;
using JJ.Framework.VectorGraphics.SideEffects;

namespace JJ.Framework.VectorGraphics.Models.Elements
{
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

		[DebuggerHidden]
		public int Count => _list.Count;

		public void Add(Element child)
		{
			if (child == null) throw new NullException(() => child);

			new SideEffect_AssertDiagram_UponSettingParentOrChild(child, _parent).Execute();
			new SideEffect_PreventCircularity(child, _parent).Execute();

			_childrenRelationship.Add(child);
		}

		public void Remove(Element child)
		{
			new SideEffect_AssertDiagram_UponSettingParentOrChild(child, _parent).Execute();

			_childrenRelationship.Remove(child);
		}

		public void Clear()
		{
			foreach (Element child in this.ToArray())
			{
				Remove(child);
			}
		}

		[DebuggerHidden]
		public bool Contains(Element child) => _list.Contains(child);

		// IEnumerable

		[DebuggerHidden]
		public IEnumerator<Element> GetEnumerator() => _list.GetEnumerator();

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator() => _list.GetEnumerator();
	}
}