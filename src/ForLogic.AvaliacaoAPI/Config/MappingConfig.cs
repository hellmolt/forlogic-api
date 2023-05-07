using AutoMapper;
using ForLogic.ClienteAPI.Data.ValueObjects;
using ForLogic.ClienteAPI.Model;

namespace ForLogic.ClienteAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<AvaliacaoVO, Avaliacao>();
                config.CreateMap<Avaliacao, AvaliacaoVO>();
            });
            return mappingConfig;
        }
    }
}
