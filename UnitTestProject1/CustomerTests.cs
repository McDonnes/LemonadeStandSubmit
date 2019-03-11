using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LemonadeStand;

namespace UnitTestProject1
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void GenerateTolerances_AuthorizedParams_CorrectTolerance()
        {
            //Arrange
            Customer testCustomer = new Customer(.4);
            bool Precipitation = true;
            int Temperature = 70;
            double expected = .18;
            double actual;
            //Act
            testCustomer.GenerateTolerances(Temperature, Precipitation);
            actual = testCustomer.Tolerance;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GenerateTolerances_ExtremeHighTemperature_CorrectTolerance()
        {
            //Arrange
            Customer testCustomer = new Customer(.4);
            bool Precipitation = true;
            int Temperature = 7000;
            double expected = .23;
            double actual;
            //Act
            testCustomer.GenerateTolerances(Temperature, Precipitation);
            actual = testCustomer.Tolerance;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GenerateTolerances_ExtremeLowTemperature_CorrectTolerance()
        {
            //Arrange
            Customer testCustomer = new Customer(.4);
            bool Precipitation = true;
            int Temperature = -7000;
            double expected = .01;
            double actual;
            //Act
            testCustomer.GenerateTolerances(Temperature, Precipitation);
            actual = testCustomer.Tolerance;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void WillBuy_HighPriceGoodMoodGoodWeather_False()
        {
            //Arrange
            Customer testCustomer = new Customer(.4);
            bool Precipitation = false;
            int Temperature = 91;
            double Price = 1.50;
            testCustomer.GenerateTolerances(Temperature, Precipitation);
            bool expected = false;
            bool actual;
            //Act
            actual = testCustomer.WillBuy(Price);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void WillBuy_LowPriceGoodMoodGoodWeather_True()
        {
            //Arrange
            Customer testCustomer = new Customer(.4);
            bool Precipitation = false;
            int Temperature = 91;
            double Price = .05;
            testCustomer.GenerateTolerances(Temperature, Precipitation);
            bool expected = true;
            bool actual;
            //Act
            actual = testCustomer.WillBuy(Price);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void WillBuy_AvgPriceBadMoodGoodWeather_False()
        {
            //Arrange
            Customer testCustomer = new Customer(.2);
            bool Precipitation = false;
            int Temperature = 91;
            double Price = .15;
            testCustomer.GenerateTolerances(Temperature, Precipitation);
            bool expected = false;
            bool actual;
            //Act
            actual = testCustomer.WillBuy(Price);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void WillBuy_AvgPriceGoodMoodBadWeather_False()
        {
            //Arrange
            Customer testCustomer = new Customer(.4);
            bool Precipitation = true;
            int Temperature = 5;
            double Price = .10;
            testCustomer.GenerateTolerances(Temperature, Precipitation);
            bool expected = false;
            bool actual;
            //Act
            actual = testCustomer.WillBuy(Price);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void WillBuy_AvgPriceAvgMoodAvgWeather_True()
        {
            //Arrange
            Customer testCustomer = new Customer(.31);
            bool Precipitation = false;
            int Temperature = 11;
            double Price = .09;
            testCustomer.GenerateTolerances(Temperature, Precipitation);
            bool expected = true;
            bool actual;
            //Act
            actual = testCustomer.WillBuy(Price);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void WillBuy_AvgPriceAvgMoodAvgWeatherWithPrecipitation_False()
        {
            //Arrange
            Customer testCustomer = new Customer(.31);
            bool Precipitation = true;
            int Temperature = 11;
            double Price = .09;
            testCustomer.GenerateTolerances(Temperature, Precipitation);
            bool expected = false;
            bool actual;
            //Act
            actual = testCustomer.WillBuy(Price);
            //Assert
            Assert.AreEqual(expected, actual);
        }


    }
}
