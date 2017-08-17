using AutoMapper;
using Tools.Core.Domain;
using Tools.Infrastructure.DTO;

namespace Tools.Infrastructure.Mappers
{
    public class AutoMapperConfig
    {
        /// <summary>
        /// Using automap creating a map from Tool object to ToolDto object
        /// </summary>
        /// <returns></returns>
        public static IMapper InitMapper() =>
            new MapperConfiguration(cfg =>
                {
                    //add here another mappers
                    cfg.CreateMap<Tool, ToolDetailsDto>();
                    cfg.CreateMap<Tool, ToolDto>();
                }
            ).CreateMapper();
    }
}