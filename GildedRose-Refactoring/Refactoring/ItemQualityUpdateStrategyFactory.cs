using System;
using System.Collections.Generic;
using GildedRose_Refactoring.Refactoring.Strategies;

namespace GildedRose_Refactoring.Refactoring
{
    public sealed class ItemQualityUpdateStrategyFactory
    {
        private static readonly Lazy<ItemQualityUpdateStrategyFactory> Lazy = new Lazy<ItemQualityUpdateStrategyFactory>(() => new ItemQualityUpdateStrategyFactory());
        public static ItemQualityUpdateStrategyFactory Current => Lazy.Value;
        public IDictionary<string, IItemQualityUpdateStrategy> Strategies { get; set; }

        private ItemQualityUpdateStrategyFactory()
        {
            Strategies = new Dictionary<string, IItemQualityUpdateStrategy>
            {
                { "Backstage passes to a TAFKAL80ETC concert", new BackstagePasses() }, 
                { "Sulfuras, Hand of Ragnaros", new DoNothing() },
                { "Aged Brie", new AgedBrie() }, 
                { "Conjured Mana Cake", new Conjured() }
            };
        }

        private static readonly Lazy<IItemQualityUpdateStrategy> Default = new Lazy<IItemQualityUpdateStrategy>(() => new Default());
        public IItemQualityUpdateStrategy GetFor(Item item)
        {
            IItemQualityUpdateStrategy strategy = Strategies.ContainsKey(item.Name) ? Strategies[item.Name] : Default.Value;
            return strategy;
        }
    }
}