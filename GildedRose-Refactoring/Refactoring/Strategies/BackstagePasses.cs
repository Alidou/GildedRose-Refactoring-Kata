namespace GildedRose_Refactoring.Refactoring.Strategies
{
    public class BackstagePasses : IItemQualityUpdateStrategy
    {
        public void UpdateQuality(Item item)
        {
            item.IncreaseQuality();

            if (item.SellIn < 11)
            {
                item.IncreaseQuality();
            }

            if (item.SellIn < 6)
            {
                item.IncreaseQuality();
            }

            item.SellIn--;

            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
        }
    }
}