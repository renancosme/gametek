using System;
using System.Collections.Generic;
using System.Text;
using Unified.Domain.Model;

namespace Unified.Domain.Interfaces
{
    public interface IRedbetAdapeter
    {
        RedbetCustomer GetCustomer(Guid customerId);

        void AddCustomer(RedbetCustomer customer);

        void UpdateCustomer(RedbetCustomer customer);

        void RemoveCustomer(Guid customerId);
    }
}
