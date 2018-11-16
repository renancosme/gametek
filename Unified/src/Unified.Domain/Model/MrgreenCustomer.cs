using System;
using System.Collections.Generic;
using System.Text;

namespace Unified.Domain.Model
{
    public class MrgreenCustomer
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string PersonalNumber { get; set; }
    }
}
