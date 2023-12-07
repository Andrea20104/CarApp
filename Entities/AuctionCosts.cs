using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class AuctionCosts
    {
        public decimal BasicUserFee { get; set; }
        public decimal SellersSpecialFee { get; set; }
        public decimal AssociationFee { get; set; }
        public decimal StorageFee { get; set; }

        public decimal TotalCost { get; set; }
    }
}
