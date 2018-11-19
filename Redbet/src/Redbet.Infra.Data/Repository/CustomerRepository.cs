using Redbet.Domain.Models.Customers;
using Redbet.Domain.Models.Customers.Repository;
using Redbet.Infra.Data.Context;

namespace Redbet.Infra.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(CustomersContext context) : base(context)
        {
        }
    }
}
