using Api.Models;
using AutoMapper;
using Entities;

namespace Api.Mapping
{

    /// <summary>
    /// Mapping Profile.
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile"/> class.
        /// </summary>
        public MappingProfile()
        {
            CreateMap<VehicleRequest, Vehicle>().ReverseMap();
            CreateMap<AuctionCosts, AuctionCostsResponse>().ReverseMap();
        }
    }
}
