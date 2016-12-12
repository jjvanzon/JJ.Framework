using JJ.Framework.Exceptions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using JJ.Framework.Presentation.VectorGraphics.Relationships;
using JJ.Framework.Presentation.VectorGraphics.SideEffects;
using JJ.Framework.Business;

namespace JJ.Framework.Presentation.VectorGraphics.Models.Elements
{
    public class ElementChildren : IEnumerable<Element>
    {
        private readonly Element _parent;
        private readonly IList<Element> _list;
        private readonly ParentToChildrenRelationship _childrenRelationship;

        internal ElementChildren(Element parent)
        {
            if (parent == null) throw new NullException(() => parent);

            _parent = parent;
            _list = new List<Element>();

            _childrenRelationship = new ParentToChildrenRelationship(_parent, _list);
        }

        [DebuggerHidden]
        public int Count => _list.Count;

        public void Add(Element child)
        {
            if (child == null) throw new NullException(() => child);

            ISideEffect sideEffect1 = new SideEffect_AssertDiagram_UponSettingParentOrChild(child, _parent);
            sideEffect1.Execute();

            ISideEffect sideEffect2 = new SideEffect_PreventCircularity(child, _parent);
            sideEffect2.Execute();

            _childrenRelationship.Add(child);
        }

        public void Remove(Element child)
        {
            ISideEffect sideEffect = new SideEffect_AssertDiagram_UponSettingParentOrChild(child, _parent);
            sideEffect.Execute();

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
