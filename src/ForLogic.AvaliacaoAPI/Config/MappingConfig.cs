using AutoMapper;
using ForLogic.AvaliacaoAPI.Data.ValueObjects;
using ForLogic.AvaliacaoAPI.Model;

namespace ForLogic.AvaliacaoAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<ClienteVO, Cliente>().ReverseMap();
                config.CreateMap<AvaliacaoVO, Avaliacao>().ReverseMap();
                config.CreateMap<CategoriaNotaVO, CategoriaNota>().ReverseMap();
                config.CreateMap<AvaliacaoClienteVO, AvaliacaoCliente>().ReverseMap();                          
            });
            return mappingConfig;
        }
    }
}
