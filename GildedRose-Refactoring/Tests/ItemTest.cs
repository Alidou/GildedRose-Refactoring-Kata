using System.Collections.Generic;
using NUnit.Framework;

namespace GildedRose_Refactoring.Tests
{
    [TestFixture]
    public class ItemTest
    {
        [Test]
        public void Quality_degrades_by_1_before_sell_by_date()
        {
            int initialQuality = 10;
            int initialSellIn = 3;
            int numberOfDays = 2;

            IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = initialSellIn, Quality = initialQuality } };
            GildedRose app = new GildedRose(items);

            app.AdvanceTime(numberOfDays);

            Assert.AreEqual(initialQuality - numberOfDays, items[0].Quality);
        }

        [Test]
        public void SellIn_reduce_over_time()
        {
            int initialSellIn = 5;
            int numberOfDays = 10;

            IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = initialSellIn, Quality = 10 } };
            GildedRose app = new GildedRose(items);

            app.AdvanceTime(numberOfDays);

            Assert.AreEqual(initialSellIn - numberOfDays, items[0].SellIn);
        }

        [Test]
        public void Once_sell_by_date_has_passed_Quality_degrades_twice_as_fast()
        {
            int initialQuality = 10;
            int initialSellIn = 1;
            int numberOfDays = 4;

            IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = initialSellIn, Quality = initialQuality } };
            GildedRose app = new GildedRose(items);

            app.AdvanceTime(numberOfDays);

            var normalRateQualityDecrease = initialSellIn;
            var doubleRateQualityDecrease = (numberOfDays - initialSellIn) * 2;
            Assert.AreEqual(initialQuality - (normalRateQualityDecrease + doubleRateQualityDecrease), items[0].Quality);
        }

        [Test]
        public void The_Quality_of_an_item_is_never_negative()
        {
            int numberOfDays = 50;

            IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 1, Quality = 1 } };
            GildedRose app = new GildedRose(items);
            app.AdvanceTime(numberOfDays);

            Assert.IsTrue(items[0].Quality > -1);
        }
    }
}