using AutoMapper;
using DHL.Server.Models.DTO;
using DHL.Server.Models.Entities;

namespace DHL.Server.Models.Profiles
{
    /// <summary>
    /// Konfigurace mapování Entity -> DTO.
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LocationEntity, Location>();
            CreateMap<DispatchTypeEntity, DispatchType>();
            CreateMap<DispatchKeyEntity, DispatchKey>();
        }
    }
}
