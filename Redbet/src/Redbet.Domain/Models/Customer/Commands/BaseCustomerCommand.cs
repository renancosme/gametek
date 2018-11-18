using Redbet.Domain.Core.Commands;
using System;

namespace Redbet.Domain.Models.Customer.Commands
{
    public abstract class BaseCustomerCommand : Command
    {
        public Guid Id { get; protected set; }

        public string FirstName { get; protected set; }

        public string LastName { get; protected set; }

        public string Address { get; protected set; }

        public string FavoriteFootballTeam { get; protected set; }

    }
}
