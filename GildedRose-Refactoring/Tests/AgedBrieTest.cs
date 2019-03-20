using System.Collections.Generic;
using NUnit.Framework;

namespace GildedRose_Refactoring.Tests
{
    [TestFixture]
    public class AgedBrieTest
    {
        public const string AgedBrie = "Aged Brie";

        [Test]
        public void Aged_Brie_increases_in_Quality_the_older_it_gets()
        {
            int initialQuality = 1;
            int numberOfDays = 4;

            IList<Item> items = new List<Item> { new Item { Name = AgedBrie, SellIn = 10, Quality = initialQuality } };
            GildedRose app = new GildedRose(items);
            app.AdvanceTime(numberOfDays);

            Assert.IsTrue(items[0].Quality > initialQuality);
            Assert.AreEqual(initialQuality + numberOfDays, items[0].Quality);
        }

        [Test]
        public void The_Quality_of_Aged_Brie_is_never_more_than_50()
        {
            int initialQuality = 1;
            int numberOfDays = 50;

            IList<Item> items = new List<Item> { new Item { Name = AgedBrie, SellIn = 10, Quality = initialQuality } };
            GildedRose app = new GildedRose(items);
            app.AdvanceTime(numberOfDays);

            Assert.IsTrue(items[0].Quality > initialQuality);
            Assert.AreEqual(50, items[0].Quality);
        }
    }
}