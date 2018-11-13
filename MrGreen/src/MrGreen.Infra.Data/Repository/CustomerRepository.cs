using MrGreen.Application.Repository;
using MrGreen.Domain.Models;
using MrGreen.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace MrGreen.Infra.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustormerRepository
    {
        public CustomerRepository(CustomerContext context) : base(context)
        {
        }
    }
}
