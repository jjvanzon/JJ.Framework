namespace JJ.Framework.Existence.Core.Trimming.TestApp.ValuesToText
{
    internal static class Program
    {
        private static void Main()
        {
            bool success =
                RunTests<Coalesce_3Args_ValuesToText_Examples>() &&
                RunTests<Coalesce_3Args_ValuesToText_Extensions>() &&
                RunTests<Coalesce_3Args_ValuesToText_ExtensionsZeroMattersFlagsInBack>() &&
                RunTests<Coalesce_3Args_ValuesToText_ExtensionsZeroMattersFlagsInFront>() &&
                RunTests<Coalesce_3Args_ValuesToText_Static>() &&
                RunTests<Coalesce_3Args_ValuesToText_StaticZeroMattersFlagsInBack>() &&
                RunTests<Coalesce_3Args_ValuesToText_StaticZeroMattersFlagsInFront>();

            System.Console.WriteLine("Done.");

            if (!success)
                System.Environment.Exit(1);
        }
    }
}
