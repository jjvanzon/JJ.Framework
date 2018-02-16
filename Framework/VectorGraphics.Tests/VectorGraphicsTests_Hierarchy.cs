using System;
using JJ.Framework.Testing;
using JJ.Framework.VectorGraphics.Models.Elements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable UnusedVariable

namespace JJ.Framework.VectorGraphics.Tests
{
	[TestClass]
	public class VectorGraphicsTests_Hierarchy
	{
		[TestMethod]
		public void Test_VectorGraphics_CircularityCheck_SetParent()
		{
			var diagram = new Diagram();
			var parent = new Point(diagram.Background);
			var child = new Point(parent);
			var grandChild = new Point(child);

			AssertHelper.ThrowsException(
				() => parent.Parent = grandChild,
				"Child cannot be added or parent cannot set, because it would cause a circular reference.");
		}

		[TestMethod]
		public void Test_VectorGraphics_CircularityCheck_AddChild()
		{
			var diagram = new Diagram();
			var parent = new Point(diagram.Background);
			var child = new Point(parent);
			var grandChild = new Point(child);

			AssertHelper.ThrowsException(
				() => grandChild.Children.Add(parent),
				"Child cannot be added or parent cannot set, because it would cause a circular reference.");
		}

		[TestMethod]
		public void Test_VectorGraphics_ChildAndParentDiagramAssertion_SetParent()
		{
			var parentDiagram = new Diagram();
			var parent = new Point(parentDiagram.Background);

			var childDiagram = new Diagram();
			var child = new Point(childDiagram.Background);

			AssertHelper.ThrowsException(
				() => child.Parent = parent,
				"Parent child must have the same diagram.");
		}

		[TestMethod]
		public void Test_VectorGraphics_ChildAndParentDiagramAssertion_AddChild()
		{
			var parentDiagram = new Diagram();
			var parent = new Point(parentDiagram.Background);

			var childDiagram = new Diagram();
			var child = new Point(childDiagram.Background);

			AssertHelper.ThrowsException(
				() => parent.Children.Add(child),
				"Parent child must have the same diagram.");
		}

		[TestMethod]
		public void Test_VectorGraphics_MoveChildToDifferentParent_ShouldWork()
		{
			var diagram = new Diagram();

			var parent1 = new Point(diagram.Background);
			var parent2 = new Point(diagram.Background);

			var child = new Point(parent1)
			{
				Parent = parent2
			};
		}

		[TestMethod]
		public void Test_VectorGraphics_Parent_NotNullable()
		{
			var diagram = new Diagram();

			var parent1 = new Point(diagram.Background);

			var child = new Point(parent1);

			AssertHelper.ThrowsException<ArgumentNullException>(() => child.Parent = null);
		}
	}
}