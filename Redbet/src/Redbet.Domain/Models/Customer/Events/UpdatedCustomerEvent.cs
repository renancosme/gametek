using System;

namespace Redbet.Domain.Models.Customer.Events
{
    public class UpdatedCustomerEvent : BaseCustomerEvent
    {
        public UpdatedCustomerEvent(Guid id, string firstName, string lastName, string address, string favoriteFootballTeam)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            FavoriteFootballTeam = favoriteFootballTeam;
            AggregateId = id;
        }
    }
}
