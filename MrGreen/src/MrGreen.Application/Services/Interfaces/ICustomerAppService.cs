using MrGreen.Application.ViewModels;
using System;

namespace MrGreen.Application.Services.Interfaces
{
    public interface ICustomerAppService
    {
        void Add(CustomerViewModel customerViewModel);

        CustomerViewModel GetById(Guid id);

        void Update(CustomerViewModel customerViewModel);

        void Remove(Guid id);
    }
}
