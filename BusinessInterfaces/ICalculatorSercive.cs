using Business.Interfaces.Services;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ICalculatorSercive : IService
    {
        AuctionCosts CalculateTotalCost(Vehicle vehicle);
    }
}
