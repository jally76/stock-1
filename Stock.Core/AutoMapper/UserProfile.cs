using AutoMapper;
using Stock.Core.Domain;
using Stock.Core.Dto;

namespace Stock.Core.AutoMapper
{
    public class UserProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<UserDto, User>()
                .ConstructProjectionUsing(str => new User())
                .ForMember(dest => dest.Password, opts => opts.Ignore())
                .ForMember(dest => dest.Salt, opts => opts.Ignore())
                .ForMember(dest => dest.Tickers, opts => opts.Ignore());

            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Tickers, opts => opts.MapFrom(src => src.Tickers))
                .ForMember(dest => dest.Password, opts => opts.MapFrom(src => ""));
        }
    }
}
