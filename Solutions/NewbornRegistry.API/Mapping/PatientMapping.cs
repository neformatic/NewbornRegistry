using AutoMapper;
using Microsoft.OpenApi.Extensions;
using NewbornRegistry.API.ViewModels.Create;
using NewbornRegistry.API.ViewModels.Get;
using NewbornRegistry.API.ViewModels.Update;
using NewbornRegistry.BLL.Models.Create;
using NewbornRegistry.BLL.Models.Get;
using NewbornRegistry.BLL.Models.Update;

namespace NewbornRegistry.API.Mapping;

public class PatientMapping : Profile
{
    public PatientMapping()
    {
        CreateMap<PatientViewModel, PatientModel>();

        CreateMap<PatientModel, PatientViewModel>()
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.GetDisplayName()));

        CreateMap<NameViewModel, NameModel>().ReverseMap();

        CreateMap<CreatePatientViewModel, CreatePatientModel>().ReverseMap();
        CreateMap<CreateNameViewModel, CreateNameModel>().ReverseMap();

        CreateMap<UpdatePatientViewModel, UpdatePatientModel>().ReverseMap();
        CreateMap<UpdateNameViewModel, UpdateNameModel>().ReverseMap();
    }
}