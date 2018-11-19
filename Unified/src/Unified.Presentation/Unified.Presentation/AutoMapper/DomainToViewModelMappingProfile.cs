using AutoMapper;
using Unified.Domain.Model;
using Unified.Presentation.ViewModels;

namespace Unified.Presentation.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, MrgreenCustomerViewModel>();
        }
    }
}