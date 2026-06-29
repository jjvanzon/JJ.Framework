
```cs
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