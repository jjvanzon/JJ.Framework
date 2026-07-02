
Mutex handling excess code:

```cs

            // Azure Pipelines complains with UnauthorizedAccessException, the 2nd run after a reboot.
            // The mutex isn't locked, because it is succesfully used by heavily concurrent other processes.
            // Try an OpenExisting with lesser right demands in case this allows DevOps to access it the 2ndrun .

            var security = new MutexSecurity();
            var everyone = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
            security.AddAccessRule(new MutexAccessRule(everyone, MutexRights.FullControl, AccessControlType.Allow));

            Mutex? mutex;
            if (!Mutex.TryOpenExisting(mutexName, out mutex))
            {
                // 2. If it doesn't exist at all, create it normally.
                mutex = new Mutex(false, mutexName);
            }
            
                // ReSharper restore UnusedParameter.Local
                
                if (mutex == null)
                {
                    return;
                }


                bool isLocked = !_createSafeFileStreamMutex.WaitOne(0);
                if (isLocked) throw new Exception(nameof(_createSafeFileStreamMutex) + $" {_createSafeFileStreamMutex} already locked.");
```

```cs
                catch (AbandonedMutexException ex)
                {
                    Console.WriteLine($"{nameof(AbandonedMutexException)}! Mutex was held by a dead thread. {ex.Message}");
                    throw;
                }

            // NOTE: This made absolutely no difference. AI hallucination.

   
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr CreateMutex(IntPtr lpMutexAttributes, bool bInitialOwner, string lpName);
         
            // Use Win32 to create mutex with "Everyone" rights (default security descriptor),
            // to appease Azure Pipelines (UnauthorizedAccessException on user-scoped default of .NET.)
            // without importing NuGet dependency.
            if (OperatingSystem.IsWindows()) // TODO: Needs .NET Standard Shim.
            {
                  IntPtr handle = CreateMutex(IntPtr.Zero, false, mutexName);
                  if (handle == IntPtr.Zero)
                  {
                      throw new Win32Exception(Marshal.GetLastWin32Error());
                  }
            }

            // Just wrap it. If CreateMutex succeeded, the OS has created/opened it.
            var mutex = new Mutex(false, mutexName);

    public static bool IsWindows() 
    {
        #if WINDOWS
            return true;
        #elif NETSTANDARD || NETFRAMEWORK
            return RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        #else
            return System.OperatingSystem.IsWindows();
        #endif
    }
```


```cs
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
                    
            var securitySettings = new MutexSecurity();
                securitySettings.AddAccessRule(allowEveryoneRule);
            }
            //catch
            //{
            //    // NCrunch under net461 throws null exception being a hard-coded bug in new MutexAccessRule, 
            //    // passing a hard-coded null to its own base constructor which then throws the null exception.
            //    // Which TFS base library does this is not entirely sure,
            //    // but it shows that we can't rely on this succeeding here.
            //    return null;
            //}

            return securitySettings;
       }
```

```cs

// From GetMutexSecurity:

        try
        {
        }
        // TODO: It's the TrimTests that fail that's the variable that triggers it?
        catch (Exception ex)
        {
            Console.WriteLine($"EXCEPTION IGNORED - {ex}");
            return null;
        }

// From CreateMutexWithName:

        try
        {
        }
        // TODO: It's the TrimTests that fail that's the variable that triggers it?
        catch (Exception ex)
        { 
            // The platforms/TFM/env/context can almost randomly complain 
            // that MutextSecurity/MutexAcl is not supported.
            // Conditions are near-impossibly to set reliably,
            // so ignoring any exception is the most reliable for now.
            Console.WriteLine($"EXCEPTION IGNORED - {ex}");
        }
```

```cs
    private static Mutex InitMutex() 
    {
        Mutex mutex = CreateMutexWithFallback();
        RegisterMutexReleaseOnExit(mutex);
        return mutex;
    }
```

```cs

    //public static readonly Mutex Mutex = CreateMutex_Local();

    // Currently out of favor:

    private static Mutex CreateMutexWithFallback() 
        => TryCreateMutex_GlobalWithAcl() ??
           TryCreateMutex_Global() ??
           TryCreateMutex_Local() ??
           throw new Exception(
               "Could not create Mutex. " +
               "Not with security descriptor 'everone', " +
               "not a global one, " +
               "nor local (per user).");

    private static Mutex CreateMutex_Old(string name)
    {
        var mutex = new Mutex(initiallyOwned: false, name);
        RegisterMutexReleaseOnExit(mutex);
        return mutex;
    }

    private static Mutex CreateMutexForFolder(string folderPath)
    {
        string name = "Global\\" + MUTEX_BASE_NAME + "_" + FileHelperCore.SanitizeFilePath(folderPath);
        return CreateMutex_Older(name);
    }

    private static Mutex CreateMutex_Older(string name)
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

```