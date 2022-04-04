namespace Mango.Services.ProductAPI
{
    using AutoMapper;

    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Dto.Product, Models.Product>();
                config.CreateMap<Models.Product, Dto.Product>();
            });

            return mappingConfig;
        }
    }
}
