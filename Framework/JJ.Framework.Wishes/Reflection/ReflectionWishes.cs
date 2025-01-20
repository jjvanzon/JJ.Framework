namespace JJ.Framework.Wishes.Reflection
{
    public static class ReflectionWishes
    {
        public static string GetAssemblyName<TType>()
            => typeof(TType).Assembly.GetName().Name;
    }
}