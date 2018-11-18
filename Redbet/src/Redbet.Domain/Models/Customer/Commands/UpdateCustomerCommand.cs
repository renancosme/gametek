using System;

namespace Redbet.Domain.Models.Customer.Commands
{
    public class UpdateCustomerCommand : BaseCustomerCommand
    {
        public UpdateCustomerCommand(Guid id, string firstName, string lastName, string address, string favoriteFootballTeam)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            FavoriteFootballTeam = favoriteFootballTeam;
        }
    }
}
