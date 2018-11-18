using Redbet.Domain.Models.Customer;
using Redbet.Domain.Models.Customer.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Console.Testing
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        public void Add(Customer obj)
        {
            //
        }

        public void Dispose()
        {
            //
        }

        public IEnumerable<Customer> Find(Expression<Func<Customer, bool>> predicate)
        {
            //
            return null;
        }

        public IEnumerable<Customer> GetAll()
        {
            //
            return null;
        }

        public Customer GetById(Guid id)
        {
            return new Customer("Fake", "Last name Fake", "Address Fake", "Team Fake");
        }

        public void Remove(Guid id)
        {
            //
        }

        public int SaveChanges()
        {
            //
            return 0;
        }

        public void Update(Customer obj)
        {
            //
        }
    }
}
