using System.Collections.Generic;
using NUnit.Framework;

namespace GildedRose
{
    [TestFixture]
    public class TestDouble_Fake
    {
        private readonly string _generic = "generic";
        private readonly string _aged_brie = "Aged Brie";
        private readonly string _backstage_pass = "Backstage passes to a TAFKAL80ETC concert";
        private readonly string _legendary_sulfuras = "Sulfuras, Hand of Ragnaros";
        
        private readonly int _legendary_item_quality = 80;

        [Test]
        public void SellIn_Decreases_GenericItem()
        {
            // Arrange
            IList<Item> items = stockOneOfEachItem();
            GildedRose sut = new GildedRose(items);
            
            // Act
            sut.UpdateQuality();
            
            // Assert
            Assert.AreEqual(9, items[0].SellIn);
        }

        [Test]
        public void LegendaryItem_QualityDoesNotChange()
        {
            // Arrange
            IList<Item> items = stockOneOfEachItem();
            GildedRose sut = new GildedRose(items);
            
            // Act
            sut.UpdateQuality();
            
            // Assert
            Assert.AreEqual(80, items[5].Quality);
        }

        private IList<Item> stockOneOfEachItem()
        {
            List<Item> oneOfEachType = new List<Item>();
            oneOfEachType.Add(new Item { Name = _generic, SellIn = 10, Quality = 20 });
            oneOfEachType.Add(new Item { Name = _aged_brie, SellIn = 5, Quality = 10 });
            oneOfEachType.Add(new Item { Name = _backstage_pass, SellIn = 20, Quality = 7 });
            oneOfEachType.Add(new Item { Name = _backstage_pass, SellIn = 3, Quality = 15 });
            oneOfEachType.Add(new Item { Name = _backstage_pass, SellIn = -1, Quality = 0 });
            oneOfEachType.Add(new Item { Name = _legendary_sulfuras, SellIn = 25, Quality = _legendary_item_quality });
            return oneOfEachType;
        }
    }
}