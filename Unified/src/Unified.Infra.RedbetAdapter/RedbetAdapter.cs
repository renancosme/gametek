﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Unified.Domain.Model;
using Unified.Domain.Services;

namespace Unified.Infra.RedbetAdapter
{
    public class RedbetAdapter : IRedbetCustomerService
    {
        public void AddCustomer(RedbetCustomer Customer)
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

        public void UpdateCustomer(RedbetCustomer Customer)
        {
            throw new NotImplementedException();
        }
    }
}
