using AutoMapper;
using Redbet.Application.ViewModels;
using Redbet.Domain.Models.Customers.Commands;

namespace Redbet.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CustomerViewModel, AddCustomerCommand>()
                .ConstructUsing(c => new AddCustomerCommand(c.FirstName, c.LastName, c.Address, c.FavoriteFootballTeam));

            CreateMap<CustomerViewModel, UpdateCustomerCommand>()
                .ConstructUsing(c => new UpdateCustomerCommand(c.Id, c.FirstName, c.LastName, c.Address, c.FavoriteFootballTeam));

            CreateMap<CustomerViewModel, DeleteCustomerCommand>()
                .ConstructUsing(c => new DeleteCustomerCommand(c.Id));
        }
    }
}
