using System;
using System.Collections.Generic;
using System.Text;
using Unified.Domain.Model;

namespace Unified.Domain.Services
{
    public interface IRedbetCustomerService
    {
        RedbetCustomer GetCustomer(Guid customerId);

        void AddCustomer(RedbetCustomer Customer);

        void UpdateCustomer(RedbetCustomer Customer);

        void RemoveCustomer(Guid customerId);
    }
}
