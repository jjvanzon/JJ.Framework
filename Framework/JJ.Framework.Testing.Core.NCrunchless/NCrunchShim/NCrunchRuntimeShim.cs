namespace NCrunch.TestRuntime.DotNetCoreShim
{
    /// <summary>
    /// Minimal shim to ensure assembly exists when instrumentation expects it. 
    /// </summary>
    public static class NCrunchRuntimeShim
    {
        /// <summary>
        /// Intentionally empty. 
        /// </summary>
        public static void EnsureLoaded() { }
    }
}
