using System.Collections.Generic;
using NUnit.Framework;

namespace GildedRose
{
    [TestFixture]
    public class TestDouble_Dummy
    {
        private readonly string _ignoredString = null;
        private readonly int _ignoredInt = -99;

        /*
          This test will fail if the item name is null.
          The behavior being tested does not interact with the item name but requires a non-null, non-special name.
        */
        [Test]
        public void SellIn_Decreases_GenericItem()
        {
            // Arrange
            IList<Item> items = new List<Item> { new Item { Name = _ignoredString, SellIn = 10, Quality = _ignoredInt } };
            GildedRose sut = new GildedRose(items);
            
            // Act
            sut.UpdateQuality();
            
            // Assert
            Assert.AreEqual(9, items[0].SellIn);
        }

    }
}