namespace JJ.Framework.Collections.Legacy.Tests;

[TestClass]
public class DistinctTestsEx
{
    private class TestItem
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
    }

    private static readonly TestItem[] testItems =
    [
        new() { FirstName = "Bob",   LastName = "Boomer"  },
        new() { FirstName = "Alice", LastName = "Boomer"  },
        new() { FirstName = "Bob",   LastName = "Ross"    },
        new() { FirstName = "Alice", LastName = "Bobsson" },
        new() { FirstName = "Ross",  LastName = "Bobsson" },
        new() { FirstName = "Bob",   LastName = "Boomer"  }
    ];

    [TestMethod]
    public void Test_Distinct_ByLambda()
    {
        var byFirstName        = testItems.Distinct(x => x.FirstName).ToArray();
        var byLastName         = testItems.Distinct(x => x.LastName).ToArray();
        var byFirstAndLastName = testItems.Distinct(x => new { x.FirstName, x.LastName }).ToArray();
        var byNothing          = testItems.Distinct(x => x).ToArray();

        IsNotNull(   testItems);
        AreEqual (6, testItems.Length);
        IsNotNull(   testItems[0]);
        AreEqual (   testItems[0].FirstName, "Bob"    );
        AreEqual (   testItems[0].LastName,  "Boomer" );
        IsNotNull(   testItems[1]);
        AreEqual (   testItems[1].FirstName, "Alice"  );
        AreEqual (   testItems[1].LastName,  "Boomer" );
        IsNotNull(   testItems[2]);
        AreEqual (   testItems[2].FirstName, "Bob"    );
        AreEqual (   testItems[2].LastName,  "Ross"   );
        IsNotNull(   testItems[3]);
        AreEqual (   testItems[3].FirstName, "Alice"  );
        AreEqual (   testItems[3].LastName,  "Bobsson");
        IsNotNull(   testItems[4]);
        AreEqual (   testItems[4].FirstName, "Ross"   );
        AreEqual (   testItems[4].LastName,  "Bobsson");
        IsNotNull(   testItems[5]);
        AreEqual (   testItems[5].FirstName, "Bob"    );
        AreEqual (   testItems[5].LastName,  "Boomer" );

        IsNotNull(   byFirstName);
        AreEqual (3, byFirstName.Length);
        IsNotNull(   byFirstName[0]);
        AreEqual (   byFirstName[0].FirstName, "Bob"    );
        AreEqual (   byFirstName[0].LastName,  "Boomer" );
        IsNotNull(   byFirstName[1]);
        AreEqual (   byFirstName[1].FirstName, "Alice"  );
        AreEqual (   byFirstName[1].LastName,  "Boomer" );
        IsNotNull(   byFirstName[2]);
        AreEqual (   byFirstName[2].FirstName, "Ross"   );
        AreEqual (   byFirstName[2].LastName,  "Bobsson");

        IsNotNull(   byLastName);
        AreEqual (3, byLastName.Length);
        IsNotNull(   byLastName[0]);
        AreEqual (   byLastName[0].FirstName, "Bob"    );
        AreEqual (   byLastName[0].LastName,  "Boomer" );
        IsNotNull(   byLastName[1]);
        AreEqual (   byLastName[1].FirstName, "Bob"    );
        AreEqual (   byLastName[1].LastName,  "Ross"   );
        IsNotNull(   byLastName[2]);
        AreEqual (   byLastName[2].FirstName, "Alice"  );
        AreEqual (   byLastName[2].LastName,  "Bobsson");
       
        IsNotNull(   byFirstAndLastName);
        AreEqual (5, byFirstAndLastName.Length);
        IsNotNull(   byFirstAndLastName[0]);
        AreEqual (   byFirstAndLastName[0].FirstName, "Bob"    );
        AreEqual (   byFirstAndLastName[0].LastName,  "Boomer" );
        IsNotNull(   byFirstAndLastName[1]);
        AreEqual (   byFirstAndLastName[1].FirstName, "Alice"  );
        AreEqual (   byFirstAndLastName[1].LastName,  "Boomer" );
        IsNotNull(   byFirstAndLastName[2]);
        AreEqual (   byFirstAndLastName[2].FirstName, "Bob"    );
        AreEqual (   byFirstAndLastName[2].LastName,  "Ross"   );
        IsNotNull(   byFirstAndLastName[3]);
        AreEqual (   byFirstAndLastName[3].FirstName, "Alice"  );
        AreEqual (   byFirstAndLastName[3].LastName,  "Bobsson");
        IsNotNull(   byFirstAndLastName[4]);
        AreEqual (   byFirstAndLastName[4].FirstName, "Ross"   );
        AreEqual (   byFirstAndLastName[4].LastName,  "Bobsson");
 
        IsNotNull(   byNothing);
        AreEqual (6, byNothing.Length);
        IsNotNull(   byNothing[0]);
        AreEqual (   byNothing[0].FirstName, "Bob"    );
        AreEqual (   byNothing[0].LastName,  "Boomer" );
        IsNotNull(   byNothing[1]);
        AreEqual (   byNothing[1].FirstName, "Alice"  );
        AreEqual (   byNothing[1].LastName,  "Boomer" );
        IsNotNull(   byNothing[2]);
        AreEqual (   byNothing[2].FirstName, "Bob"    );
        AreEqual (   byNothing[2].LastName,  "Ross"   );
        IsNotNull(   byNothing[3]);
        AreEqual (   byNothing[3].FirstName, "Alice"  );
        AreEqual (   byNothing[3].LastName,  "Bobsson");
        IsNotNull(   byNothing[4]);
        AreEqual (   byNothing[4].FirstName, "Ross"   );
        AreEqual (   byNothing[4].LastName,  "Bobsson");
        IsNotNull(   byNothing[5]);
        AreEqual (   byNothing[5].FirstName, "Bob"    );
        AreEqual (   byNothing[5].LastName,  "Boomer" );
    }
}