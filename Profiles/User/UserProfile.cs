using AutoMapper;

namespace ShippeeAPI.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, RecruiterFavoriteDto>()
            .ForMember(
                dest => dest.id,
                opt => opt.MapFrom(x => $"{x.id}")
            )
            .ForMember(
                 dest => dest.surname,
                opt => opt.MapFrom(x =>  $"{x.surname}")
            )
            .ForMember(
                 dest => dest.firstname,
                opt => opt.MapFrom(x =>  $"{x.firstname}")
            )
            .ForMember(
                 dest => dest.email,
                opt => opt.MapFrom(x =>  $"{x.email}")
            )
            .ForMember(
                 dest => dest.picture,
                opt => opt.MapFrom(x =>  $"{x.picture}")
            )
            .ForMember(
                 dest => dest.is_online,
                opt => opt.MapFrom(x =>  $"{x.is_online}")
            );

        CreateMap<User, StudentFavoriteDto>()
            .ForMember(
                dest => dest.id,
                opt => opt.MapFrom(x => $"{x.id}")
            )
            .ForMember(
                 dest => dest.surname,
                opt => opt.MapFrom(x =>  $"{x.surname}")
            )
            .ForMember(
                 dest => dest.firstname,
                opt => opt.MapFrom(x =>  $"{x.firstname}")
            )
            .ForMember(
                 dest => dest.email,
                opt => opt.MapFrom(x =>  $"{x.email}")
            )
            .ForMember(
                 dest => dest.picture,
                opt => opt.MapFrom(x =>  $"{x.picture}")
            )
            .ForMember(
                 dest => dest.is_online,
                opt => opt.MapFrom(x =>  $"{x.is_online}")
            );
    }
}