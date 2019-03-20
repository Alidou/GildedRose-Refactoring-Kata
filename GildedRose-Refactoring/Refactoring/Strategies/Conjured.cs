namespace GildedRose_Refactoring.Refactoring.Strategies
{
    public class Conjured : IItemQualityUpdateStrategy
    {
        public void UpdateQuality(Item item)
        {
            item.SellIn--;

            item.DecreaseQuality(2);

            if (item.SellIn < 0)
            {
                item.DecreaseQuality(2);
            }
        }
    }
}