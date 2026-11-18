JJ.Framework.Collections.Legacy
===============================

Expanding `.NET` with extra extension methods for collections. A set of elements released to support legacy `JJ` projects.

Here's a more extended version: [`JJ.Framework.Collections`](https://www.nuget.org/packages/JJ.Framework.Collections)

The current package is a historic pull for legacy purposes with a few other random things added for them.

Overloads added for:

- [Add](#add)
- [AddRange](#addrange)
- [Concat](#concat)
- [Distinct](#distinct)
- [Except](#except)
- [ForEach](#foreach)
- [OfType](#oftype)
- [OneBecomesTwo](#onebecomestwo)
- [Product](#product)
- [RemoveRange](#removerange)
- [SelectAncestors](#selectancestors)
- [SelfAndAncestors](#selfandancestors)
- [Sum](#sum)
- [Union](#union)


## Add

Add multiple items to a collection by means of a comma separated argument list, e.g. `myCollection.Add(1, 5, 12);`

## AddRange

AddRange is a member of `List<T>`. This is an overload for `ICollection<T>` so you can use it for more collection types.

## Concat

Overloads that take a single item, e.g. `myCollection.Concat(myItem);`  
or that starts with a single item and then adds a collection to it e.g. `myItem.Concat(myCollection);`

## Distinct

Overload that takes a key selector that determines what makes an item unique, e.g. `myItems.Distinct(x => x.LastName);`  
For multi-part keys, use `myItems.Distinct(x => new { x.FirstName, x.LastName });`

## Except

An overload that takes a predicate, e.g. `myCollection.Except(x => string.Equals(x, "Blah"));`
(This is the same as a negated `Where` predicate, but if you are already thinking in terms of `Except`, this might express your intent clearer.)

## ForEach

Variant of the `ForEach` LINQ method that gives you access to an index number for each element you iterate over.
It also works with more collection types than .NET's original `List<T>` method. Example:  
`myColl.ForEach((x, i) => WriteLine(x + "[" + i + "]"));`


## OfType

Non-generic variation on `OfType<T>`, but now takes a `Type` as a parameter. I.e. `animals.OfType(typeof(Dog))` as opposed to `animals.OfType<Dog>()`. It won't automatically cast (so the output item type stays `Animal` and does not become `Dog`). Can be useful for certain non-generic scenarios.

## OneBecomesTwo

Allow specifying 1 value as a list, but turn it into 2 repeating ones, as a helper for "post and fence problems".  
Collections of 0, 2 or more elements are left alone and returned as is.
Only for collections with exactly 1 item it will return a new collection of 2 repeated items.

## Product

Works similar to `Sum`, but instead of adding up all the numbers, all the numbers are multiplied.
If the collection is empty, returns `1` (the null-operation for a multiplication).

## RemoveRange

`RemoveRange` is a member of `List<T>`. Here is an overload that works for any `ICollection<T>`, but it also takes items/collections instead of indices.  
Example: `list.RemoveRange("Orange", "Peach");`

## SelectAncestors

Offers a single-line generally usable solution for gathering up parents and their parents in any tree structure. Safe against circularities.  
Example: `var ancestors = child.SelectAncestors(x => x.Parent);`

## SelfAndAncestors

Same as `SelectAncestors`, but now includes the item itself in the output collection. Gracefully handles circularities.  
Example: `var items = child.SelfAndAncestors(x => x.Parent);`  
Output in that case contains all the `Parents` but also the `child`.

## Sum

An overload of the `Sum` `LINQ` method that takes `TimeSpans`.

## Union

A variant of `.NET's` `Union` method but now supporting short static invocation styles e.g.,  
`Union(list1, list2)`


Release Notes
-------------

#### `2026-11-16` | `0.261` : __Legacy Release__

- Release of legacy collection utils.
- Overloads for `Add`, `AddRange`, `Concat`, `Distinct`, `Except`, `ForEach`, `OfType`, `OneBecomesTwo`, `Product`, `RemoveRange`, `SelectAncestors`, `SelfAndAncestors`, `Sum`, `Union`
- Full test coverage, wide .NET version support, native AOT/trim friendly.
- Adjusted Core/Legacy split for [`JJ.Framework.Collections`](https://github.com/jjvanzon/JJ.Framework/tree/main/Framework/JJ.Framework.Collections)
- Older legacy collections utils stay in [`JJ.Framework.Common.Legacy`](https://www.nuget.org/packages/JJ.Framework.Common.Legacy)
- Newer legacy collection utils are in [`JJ.Framework.Collections.Legacy`](https://github.com/jjvanzon/JJ.Framework/tree/main/Framework/JJ.Framework.Collections)
- `JJ.Framework.Collections.Core` variant is now gone.
- And manually ported back/forth between main/legacy branches.
- Refined use of `Ex` prefix for `2021` elements piled on top of `2015` elements.
- Similar Core/Legacy split for [`Common.Legacy.Tests`](https://github.com/jjvanzon/JJ.Framework/tree/main/Framework/JJ.Framework.Common.Tests).

💬 Feedback 
------------

Got feedback or questions? You can reach me [here.](https://jjvanzon.github.io/#-how-to-reach-me)
