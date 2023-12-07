using Api.Models;
using AutoMapper;
using Business.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly ICalculatorService _calculatorService;
        private readonly IMapper _mapper;

        public VehicleController(ICalculatorService calculatorService, IMapper mapper)
        {
            _calculatorService = calculatorService;
            _mapper = mapper;
        }

        [HttpPost("calculateTotalCost")]
        public IActionResult CalculateTotalCost([FromBody] VehicleRequest vehicleRequest)
        {
            if (vehicleRequest == null)
            {
                return BadRequest("Invalid vehicle data.");
            }
            Vehicle vehicle = _mapper.Map<Vehicle>(vehicleRequest);
            AuctionCosts totalCost = _calculatorService.CalculateTotalCost(vehicle);
            AuctionCostsResponse totalCostResponse = _mapper.Map<AuctionCostsResponse>(totalCost);
            return Ok(totalCostResponse);
        }
    }
}