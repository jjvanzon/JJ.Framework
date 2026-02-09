namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class FilledIn_Text_Tests : TestBase
{
    [TestMethod]
    public void FilledIn_Text_True_Extensions()
    {
        IsTrue(Text           .FilledIn());
        IsTrue(NullyFilledText.FilledIn());
    }
        
    [TestMethod]
    public void FilledIn_Text_True_Static()
    {
        IsTrue(FilledIn(Text           ));
        IsTrue(FilledIn(NullyFilledText));
    }        

    [TestMethod]
    public void FilledIn_Text_False_Extensions()
    {
        IsFalse(Empty     .FilledIn());
        IsFalse(Space     .FilledIn());
        IsFalse(NullText  .FilledIn());
        IsFalse(NullyEmpty.FilledIn());
        IsFalse(NullySpace.FilledIn());
    }

    [TestMethod]
    public void FilledIn_Text_False_Static()
    {
        IsFalse(FilledIn(Empty     ));
        IsFalse(FilledIn(Space     ));
        IsFalse(FilledIn(NullText  ));
        IsFalse(FilledIn(NullyEmpty));
        IsFalse(FilledIn(NullySpace));
    }
    
    [TestMethod]
    public void FilledIn_Text_SpaceMattersNo_Extensions()
    {
        IsFalse(NullText       .FilledIn(                        ));
        IsFalse(NullText       .FilledIn(     spaceMatters: false));
        IsFalse(NullText       .FilledIn(                   false));
        IsFalse(Empty          .FilledIn(                        ));
        IsFalse(Empty          .FilledIn(     spaceMatters: false));
        IsFalse(Empty          .FilledIn(                   false));
        IsFalse(NullyEmpty     .FilledIn(                        ));
        IsFalse(NullyEmpty     .FilledIn(     spaceMatters: false));
        IsFalse(NullyEmpty     .FilledIn(                   false));
        IsFalse(Space          .FilledIn(                        ));
        IsFalse(Space          .FilledIn(     spaceMatters: false));
        IsFalse(Space          .FilledIn(                   false));
        IsFalse(NullySpace     .FilledIn(                        ));
        IsFalse(NullySpace     .FilledIn(     spaceMatters: false));
        IsFalse(NullySpace     .FilledIn(                   false));
        IsTrue (Text           .FilledIn(                        ));
        IsTrue (Text           .FilledIn(     spaceMatters: false));
        IsTrue (Text           .FilledIn(                   false));
        IsTrue (NullyFilledText.FilledIn(                        ));
        IsTrue (NullyFilledText.FilledIn(     spaceMatters: false));
        IsTrue (NullyFilledText.FilledIn(                   false));
    }
    
    [TestMethod]
    public void FilledIn_Text_SpaceMattersNo_StaticFlagsInBack()
    {
        IsFalse(FilledIn(NullText                                ));
        IsFalse(FilledIn(NullText,            spaceMatters: false));
        IsFalse(FilledIn(NullText,                          false));
        IsFalse(FilledIn(Empty                                   ));
        IsFalse(FilledIn(Empty,               spaceMatters: false));
        IsFalse(FilledIn(Empty,                             false));
        IsFalse(FilledIn(NullyEmpty                              ));
        IsFalse(FilledIn(NullyEmpty,          spaceMatters: false));
        IsFalse(FilledIn(NullyEmpty,                        false));
        IsFalse(FilledIn(Space                                   ));
        IsFalse(FilledIn(Space,               spaceMatters: false));
        IsFalse(FilledIn(Space,                             false));
        IsFalse(FilledIn(NullySpace                              ));
        IsFalse(FilledIn(NullySpace,          spaceMatters: false));
        IsFalse(FilledIn(NullySpace,                        false));
        IsTrue (FilledIn(Text                                    ));
        IsTrue (FilledIn(Text,                spaceMatters: false));
        IsTrue (FilledIn(Text,                              false));
        IsTrue (FilledIn(NullyFilledText                         ));
        IsTrue (FilledIn(NullyFilledText,     spaceMatters: false));
        IsTrue (FilledIn(NullyFilledText,                   false));
    }
    
    [TestMethod]
    public void FilledIn_Text_SpaceMattersNo_StaticFlagsInFront()
    {
        IsFalse(FilledIn(                     NullText           ));
        IsFalse(FilledIn(spaceMatters: false, NullText           ));
        IsFalse(FilledIn(              false, NullText           ));
        IsFalse(FilledIn(                     Empty              ));
        IsFalse(FilledIn(spaceMatters: false, Empty              ));
        IsFalse(FilledIn(              false, Empty              ));
        IsFalse(FilledIn(                     NullyEmpty         ));
        IsFalse(FilledIn(spaceMatters: false, NullyEmpty         ));
        IsFalse(FilledIn(              false, NullyEmpty         ));
        IsFalse(FilledIn(                     Space              ));
        IsFalse(FilledIn(spaceMatters: false, Space              ));
        IsFalse(FilledIn(              false, Space              ));
        IsFalse(FilledIn(                     NullySpace         ));
        IsFalse(FilledIn(spaceMatters: false, NullySpace         ));
        IsFalse(FilledIn(              false, NullySpace         ));
        IsTrue (FilledIn(                     Text               ));
        IsTrue (FilledIn(spaceMatters: false, Text               ));
        IsTrue (FilledIn(              false, Text               ));
        IsTrue (FilledIn(                     NullyFilledText    ));
        IsTrue (FilledIn(spaceMatters: false, NullyFilledText    ));
        IsTrue (FilledIn(              false, NullyFilledText    ));
    }
    
    [TestMethod]
    public void FilledIn_Text_SpaceMattersYes_Extensions()
    {
        IsFalse(NullText       .FilledIn(     spaceMatters       ));
        IsFalse(NullText       .FilledIn(     spaceMatters: true ));
        IsFalse(NullText       .FilledIn(                   true ));
        IsFalse(Empty          .FilledIn(     spaceMatters       ));
        IsFalse(Empty          .FilledIn(     spaceMatters: true ));
        IsFalse(Empty          .FilledIn(                   true ));
        IsFalse(NullyEmpty     .FilledIn(     spaceMatters       ));
        IsFalse(NullyEmpty     .FilledIn(     spaceMatters: true ));
        IsFalse(NullyEmpty     .FilledIn(                   true ));
        IsTrue (Space          .FilledIn(     spaceMatters       ));
        IsTrue (Space          .FilledIn(     spaceMatters: true ));
        IsTrue (Space          .FilledIn(                   true ));
        IsTrue (NullySpace     .FilledIn(     spaceMatters       ));
        IsTrue (NullySpace     .FilledIn(     spaceMatters: true ));
        IsTrue (NullySpace     .FilledIn(                   true ));
        IsTrue (Text           .FilledIn(     spaceMatters       ));
        IsTrue (Text           .FilledIn(     spaceMatters: true ));
        IsTrue (Text           .FilledIn(                   true ));
        IsTrue (NullyFilledText.FilledIn(     spaceMatters       ));
        IsTrue (NullyFilledText.FilledIn(     spaceMatters: true ));
        IsTrue (NullyFilledText.FilledIn(                   true ));
    }
    
    [TestMethod]
    public void FilledIn_Text_SpaceMattersYes_Static_FlagsInBack()
    {
        IsFalse(FilledIn(NullText,            spaceMatters       ));
        IsFalse(FilledIn(NullText,            spaceMatters: true ));
        IsFalse(FilledIn(NullText,                          true ));
        IsFalse(FilledIn(Empty,               spaceMatters       ));
        IsFalse(FilledIn(Empty,               spaceMatters: true ));
        IsFalse(FilledIn(Empty,                             true ));
        IsFalse(FilledIn(NullyEmpty,          spaceMatters       ));
        IsFalse(FilledIn(NullyEmpty,          spaceMatters: true ));
        IsFalse(FilledIn(NullyEmpty,                        true ));
        IsTrue (FilledIn(Space,               spaceMatters       ));
        IsTrue (FilledIn(Space,               spaceMatters: true ));
        IsTrue (FilledIn(Space,                             true ));
        IsTrue (FilledIn(NullySpace,          spaceMatters       ));
        IsTrue (FilledIn(NullySpace,          spaceMatters: true ));
        IsTrue (FilledIn(NullySpace,                        true ));
        IsTrue (FilledIn(Text,                spaceMatters       ));
        IsTrue (FilledIn(Text,                spaceMatters: true ));
        IsTrue (FilledIn(Text,                              true ));
        IsTrue (FilledIn(NullyFilledText,     spaceMatters       ));
        IsTrue (FilledIn(NullyFilledText,     spaceMatters: true ));
        IsTrue (FilledIn(NullyFilledText,                   true ));
    }
    
    [TestMethod]
    public void FilledIn_Text_SpaceMattersYes_Static_FlagsInFront()
    {
        IsFalse(FilledIn(spaceMatters,        NullText           ));
        IsFalse(FilledIn(spaceMatters: true,  NullText           ));
        IsFalse(FilledIn(              true,  NullText           ));
        IsFalse(FilledIn(spaceMatters,        Empty              ));
        IsFalse(FilledIn(spaceMatters: true,  Empty              ));
        IsFalse(FilledIn(              true,  Empty              ));
        IsFalse(FilledIn(spaceMatters,        NullyEmpty         ));
        IsFalse(FilledIn(spaceMatters: true,  NullyEmpty         ));
        IsFalse(FilledIn(              true,  NullyEmpty         ));
        IsTrue (FilledIn(spaceMatters,        Space              ));
        IsTrue (FilledIn(spaceMatters: true,  Space              ));
        IsTrue (FilledIn(              true,  Space              ));
        IsTrue (FilledIn(spaceMatters,        NullySpace         ));
        IsTrue (FilledIn(spaceMatters: true,  NullySpace         ));
        IsTrue (FilledIn(              true,  NullySpace         ));
        IsTrue (FilledIn(spaceMatters,        Text               ));
        IsTrue (FilledIn(spaceMatters: true,  Text               ));
        IsTrue (FilledIn(              true,  Text               ));
        IsTrue (FilledIn(spaceMatters,        NullyFilledText    ));
        IsTrue (FilledIn(spaceMatters: true,  NullyFilledText    ));
        IsTrue (FilledIn(              true,  NullyFilledText    ));
    }
}