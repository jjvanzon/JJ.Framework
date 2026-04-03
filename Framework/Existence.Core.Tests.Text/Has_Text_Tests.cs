// ReSharper disable ReturnValueOfPureMethodIsNotUsed

namespace JJ.Framework.Existence.Core.Text.Tests;

[TestClass]
public class Has_Text_Tests : TestBase
{
    [TestMethod]
    public void Has_Text_True()
    {
        IsTrue(Has(Text           ));
        IsTrue(Has(NullyFilledText));
    }

    [TestMethod]
    public void Has_Text_False()
    {
        IsFalse(Has(Empty     ));
        IsFalse(Has(Space     ));
        IsFalse(Has(NullText  ));
        IsFalse(Has(NullyEmpty));
        IsFalse(Has(NullySpace));
    }
    
    [TestMethod]
    public void Has_Text_SpaceMattersNo_FlagsInBack()
    {
        IsFalse(Has(NullText                                ));
        IsFalse(Has(NullText,            spaceMatters: false));
        IsFalse(Has(NullText,                          false));
        IsFalse(Has(Empty                                   ));
        IsFalse(Has(Empty,               spaceMatters: false));
        IsFalse(Has(Empty,                             false));
        IsFalse(Has(NullyEmpty                              ));
        IsFalse(Has(NullyEmpty,          spaceMatters: false));
        IsFalse(Has(NullyEmpty,                        false));
        IsFalse(Has(Space                                   ));
        IsFalse(Has(Space,               spaceMatters: false));
        IsFalse(Has(Space,                             false));
        IsFalse(Has(NullySpace                              ));
        IsFalse(Has(NullySpace,          spaceMatters: false));
        IsFalse(Has(NullySpace,                        false));
        IsTrue (Has(Text                                    ));
        IsTrue (Has(Text,                spaceMatters: false));
        IsTrue (Has(Text,                              false));
        IsTrue (Has(NullyFilledText                         ));
        IsTrue (Has(NullyFilledText,     spaceMatters: false));
        IsTrue (Has(NullyFilledText,                   false));
    }
    
    [TestMethod]
    public void Has_Text_SpaceMattersNo_FlagsInFront()
    {
        IsFalse(Has(                     NullText           ));
        IsFalse(Has(spaceMatters: false, NullText           ));
        IsFalse(Has(              false, NullText           ));
        IsFalse(Has(                     Empty              ));
        IsFalse(Has(spaceMatters: false, Empty              ));
        IsFalse(Has(              false, Empty              ));
        IsFalse(Has(                     NullyEmpty         ));
        IsFalse(Has(spaceMatters: false, NullyEmpty         ));
        IsFalse(Has(              false, NullyEmpty         ));
        IsFalse(Has(                     Space              ));
        IsFalse(Has(spaceMatters: false, Space              ));
        IsFalse(Has(              false, Space              ));
        IsFalse(Has(                     NullySpace         ));
        IsFalse(Has(spaceMatters: false, NullySpace         ));
        IsFalse(Has(              false, NullySpace         ));
        IsTrue (Has(                     Text               ));
        IsTrue (Has(spaceMatters: false, Text               ));
        IsTrue (Has(              false, Text               ));
        IsTrue (Has(                     NullyFilledText    ));
        IsTrue (Has(spaceMatters: false, NullyFilledText    ));
        IsTrue (Has(              false, NullyFilledText    ));

    }
    
    [TestMethod]
    public void Has_Text_SpaceMattersYes_FlagsInBack()
    {
        IsFalse(Has(NullText,            spaceMatters       ));
        IsFalse(Has(NullText,            spaceMatters: true ));
        IsFalse(Has(NullText,                          true ));
        IsFalse(Has(Empty,               spaceMatters       ));
        IsFalse(Has(Empty,               spaceMatters: true ));
        IsFalse(Has(Empty,                             true ));
        IsFalse(Has(NullyEmpty,          spaceMatters       ));
        IsFalse(Has(NullyEmpty,          spaceMatters: true ));
        IsFalse(Has(NullyEmpty,                        true ));
        IsTrue (Has(Space,               spaceMatters       ));
        IsTrue (Has(Space,               spaceMatters: true ));
        IsTrue (Has(Space,                             true ));
        IsTrue (Has(NullySpace,          spaceMatters       ));
        IsTrue (Has(NullySpace,          spaceMatters: true ));
        IsTrue (Has(NullySpace,                        true ));
        IsTrue (Has(Text,                spaceMatters       ));
        IsTrue (Has(Text,                spaceMatters: true ));
        IsTrue (Has(Text,                              true ));
        IsTrue (Has(NullyFilledText,     spaceMatters       ));
        IsTrue (Has(NullyFilledText,     spaceMatters: true ));
        IsTrue (Has(NullyFilledText,                   true ));
    }
    
    [TestMethod]
    public void Has_Text_SpaceMattersYes_FlagsInFront()
    {
        IsFalse(Has(spaceMatters,        NullText           ));
        IsFalse(Has(spaceMatters: true,  NullText           ));
        IsFalse(Has(              true,  NullText           ));
        IsFalse(Has(spaceMatters,        Empty              ));
        IsFalse(Has(spaceMatters: true,  Empty              ));
        IsFalse(Has(              true,  Empty              ));
        IsFalse(Has(spaceMatters,        NullyEmpty         ));
        IsFalse(Has(spaceMatters: true,  NullyEmpty         ));
        IsFalse(Has(              true,  NullyEmpty         ));
        IsTrue (Has(spaceMatters,        Space              ));
        IsTrue (Has(spaceMatters: true,  Space              ));
        IsTrue (Has(              true,  Space              ));
        IsTrue (Has(spaceMatters,        NullySpace         ));
        IsTrue (Has(spaceMatters: true,  NullySpace         ));
        IsTrue (Has(              true,  NullySpace         ));
        IsTrue (Has(spaceMatters,        Text               ));
        IsTrue (Has(spaceMatters: true,  Text               ));
        IsTrue (Has(              true,  Text               ));
        IsTrue (Has(spaceMatters,        NullyFilledText    ));
        IsTrue (Has(spaceMatters: true,  NullyFilledText    ));
        IsTrue (Has(              true,  NullyFilledText    ));
    }

    /// <inheritdoc cref="_notnullwhentests" />
    [TestMethod]
    public void Has_Text_NotNullWhen()
    {
        string? Text() => NullyFilledText;

        { string? text = Text(); if (Has(text              )) text.ToString(); }
        { string? text = Text(); if (Has(text, true        )) text.ToString(); }
        { string? text = Text(); if (Has(text, spaceMatters)) text.ToString(); }
        { string? text = Text(); if (Has(              text)) text.ToString(); }
        { string? text = Text(); if (Has(true,         text)) text.ToString(); }
        { string? text = Text(); if (Has(spaceMatters, text)) text.ToString(); }
    }
}