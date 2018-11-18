using Redbet.Domain.Models.Customer;
using Redbet.Domain.Models.Customer.Repository;
using Redbet.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redbet.Infra.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(CustomersContext context) : base(context)
        {
        }
    }
}
