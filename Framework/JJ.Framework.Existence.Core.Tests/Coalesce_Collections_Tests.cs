namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_Collections_Tests
{
    [TestMethod]
    public void BUG_Coalesce_NullArrayZeroMatters_FailsToResolve()
    {
        // TODO: ZeroMatters flags fail to resolve
        // Null collection
        NoNullRet(0, Coalesce(NullArray));
      //NoNullRet(0, Coalesce(zeroMatters, FilledArray));

        NoNullRet(0, NullIColl.Coalesce());
      //NoNullRet(0, NullIColl.Coalesce(zeroMatters));
    }

    [TestMethod]
    public void Coalesce_1Arg_Collections()
    {
        List<string>? coll = null;
        List<string> result = Coalesce( [ coll ] );
        IsNull(coll);
        NoNullRet(Coalesce(coll));
    }

    [TestMethod]
    public void Coalesce_CollectionItems_Static()
    {
        NoNullRet(1, Coalesce(FilledArray                     ));
        NoNullRet(1, Coalesce(FilledList                      ));
        NoNullRet(1, Coalesce(FilledHashSet                   ));
        NoNullRet(1, Coalesce(FilledIList                     ));
        NoNullRet(1, Coalesce(FilledISet                      ));
        NoNullRet(1, Coalesce(FilledIColl                     ));
        NoNullRet(1, Coalesce(FilledIReadOnlyList             ));
        NoNullRet(1, Coalesce(FilledIReadOnlyColl             ));
        NoNullRet(1, Coalesce(FilledIEnumerable               ));
        
        NoNullRet(1, Coalesce(NullyFilledArray                ));
        NoNullRet(1, Coalesce(NullyFilledList                 ));
        NoNullRet(1, Coalesce(NullyFilledHashSet              ));
        NoNullRet(1, Coalesce(NullyFilledIList                ));
        NoNullRet(1, Coalesce(NullyFilledISet                 ));
        NoNullRet(1, Coalesce(NullyFilledIColl                ));
        NoNullRet(1, Coalesce(NullyFilledIReadOnlyList        ));
        NoNullRet(1, Coalesce(NullyFilledIReadOnlyColl        ));
        NoNullRet(1, Coalesce(NullyFilledIEnumerable          ));
        
        NoNullRet(0, Coalesce(EmptyArray                      ));
        NoNullRet(0, Coalesce(EmptyList                       ));
        NoNullRet(0, Coalesce(EmptyHashSet                    ));
        NoNullRet(0, Coalesce(EmptyIList                      ));
        NoNullRet(0, Coalesce(EmptyISet                       ));
        NoNullRet(0, Coalesce(EmptyIColl                      ));
        NoNullRet(0, Coalesce(EmptyIReadOnlyList              ));
        NoNullRet(0, Coalesce(EmptyIReadOnlyColl              ));
        NoNullRet(0, Coalesce(EmptyIEnumerable                ));
        
        NoNullRet(0, Coalesce(NullableEmptyArray              ));
        NoNullRet(0, Coalesce(NullableEmptyList               ));
        NoNullRet(0, Coalesce(NullableEmptyHashSet            ));
        NoNullRet(0, Coalesce(NullableEmptyIList              ));
        NoNullRet(0, Coalesce(NullableEmptyISet               ));
        NoNullRet(0, Coalesce(NullableEmptyIColl              ));
        NoNullRet(0, Coalesce(NullableEmptyIReadOnlyList      ));
        NoNullRet(0, Coalesce(NullableEmptyIReadOnlyColl      ));
        NoNullRet(0, Coalesce(NullableEmptyIEnumerable        ));
        
        NoNullRet(0, Coalesce(NullArray                       ));
        NoNullRet(0, Coalesce(NullList                        ));
        NoNullRet(0, Coalesce(NullHashSet                     ));
        NoNullRet(0, Coalesce(NullIList                       ));
        NoNullRet(0, Coalesce(NullISet                        ));
        NoNullRet(0, Coalesce(NullIColl                       ));
        NoNullRet(0, Coalesce(NullIReadOnlyList               ));
        NoNullRet(0, Coalesce(NullIReadOnlyColl               ));
        NoNullRet(0, Coalesce(NullIEnumerable                 ));
    }

    [TestMethod]
    public void Coalesce_CollectionItems_Extensions()
    {
        NoNullRet(1, FilledArray                     .Coalesce());
        NoNullRet(1, FilledList                      .Coalesce());
        NoNullRet(1, FilledHashSet                   .Coalesce());
        NoNullRet(1, FilledIList                     .Coalesce());
        NoNullRet(1, FilledISet                      .Coalesce());
        NoNullRet(1, FilledIColl                     .Coalesce());
        NoNullRet(1, FilledIReadOnlyList             .Coalesce());
        NoNullRet(1, FilledIReadOnlyColl             .Coalesce());
        NoNullRet(1, FilledIEnumerable               .Coalesce());
        
        NoNullRet(1, NullyFilledArray                .Coalesce());
        NoNullRet(1, NullyFilledList                 .Coalesce());
        NoNullRet(1, NullyFilledHashSet              .Coalesce());
        NoNullRet(1, NullyFilledIList                .Coalesce());
        NoNullRet(1, NullyFilledISet                 .Coalesce());
        NoNullRet(1, NullyFilledIColl                .Coalesce());
        NoNullRet(1, NullyFilledIReadOnlyList        .Coalesce());
        NoNullRet(1, NullyFilledIReadOnlyColl        .Coalesce());
        NoNullRet(1, NullyFilledIEnumerable          .Coalesce());
        
        NoNullRet(0, EmptyArray                      .Coalesce());
        NoNullRet(0, EmptyList                       .Coalesce());
        NoNullRet(0, EmptyHashSet                    .Coalesce());
        NoNullRet(0, EmptyIList                      .Coalesce());
        NoNullRet(0, EmptyISet                       .Coalesce());
        NoNullRet(0, EmptyIColl                      .Coalesce());
        NoNullRet(0, EmptyIReadOnlyList              .Coalesce());
        NoNullRet(0, EmptyIReadOnlyColl              .Coalesce());
        NoNullRet(0, EmptyIEnumerable                .Coalesce());
        
        NoNullRet(0, NullableEmptyArray              .Coalesce());
        NoNullRet(0, NullableEmptyList               .Coalesce());
        NoNullRet(0, NullableEmptyHashSet            .Coalesce());
        NoNullRet(0, NullableEmptyIList              .Coalesce());
        NoNullRet(0, NullableEmptyISet               .Coalesce());
        NoNullRet(0, NullableEmptyIColl              .Coalesce());
        NoNullRet(0, NullableEmptyIReadOnlyList      .Coalesce());
        NoNullRet(0, NullableEmptyIReadOnlyColl      .Coalesce());
        NoNullRet(0, NullableEmptyIEnumerable        .Coalesce());
        
        NoNullRet(0, NullArray                       .Coalesce());
        NoNullRet(0, NullList                        .Coalesce());
        NoNullRet(0, NullHashSet                     .Coalesce());
        NoNullRet(0, NullIList                       .Coalesce());
        NoNullRet(0, NullISet                        .Coalesce());
        NoNullRet(0, NullIColl                       .Coalesce());
        NoNullRet(0, NullIReadOnlyList               .Coalesce());
        NoNullRet(0, NullIReadOnlyColl               .Coalesce());
        NoNullRet(0, NullIEnumerable                 .Coalesce());
    }
}
