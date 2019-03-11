using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LemonadeStand;

namespace UnitTestProject1
{
    
    [TestClass]
    public class StoreTests
    {
        [TestMethod]
        public void RunTotal_AuthorizedTransaction_ProperTotal()
        {
            //Arrange
            Store store = new Store();
            int ItemNum = 1;
            int ItemQuantity = 10;
            double expected = 2.50;
            double actual;
            //Act
            actual = store.RunTotal(ItemNum, ItemQuantity);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RunTotal_UnauthorizedItemNum_NoCost()
        {
            //Arrange
            Store store = new Store();
            int ItemNum = 9;
            int ItemQuantity = 10;
            double expected = 0.00;
            double actual;
            //Act
            actual = store.RunTotal(ItemNum, ItemQuantity);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RunTotal_NegativeItemQuantity_NoCost()
        {
            //Arrange
            Store store = new Store();
            int ItemNum = 1;
            int ItemQuantity = -10;
            double expected = 0.00;
            double actual;
            //Act
            actual = store.RunTotal(ItemNum, ItemQuantity);
            //Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
