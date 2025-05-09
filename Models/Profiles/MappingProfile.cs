using AutoMapper;
using DHL.Server.Features.Ciselniky.Models;
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
        }
    }
}
