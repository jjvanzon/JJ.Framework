#pragma warning disable IL2026

/*
namespace JJ.Framework.Existence.Core.Trimming.TestApp.ValuesToText
{
    internal static class Program
    {
        private static void Main()
        {
*/
            // Dump assembly and types for inspection at startup
            var asm = System.Reflection.Assembly.GetExecutingAssembly();
            WriteLine("Assembly: " + asm.GetName().Name);
            var entry = asm.EntryPoint;
            WriteLine("EntryPoint: " + (entry != null ? (entry.DeclaringType?.FullName + "." + entry.Name) : "<none>"));
            //foreach (var t in asm.GetTypes())
            //{
            //    WriteLine("Type: " + t.FullName);
            //}

            bool success =
                RunTests<Coalesce_3Args_ValuesToText_Examples>() &&
                RunTests<Coalesce_3Args_ValuesToText_Extensions>() &&
                RunTests<Coalesce_3Args_ValuesToText_ExtensionsZeroMattersFlagsInBack>() &&
                RunTests<Coalesce_3Args_ValuesToText_ExtensionsZeroMattersFlagsInFront>() &&
                RunTests<Coalesce_3Args_ValuesToText_Static>() &&
                RunTests<Coalesce_3Args_ValuesToText_StaticZeroMattersFlagsInBack>() &&
                RunTests<Coalesce_3Args_ValuesToText_StaticZeroMattersFlagsInFront>();

            WriteLine("Done.");

            if (!success)
                Exit(1);
/*
        }
    }
}
*/