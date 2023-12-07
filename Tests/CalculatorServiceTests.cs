using Business;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CalculatorServiceTests
    {
        [TestMethod]
        public void CalculateTotalCost_ShouldCalculateCorrectTotalCost()
        {
            // Arrange
            var vehicle = new Vehicle { BasePrice = 1000m, VehicleType = "Common" };
            var calculatorService = new CalculatorService();

            // Act
            var totalCost = calculatorService.CalculateTotalCost(vehicle);

            // Assert
            Assert.AreEqual(1180m, totalCost);
        }

        public void CalculateTotalCost_ShouldCalculateCorrectTotalCost(decimal basePrice, string vehicleType, decimal expectedTotalCost)
        {
            // Arrange
            var vehicle = new Vehicle { BasePrice = basePrice, VehicleType = vehicleType };
            var calculatorService = new CalculatorService();

            // Act
            var totalCost = calculatorService.CalculateTotalCost(vehicle);

            // Assert
            Assert.AreEqual(expectedTotalCost, totalCost);
        }

        [TestMethod]
        public void CalculateTotalCost_ShouldThrowArgumentNullException_WhenVehicleIsNull()
        {
            // Arrange
            var calculatorService = new CalculatorService();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => calculatorService.CalculateTotalCost(null));
        }
    }
}