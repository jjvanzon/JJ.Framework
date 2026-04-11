namespace JJ.Framework.ResourceStrings.Legacy.Tests;

using static CommonTitles;

[TestClass]
public class CommonTitlesTests() 
    : ResourceStringTester(
        typeof(CommonTitles), 
        known: ["en-US", "nl-NL"], 
        unknown: "de-DE", 
        @default: "")
{
    private static readonly CultureInfo _enUS = GetCultureInfo("en-US");
    private static readonly CultureInfo _nlNL = GetCultureInfo("nl-NL");

    [TestMethod]
    public void CommonTitles_AllPublicMembers_ReturnText_ForKnownCultures() 
        => AssertAllMembers();
    
    [TestMethod]
    public void CommonTitles_UnknownCulture_DefaultsToEnUS() 
        => AssertUnknownCulture();

    [TestMethod]
    public void CommonTitles_ResourceManager_IsNotNull() 
        => IsNotNull(ResourceManager);

    [TestMethod]
    public void CommonTitles_CheckExactText_InvariantCulture()
    {
        CultureInfo saved = CurrentThread.CurrentUICulture;
        try
        {
            CurrentThread.CurrentUICulture = InvariantCulture;
            AreEqual("Add",           Add);
            AreEqual("Cancel",        Cancel);
            AreEqual("Delete",        Delete);
            AreEqual("Edit",          Edit);
            AreEqual("Number of {0}", EntityCount);
            AreEqual("ID",            ID);
            AreEqual("Language",      Language);
            AreEqual("LogIn",         LogIn);
            AreEqual("LogOut",        LogOut);
            AreEqual("New",           New);
            AreEqual("No",            No);
            AreEqual("None",          None);
            AreEqual("NotAuthorized", NotAuthorized);
            AreEqual("Remove",        Remove);
            AreEqual("Save",          Save);
            AreEqual("Search",        Search);
            AreEqual("Yes",           Yes);
        }
        finally
        {
            CurrentThread.CurrentUICulture = saved;
        }
    }
    
    [TestMethod]
    public void CommonTitles_CheckExactText_enUS()
    {
        CultureInfo saved = CurrentThread.CurrentUICulture;
        try
        {
            CurrentThread.CurrentUICulture = _enUS;
            AreEqual("Add",            Add);
            AreEqual("Cancel",         Cancel);
            AreEqual("Delete",         Delete);
            AreEqual("Edit",           Edit);
            AreEqual("Number of {0}",  EntityCount);
            AreEqual("ID",             ID);
            AreEqual("Language",       Language);
            AreEqual("Log In",         LogIn);
            AreEqual("Log Out",        LogOut);
            AreEqual("New",            New);
            AreEqual("No",             No);
            AreEqual("None",           None);
            AreEqual("Not Authorized", NotAuthorized);
            AreEqual("Remove",         Remove);
            AreEqual("Save",           Save);
            AreEqual("Search",         Search);
            AreEqual("Yes",            Yes);
        }
        finally
        {
            CurrentThread.CurrentUICulture = saved;
        }
    }

    [TestMethod]
    public void CommonTitles_CheckExactText_nlNL()
    {
        CultureInfo saved = CurrentThread.CurrentUICulture;
        try
        {
            CurrentThread.CurrentUICulture = _nlNL;
            AreEqual("Toevoegen",       Add);
            AreEqual("Annuleren",       Cancel);
            AreEqual("Verwijderen",     Delete);
            AreEqual("Bewerken",        Edit);
            AreEqual("Aantal {0}",      EntityCount);
            AreEqual("ID",              ID);
            AreEqual("Taal",            Language);
            AreEqual("Inloggen",        LogIn);
            AreEqual("Uitloggen",       LogOut);
            AreEqual("Nieuw",           New);
            AreEqual("Nee",             No);
            AreEqual("Geen",            None);
            AreEqual("Niet gemachtigd", NotAuthorized);
            AreEqual("Verwijderen",     Remove);
            AreEqual("Opslaan",         Save);
            AreEqual("Zoeken",          Search);
            AreEqual("Ja",              Yes);
        }
        finally
        {
            CurrentThread.CurrentUICulture = saved;
        }
    }
}
