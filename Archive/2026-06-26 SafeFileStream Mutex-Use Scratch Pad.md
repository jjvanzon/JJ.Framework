
Mutex handling excess code:

```cs

            // Azure Pipelines complains with UnauthorizedAccessException, the 2nd run after a reboot.
            // The mutex isn't locked, because it is succesfully used by heavily concurrent other processes.
            // Try an OpenExisting with lesser right demands in case this allows DevOps to access it the 2ndrun .

            //var security = new MutexSecurity();
            //var everyone = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
            //security.AddAccessRule(new MutexAccessRule(everyone, MutexRights.FullControl, AccessControlType.Allow));

            //Mutex? mutex;
            //if (!Mutex.TryOpenExisting(mutexName, out mutex))
            //{
            //    // 2. If it doesn't exist at all, create it normally.
            //    mutex = new Mutex(false, mutexName);
            //}
            
                // ReSharper restore UnusedParameter.Local
                
                //if (mutex == null)
                //{
                //    return;
                //}


                //bool isLocked = !_createSafeFileStreamMutex.WaitOne(0);
                //if (isLocked) throw new Exception(nameof(_createSafeFileStreamMutex) + $" {_createSafeFileStreamMutex} already locked.");

```cs
                //catch (AbandonedMutexException ex)
                //{
                //    Console.WriteLine($"{nameof(AbandonedMutexException)}! Mutex was held by a dead thread. {ex.Message}");
                //    throw;
                //}

            // NOTE: This made absolutely no difference. AI hallucination.

   
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr CreateMutex(IntPtr lpMutexAttributes, bool bInitialOwner, string lpName);
         
            // Use Win32 to create mutex with "Everyone" rights (default security descriptor),
            // to appease Azure Pipelines (UnauthorizedAccessException on user-scoped default of .NET.)
            // without importing NuGet dependency.
            //if (OperatingSystem.IsWindows()) // TODO: Needs .NET Standard Shim.
            //{
                  IntPtr handle = CreateMutex(IntPtr.Zero, false, mutexName);
                  if (handle == IntPtr.Zero)
                  {
                      throw new Win32Exception(Marshal.GetLastWin32Error());
                  }
            //}

            // Just wrap it. If CreateMutex succeeded, the OS has created/opened it.
            var mutex = new Mutex(false, mutexName);
```