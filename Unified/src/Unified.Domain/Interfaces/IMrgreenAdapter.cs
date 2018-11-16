using System;
using System.Collections.Generic;
using Unified.Domain.Model;

namespace Unified.Domain.Interfaces
{
    public interface IMrgreenAdapter
    {
        IEnumerable<MrgreenCustomer> GetAll();

        MrgreenCustomer GetCustomer(Guid customerId);

        void AddCustomer(MrgreenCustomer customer);

        void UpdateCustomer(MrgreenCustomer customer);

        void RemoveCustomer(Guid customerId);
    }
}
