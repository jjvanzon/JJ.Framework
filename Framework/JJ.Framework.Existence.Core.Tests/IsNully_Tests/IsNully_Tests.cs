// ReSharper disable NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract
namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class IsNully_Text_Tests : TestBase
{
    [TestMethod]
    public void IsNully_Text_False_Extensions()
    {
        IsFalse(Text           .IsNully());
        IsFalse(NullyFilledText.IsNully());
    }
        
    [TestMethod]
    public void IsNully_Text_False_Static()
    {
        IsFalse(IsNully(Text           ));
        IsFalse(IsNully(NullyFilledText));
    }        

    [TestMethod]
    public void IsNully_Text_True_Extensions()
    {
        IsTrue (Empty     .IsNully());
        IsTrue (Space     .IsNully());
        IsTrue (NullText  .IsNully());
        IsTrue (NullyEmpty.IsNully());
        IsTrue (NullySpace.IsNully());
    }

    [TestMethod]
    public void IsNully_Text_True_Static()
    {
        IsTrue (IsNully(Empty     ));
        IsTrue (IsNully(Space     ));
        IsTrue (IsNully(NullText  ));
        IsTrue (IsNully(NullyEmpty));
        IsTrue (IsNully(NullySpace));
    }
    
    [TestMethod]
    public void IsNully_Text_SpaceMattersNo_Extensions()
    {
        IsTrue (NullText       .IsNully(                        ));
        IsTrue (NullText       .IsNully(     spaceMatters: false));
        IsTrue (NullText       .IsNully(                   false));
        IsTrue (Empty          .IsNully(                        ));
        IsTrue (Empty          .IsNully(     spaceMatters: false));
        IsTrue (Empty          .IsNully(                   false));
        IsTrue (NullyEmpty     .IsNully(                        ));
        IsTrue (NullyEmpty     .IsNully(     spaceMatters: false));
        IsTrue (NullyEmpty     .IsNully(                   false));
        IsTrue (Space          .IsNully(                        ));
        IsTrue (Space          .IsNully(     spaceMatters: false));
        IsTrue (Space          .IsNully(                   false));
        IsTrue (NullySpace     .IsNully(                        ));
        IsTrue (NullySpace     .IsNully(     spaceMatters: false));
        IsTrue (NullySpace     .IsNully(                   false));
        IsFalse(Text           .IsNully(                        ));
        IsFalse(Text           .IsNully(     spaceMatters: false));
        IsFalse(Text           .IsNully(                   false));
        IsFalse(NullyFilledText.IsNully(                        ));
        IsFalse(NullyFilledText.IsNully(     spaceMatters: false));
        IsFalse(NullyFilledText.IsNully(                   false));
    }
    
    [TestMethod]
    public void IsNully_Text_SpaceMattersNo_StaticFlagsInBack()
    {
        IsTrue (IsNully(NullText                                ));
        IsTrue (IsNully(NullText,            spaceMatters: false));
        IsTrue (IsNully(NullText,                          false));
        IsTrue (IsNully(Empty                                   ));
        IsTrue (IsNully(Empty,               spaceMatters: false));
        IsTrue (IsNully(Empty,                             false));
        IsTrue (IsNully(NullyEmpty                              ));
        IsTrue (IsNully(NullyEmpty,          spaceMatters: false));
        IsTrue (IsNully(NullyEmpty,                        false));
        IsTrue (IsNully(Space                                   ));
        IsTrue (IsNully(Space,               spaceMatters: false));
        IsTrue (IsNully(Space,                             false));
        IsTrue (IsNully(NullySpace                              ));
        IsTrue (IsNully(NullySpace,          spaceMatters: false));
        IsTrue (IsNully(NullySpace,                        false));
        IsFalse(IsNully(Text                                    ));
        IsFalse(IsNully(Text,                spaceMatters: false));
        IsFalse(IsNully(Text,                              false));
        IsFalse(IsNully(NullyFilledText                         ));
        IsFalse(IsNully(NullyFilledText,     spaceMatters: false));
        IsFalse(IsNully(NullyFilledText,                   false));
    }
    
    [TestMethod]
    public void IsNully_Text_SpaceMattersNo_StaticFlagsInFront()
    {
        IsTrue (IsNully(                     NullText           ));
        IsTrue (IsNully(spaceMatters: false, NullText           ));
        IsTrue (IsNully(              false, NullText           ));
        IsTrue (IsNully(                     Empty              ));
        IsTrue (IsNully(spaceMatters: false, Empty              ));
        IsTrue (IsNully(              false, Empty              ));
        IsTrue (IsNully(                     NullyEmpty         ));
        IsTrue (IsNully(spaceMatters: false, NullyEmpty         ));
        IsTrue (IsNully(              false, NullyEmpty         ));
        IsTrue (IsNully(                     Space              ));
        IsTrue (IsNully(spaceMatters: false, Space              ));
        IsTrue (IsNully(              false, Space              ));
        IsTrue (IsNully(                     NullySpace         ));
        IsTrue (IsNully(spaceMatters: false, NullySpace         ));
        IsTrue (IsNully(              false, NullySpace         ));
        IsFalse(IsNully(                     Text               ));
        IsFalse(IsNully(spaceMatters: false, Text               ));
        IsFalse(IsNully(              false, Text               ));
        IsFalse(IsNully(                     NullyFilledText    ));
        IsFalse(IsNully(spaceMatters: false, NullyFilledText    ));
        IsFalse(IsNully(              false, NullyFilledText    ));
    }
    
    [TestMethod]
    public void IsNully_Text_SpaceMattersYes_Extensions()
    {
        IsTrue (NullText       .IsNully(     spaceMatters       ));
        IsTrue (NullText       .IsNully(     spaceMatters: true ));
        IsTrue (NullText       .IsNully(                   true ));
        IsTrue (Empty          .IsNully(     spaceMatters       ));
        IsTrue (Empty          .IsNully(     spaceMatters: true ));
        IsTrue (Empty          .IsNully(                   true ));
        IsTrue (NullyEmpty     .IsNully(     spaceMatters       ));
        IsTrue (NullyEmpty     .IsNully(     spaceMatters: true ));
        IsTrue (NullyEmpty     .IsNully(                   true ));
        IsFalse(Space          .IsNully(     spaceMatters       ));
        IsFalse(Space          .IsNully(     spaceMatters: true ));
        IsFalse(Space          .IsNully(                   true ));
        IsFalse(NullySpace     .IsNully(     spaceMatters       ));
        IsFalse(NullySpace     .IsNully(     spaceMatters: true ));
        IsFalse(NullySpace     .IsNully(                   true ));
        IsFalse(Text           .IsNully(     spaceMatters       ));
        IsFalse(Text           .IsNully(     spaceMatters: true ));
        IsFalse(Text           .IsNully(                   true ));
        IsFalse(NullyFilledText.IsNully(     spaceMatters       ));
        IsFalse(NullyFilledText.IsNully(     spaceMatters: true ));
        IsFalse(NullyFilledText.IsNully(                   true ));
    }
    
    [TestMethod]
    public void IsNully_Text_SpaceMattersYes_Static_FlagsInBack()
    {
        IsTrue (IsNully(NullText,            spaceMatters       ));
        IsTrue (IsNully(NullText,            spaceMatters: true ));
        IsTrue (IsNully(NullText,                          true ));
        IsTrue (IsNully(Empty,               spaceMatters       ));
        IsTrue (IsNully(Empty,               spaceMatters: true ));
        IsTrue (IsNully(Empty,                             true ));
        IsTrue (IsNully(NullyEmpty,          spaceMatters       ));
        IsTrue (IsNully(NullyEmpty,          spaceMatters: true ));
        IsTrue (IsNully(NullyEmpty,                        true ));
        IsFalse(IsNully(Space,               spaceMatters       ));
        IsFalse(IsNully(Space,               spaceMatters: true ));
        IsFalse(IsNully(Space,                             true ));
        IsFalse(IsNully(NullySpace,          spaceMatters       ));
        IsFalse(IsNully(NullySpace,          spaceMatters: true ));
        IsFalse(IsNully(NullySpace,                        true ));
        IsFalse(IsNully(Text,                spaceMatters       ));
        IsFalse(IsNully(Text,                spaceMatters: true ));
        IsFalse(IsNully(Text,                              true ));
        IsFalse(IsNully(NullyFilledText,     spaceMatters       ));
        IsFalse(IsNully(NullyFilledText,     spaceMatters: true ));
        IsFalse(IsNully(NullyFilledText,                   true ));
    }
    
    [TestMethod]
    public void IsNully_Text_SpaceMattersYes_Static_FlagsInFront()
    {
        IsTrue (IsNully(spaceMatters,        NullText           ));
        IsTrue (IsNully(spaceMatters: true,  NullText           ));
        IsTrue (IsNully(              true,  NullText           ));
        IsTrue (IsNully(spaceMatters,        Empty              ));
        IsTrue (IsNully(spaceMatters: true,  Empty              ));
        IsTrue (IsNully(              true,  Empty              ));
        IsTrue (IsNully(spaceMatters,        NullyEmpty         ));
        IsTrue (IsNully(spaceMatters: true,  NullyEmpty         ));
        IsTrue (IsNully(              true,  NullyEmpty         ));
        IsFalse(IsNully(spaceMatters,        Space              ));
        IsFalse(IsNully(spaceMatters: true,  Space              ));
        IsFalse(IsNully(              true,  Space              ));
        IsFalse(IsNully(spaceMatters,        NullySpace         ));
        IsFalse(IsNully(spaceMatters: true,  NullySpace         ));
        IsFalse(IsNully(              true,  NullySpace         ));
        IsFalse(IsNully(spaceMatters,        Text               ));
        IsFalse(IsNully(spaceMatters: true,  Text               ));
        IsFalse(IsNully(              true,  Text               ));
        IsFalse(IsNully(spaceMatters,        NullyFilledText    ));
        IsFalse(IsNully(spaceMatters: true,  NullyFilledText    ));
        IsFalse(IsNully(              true,  NullyFilledText    ));
    }
}