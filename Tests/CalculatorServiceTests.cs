using Business;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CalculatorServiceTests
    {
        [TestMethod]
        public void CalculateTotalCost_ValidVehicleCommon_ReturnsAuctionCosts()
        {
            // Arrange
            var vehicle = new Vehicle
            {
                VehicleType = "Common",
                BasePrice = 398m
            };

            var calculatorService = calculatorServiceTest();

            // Act
            var result = calculatorService.CalculateTotalCost(vehicle);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(550.76m, result.TotalCost);
        }

        [TestMethod]
        public void CalculateTotalCost_ValidVehicleCommonTest2_ReturnsAuctionCosts()
        {
            // Arrange
            var vehicle = new Vehicle
            {
                VehicleType = "Common",
                BasePrice = 501m
            };

            var calculatorService = calculatorServiceTest();

            // Act
            var result = calculatorService.CalculateTotalCost(vehicle);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(671.02m, result.TotalCost);
        }

        [TestMethod]
        public void CalculateTotalCost_ValidVehicleCommonTest3_ReturnsAuctionCosts()
        {
            // Arrange
            var vehicle = new Vehicle
            {
                VehicleType = "Common",
                BasePrice = 57m
            };

            var calculatorService = calculatorServiceTest();

            // Act
            var result = calculatorService.CalculateTotalCost(vehicle);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(173.14m, result.TotalCost);
        }

        [TestMethod]
        public void CalculateTotalCost_ValidVehicleLuxury_ReturnsAuctionCosts()
        {
            // Arrange
            var vehicle = new Vehicle
            {
                VehicleType = "Luxury",
                BasePrice = 1800 // 
            };

            var calculatorService = calculatorServiceTest();

            // Act
            var result = calculatorService.CalculateTotalCost(vehicle);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2167m, result.TotalCost);
        }

        [TestMethod]
        public void CalculateTotalCost_ValidVehicleLuxuryTest2_ReturnsAuctionCosts()
        {
            // Arrange
            var vehicle = new Vehicle
            {
                VehicleType = "Luxury",
                BasePrice = 1000000 // 
            };

            var calculatorService = calculatorServiceTest();

            // Act
            var result = calculatorService.CalculateTotalCost(vehicle);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1040320m, result.TotalCost);
        }

        public CalculatorService calculatorServiceTest()
        {
            return new CalculatorService();
        }
    }
}