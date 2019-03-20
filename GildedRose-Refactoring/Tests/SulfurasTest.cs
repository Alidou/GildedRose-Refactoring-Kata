using System.Collections.Generic;
using NUnit.Framework;

namespace GildedRose_Refactoring.Tests
{
    [TestFixture]
    public class SulfurasTest
    {
        public const string Sulfuras = "Sulfuras, Hand of Ragnaros";

        [Test]
        public void Sulfuras_never_has_to_be_sold()
        {
            int initialSellIn = 10;
            int numberOfDays = 50;

            IList<Item> items = new List<Item> { new Item { Name = Sulfuras, SellIn = initialSellIn, Quality = 80 } };
            GildedRose app = new GildedRose(items);
            app.AdvanceTime(numberOfDays);

            Assert.AreEqual(initialSellIn, items[0].SellIn);
        }

        [Test]
        public void Sulfuras_never_decreases_in_Quality()
        {
            int initialQuality = 80;
            int numberOfDays = 50;

            IList<Item> items = new List<Item> { new Item { Name = Sulfuras, SellIn = 10, Quality = initialQuality } };
            GildedRose app = new GildedRose(items);
            app.AdvanceTime(numberOfDays);

            Assert.AreEqual(initialQuality, items[0].Quality);
        }
    }
}