using AutoMapper;
using Stock.Core.Domain;
using Stock.Core.Dto;

namespace Stock.Core.AutoMapper
{
    public class CompanyProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<CompanyDto, Company>();

            CreateMap<Company, CompanyDto>();

            CreateMap<Company, TickerDto>()
                .ForMember(dest => dest.Company, opts => opts.MapFrom(src => src.Name))
                .ForMember(dest => dest.Code, opts => opts.MapFrom(src => src.StockCode));
        }
    }
}
