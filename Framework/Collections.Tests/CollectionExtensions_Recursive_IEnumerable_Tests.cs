using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Collections.Tests
{
    [TestClass]
    public class CollectionExtensions_Recursive_IEnumerable_Tests
    {
        [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "}")]
        private class Item
        {
            public string Name { get; set; }
            public IEnumerable<Item> Children { get; set; } = new List<Item>();

            private string DebuggerDisplay => $"{{{nameof(Item)}}} '{Name}' [{Children?.Count()}]";
        }

        [TestMethod]
        public void Test_CollectionExtensions_Recursive_SelectRecursive_IEnumerable_OnItem()
        {
            // Setup
            Item item = CreateItem();

            // Execute
            IList<Item> items = item.SelectRecursive(x => x.Children).ToArray();

            // Assert
            IList<string> expectedItemsNames = new[] { "1.1", "1.2", "1.2.1", "1.3", "1.3.1", "1.3.2" };
            AssertItemNames(expectedItemsNames, items);
        }

        [TestMethod]
        public void Test_CollectionExtensions_Recursive_SelectRecursive_IEnumerable_OnCollection()
        {
            // Setup
            Item item = CreateItem();

            // Execute
            IList<Item> items = item.Children.SelectRecursive(x => x.Children).ToArray();

            // Assert
            IList<string> expectedItemsNames = new[] { "1.2.1", "1.3.1", "1.3.2" };
            AssertItemNames(expectedItemsNames, items);
        }

        [TestMethod]
        public void Test_CollectionExtensions_Recursive_UnionRecursive_IEnumerable_OnItem()
        {
            // Setup
            Item item = CreateItem();

            // Execute
            IList<Item> items = item.UnionRecursive(x => x.Children).ToArray();

            // Assert
            IList<string> expectedItemsNames = new[] { "1", "1.1", "1.2", "1.2.1", "1.3", "1.3.1", "1.3.2" };
            AssertItemNames(expectedItemsNames, items);
        }

        [TestMethod]
        public void Test_CollectionExtensions_Recursive_UnionRecursive_IEnumerable_OnCollection()
        {
            // Setup
            Item item = CreateItem();

            // Execute
            IList<Item> items = item.Children.UnionRecursive(x => x.Children).ToArray();

            // Assert
            IList<string> expectedItemsNames = new[] { "1.1", "1.2", "1.2.1", "1.3", "1.3.1", "1.3.2" };
            AssertItemNames(expectedItemsNames, items);
        }

        // Helpers

        private Item CreateItem()
        {
            var item = new Item
            {
                Name = "1",
                Children = new[]
                {
                    new Item { Name = "1.1" },
                    new Item
                    {
                        Name = "1.2",
                        Children = new[]
                        {
                            new Item { Name = "1.2.1" },
                        }
                    },
                    new Item
                    {
                        Name = "1.3",
                        Children = new[]
                        {
                            new Item { Name = "1.3.1" },
                            new Item { Name = "1.3.2" },
                        }
                    },
                }
            };

            return item;
        }

        private void AssertItemNames(IList<string> expectedItemsNames, IList<Item> items)
        {
            IList<string> actualItemNames = items.Select(x => x.Name).ToArray();

            AssertHelper.AreEqual(expectedItemsNames.Count, () => items.Count);
            AssertHelper.IsTrue(() => actualItemNames.SequenceEqual(expectedItemsNames));
        }
    }
}