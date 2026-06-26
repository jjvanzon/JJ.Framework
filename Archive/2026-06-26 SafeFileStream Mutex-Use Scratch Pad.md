
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

```
                //catch (AbandonedMutexException ex)
                //{
                //    Console.WriteLine($"{nameof(AbandonedMutexException)}! Mutex was held by a dead thread. {ex.Message}");
                //    throw;
                //}
