using System;
using System.Collections.Generic;
using System.Text;

namespace Unified.Domain.Model
{
    public abstract class Customer
    {
        public string FirstName { get; protected set; }

        public string LastName { get; protected set; }

        public string Address { get; protected set; }
    }
}
