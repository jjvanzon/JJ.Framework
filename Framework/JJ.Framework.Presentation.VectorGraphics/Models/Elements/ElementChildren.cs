using JJ.Framework.Reflection.Exceptions;
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
        private Element _parent;
        private IList<Element> _list;

        private ParentToChildrenRelationship _childrenRelationship;

        internal ElementChildren(Element parent)
        {
            if (parent == null) throw new NullException(() => parent);

            _parent = parent;
            _list = new List<Element>();

            _childrenRelationship = new ParentToChildrenRelationship(_parent, _list);
        }

        [DebuggerHidden]
        public int Count
        {
            get { return _list.Count; }
        }

        public void Add(Element child)
        {
            if (child == null) throw new NullException(() => child);

            ISideEffect sideEffect = new SideEffect_VerifyDiagram_WhenSettingParentOrChild(child, _parent);
            sideEffect.Execute();

            _childrenRelationship.Add(child);
        }

        public void Remove(Element child)
        {
            ISideEffect sideEffect = new SideEffect_VerifyDiagram_WhenSettingParentOrChild(child, _parent);
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
        public bool Contains(Element child)
        {
            return _list.Contains(child);
        }

        // IEnumerable

        [DebuggerHidden]
        public IEnumerator<Element> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        [DebuggerHidden]
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}
