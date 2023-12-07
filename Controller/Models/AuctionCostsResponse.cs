namespace Api.Models
{
    public class AuctionCostsResponse
    {
        public decimal BasicUserFee { get; set; }
        public decimal SellersSpecialFee { get; set; }
        public decimal AssociationFee { get; set; }
        public decimal StorageFee { get; set; }

        public decimal TotalCost { get; set; }

    }
}
