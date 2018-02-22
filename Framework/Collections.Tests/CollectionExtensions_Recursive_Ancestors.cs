using System.Diagnostics;
using System.Linq;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Collections.Tests
{
	[TestClass]
	public class CollectionExtensions_Recursive_Ancestors
	{
		[DebuggerDisplay("{" + nameof(DebuggerDisplay) + "}")]
		private class Item
		{
			public string Name { get; set; }
			public Item Parent { get; set; }

			private string DebuggerDisplay => $"{{{nameof(Item)}}} '{Name}' [HasParent={Parent != null}]";
		}

		[TestMethod]
		public void Test_CollectionExtensions_Recursive_SelectAncestors_NoAncestors()
		{
			var self = new Item { Name = "Item 1" };

			Item[] ancestors = self.SelectAncestors(x => x.Parent).ToArray();

			AssertHelper.IsNotNull(() => ancestors);
			AssertHelper.AreEqual(0, () => ancestors.Length);
		}

		[TestMethod]
		public void Test_CollectionExtensions_Recursive_SelectAncestors_OneAncestor()
		{
			var parent = new Item { Name = "Parent" };
			var child = new Item { Name = "Child", Parent = parent };

			Item[] ancestors = child.SelectAncestors(x => x.Parent).ToArray();

			AssertHelper.IsNotNull(() => ancestors);
			AssertHelper.AreEqual(1, () => ancestors.Length);
			Item ancestor = ancestors[0];
			AssertHelper.IsNotNull(() => ancestor);
			AssertHelper.AreSame(parent, () => ancestor);
		}

		[TestMethod]
		public void Test_CollectionExtensions_Recursive_SelectAncestors_TwoAncestor()
		{
			var grandParent = new Item { Name = "Grandparent" };
			var parent = new Item { Name = "Parent", Parent = grandParent };
			var child = new Item { Name = "Child", Parent = parent };

			Item[] ancestors = child.SelectAncestors(x => x.Parent).ToArray();

			AssertHelper.IsNotNull(() => ancestors);
			AssertHelper.AreEqual(2, () => ancestors.Length);
			Item ancestor1 = ancestors[0];
			AssertHelper.IsNotNull(() => ancestor1);
			AssertHelper.AreSame(parent, () => ancestor1);

			Item ancestor2 = ancestors[1];
			AssertHelper.IsNotNull(() => ancestor2);
			AssertHelper.AreSame(grandParent, () => ancestor2);
		}


		[TestMethod]
		public void Test_CollectionExtensions_Recursive_SelfAndAncestors_NoAncestors()
		{
			var self = new Item { Name = "Item 1" };

			Item[] items = self.SelfAndAncestors(x => x.Parent).ToArray();

			AssertHelper.IsNotNull(() => items);
			AssertHelper.AreEqual(1, () => items.Length);
			Item item0 = items[0];
			AssertHelper.IsNotNull(() => item0);
			AssertHelper.AreSame(self, () => self);
		}

		[TestMethod]
		public void Test_CollectionExtensions_Recursive_SelfAndAncestors_OneAncestor()
		{
			var parent = new Item { Name = "Parent" };
			var child = new Item { Name = "Child", Parent = parent };

			Item[] items = child.SelfAndAncestors(x => x.Parent).ToArray();

			AssertHelper.IsNotNull(() => items);
			AssertHelper.AreEqual(2, () => items.Length);
			Item item1 = items[0];
			AssertHelper.IsNotNull(() => item1);
			AssertHelper.AreSame(child, () => item1);
			Item item2 = items[1];
			AssertHelper.IsNotNull(() => item2);
			AssertHelper.AreSame(parent, () => item2);
		}

		[TestMethod]
		public void Test_CollectionExtensions_Recursive_SelfAndAncestors_TwoAncestor()
		{
			var grandParent = new Item { Name = "Grandparent" };
			var parent = new Item { Name = "Parent", Parent = grandParent };
			var child = new Item { Name = "Child", Parent = parent };

			Item[] items = child.SelfAndAncestors(x => x.Parent).ToArray();

			AssertHelper.IsNotNull(() => items);
			AssertHelper.AreEqual(3, () => items.Length);
			Item item1 = items[0];
			AssertHelper.IsNotNull(() => item1);
			AssertHelper.AreSame(child, () => item1);
			Item item2 = items[1];
			AssertHelper.IsNotNull(() => item2);
			AssertHelper.AreSame(parent, () => item2);
			Item item3 = items[2];
			AssertHelper.IsNotNull(() => item3);
			AssertHelper.AreSame(grandParent, () => item3);
		}

		[TestMethod]
		public void Test_CollectionExtensions_Recursive_SelfAndAncestors_TwoAncestor_Circular()
		{
			var grandParent = new Item { Name = "Grandparent" };
			var parent = new Item { Name = "Parent", Parent = grandParent };
			var child = new Item { Name = "Child", Parent = parent };

			// This makes it circular.
			grandParent.Parent = child;

			Item[] items = child.SelfAndAncestors(x => x.Parent).ToArray();

			AssertHelper.IsNotNull(() => items);
			AssertHelper.AreEqual(3, () => items.Length);
			Item item1 = items[0];
			AssertHelper.IsNotNull(() => item1);
			AssertHelper.AreSame(child, () => item1);
			Item item2 = items[1];
			AssertHelper.IsNotNull(() => item2);
			AssertHelper.AreSame(parent, () => item2);
			Item item3 = items[2];
			AssertHelper.IsNotNull(() => item3);
			AssertHelper.AreSame(grandParent, () => item3);
		}
	}
}
