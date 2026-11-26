namespace JJ.Framework.Configuration.Core;

public static class CustomConfigManagerCore
{
    public static T GetSection<T>() => throw new NotImplementedException();
    public static T GetSection<T>(Assembly assembly) => throw new NotImplementedException();
    public static T GetSection<T>(string sectionName) => throw new NotImplementedException();

    public static T? TryGetSection<T>() => throw new NotImplementedException();
    public static T? TryGetSection<T>(Assembly assembly) => throw new NotImplementedException();
    public static T? TryGetSection<T>(string sectionName) => throw new NotImplementedException();

    public static void SetSection<T>(T section) => throw new NotImplementedException();
    public static void SetSection<T>(Assembly assembly, T section) => throw new NotImplementedException();
    public static void SetSection<T>(string sectionName, T section) => throw new NotImplementedException();

    public static void RefreshSection(Assembly assembly) => throw new NotImplementedException();
    public static void RefreshSection(string sectionName) => throw new NotImplementedException();
}