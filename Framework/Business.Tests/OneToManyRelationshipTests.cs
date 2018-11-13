using System;
using System.Linq;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable UnusedMember.Local
// ReSharper disable FieldCanBeMadeReadOnly.Local

// ReSharper disable ArrangeTypeMemberModifiers
// ReSharper disable ClassNeverInstantiated.Local
#pragma warning disable 649

namespace JJ.Framework.Business.Tests
{
    [TestClass]
    public class OneToManyRelationshipTests
    {
        class ParentToChildrenRelationship : OneToManyRelationship<Element, Element>
        {
            public ParentToChildrenRelationship(Element parent) : base(parent) { }

            protected override void SetParent(Element child) => child.Parent = _parent;
            protected override void NullifyParent(Element child) => child.Parent = null;
        }

        class ChildToParentRelationship : ManyToOneRelationship<Element, Element>
        {
            public ChildToParentRelationship(Element child) : base(child) { }

            protected override bool Contains(Element parent) => parent.Children.Contains(_child);
            protected override void Add(Element parent) => parent.Children.Add(_child);
            protected override void Remove(Element parent) => parent.Children.Remove(_child);
        }

        class Element
        {
            private ChildToParentRelationship _parentRelationship;

            public Element Parent
            {
                get => _parentRelationship.Parent;
                set => _parentRelationship.Parent = value;
            }

            public ParentToChildrenRelationship Children { get; }

            public Element()
            {
                _parentRelationship = new ChildToParentRelationship(this);
                Children = new ParentToChildrenRelationship(this);
            }
        }

        [TestMethod]
        public void Test_OneToManyRelationship_SetParent_AutomaticallyAddsChild()
        {
            // Arrange
            var child = new Element();
            var parent = new Element();

            // Act
            child.Parent = parent;

            // Assert
            // Is the parent really assigned?
            AssertHelper.AreSame(parent, () => child.Parent);

            // Was the child added to the parent?
            AssertHelper.AreEqual(1, () => parent.Children.Count);
            Element childInParent = parent.Children.Single();
            AssertHelper.AreSame(child, () => childInParent);
        }

        [TestMethod]
        public void Test_OneToManyRelationship_AddChild_AutomaticallySetsParent()
        {
            // Arrange
            var child = new Element();
            var parent = new Element();

            // Act
            parent.Children.Add(child);

            // Assert
            // Is the child really in the parent?
            AssertHelper.AreEqual(1, () => parent.Children.Count);
            Element childInParent = parent.Children.Single();
            AssertHelper.AreSame(child, () => childInParent);

            // Was the parent assigned to the child?
            AssertHelper.AreSame(parent, () => child.Parent);
        }

        [TestMethod]
        public void Test_OneToManyRelationship_NullifyParent_AutomaticallyRemovesChild()
        {
            // Arrange
            var child1 = new Element();
            var child2 = new Element();
            var parent = new Element();

            child1.Parent = parent;
            child2.Parent = parent;

            // Pre-Assert
            // Were the children really added?
            AssertHelper.AreEqual(2, () => parent.Children.Count);

            // Act
            child1.Parent = null;

            // Post-Assert
            // Was the parent really nullified?
            AssertHelper.IsNull(() => child1.Parent);

            // Does the other child still have its parent?
            AssertHelper.AreSame(parent, () => child2.Parent);

            // Is the child removed?
            AssertHelper.AreEqual(1, () => parent.Children.Count);

            // Is the right child still present?
            Element childInParent = parent.Children.Single();
            AssertHelper.AreSame(child2, () => childInParent);
        }

        [TestMethod]
        public void Test_OneToManyRelationship_RemoveChild_AutomaticallyNullifiesParent()
        {
            // Arrange
            var child1 = new Element();
            var child2 = new Element();
            var parent = new Element();

            child1.Parent = parent;
            child2.Parent = parent;

            // Pre-Assert
            // Were the children really added?
            AssertHelper.AreEqual(2, () => parent.Children.Count);

            // Act
            parent.Children.Remove(child1);

            // Post-Assert
            // Was the parent really nullified?
            AssertHelper.IsNull(() => child1.Parent);

            // Does the other child still have its parent?
            AssertHelper.AreSame(parent, () => child2.Parent);

            // Is the child removed?
            AssertHelper.AreEqual(1, () => parent.Children.Count);

            // Is the right child still present?
            Element childInParent = parent.Children.Single();
            AssertHelper.AreSame(child2, () => childInParent);
        }
    }
}