using System.Collections.Generic;
using NUnit.Framework;

namespace GildedRose_Refactoring.Tests
{
    [TestFixture]
    public class ConjuredTest
    {
        public const string Conjured = "Conjured Mana Cake";

        [Test]
        public void Quality_degrades_by_2_before_sell_by_date()
        {
            int initialQuality = 10;
            int initialSellIn = 3;
            int numberOfDays = 2;

            IList<Item> items = new List<Item> { new Item { Name = Conjured, SellIn = initialSellIn, Quality = initialQuality } };
            GildedRose app = new GildedRose(items);

            app.AdvanceTime(numberOfDays);

            Assert.AreEqual(initialQuality - (numberOfDays *2), items[0].Quality);
        }
    }
}