using AutoMapper;
using InterviewProject.Models;

namespace InterviewProject
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<OrderTaxModel, Taxjar.Tax>()
                .ForMember(t => t.ToStreet, m => m.MapFrom(src => src.ToAddress.Street))
                .ForMember(t => t.ToCity, m => m.MapFrom(src => src.ToAddress.City))
                .ForMember(t => t.ToState, m => m.MapFrom(src => src.ToAddress.State))
                .ForMember(t => t.ToZip, m => m.MapFrom(src => src.ToAddress.Zip))
                .ForMember(t => t.ToCountry, m => m.MapFrom(src => src.ToAddress.Country))
                .ForMember(t => t.FromStreet, m => m.MapFrom(src => src.FromAddress.Street))
                .ForMember(t => t.FromCity, m => m.MapFrom(src => src.FromAddress.City))
                .ForMember(t => t.FromState, m => m.MapFrom(src => src.FromAddress.State))
                .ForMember(t => t.FromZip, m => m.MapFrom(src => src.FromAddress.Zip))
                .ForMember(t => t.FromCountry, m => m.MapFrom(src => src.FromAddress.Country))
                .ForMember(t => t.Shipping, m => m.MapFrom(src => src.ShippingCost))
                .ForMember(t => t.Amount, m => m.MapFrom(src => src.OrderAmount));
        }
    }
}
