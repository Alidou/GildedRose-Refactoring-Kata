namespace GildedRose_Refactoring.Refactoring.Strategies
{
    public class Default : IItemQualityUpdateStrategy
    {
        public void UpdateQuality(Item item)
        {
            item.SellIn--;

            item.DecreaseQuality();

            if (item.SellIn < 0)
            {
                item.DecreaseQuality();
            }
        }
    }
}