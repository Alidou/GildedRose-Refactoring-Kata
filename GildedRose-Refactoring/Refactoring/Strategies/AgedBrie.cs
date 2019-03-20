namespace GildedRose_Refactoring.Refactoring.Strategies
{
    public class AgedBrie : IItemQualityUpdateStrategy
    {
        public void UpdateQuality(Item item)
        {
            item.SellIn--;

            item.IncreaseQuality();

            if (item.SellIn < 0)
            {
                item.IncreaseQuality();
            }
        }
    }
}