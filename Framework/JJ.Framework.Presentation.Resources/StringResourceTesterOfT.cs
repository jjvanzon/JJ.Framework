namespace JJ.Framework.StringResources.Legacy
{
    /// <summary>
    /// Generic syntax sugar over <see cref="StringResourceTester"/>
    /// so you can write <c>new StringResourceTester&lt;MyResources&gt;(...)</c>
    /// instead of <c>new StringResourceTester(typeof(MyResources), ...)</c>.
    /// </summary>
    public class StringResourceTester<[Dyn(PubProps|PubMethods)] T> : StringResourceTester
    {
        // ReSharper disable once UnusedParameter.Local
        /// <inheritdoc cref="StringResourceTester{T}" />
        public StringResourceTester(
            T resourceObject,
            string[] known, string unknown, string @default, NoLog nolog)
            : base(typeof(T), resourceObject, known, unknown, @default, nolog)
        {
        }

        // ReSharper disable once UnusedParameter.Local
        /// <inheritdoc cref="StringResourceTester{T}" />
        public StringResourceTester(
            string[] known, string unknown, string @default, NoLog nolog)
            : base(typeof(T), known, unknown, @default, nolog)
        {
        }

        /// <inheritdoc cref="StringResourceTester{T}" />
        public StringResourceTester(
            string[] known, string unknown, string @default, bool nolog = default)
            : base(typeof(T), known, unknown, @default, nolog)
        {
        }

        /// <inheritdoc cref="StringResourceTester{T}" />
        public StringResourceTester(
            T resourceObject,
            string[] known, string unknown, string @default, bool nolog = default)
            : base(typeof(T), resourceObject, known, unknown, @default, nolog)
        {
        }
    }
}
