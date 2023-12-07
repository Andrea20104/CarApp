using AutoMapper;

namespace Api.Mapping
{
    using AutoMapper;

    /// <summary>
    /// Auto Mapper Config.
    /// </summary>
    public class AutoMapperConfig
    {

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        /// <returns>IMapper.</returns>
        public static IMapper Initialize()
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            return mapperConfig.CreateMapper();
        }
    }
}
