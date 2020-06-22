using AutoMapper;
using QuotationCore.API.Dtos;
using QuotationCore.Domain;

namespace QuotationCore.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Quotation,QuotationDto>().ReverseMap(); 
            CreateMap<Item, ItemDto>().ReverseMap();
            CreateMap<Validation, ValidationDto>().ReverseMap();
        }
        
    }
}