namespace Api.Models
{
    public class VehicleRequest
    {
        public VehicleRequest(decimal basePrice, string vehicleType)
        {
            BasePrice = basePrice;
            VehicleType = vehicleType;
        }

        public decimal BasePrice { get; }
        public string VehicleType { get; }
    }
}
