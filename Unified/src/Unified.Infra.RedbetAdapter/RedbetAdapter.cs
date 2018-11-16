using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Unified.Domain.Model;
using Unified.Domain.Interfaces;

namespace Unified.Infra.RedbetAdapter
{
    public class RedbetAdapter : IRedbetAdapeter
    {
        public void AddCustomer(RedbetCustomer customer)
        {
            throw new NotImplementedException();
        }

        public RedbetCustomer GetCustomer(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public void RemoveCustomer(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomer(RedbetCustomer customer)
        {
            throw new NotImplementedException();
        }
    }
}
