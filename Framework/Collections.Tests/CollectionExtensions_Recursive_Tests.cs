using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Collections.Tests
{
    [TestClass]
    public class CollectionExtensions_Recursive_Tests
    {
        [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "}")]
        private class Item
        {
            public string Name { get; set; }
            public IList<Item> Children { get; set; } = new List<Item>();

            private string DebuggerDisplay => $"{{{nameof(Item)}}} '{Name}' [{Children?.Count}]";
        }

        [TestMethod]
        public void Test_CollectionExtensions_Recursive_SelectRecursive_OnItem()
        {
            // Setup
            Item item = CreateItem();

            // Execute
            IList<Item> items = item.SelectRecursive(x => x.Children).ToArray();

            // Assert
            IList<string> expectedItemsNames = new string[] { "1.1", "1.2", "1.2.1", "1.3", "1.3.1", "1.3.2" };
            AssertItemNames(expectedItemsNames, items);
        }

        [TestMethod]
        public void Test_CollectionExtensions_Recursive_SelectRecursive_OnCollection()
        {
            // Setup
            Item item = CreateItem();

            // Execute
            IList<Item> items = item.Children.SelectRecursive(x => x.Children).ToArray();

            // Assert
            IList<string> expectedItemsNames = new string[] { "1.2.1", "1.3.1", "1.3.2" };
            AssertItemNames(expectedItemsNames, items);
        }

        [TestMethod]
        public void Test_CollectionExtensions_Recursive_UnionRecursive_OnItem()
        {
            // Setup
            Item item = CreateItem();

            // Execute
            IList<Item> items = item.UnionRecursive(x => x.Children).ToArray();

            // Assert
            IList<string> expectedItemsNames = new string[] { "1", "1.1", "1.2", "1.2.1", "1.3", "1.3.1", "1.3.2" };
            AssertItemNames(expectedItemsNames, items);
        }

        [TestMethod]
        public void Test_CollectionExtensions_Recursive_UnionRecursive_OnCollection()
        {
            // Setup
            Item item = CreateItem();

            // Execute
            IList<Item> items = item.Children.UnionRecursive(x => x.Children).ToArray();

            // Assert
            IList<string> expectedItemsNames = new string[] { "1.1", "1.2", "1.2.1", "1.3", "1.3.1", "1.3.2" };
            AssertItemNames(expectedItemsNames, items);
        }

        // Helpers

        private Item CreateItem()
        {
            var item = new Item
            {
                Name = "1",
                Children = new Item[]
                {
                    new Item { Name = "1.1" },
                    new Item
                    {
                        Name = "1.2",
                        Children = new Item[]
                        {
                            new Item { Name = "1.2.1" },
                        }
                    },
                    new Item
                    {
                        Name = "1.3",
                        Children = new Item[]
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

            // For now, sort, but later the orders should actually be kept in tact.
            expectedItemsNames = expectedItemsNames.OrderBy(x => x).ToArray();
            actualItemNames = actualItemNames.OrderBy(x => x).ToArray();

            AssertHelper.AreEqual(expectedItemsNames.Count, () => items.Count);
            AssertHelper.IsTrue(() => Enumerable.SequenceEqual(expectedItemsNames, actualItemNames));
        }
    }
}