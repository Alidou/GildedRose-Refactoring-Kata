namespace GildedRose_Refactoring.Refactoring
{
    public static class ItemExtensions
    {
        public static void IncreaseQuality(this Item item, int amount = 1, int maxQuality = 50)
        {
            int i = 0;
            while (i < amount && item.Quality < maxQuality)
            {
                item.Quality++;
                i++;
            }
        }

        public static void DecreaseQuality(this Item item, int amount = 1, int minQuality = 0)
        {
            int i = 0;
            while (i < amount && item.Quality > minQuality)
            {
                item.Quality--;
                i++;
            }
        }
    }
}
