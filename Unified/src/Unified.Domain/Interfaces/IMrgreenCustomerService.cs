using System;
using System.Collections.Generic;
using System.Text;
using Unified.Domain.Model;

namespace Unified.Domain.Services
{
    public interface IMrgreenCustomerService
    {
        MrgreenCustomer GetCustomer(Guid customerId);

        void AddCustomer(MrgreenCustomer Customer);

        void UpdateCustomer(MrgreenCustomer Customer);

        void RemoveCustomer(Guid customerId);
    }
}
