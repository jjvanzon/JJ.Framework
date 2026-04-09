namespace JJ.Framework.ResourceStrings.Legacy.Tests;

[TestClass]
public class CommonTitlesTests
{
    [TestMethod]
    public void ResourceManager_IsNotNull()
    {
        var resourceManager = CommonTitles.ResourceManager;
        IsNotNull(resourceManager);
    }
    
    [TestMethod]
    public void CommonTitles_InvariantCulture()
    {
        CultureInfo saved = CurrentThread.CurrentUICulture;
        try
        {
            CurrentThread.CurrentUICulture = InvariantCulture;
            AreEqual("Add",            CommonTitles.Add);
            AreEqual("Cancel",         CommonTitles.Cancel);
            AreEqual("Delete",         CommonTitles.Delete);
            AreEqual("Edit",           CommonTitles.Edit);
            AreEqual("Number of {0}",  CommonTitles.EntityCount);
            AreEqual("ID",             CommonTitles.ID);
            AreEqual("Language",       CommonTitles.Language);
            AreEqual("LogIn",          CommonTitles.LogIn);
            AreEqual("LogOut",         CommonTitles.LogOut);
            AreEqual("New",            CommonTitles.New);
            AreEqual("No",             CommonTitles.No);
            AreEqual("None",           CommonTitles.None);
            AreEqual("NotAuthorized",  CommonTitles.NotAuthorized);
            AreEqual("Remove",         CommonTitles.Remove);
            AreEqual("Save",           CommonTitles.Save);
            AreEqual("Search",         CommonTitles.Search);
            AreEqual("Yes",            CommonTitles.Yes);
        }
        finally
        {
            CurrentThread.CurrentUICulture = saved;
        }
    }
    
    [TestMethod]
    public void CommonTitles_enUS()
    {
        CultureInfo saved = CurrentThread.CurrentUICulture;
        try
        {
            CurrentThread.CurrentUICulture = new("en-US");
            AreEqual("Add",            CommonTitles.Add);
            AreEqual("Cancel",         CommonTitles.Cancel);
            AreEqual("Delete",         CommonTitles.Delete);
            AreEqual("Edit",           CommonTitles.Edit);
            AreEqual("Number of {0}",  CommonTitles.EntityCount);
            AreEqual("ID",             CommonTitles.ID);
            AreEqual("Language",       CommonTitles.Language);
            AreEqual("Log In",         CommonTitles.LogIn);
            AreEqual("Log Out",        CommonTitles.LogOut);
            AreEqual("New",            CommonTitles.New);
            AreEqual("No",             CommonTitles.No);
            AreEqual("None",           CommonTitles.None);
            AreEqual("Not Authorized", CommonTitles.NotAuthorized);
            AreEqual("Remove",         CommonTitles.Remove);
            AreEqual("Save",           CommonTitles.Save);
            AreEqual("Search",         CommonTitles.Search);
            AreEqual("Yes",            CommonTitles.Yes);
        }
        finally
        {
            CurrentThread.CurrentUICulture = saved;
        }
    }

    [TestMethod]
    public void CommonTitles_nlNL()
    {
        CultureInfo saved = CurrentThread.CurrentUICulture;
        try
        {
            CurrentThread.CurrentUICulture = new("nl-NL");
            AreEqual("Toevoegen",       CommonTitles.Add);
            AreEqual("Annuleren",       CommonTitles.Cancel);
            AreEqual("Verwijderen",     CommonTitles.Delete);
            AreEqual("Bewerken",        CommonTitles.Edit);
            AreEqual("Aantal {0}",      CommonTitles.EntityCount);
            AreEqual("ID",              CommonTitles.ID);
            AreEqual("Taal",            CommonTitles.Language);
            AreEqual("Inloggen",        CommonTitles.LogIn);
            AreEqual("Uitloggen",       CommonTitles.LogOut);
            AreEqual("Nieuw",           CommonTitles.New);
            AreEqual("Nee",             CommonTitles.No);
            AreEqual("Geen",            CommonTitles.None);
            AreEqual("Niet gemachtigd", CommonTitles.NotAuthorized);
            AreEqual("Verwijderen",     CommonTitles.Remove);
            AreEqual("Opslaan",         CommonTitles.Save);
            AreEqual("Zoeken",          CommonTitles.Search);
            AreEqual("Ja",              CommonTitles.Yes);
        }
        finally
        {
            CurrentThread.CurrentUICulture = saved;
        }
    }
}
