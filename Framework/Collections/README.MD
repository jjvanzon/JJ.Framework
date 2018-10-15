# JJ.Framework.Collections

Basic helpers for working with lists of information.

* Handy LINQ-style extension methods.
* Recursive collection extensions.
* A port of a RedBlackTree collection.

## Collection Extensions

Many of these methods are variations on the already existing LINQ methods. You might expect these to have been present in the .NET Framework already, but you sometimes miss a few.

* `Add`
	* Add multiple items to a collection by means of a comma separated argument list, e.g.
	`myCollection.Add(1, 5, 12);`
* `Add` / `Remove`
	* For some polymorphism between `Lists`, `Stacks` and `Queues`, there are these `Add` and `Remove` extension methods, in place of `Push`, `Pop`, `Enqueue` and `Dequeue`.
* `AddRange`
	* `AddRange` is a member of `List<T>`. Here are variations for `IEnumerable<T>` and `HashSet<T>`.
* `AsArray`, `AsList`, `AsEnumerable`
	* Converts a single item to an array, list or enumerable. Example: `List<int> myInts = 3.AsList();` (The names `ToArray` and `ToList` conflicted with other overloads.)
* `Concat` variations with:
	* A comma separated argument list, e.g. `myCollection.Concat(4, 7, 12);`
	* A single item, e.g. `myCollection.Concat(myItem);`
	* Starts with a single item and then adds a collection to it e.g. `myItem.Concat(myCollection);`
* `CrossJoin`
	* Returns all combinations of items combining one from collection 1 with one from collection 2, one from collection 3, etc.
* `Distinct`
	* Variation that takes a key selector that determines what makes an item unique, e.g.
	`myItems.Distinct(x => x.LastName);` For multi-part as keys, use:
    `myItems.Distinct(x => new { x.FirstName, x.LastName });`
* `DistinctMany`
	* Returns distinct arrays. So checks the equality of all items in the arrays and returns the unique arrays. (Actually, not only arrays, any enumerable.) E.g. `severalArrays.DistinctMany();`
* `Except` variations with:
	* A single item, e.g. `myCollection.Except(myItem);`
	* A predicate, e.g. `myCollection.Except(x => string.Equals("Blah"));`
    * The choice to keep duplicates. (The original `Except` method from .NET automatically does a distinct, which is something you do not always want.)
* `FirstWithClearException` / `SingleOrDefaultWithClearException` / `SingleWithClearException`
	* The regular `First`, `Single` or `SingleOrDefault` methods will give you an exception for instance when there are no items in the collection or if there are multiple items in the collection. But not a very clear exception, like *'Sequence contains no elements.'* The `WithClearException` variations will allow you to do a `First`, `Single` or `SingleOrDefault`, but get a clearer exception message e.g. *'Product with key { productNumber = 123 } not unique.'*
* `ForEach`
	* Not all collection types have the `ForEach` method. Here you have an overload for `IEnumerable<T>` so you can use it for more collection types.
* `IndexOf` variations for:
	* Collection types other than `List<T>`.
	* One that takes a predicate. E.g. `int index = items.IndexOf(x => x.ID == 3);` (like the `List<T>.FindIndex` method)
* `TryGetIndexOf`
	* Similar to `IndexOf`, but returns null if the item is not found.
* `MinOrDefault` / `MaxOrDefault`
	* Same as `Min` and `Max`, but instead of crashing when zero items, returns default instead.
* `PeekOrDefault` / `PopOrDefault`
	* Same as `Peek` or `Pop` for `Stacks` and `Queues`, but instead of crashing when zero items, returns default instead.
* `Product`
	* Works similar to `Sum`, but instead of adding up all the numbers, all the numbers are multiplied.
* `RemoveFirst` / `TryRemoveFirst`
	* Removes the first occurrence that matches the predicate. Example:
	`myCollection.RemoveFirst(x => x.ID == 3);`
* `Repeat`
	* Repeats a collection a number of times and returns a new collection. E.g. `new[] { 1, 2 }.Repeat(3);` returns a collection `{ 1, 2, 1, 2, 1, 2 }`
* `ToHashSet`
	* Yes, you could write `new HashSet(someCollection)`. But there are already the `ToArray()` and `ToList()` methods, so why not a `ToHashSet()` method to make it consistent?
* `ToNonUniqueDictionary`
	* Similar to `ToDictionary`, but allows the same key to be present more than once. A `GroupBy` can overcome that limitation too, but sometimes it is nice to have the return value be a `Dictionary`, which might make for a faster lookup too.
* `TrimAll`
	* Trims all the strings in the collection.
* `Union` variations with:
	* A comma separated argument list, e.g. `myCollection.Union(4, 7, 12);`
	* A single item, e.g. `myCollection.Union(myItem);`
	* Starts with a single item and then adds a collection to it e.g. `myItem.Union(myCollection);`
* `Zip` variations:
	* Without a result, when you just want to process two collections side by side in another way.
	* Without a result selector and returns tuples instead.


## Recursive Collection Extensions

LINQ methods allow you to process a whole collection of items in one blow. Process a whole *tree* of items in one blow? For many cases these *Recursive Collection Extensions* offer a one-line solution.

### Enumerate Descendants

This line of code:

	var allItems = root.UnionRecursive(x => x.Children);

Gives you a list of all the nodes in a tree structure like the following:

	var root = new Item
	{
		Children = new[]
		{
			new Item()
			new Item
			{
				Children = new[]
				{
					new Item()
				}
			},
			new Item
			{
				Children = new[]
				{
					new Item(),
					new Item(),
				}
			},
		}
	};

There is also a `SelectRecursive` method:

	var allItemsExceptRoot = root.SelectRecursive(x => x.Children);

The difference with `UnionRecursive` is that it does not include the root in the result collection.

You can also use a collection as a starting point:

	var allItems = myRootItems.UnionRecursive(x => x.Children);

And there are other overloads for specialized use-cases.

### Enumerate Ancestors

On top of enumerating descendants you can also enumerate ancestors:

	var ancestors = child.SelectAncestors(x => x.Parent);

A variation on that, which includes the child node:

	var items = child.SelfAndAncestors(x => x.Parent);

### Circular References / Graphs

Circularities in the structure are gracefully handled, so you can also recursively process non-tree graphs, processing all the items in one blow.