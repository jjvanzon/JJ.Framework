Test_Concat_TwoCollections:

        IsNotNull(coll1);
        AreEqual(3, coll1.Length);
        AreEqual(1, coll1[0]);
        AreEqual(2, coll1[1]);
        AreEqual(3, coll1[2]);


        IsNotNull(coll2);
        AreEqual(4, coll2.Count);
        AreEqual(3, coll2[0]);
        AreEqual(4, coll2[1]);
        AreEqual(5, coll2[2]);
        AreEqual(6, coll2[3]);

        IsNotNull(result);
        AreEqual(7, result.Length);
        AreEqual(1, result[0]);
        AreEqual(2, result[1]);
        AreEqual(3, result[2]);
        AreEqual(3, result[3]); // Deliberate duplicate value 3.
        AreEqual(4, result[4]);
        AreEqual(5, result[5]);
        AreEqual(6, result[6]);

Test_Concat_Item_And_Collection:

        AreEqual(4, result.Length);
        AreEqual(1, result[0]);
        AreEqual(1, result[1]);
        AreEqual(2, result[2]);
        AreEqual(3, result[3]);

Test_Concat_Collection_And_Item:

        AreEqual(3, coll.Length);
        AreEqual(1, coll[0]);
        AreEqual(2, coll[1]);
        AreEqual(3, coll[2]);

        AreEqual(4, result.Length);
        AreEqual(1, result[0]);
        AreEqual(2, result[1]);
        AreEqual(3, result[2]);
        AreEqual(1, result[3]);

Test_Except_ByCollections:

        IsNotNull(input);
        AreEqual(5, input.Length);
        AreEqual("Alice",    input[0]);
        AreEqual("Bob",      input[1]);
        AreEqual("Ross",     input[2]);
        AreEqual("JJ",       input[3]);
        AreEqual("The Dude", input[4]);

        IsNotNull(output);
        AreEqual(3, output.Length);
        AreEqual("Alice",    output[0]);
        AreEqual("Ross",     output[1]);
        AreEqual("The Dude", output[2]);

Test_AddRange_WithParams:

        AreEqual(3, coll.Count);
        AreEqual("Apple",  coll.ElementAt(0));
        AreEqual("Orange", coll.ElementAt(1));
        AreEqual("Banana", coll.ElementAt(2));


        AreEqual(5, coll.Count);
        AreEqual("Apple",  coll.ElementAt(0));
        AreEqual("Orange", coll.ElementAt(1));
        AreEqual("Banana", coll.ElementAt(2));
        AreEqual("Prune",  coll.ElementAt(3));
        AreEqual("Pear",   coll.ElementAt(4));

Test_AddRange_WithIList_CollectionsCore_DoesNotClash_WithCommonLegacy:

            int[] expected = [ 1, 2, 3, 3, 4, 5 ];
            int[] actual = list.ToArray();
            CollectionAssert.AreEqual(expected, actual);

            int[] expected = [ 1, 2, 3, 3, 4, 5 ];
            int[] actual = list.ToArray();
            CollectionAssert.AreEqual(expected, actual);

Test_Add_WithParams:

        AreEqual(3, coll.Count);
        AreEqual("Apple",  coll.ElementAt(0));
        AreEqual("Orange", coll.ElementAt(1));
        AreEqual("Banana", coll.ElementAt(2));


        AreEqual(5, coll.Count);
        AreEqual("Apple",  coll.ElementAt(0));
        AreEqual("Orange", coll.ElementAt(1));
        AreEqual("Banana", coll.ElementAt(2));
        AreEqual("Prune",  coll.ElementAt(3));
        AreEqual("Pear",   coll.ElementAt(4));

Test_Add_WithIList_CollectionsCore_DoesNotClash_WithCommonLegacy:

            int[] expected = [ 1, 2, 3, 3, 4, 5 ];
            int[] actual = list.ToArray();
            CollectionAssert.AreEqual(expected, actual);

            int[] expected = [ 1, 2, 3, 3, 4, 5 ];
            int[] actual = list.ToArray();
            CollectionAssert.AreEqual(expected, actual);
