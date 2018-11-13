using MrGreen.Application.Repository;
using MrGreen.Application.Services.Interfaces;
using MrGreen.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MrGreen.Application.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustormerRepository _customerRepository;

        public CustomerAppService(ICustormerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void Add(CustomerViewModel customerViewModel)
        {
            var customer = new Domain.Models.Customer(
                                customerViewModel.FirstName,
                                customerViewModel.LastName,
                                customerViewModel.Address,
                                customerViewModel.PersonalNumber);

            // Only to initial tests
            if (!customer.IsValid()) throw new Exception(customer.ValidationResult.Errors[0].ErrorMessage);

            _customerRepository.Add(customer);
        }
        
        public CustomerViewModel GetById(Guid id)
        {
            var customer = _customerRepository.GetById(id);
            return new CustomerViewModel
                       {
                           Id = customer.Id,
                           FirstName = customer.FirstName,
                           LastName = customer.LastName,
                           Address = customer.Address,
                           PersonalNumber = customer.PersonalNumber
                       };
        }

        public void Remove(Guid id)
        {
            _customerRepository.Remove(id);
        }

        public void Update(CustomerViewModel customerViewModel)
        {
            var customer = _customerRepository.GetById(customerViewModel.Id);

            customer.FirstName = customerViewModel.FirstName;
            customer.LastName = customerViewModel.LastName;
            customer.Address = customerViewModel.Address;
            customer.PersonalNumber = customerViewModel.PersonalNumber;

            // Only to initial tests
            if (!customer.IsValid()) throw new Exception(customer.ValidationResult.Errors[0].ErrorMessage);

            _customerRepository.Update(customer);
        }
    }
}
