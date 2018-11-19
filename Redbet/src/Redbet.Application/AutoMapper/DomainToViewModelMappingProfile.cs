using AutoMapper;
using Redbet.Application.ViewModels;
using Redbet.Domain.Models.Customers;

namespace Redbet.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
        }
    }
}
