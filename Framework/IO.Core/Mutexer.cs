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
    private const string MUTEX_BASE_NAME            = "JJ_SafeFileStream_7f64fd76542045bb98c2e28a44d2df25";
    private const string MUTEX_NAME_LOCAL           = "Local\\"  + MUTEX_BASE_NAME;
    private const string MUTEX_NAME_LOCAL_WITH_ACL  = "Local\\"  + MUTEX_BASE_NAME + "_WithAcl";
    private const string MUTEX_NAME_GLOBAL          = "Global\\" + MUTEX_BASE_NAME;
    private const string MUTEX_NAME_GLOBAL_WITH_ACL = "Global\\" + MUTEX_BASE_NAME + "_WithAcl";

    //public static readonly Mutex Mutex = CreateMutex_Local();
    public static readonly Mutex Mutex = TryCreateMutex_LocalWithAcl() ?? CreateMutex_Local();

    // NOTE: Most of these variants are unused, but keep them for now 
    // as they might be required when things get rough again.

    private static Mutex CreateMutexWithFallback() 
        => TryCreateMutex_GlobalWithAcl() ??
           TryCreateMutex_Global() ??
           TryCreateMutex_Local() ??
           throw new Exception(
               "Could not create Mutex. " +
               "Not with security descriptor 'everone', " +
               "not a global one, " +
               "nor local (per user).");

    private static Mutex? TryCreateMutex_GlobalWithAcl() => TryCreateMutex_ByNameWithAcl(MUTEX_NAME_GLOBAL_WITH_ACL);
    private static Mutex     CreateMutex_GlobalWithAcl() =>    CreateMutex_ByNameWithAcl(MUTEX_NAME_GLOBAL_WITH_ACL);
    private static Mutex? TryCreateMutex_LocalWithAcl () => TryCreateMutex_ByNameWithAcl(MUTEX_NAME_LOCAL_WITH_ACL );
    private static Mutex     CreateMutex_LocalWithAcl () =>    CreateMutex_ByNameWithAcl(MUTEX_NAME_LOCAL_WITH_ACL );
    private static Mutex? TryCreateMutex_Global       () => TryCreateMutex_ByName       (MUTEX_NAME_GLOBAL         );
    private static Mutex     CreateMutex_Global       () =>    CreateMutex_ByName       (MUTEX_NAME_GLOBAL         );
    private static Mutex? TryCreateMutex_Local        () => TryCreateMutex_ByName       (MUTEX_NAME_LOCAL          );
    private static Mutex     CreateMutex_Local        () =>    CreateMutex_ByName       (MUTEX_NAME_LOCAL          );
    
    private static Mutex? TryCreateMutex_ByName(string name)
    {
        try
        {
            return CreateMutex_ByName(name);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"EXCEPTION IGNORED - {ex}");
            return null;
        }
    }

    private static Mutex CreateMutex_ByName(string name)
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

    private static Mutex? TryCreateMutex_ByNameWithAcl(string name)
    {
        if (!IsWindows()) return null;

        try
        {
            return CreateMutex_ByNameWithAcl(name);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"EXCEPTION IGNORED - {ex}");
            return null;
        }
    }

    private static Mutex CreateMutex_ByNameWithAcl(string name)
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

    // Currently out of favor:

    private static Mutex CreateMutex_ByName_Old(string name)
    {
        var mutex = new Mutex(initiallyOwned: false, name);
        RegisterMutexReleaseOnExit(mutex);
        return mutex;
    }

    private static Mutex CreateMutexForFolder(string folderPath)
    {
        string name = MUTEX_NAME_GLOBAL + "_" + FileHelperCore.SanitizeFilePath(folderPath);
        return CreateMutex_ByName_Older(name);
    }

    private static Mutex CreateMutex_ByName_Older(string name)
    {
        Mutex? mutex = null;

        if (IsWindows())
        {
            MutexSecurity? sec = GetMutexSecurity();
            if (sec != null)
            {
                mutex = MutexAcl.Create(false, name, out _, sec);
            }
        }

        mutex ??= new Mutex(false, name);
            
        RegisterMutexReleaseOnExit(mutex);

        return mutex;
    }

}
