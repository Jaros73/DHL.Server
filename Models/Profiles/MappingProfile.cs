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
            CreateMap<CourseEntity, CourseDto>().ReverseMap();
            CreateMap<IrregularCourseEntity, IrregularCourseDto>().ReverseMap();
            CreateMap<MachiningEntity, MachiningDto>().ReverseMap();
            CreateMap<RegionalReportEntity, RegionalReportDto>().ReverseMap();
            CreateMap<RemainderEntity, RemainderDto>().ReverseMap();
            CreateMap<AttachmentEntity, AttachmentDto>().ReverseMap();
            CreateMap<KurzyPEEntity, KurzyPEDto>().ReverseMap();
            CreateMap<ZatezAPEntity, ZatezAPDto>().ReverseMap();
            CreateMap<CourseDelayReasonEntity, CourseDelayReasonDto>().ReverseMap();
            CreateMap<TransporterEntity, TransporterDto>().ReverseMap();
            CreateMap<StopEntity, StopDto>().ReverseMap();
            CreateMap<VehicleEntity, VehicleDto>().ReverseMap();
            CreateMap<TrailerEntity, TrailerDto>().ReverseMap();

        }
    }
}
