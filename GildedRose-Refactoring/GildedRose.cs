using System.Collections.Generic;
using GildedRose_Refactoring.Refactoring;

namespace GildedRose_Refactoring
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                var updateStrategy = ItemQualityUpdateStrategyFactory.Current.GetFor(item);
                updateStrategy.UpdateQuality(item);
            }
        }
    }
}