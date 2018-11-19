using Redbet.Domain.Core.Events;
using System;

namespace Redbet.Domain.Models.Customers.Events
{
    public abstract class BaseCustomerEvent : Event
    {
        public Guid Id { get; protected set; }

        public string FirstName { get; protected set; }

        public string LastName { get; protected set; }

        public string Address { get; protected set; }

        public string FavoriteFootballTeam { get; protected set; }
    }
}
