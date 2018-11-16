using System;

namespace Unified.Domain.Model
{
    public class RedbetCustomer
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string FavoriteFootballTeam { get; set; }
    }
}
