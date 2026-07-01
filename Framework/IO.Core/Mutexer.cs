using System.Security.AccessControl;
using System.Security.Principal;
using static System.AppDomain;
#pragma warning disable IDE0051

namespace JJ.Framework.IO.Core;

internal static class Mutexer
{
    private const string MUTEX_NAME = "JJ_SafeFileStream_7f64fd76542045bb98c2e28a44d2df25";
    private const string GLOBAL_MUTEX_NAME_WITH_ACL = "Global\\" + MUTEX_NAME + "_WithAcl";
    private const string GLOBAL_MUTEX_NAME = "Global\\" + MUTEX_NAME;
    private const string LOCAL_MUTEX_NAME = "Local\\" + MUTEX_NAME;

    public static readonly Mutex Mutex = CreateMutexLocal();

    //private static Mutex InitMutex() 
    //{
    //    Mutex mutex = CreateMutexWithFallback();
    //    RegisterMutexReleaseOnExit(mutex);
    //    return mutex;
    //}

    private static Mutex CreateMutexWithFallback()
    {
        return TryCreateMutex_GlobalWithAcl() ??
               TryCreateMutex_Global() ??
               TryCreateMutex_Local() ??
               throw new Exception(
                   "Could not create Mutex. " +
                   "Not with security descriptor 'everone', " +
                   "not a global one, " +
                   "nor local (per user).");
    }

    private static Mutex? TryCreateMutex_GlobalWithAcl()
    {
        try
        {
            if (!IsWindows()) return null;

            MutexSecurity? sec = GetMutexSecurity();
            if (sec == null) return null;
            Mutex mutex = MutexAcl.Create(initiallyOwned: false, GLOBAL_MUTEX_NAME_WITH_ACL, out _, sec);
            RegisterMutexReleaseOnExit(mutex);
            return mutex;

        }
        catch (Exception ex)
        {
            Console.WriteLine($"EXCEPTION IGNORED - {ex}");
            return null;
        }
    }

    private static Mutex? TryCreateMutex_Global()
    {
        try
        {
            var mutex = new Mutex(initiallyOwned: false, GLOBAL_MUTEX_NAME);
            RegisterMutexReleaseOnExit(mutex);
            return mutex;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"EXCEPTION IGNORED - {ex}");
            return null;
        }
    }

    private static Mutex? TryCreateMutex_Local()
    {
        try
        {
            return CreateMutexLocal();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"EXCEPTION IGNORED - {ex}");
            return null;
        }
    }

    private static Mutex CreateMutexLocal()
    {
        var mutex = new Mutex(initiallyOwned: false, LOCAL_MUTEX_NAME);
        RegisterMutexReleaseOnExit(mutex);
        return mutex;
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

    /// <summary>
    /// <para> Returns a security descriptor that can give a mutex "Everyone" rights. </para>
    /// 
    /// <para> Azure Pipelines complains with UnauthorizedAccessException, the 2nd run after a reboot.
    /// The mutex isn't locked; it was succesfully used by heavily concurrent other processes. </para>
    /// 
    /// <para> It appears to have difficuly accessing a Mutex created from another user session. </para>
    /// </summary>
    private static MutexSecurity? GetMutexSecurity()
    {
        if (!IsWindows()) return null;

        var securitySettings = new MutexSecurity();

        // Source: https://stackoverflow.com/questions/229565/what-is-a-good-pattern-for-using-a-global-mutex-in-c
        // edited by Jeremy Wiebe to add example of setting up security for multi-user usage
        // edited by 'Marc' to work also on localized systems (don't use just "Everyone") 
        var allowEveryoneRule = 
            new MutexAccessRule( 
                new SecurityIdentifier(WellKnownSidType.WorldSid, null), 
                MutexRights.FullControl, 
                AccessControlType.Allow);

        securitySettings.AddAccessRule(allowEveryoneRule);

        return securitySettings;
    }

    private static Mutex CreateMutexForFolder(string folderPath)
    {
        string name = GLOBAL_MUTEX_NAME + "_" + FileHelperCore.SanitizeFilePath(folderPath);
        return CreateMutexWithName(name);
    }

    private static Mutex CreateMutexWithName(string name)
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
