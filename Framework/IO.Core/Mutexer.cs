// ReSharper disable InlineTemporaryVariable
// ReSharper disable UnusedMember.Local

using System.Security.AccessControl;
using System.Security.Principal;
using static System.Security.AccessControl.AccessControlType;
using static System.Security.AccessControl.MutexRights;
using static System.AppDomain;

namespace JJ.Framework.IO.Core;

internal static class Mutexer
{
    private const string MUTEX_BASE_NAME = "JJ_SafeFileStream_7f64fd76542045bb98c2e28a44d2df25";
    public static readonly Mutex Mutex = TryCreateMutex_LocalWithAcl() ?? CreateMutex_Local();

    // NOTE: Most of these variants are unused, but keep them for now 
    // as they might be required when things get rough again.

    private static Mutex? TryCreateMutex_GlobalWithAcl() => TryCreateMutex_WithAcl("Global\\" + MUTEX_BASE_NAME + "_WithAcl");
    private static Mutex     CreateMutex_GlobalWithAcl() =>    CreateMutex_WithAcl("Global\\" + MUTEX_BASE_NAME + "_WithAcl");
    private static Mutex? TryCreateMutex_LocalWithAcl () => TryCreateMutex_WithAcl("Local\\"  + MUTEX_BASE_NAME + "_WithAcl");
    private static Mutex     CreateMutex_LocalWithAcl () =>    CreateMutex_WithAcl("Local\\"  + MUTEX_BASE_NAME + "_WithAcl");
    private static Mutex? TryCreateMutex_Global       () => TryCreateMutex        ("Global\\" + MUTEX_BASE_NAME             );
    private static Mutex     CreateMutex_Global       () =>    CreateMutex        ("Global\\" + MUTEX_BASE_NAME             );
    private static Mutex? TryCreateMutex_Local        () => TryCreateMutex        ("Local\\"  + MUTEX_BASE_NAME             );
    private static Mutex     CreateMutex_Local        () =>    CreateMutex        ("Local\\"  + MUTEX_BASE_NAME             );
    
    private static Mutex? TryCreateMutex(string name)
    {
        try
        {
            return CreateMutex(name);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"EXCEPTION IGNORED - {ex}");
            return null;
        }
    }

    private static Mutex CreateMutex(string name)
    {
        try
        {
            // In Azure DevOps, this can create the Mutex with full rights the first time,
            // but when created the 2nd time, demand of full rights fails.
            var mutex = new Mutex(initiallyOwned: false, name);
            RegisterMutexReleaseOnExit(mutex);
            return mutex;
        }
        catch (UnauthorizedAccessException ex)
        {
            // This only demands limited rights, but enough for use.
            if (Mutex.TryOpenExisting(name, out Mutex? existingMutex))
            {
                return existingMutex;
            }

            throw new Exception("Both new Mutex and Mutex.TryOpenExisting failed.", ex);
        }
    }

    private static Mutex? TryCreateMutex_WithAcl(string name)
    {
        if (!IsWindows()) return null;

        try
        {
            return CreateMutex_WithAcl(name);
        }
        catch (Exception ex)
        {
            // Depending on the environment (NCrunch, Visual Studio Build, Azure Pipelines Local Agent)
            // The MutexAccessRule constructor crashes ITSELF by passing a hard-coded null to its own base class.
            // Which TFS base library does this is not entirely sure. This might be a stub framework version or otherwise.
            // First we tried solving it by adding conditions, but edge cases kept surfacing this bug again.
            // So for reliability, we can't can't rely on this succeeding here.
            // We tend to omit the access rule if this happens.
            Console.WriteLine($"EXCEPTION IGNORED - {ex}");
            return null;
        }
    }

    private static Mutex CreateMutex_WithAcl(string name)
    {
        if (!IsWindows()) throw new Exception("No possible unless IsWindows() is true.");
        MutexSecurity sec = GetMutexSecurity();
        Mutex mutex = MutexAcl.Create(initiallyOwned: false, name, out _, sec);
        RegisterMutexReleaseOnExit(mutex);
        return mutex;
    }

    /// <summary>
    /// <para> Returns a security descriptor that can give a mutex "Everyone" rights. </para>
    /// 
    /// <para> Azure Pipelines complains with UnauthorizedAccessException, the 2nd run after a reboot.
    /// The mutex isn't locked; it was succesfully used by heavily concurrent other processes. </para>
    /// 
    /// <para> It appears to have difficuly accessing a Mutex created from another user session. </para>
    /// </summary>
    private static MutexSecurity GetMutexSecurity()
    {
        if (!IsWindows()) throw new Exception("No possible unless IsWindows() is true.");

        var securitySettings = new MutexSecurity();

        // Source: https://stackoverflow.com/questions/229565/what-is-a-good-pattern-for-using-a-global-mutex-in-c
        // edited by Jeremy Wiebe to add example of setting up security for multi-user usage
        // edited by 'Marc' to work also on localized systems (don't use just "Everyone") 
        var allowEveryoneRule = 
            new MutexAccessRule( 
                new SecurityIdentifier(WellKnownSidType.WorldSid, null), 
                FullControl, 
                Allow);

        securitySettings.AddAccessRule(allowEveryoneRule);

        return securitySettings;
    }

    
    private static void RegisterMutexReleaseOnExit(Mutex mutex)
    {
        CurrentDomain.ProcessExit += (_, _) =>
        {
            try { mutex.ReleaseMutex(); } 
            catch { /* If it didn't get abandoned, ReleaseMutex probably fails.*/ }
            mutex.Dispose();
        };
    }
}
