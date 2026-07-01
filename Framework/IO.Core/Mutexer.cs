using System.Security.AccessControl;
using System.Security.Principal;
using static System.AppDomain;

namespace JJ.Framework.IO.Core;

internal static class Mutexer
{
    private const string MUTEX_NAME = "JJ_SafeFileStream_7f64fd76542045bb98c2e28a44d2df25";
    private const string GLOBAL_MUTEX_NAME = "Global\\" + MUTEX_NAME;
    private const string LOCAL_MUTEX_NAME = "Local\\" + MUTEX_NAME;

    public static readonly Mutex Mutex = InitMutex();

    private static Mutex InitMutex() 
    {
        Mutex mutex = CreateMutexWithFallback();
        RegisterReleaseMutexOnExit(mutex);
        return mutex;
    }

    private static Mutex CreateMutexForFolder(string folderPath)
    {
        string name = GLOBAL_MUTEX_NAME + "_" + FileHelperCore.SanitizeFilePath(folderPath);
        return CreateMutexWithName(name);
    }

    private static Mutex CreateMutexWithName(string name)
    {
        Mutex? mutex = null;

        //try
        {
            if (IsWindows())
            {
                MutexSecurity? sec = GetMutexSecurity();
                if (sec != null)
                {
                    mutex = MutexAcl.Create(false, name, out _, sec);
                }
            }
        }
        // TODO: It's the TrimTests that fail that's the variable that triggers it.
        //catch (Exception ex)
        //{ 
        //    // The platforms/TFM/env/context can almost randomly complain 
        //    // that MutextSecurity/MutexAcl is not supported.
        //    // Conditions are near-impossibly to set reliably,
        //    // so ignoring any exception is the most reliable for now.
        //    Console.WriteLine($"EXCEPTION IGNORED - {ex}");
        //}

        mutex ??= new Mutex(false, name);
            
        RegisterReleaseMutexOnExit(mutex);

        return mutex;
    }

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
            Mutex mutex = MutexAcl.Create(false, GLOBAL_MUTEX_NAME, out _, sec);
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
            return new Mutex(false, GLOBAL_MUTEX_NAME);
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
            return new Mutex(false, LOCAL_MUTEX_NAME);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"EXCEPTION IGNORED - {ex}");
            return null;
        }
    }

    private static void RegisterReleaseMutexOnExit(Mutex mutex)
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

        //try
        {
            // Source: https://stackoverflow.com/questions/229565/what-is-a-good-pattern-for-using-a-global-mutex-in-c
            // edited by Jeremy Wiebe to add example of setting up security for multi-user usage
            // edited by 'Marc' to work also on localized systems (don't use just "Everyone") 
            var allowEveryoneRule = 
                new MutexAccessRule( 
                    new SecurityIdentifier(WellKnownSidType.WorldSid, null), 
                    MutexRights.FullControl, 
                    AccessControlType.Allow
                );
            securitySettings.AddAccessRule(allowEveryoneRule);
        }
        // TODO: It's the TrimTests that fail that's the variable that triggers it.
        //catch (Exception ex)
        //{
        //    // Depending on the environment (NCrunch, Visual Studio Build, Azure Pipelines Local Agent)
        //    // The MutexAccessRule constructor crashes ITSELF by passing a hard-coded null to its own base class.
        //    // Which TFS base library does this is not entirely sure.
        //    // This might be a stub framework version or otherwise.
        //    // First we tried solving it by adding conditions, but edge cases kept surfacing this bug again.
        //    // So for reliability, we can't can't rely on this succeeding here.
        //    // So we omit the access rule if this happens.
        //    Console.WriteLine($"EXCEPTION IGNORED - {ex}");
        //    return null;
        //}

        return securitySettings;
    }
}
