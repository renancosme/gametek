using Redbet.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redbet.Application.Interfaces
{
    public interface ICustomerAppService : IDisposable
    {
        void Add(CustomerViewModel createCustomerViewModel);

        CustomerViewModel GetById(Guid id);

        void Update(CustomerViewModel customerViewModel);

        void Remove(Guid id);

        IEnumerable<CustomerViewModel> GetAll();
    }
}
