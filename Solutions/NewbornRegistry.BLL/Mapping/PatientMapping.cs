using AutoMapper;
using NewbornRegistry.BLL.Models.Create;
using NewbornRegistry.BLL.Models.Get;
using NewbornRegistry.BLL.Models.Update;
using NewbornRegistry.DAL.Entities;

namespace NewbornRegistry.BLL.Mapping;

public class PatientMapping : Profile
{
    public PatientMapping()
    {
        CreateMap<PatientModel, Patient>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Name.Id))
            .ForMember(dest => dest.Use, opt => opt.MapFrom(src => src.Name.Use))
            .ForMember(dest => dest.Family, opt => opt.MapFrom(src => src.Name.Family))
            .ForMember(dest => dest.Given, opt => opt.MapFrom(src => src.Name.Given))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
            .ReverseMap();

        CreateMap<CreatePatientModel, Patient>()
            .ForMember(dest => dest.Use, opt => opt.MapFrom(src => src.Name.Use))
            .ForMember(dest => dest.Family, opt => opt.MapFrom(src => src.Name.Family))
            .ForMember(dest => dest.Given, opt => opt.MapFrom(src => src.Name.Given))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
            .ReverseMap();

        CreateMap<UpdatePatientModel, Patient>()
            .ForMember(dest => dest.Use, opt => opt.MapFrom(src => src.Name.Use))
            .ForMember(dest => dest.Family, opt => opt.MapFrom(src => src.Name.Family))
            .ForMember(dest => dest.Given, opt => opt.MapFrom(src => src.Name.Given))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
            .ReverseMap();

    }
}