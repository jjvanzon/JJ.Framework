namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_Collections_Tests
{
    [TestMethod]
    public void Coalesce_1Arg_Collections()
    {
        List<string>? coll = null;
        List<string> result = Coalesce( [ coll ] );
        IsNull(coll);
        NoNullRet(Coalesce(coll));
    }

    // TODO: Use NoNullRet

    [TestMethod]
    public void Coalesce_Collections_CoalesceItems_Static()
    {
        AreEqual(1, Coalesce(FilledArray                     ));
        AreEqual(1, Coalesce(FilledList                      ));
        AreEqual(1, Coalesce(FilledHashSet                   ));
        AreEqual(1, Coalesce(FilledIList                     ));
        AreEqual(1, Coalesce(FilledISet                      ));
        AreEqual(1, Coalesce(FilledIColl                     ));
        AreEqual(1, Coalesce(FilledIReadOnlyList             ));
        AreEqual(1, Coalesce(FilledIReadOnlyColl             ));
        AreEqual(1, Coalesce(FilledIEnumerable               ));
        
        AreEqual(1, Coalesce(NullyFilledArray                ));
        AreEqual(1, Coalesce(NullyFilledList                 ));
        AreEqual(1, Coalesce(NullyFilledHashSet              ));
        AreEqual(1, Coalesce(NullyFilledIList                ));
        AreEqual(1, Coalesce(NullyFilledISet                 ));
        AreEqual(1, Coalesce(NullyFilledIColl                ));
        AreEqual(1, Coalesce(NullyFilledIReadOnlyList        ));
        AreEqual(1, Coalesce(NullyFilledIReadOnlyColl        ));
        AreEqual(1, Coalesce(NullyFilledIEnumerable          ));
        
        AreEqual(0, Coalesce(EmptyArray                      ));
        AreEqual(0, Coalesce(EmptyList                       ));
        AreEqual(0, Coalesce(EmptyHashSet                    ));
        AreEqual(0, Coalesce(EmptyIList                      ));
        AreEqual(0, Coalesce(EmptyISet                       ));
        AreEqual(0, Coalesce(EmptyIColl                      ));
        AreEqual(0, Coalesce(EmptyIReadOnlyList              ));
        AreEqual(0, Coalesce(EmptyIReadOnlyColl              ));
        AreEqual(0, Coalesce(EmptyIEnumerable                ));
        
        AreEqual(0, Coalesce(NullableEmptyArray              ));
        AreEqual(0, Coalesce(NullableEmptyList               ));
        AreEqual(0, Coalesce(NullableEmptyHashSet            ));
        AreEqual(0, Coalesce(NullableEmptyIList              ));
        AreEqual(0, Coalesce(NullableEmptyISet               ));
        AreEqual(0, Coalesce(NullableEmptyIColl              ));
        AreEqual(0, Coalesce(NullableEmptyIReadOnlyList      ));
        AreEqual(0, Coalesce(NullableEmptyIReadOnlyColl      ));
        AreEqual(0, Coalesce(NullableEmptyIEnumerable        ));
        
        AreEqual(0, Coalesce(NullArray                       ));
        AreEqual(0, Coalesce(NullList                        ));
        AreEqual(0, Coalesce(NullHashSet                     ));
        AreEqual(0, Coalesce(NullIList                       ));
        AreEqual(0, Coalesce(NullISet                        ));
        AreEqual(0, Coalesce(NullIColl                       ));
        AreEqual(0, Coalesce(NullIReadOnlyList               ));
        AreEqual(0, Coalesce(NullIReadOnlyColl               ));
        AreEqual(0, Coalesce(NullIEnumerable                 ));
    }

    [TestMethod]
    public void Coalesce_Collections_CoalesceItems_Extensions()
    {
        AreEqual(1, FilledArray                     .Coalesce());
        AreEqual(1, FilledList                      .Coalesce());
        AreEqual(1, FilledHashSet                   .Coalesce());
        AreEqual(1, FilledIList                     .Coalesce());
        AreEqual(1, FilledISet                      .Coalesce());
        AreEqual(1, FilledIColl                     .Coalesce());
        AreEqual(1, FilledIReadOnlyList             .Coalesce());
        AreEqual(1, FilledIReadOnlyColl             .Coalesce());
        AreEqual(1, FilledIEnumerable               .Coalesce());
        
        AreEqual(1, NullyFilledArray                .Coalesce());
        AreEqual(1, NullyFilledList                 .Coalesce());
        AreEqual(1, NullyFilledHashSet              .Coalesce());
        AreEqual(1, NullyFilledIList                .Coalesce());
        AreEqual(1, NullyFilledISet                 .Coalesce());
        AreEqual(1, NullyFilledIColl                .Coalesce());
        AreEqual(1, NullyFilledIReadOnlyList        .Coalesce());
        AreEqual(1, NullyFilledIReadOnlyColl        .Coalesce());
        AreEqual(1, NullyFilledIEnumerable          .Coalesce());
        
        AreEqual(0, EmptyArray                      .Coalesce());
        AreEqual(0, EmptyList                       .Coalesce());
        AreEqual(0, EmptyHashSet                    .Coalesce());
        AreEqual(0, EmptyIList                      .Coalesce());
        AreEqual(0, EmptyISet                       .Coalesce());
        AreEqual(0, EmptyIColl                      .Coalesce());
        AreEqual(0, EmptyIReadOnlyList              .Coalesce());
        AreEqual(0, EmptyIReadOnlyColl              .Coalesce());
        AreEqual(0, EmptyIEnumerable                .Coalesce());
        
        AreEqual(0, NullableEmptyArray              .Coalesce());
        AreEqual(0, NullableEmptyList               .Coalesce());
        AreEqual(0, NullableEmptyHashSet            .Coalesce());
        AreEqual(0, NullableEmptyIList              .Coalesce());
        AreEqual(0, NullableEmptyISet               .Coalesce());
        AreEqual(0, NullableEmptyIColl              .Coalesce());
        AreEqual(0, NullableEmptyIReadOnlyList      .Coalesce());
        AreEqual(0, NullableEmptyIReadOnlyColl      .Coalesce());
        AreEqual(0, NullableEmptyIEnumerable        .Coalesce());
        
        AreEqual(0, NullArray                       .Coalesce());
        AreEqual(0, NullList                        .Coalesce());
        AreEqual(0, NullHashSet                     .Coalesce());
        AreEqual(0, NullIList                       .Coalesce());
        AreEqual(0, NullISet                        .Coalesce());
        AreEqual(0, NullIColl                       .Coalesce());
        AreEqual(0, NullIReadOnlyList               .Coalesce());
        AreEqual(0, NullIReadOnlyColl               .Coalesce());
        AreEqual(0, NullIEnumerable                 .Coalesce());
    }
}
