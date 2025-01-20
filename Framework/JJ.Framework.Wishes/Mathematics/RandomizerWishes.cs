namespace JJ.Framework.Wishes.Mathematics
{
    public static class RandomizerWishes
    {
        public static T GetRandomItem<T>(params T[] collection)
            => Randomizer_Copied.GetRandomItem(collection);
    }
}