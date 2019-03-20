using System.Collections.Generic;
using NUnit.Framework;

namespace GildedRose_Refactoring.Tests
{
    [TestFixture]
    public class BackstagePassesTest
    {
        public const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";

        [Test]
        public void Backstage_passes_increases_in_Quality_as_its_SellIn_value_approaches()
        {
            int initialQuality = 10;
            int initialSellIn = 15;
            int numberOfDays = 2;

            IList<Item> items = new List<Item> { new Item { Name = BackstagePasses, SellIn = initialSellIn, Quality = initialQuality } };
            GildedRose app = new GildedRose(items);
            app.AdvanceTime(numberOfDays);

            Assert.AreEqual(initialQuality + numberOfDays, items[0].Quality);
        }

        [Test]
        public void The_Quality_of_Backstage_passes_is_never_more_than_50()
        {
            int initialQuality = 49;
            int numberOfDays = 5;

            IList<Item> items = new List<Item> { new Item { Name = BackstagePasses, SellIn = 10, Quality = initialQuality } };
            GildedRose app = new GildedRose(items);
            app.AdvanceTime(numberOfDays);

            Assert.IsTrue(items[0].Quality > initialQuality);
            Assert.AreEqual(50, items[0].Quality);
        }

        [Test]
        public void Backstage_passes_increases_in_Quality_by_2_when_SellIn_between_5_and_10()
        {
            int initialQuality = 10;
            int initialSellIn = 9;
            int numberOfDays = 3;

            IList<Item> items = new List<Item> { new Item { Name = BackstagePasses, SellIn = initialSellIn, Quality = initialQuality } };
            GildedRose app = new GildedRose(items);
            app.AdvanceTime(numberOfDays);

            var qualityIncrease = initialQuality + (numberOfDays * 2);

            Assert.AreEqual(qualityIncrease, items[0].Quality);
        }

        [Test]
        public void Backstage_passes_increases_in_Quality_by_3_when_SellIn_between_0_and_5()
        {
            int initialQuality = 10;
            int initialSellIn = 3;
            int numberOfDays = 2;

            IList<Item> items = new List<Item> { new Item { Name = BackstagePasses, SellIn = initialSellIn, Quality = initialQuality } };
            GildedRose app = new GildedRose(items);
            app.AdvanceTime(numberOfDays);

            var qualityIncrease = initialQuality + (numberOfDays * 3);

            Assert.AreEqual(qualityIncrease, items[0].Quality);
        }

        [Test]
        public void Backstage_passes_Quality_drops_to_0_after_concert()
        {
            int initialQuality = 10;
            int initialSellIn = 1;
            int numberOfDays = 2;

            IList<Item> items = new List<Item> { new Item { Name = BackstagePasses, SellIn = initialSellIn, Quality = initialQuality } };
            GildedRose app = new GildedRose(items);
            app.AdvanceTime(numberOfDays);

            Assert.AreEqual(0, items[0].Quality);
        }
    }
}