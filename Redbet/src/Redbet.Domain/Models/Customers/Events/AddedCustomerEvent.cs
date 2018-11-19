using System;

namespace Redbet.Domain.Models.Customers.Events
{
    public class AddedCustomerEvent : BaseCustomerEvent
    {
        public AddedCustomerEvent(Guid id, string firstName, string lastName, string address, string favoriteFootballTeam)
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
