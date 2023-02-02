using AutoMapper;

namespace ShippeeAPI.Profiles;

public class CompanyProfile : Profile
{
    public CompanyProfile()
    {
        CreateMap<Company, CompanyDto>()
            .ForMember(
                dest => dest.siren,
                opt => opt.MapFrom(x => $"{x.siren}")
            )
            .ForMember(
                 dest => dest.name,
                opt => opt.MapFrom(x =>  $"{x.name}")
            );
    }
}