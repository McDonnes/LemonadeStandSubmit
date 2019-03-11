using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LemonadeStand;

namespace UnitTestProject1
{
    [TestClass]
    public class InventoryTests
    {
        [TestMethod]
        public void Restock_Add3Lemons_ItemIncrement()
        {
            //Arrange
            Inventory inventory = new Inventory();
            int NumberOfItemsToAdd = 3;
            inventory.Restock(0, NumberOfItemsToAdd);
            int expected = 3;
            int actual;
            //Act
            actual = inventory.GetLemons();
            //Assert
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void Restock_Add6Cups_ItemIncrement()
        {
            //Arrange
            Inventory inventory = new Inventory();
            int NumberOfItemsToAdd = 6;
            inventory.Restock(2, NumberOfItemsToAdd);
            int expected = 6;
            int actual;
            //Act
            actual = inventory.GetCups();
            //Assert
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void Restock_AddNegativeSugar_NoItemIncrement()
        {
            //Arrange
            Inventory inventory = new Inventory();
            int NumberOfItemsToAdd = -3;
            inventory.Restock(1, NumberOfItemsToAdd);
            int expected = 0;
            int actual;
            //Act
            actual = inventory.GetSugar();
            //Assert
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void TakeItems_AuthorizedItemType_ProperItemDecrement()
        {
            //Arrange
            Inventory inventory = new Inventory();
            int NumberOfItemsToTake = 3;
            inventory.Restock(0, 10);
            int expected = 7;
            int actual; 
            //Act
            inventory.TakeItems(1, NumberOfItemsToTake);
            actual = inventory.GetLemons();
            //Assert
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void TakeItems_AuthorizedTakeItem_True()
        {
            //Arrange
            Inventory inventory = new Inventory();
            int NumberOfItemsToTake = 3;
            inventory.Restock(0, 10);
            bool expected = true;
            bool actual;
            //Act
            actual = inventory.TakeItems(1, NumberOfItemsToTake);
            //Assert
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void TakeItems_UnauthorizedTakeItem_False()
        {
            //Arrange
            Inventory inventory = new Inventory();
            int NumberOfItemsToTake = 11;
            inventory.Restock(1, 10);
            bool expected = false;
            bool actual;
            //Act
            actual = inventory.TakeItems(1, NumberOfItemsToTake);
            //Assert
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void TakeItems_UnauthorizedItemType_NoItemDecrement()
        {
            //Arrange
            Inventory inventory = new Inventory();
            int NumberOfItemsToTake = 3;
            inventory.Restock(0, 10);
            int expected = 10;
            int actual;
            //Act
            inventory.TakeItems(6, NumberOfItemsToTake);
            actual = inventory.GetLemons();
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TakeItems_ItemAmountZero_NoItemDecrement()
        {
            //Arrange
            Inventory inventory = new Inventory();
            int NumberOfItemsToTake = 0;
            inventory.Restock(0, 10);
            int expected = 10;
            int actual;
            //Act
            inventory.TakeItems(1, NumberOfItemsToTake);
            actual = inventory.GetLemons();
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TakeItems_ItemAmountNegative_NoItemDecrement()
        {
            //Arrange
            Inventory inventory = new Inventory();
            int NumberOfItemsToTake = -3;
            inventory.Restock(0, 10);
            int expected = 10;
            int actual;
            //Act
            inventory.TakeItems(1, NumberOfItemsToTake);
            actual = inventory.GetLemons();
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TakeItems_NotEnoughItems_NoItemDecrement()
        {
            //Arrange
            Inventory inventory = new Inventory();
            int NumberOfItemsToTake = 14;
            inventory.Restock(0, 10);
            int expected = 10;
            int actual;
            //Act
            inventory.TakeItems(1, NumberOfItemsToTake);
            actual = inventory.GetLemons();
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IceMelted_Runs_IceAmountIsZero()
        {
            //Arrange
            Inventory inventory = new Inventory();
            inventory.Restock(3, 10);
            int expected = 0;
            int actual;
            //Act
            inventory.IceMelted();
            actual = inventory.GetIce();
            //Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
