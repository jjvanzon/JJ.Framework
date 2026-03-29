

        private static void AssertExceptionIsAllowed<T>(Exception ex)
            => AssertExceptionIsAllowed(ex, GetAssemblyName<T>().ToLower());
        
        private static void AssertExceptionIsAllowed(Exception ex, Assembly assembly) 
            => AssertExceptionIsAllowed(ex, TryGetAssemblyName(assembly).ToLower());
        
        private static void AssertExceptionIsAllowed(Exception ex, string? configSectionName)
        {
            // Allow 'Not Found' Exception
            string allowedMessage    = $"Configuration section '{configSectionName}' not found.";
            bool   messageIsAllowed  = string.Equals(ex.Message,                 allowedMessage);
            bool   messageIsAllowed2 = string.Equals(ex.InnerException?.Message, allowedMessage);
            bool   mustThrow         = !messageIsAllowed && !messageIsAllowed2;
            
            if (mustThrow)
            {
                throw new Exception($"The only exceptions message allowed is: '{allowedMessage}'", ex);
            }
        }
