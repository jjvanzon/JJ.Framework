namespace JJ.Framework.Text.Core.Tests;

[TestClass]
public class TextCore_ShortGuids_Tests
{
    [TestMethod]
    public void Test_TextCore_WithShortGuids_CommonFormats()
    {
        AreEqual("before - c - after",               "before - cf9ecb39-ad86-4a29-84c4-c0f79b9c59fa - after"      .WithShortGuids(1));
        AreEqual("before - 42 - after",              "before - {426f51a9186b4115af98cca1131b8dd4} - after"        .WithShortGuids(2));
        AreEqual("before - 07c - after",             "before - {07c75275-0150-4414-bbca-0081b021a0ea} - after"    .WithShortGuids(3));
        AreEqual("before - 9390 - after",            "before - 9390B28866D94C7BA32BFD2B12CA0AA7 - after"          .WithShortGuids(4));
        AreEqual("before - 155FE - after",           "before - 155FEB11-A3F4-486A-AE7A-CF2F8961DB10 - after"      .WithShortGuids(5));
        AreEqual("before - 3F0EC2 - after",          "before - {3F0EC22422DE4921A7A963C1FD222B33} - after"        .WithShortGuids(6));
        AreEqual("before - B5F8F33 - after",         "before - {B5F8F331-66B0-47F7-861D-9D849C7776C2} - after"    .WithShortGuids(7));
        AreEqual("before - cf9ecb39 - after",       @"before - ""cf9ecb39-ad86-4a29-84c4-c0f79b9c59fa"" - after"  .WithShortGuids(8));     
        AreEqual("before - 426f51a91 - after",      @"before - ""{426f51a9186b4115af98cca1131b8dd4}"" - after"    .WithShortGuids(9));      
        AreEqual("before - 07c7527501 - after",     @"before - ""{07c75275-0150-4414-bbca-0081b021a0ea}"" - after".WithShortGuids(10));          
        AreEqual("before - 9390B28866D - after",    @"before - ""9390B28866D94C7BA32BFD2B12CA0AA7"" - after"      .WithShortGuids(11));  
        AreEqual("before - 155FEB11A3F4 - after",   @"before - ""155FEB11-A3F4-486A-AE7A-CF2F8961DB10"" - after"  .WithShortGuids(12));      
        AreEqual("before - 3F0EC22422DE4 - after",  @"before - ""{3F0EC22422DE4921A7A963C1FD222B33}"" - after"    .WithShortGuids(13));      
        AreEqual("before - B5F8F33166B047 - after", @"before - ""{B5F8F331-66B0-47F7-861D-9D849C7776C2}"" - after".WithShortGuids(14));          
    }

    [TestMethod]
    public void Test_TextCore_WithShortGuids_ShortenTheShortened()
    {
        AreEqual("Hi - 61E6FA - Hello", "Hi - 61E6FA88-AE55-453F-E3BB27763720 - Hello".WithShortGuids(6));
        AreEqual("Hi - 61E6FA - Hello", "Hi - 61E6FA88AE55-453F-E3BB27763720 - Hello".WithShortGuids(6));
        AreEqual("Hi - abc1 - Hello",   "Hi - {abc123def456} - Hello".WithShortGuids(4));
    }

    [TestMethod]
    public void Test_TextCore_WithShortGuids_ShortLengthUnder1Throws()
    {
        Throws(() => "61E6FA88-AE55-453F-8973-E3BB27763720".WithShortGuids(0), "length < 1");
        Throws(() => "61E6FA88-AE55-453F-8973-E3BB27763720".WithShortGuids(-1), "length < 1");
        Throws(() => "61E6FA88-AE55-453F-8973-E3BB27763720".WithShortGuids(-100), "length < 1");
    }

    [TestMethod]
    public void Test_TextCore_WithShortGuids_NullyText()
    {
        string? @null = null;
        AreEqual("", "".WithShortGuids(4));
        AreEqual(" ", " ".WithShortGuids(4));
        AreEqual("", @null.WithShortGuids(4));
    }

    [TestMethod]
    public void Test_TextCore_WithShortGuids_EdgeCases()
    {
        // Spaces are not separators inside guids. But the different digit strings are shortened individually.
        AreEqual("61E AE5 453 897 E3B - Hello there", "61E6FA88 AE55 453F 8973 E3BB27763720 - Hello there".WithShortGuids(3)); 
        // Misplaced dashes
        AreEqual("61E - Hello there", "61-E6FA-88AE55453F-8-97-3E3-BB27763720 - Hello there".WithShortGuids(3)); 
        // More strange ones
        AreEqual("-ABCDEF-", "-ABCDEF-".WithShortGuids(3));
        AreEqual("ABCD-G", "ABCDEF-ABCDEF-ABCDEF-G".WithShortGuids(4));
    }

    [TestMethod]
    public void Test_TextCore_WithShortGuids_AvoidsReplacingWords()
    {
        // Prime example: added COULD be hex string, but it is likely a word.
        AreEqual("Item added", "Item added".WithShortGuids(1)); 
        // 2-Letter Words
        AreEqual("ab", "ab".WithShortGuids(1));
        AreEqual("ad", "ad".WithShortGuids(1));
        AreEqual("be", "be".WithShortGuids(1));
        AreEqual("fa", "fa".WithShortGuids(1));
        // 3-Letter Words
        AreEqual("ace", "ace".WithShortGuids(1));
        AreEqual("bad", "bad".WithShortGuids(1));
        AreEqual("bed", "bed".WithShortGuids(1));
        AreEqual("bee", "bee".WithShortGuids(1));
        AreEqual("cab", "cab".WithShortGuids(1));
        AreEqual("cad", "cad".WithShortGuids(1));
        AreEqual("dab", "dab".WithShortGuids(1));
        AreEqual("dad", "dad".WithShortGuids(1));
        AreEqual("fed", "fed".WithShortGuids(1));
        AreEqual("fee", "fee".WithShortGuids(1));
        // 4-Letter Words
        AreEqual("abed", "abed".WithShortGuids(1));
        AreEqual("aced", "aced".WithShortGuids(1));
        AreEqual("babe", "babe".WithShortGuids(1));
        AreEqual("bade", "bade".WithShortGuids(1));
        AreEqual("bead", "bead".WithShortGuids(1));
        AreEqual("beef", "beef".WithShortGuids(1));
        AreEqual("cafe", "cafe".WithShortGuids(1));
        AreEqual("cede", "cede".WithShortGuids(1));
        AreEqual("dace", "dace".WithShortGuids(1));
        AreEqual("dead", "dead".WithShortGuids(1));
        AreEqual("deaf", "deaf".WithShortGuids(1));
        AreEqual("deed", "deed".WithShortGuids(1));
        AreEqual("face", "face".WithShortGuids(1));
        AreEqual("fade", "fade".WithShortGuids(1));
        AreEqual("feed", "feed".WithShortGuids(1));
        // 5-Letter Words
        AreEqual("added", "added".WithShortGuids(1));
        AreEqual("ceded", "ceded".WithShortGuids(1));
        AreEqual("decaf", "decaf".WithShortGuids(1));
        AreEqual("ebbed", "ebbed".WithShortGuids(1));
        AreEqual("faced", "faced".WithShortGuids(1));
        AreEqual("faded", "faded".WithShortGuids(1));
        // 6-Letter Words
        AreEqual("accede", "accede".WithShortGuids(1));
        AreEqual("beaded", "beaded".WithShortGuids(1));
        AreEqual("bedded", "bedded".WithShortGuids(1));
        AreEqual("beefed", "beefed".WithShortGuids(1));
        AreEqual("cabbed", "cabbed".WithShortGuids(1));
        AreEqual("dabbed", "dabbed".WithShortGuids(1));
        AreEqual("deeded", "deeded".WithShortGuids(1));
        AreEqual("deface", "deface".WithShortGuids(1));
        AreEqual("efface", "efface".WithShortGuids(1));
        AreEqual("facade", "facade".WithShortGuids(1));
        // 7-Letter Words
        AreEqual("defaced", "defaced".WithShortGuids(1));
        AreEqual("facaded", "facaded".WithShortGuids(1));
        AreEqual("effaced", "effaced".WithShortGuids(1));
        // Longer
        AreEqual("Babbaged", "Babbaged".WithShortGuids(1));
        AreEqual("Cabbaged", "Cabbaged".WithShortGuids(1));
        AreEqual("Decafeed", "Decafeed".WithShortGuids(1));
        // Edge Cases
        AreEqual("d",        "decaf1"           .WithShortGuids(1)); // Has decimals
        AreEqual("d",        "dcfc"             .WithShortGuids(1)); // No vowels
        AreEqual("decaffd",  "decaffd"          .WithShortGuids(1)); // just enough vowels
        AreEqual("d",        "decaffdd"         .WithShortGuids(1)); // not enough vowels.
        AreEqual("d",        "decaffed-decaffed".WithShortGuids(1)); // too many letters
        AreEqual("DECAFFED", "DECAFFED"         .WithShortGuids(1));
    }
}