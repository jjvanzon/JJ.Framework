using System;
using JJ.Framework.Business;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable ArrangeTypeMemberModifiers

namespace JJ.Demos.Business
{
    [TestClass]
    public class OneToManyRelationshipDemo
    {
        class ChildrenRelationship : OneToManyRelationship<Element, Element>
        {
            public ChildrenRelationship(Element parent) 
                : base(parent) { }

            protected override void SetParent(Element child) 
                => child.Parent = _parent;

            protected override void NullifyParent(Element child)
                => child.Parent = null;
        }

        class ParentRelationship : ManyToOneRelationship<Element, Element>
        {
            public ParentRelationship(Element child) 
                : base(child) { }

            protected override bool Contains(Element parent) 
                => parent.Children.Contains(_child);

            protected override void Add(Element parent) 
                => parent.Children.Add(_child);

            protected override void Remove(Element parent) 
                => parent.Children.Remove(_child);
        }

        class Element
        {
            private ParentRelationship _parentRelationship;

            public Element Parent
            {
                get => _parentRelationship.Parent;
                set => _parentRelationship.Parent = value;
            }

            public ChildrenRelationship Children { get; }

            public Element()
            {
                _parentRelationship = new ParentRelationship(this);
                Children = new ChildrenRelationship(this);
            }
        }

        [TestMethod]
        public void Demo_OneToManyRelationship()
        {
            var parent = new Element();
            var child1 = new Element();
            var child2 = new Element();

            child1.Parent = parent;
            child2.Parent = parent;

            // Children were added.
            AssertHelper.AreEqual(2, () => parent.Children.Count);

            parent.Children.Remove(child1);

            // Parent was nullified.
            AssertHelper.IsNull(() => child1.Parent);
            AssertHelper.IsNotNull(() => child2.Parent);
        }
    }
}
