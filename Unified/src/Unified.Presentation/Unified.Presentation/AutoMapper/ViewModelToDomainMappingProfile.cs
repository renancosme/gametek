using AutoMapper;
using Unified.Domain.Model;
using Unified.Presentation.ViewModels;

namespace Unified.Presentation.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<Customer, MrgreenCustomerViewModel>();
        }
    }
}