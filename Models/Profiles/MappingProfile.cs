using AutoMapper;
using DHL.Server.Features.Ciselniky.Models;
using DHL.Server.Features.Dispatching.Models;
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
            CreateMap<LocationEntity, LocationDto>();
            CreateMap<DispatchTypeEntity, DispatchType>();
            CreateMap<DispatchKeyEntity, DispatchKey>();
            CreateMap<DispatchModelEntity, DispatchModelDto>().ReverseMap();
            CreateMap<DispatchKey, DispatchKeyDto>().ReverseMap();
            CreateMap<DispatchType, DispatchTypeDto>().ReverseMap();
            CreateMap<KurzEntity, KurzDto>().ReverseMap();
            CreateMap<MimKurzEntity, MimKurzDto>().ReverseMap();
            CreateMap<VykonStrojEntity, VykonStrojDto>().ReverseMap();
            CreateMap<RegionalReportEntity, RegionalReportDto>().ReverseMap();
            CreateMap<ZbytekEntity, ZbytekDto>().ReverseMap();
            CreateMap<PrilohyEntity, PrilohyDto>().ReverseMap();
            CreateMap<KurzyPEEntity, KurzyPEDto>().ReverseMap();
            CreateMap<ZatezAPEntity, ZatezAPDto>().ReverseMap();
            CreateMap<ZpozdeniKurzuEntity, ZpozdeniKurzuDto>().ReverseMap();
            CreateMap<PrepravceEntity, PrepravceDto>().ReverseMap();
            CreateMap<ZastavkaEntity, ZastavkaDto>().ReverseMap();
            CreateMap<VozidloEntity, VozidloDto>().ReverseMap();
            CreateMap<PripojVozidloEntity, PripojVozidloDto>().ReverseMap();
            CreateMap<KlicEntity, KlicDto>().ReverseMap();
            CreateMap<LocationEntity, LocationDto>();
            CreateMap<LocationEntity, Location>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

        }
    }
}
