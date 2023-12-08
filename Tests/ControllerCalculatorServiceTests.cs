using Api.Models;
using AutoMapper;
using Business.Interfaces;
using Controller.Controllers;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class ControllerCalculatorServiceTests
    {
        [TestMethod]
        public void CalculateTotalCost_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var calculatorServiceMock = new Mock<ICalculatorSercive>();
            var mapperMock = new Mock<IMapper>();

            var controller = new VehicleController(calculatorServiceMock.Object, mapperMock.Object);

            var vehicleRequest = new VehicleRequest(398,"Common");

            var vehicle = new Vehicle
            {
                BasePrice = 398,
                VehicleType = "Common"
            };

            var auctionCosts = new AuctionCosts
            {
                BasicUserFee = 100,
                AssociationFee = 10,
                SellersSpecialFee = 30,
                StorageFee = 10,
                TotalCost = 500
            };

            var auctionCostsResponse = new AuctionCostsResponse
            {
                BasicUserFee = 100,
                AssociationFee = 10,
                SellersSpecialFee = 30,
                StorageFee = 10,
                TotalCost = 500
            };

            mapperMock.Setup(m => m.Map<Vehicle>(It.IsAny<VehicleRequest>())).Returns(vehicle);
            calculatorServiceMock.Setup(c => c.CalculateTotalCost(It.IsAny<Vehicle>())).Returns(auctionCosts);
            mapperMock.Setup(m => m.Map<AuctionCostsResponse>(It.IsAny<AuctionCosts>())).Returns(auctionCostsResponse);

            // Act
            var result = controller.CalculateTotalCost(vehicleRequest);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = (OkObjectResult)result;
            Assert.IsInstanceOfType(okResult.Value, typeof(AuctionCostsResponse));
            var resultValue = (AuctionCostsResponse)okResult.Value!;

            Assert.IsNotNull(resultValue);
        }

        [TestMethod]
        public void CalculateTotalCost_InvalidRequest_ReturnsBadRequest()
        {
            // Arrange
            var calculatorServiceMock = new Mock<ICalculatorSercive>();
            var mapperMock = new Mock<IMapper>();

            var controller = new VehicleController(calculatorServiceMock.Object, mapperMock.Object);

            // Act
            var result = controller.CalculateTotalCost(null!);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            var badRequestResult = (BadRequestObjectResult)result;
            Assert.AreEqual("Invalid vehicle data.", badRequestResult.Value);
        }
    }
}
