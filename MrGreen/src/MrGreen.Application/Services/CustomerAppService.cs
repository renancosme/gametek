using MrGreen.Application.Repository;
using MrGreen.Application.Services.Interfaces;
using MrGreen.Application.ViewModels;
using MrGreen.Domain.Exceptions;
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

        public CustomerViewModel Add(CreateCustomerViewModel createCustomerViewModel)
        {
            var customer = new Domain.Models.Customer(
                                createCustomerViewModel.FirstName,
                                createCustomerViewModel.LastName,
                                createCustomerViewModel.Address,
                                createCustomerViewModel.PersonalNumber);

            if (!customer.IsValid()) throw new DomainException(customer.ValidationResult);

            _customerRepository.Add(customer);
            _customerRepository.SaveChanges();

            return new CustomerViewModel(customer.Id, customer.FirstName, customer.LastName, customer.Address, customer.PersonalNumber);
        }

        public IEnumerable<CustomerViewModel> GetAll()
        {
            var customers = _customerRepository.GetAll();

            var customersToReturn = new List<CustomerViewModel>();
            foreach (var customer in customers)
            {
                customersToReturn.Add(new CustomerViewModel(customer.Id, customer.FirstName, customer.LastName, customer.Address, customer.PersonalNumber));
            }

            return customersToReturn;
        }

        public CustomerViewModel GetById(Guid id)
        {
            var customer = _customerRepository.GetById(id);

            if (customer == null) return null;

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
            _customerRepository.SaveChanges();
        }

        public void Update(CustomerViewModel customerViewModel)
        {
            var customer = _customerRepository.GetById(customerViewModel.Id);

            customer.FirstName = customerViewModel.FirstName;
            customer.LastName = customerViewModel.LastName;
            customer.Address = customerViewModel.Address;
            customer.PersonalNumber = customerViewModel.PersonalNumber;
                        
            if (!customer.IsValid()) throw new DomainException(customer.ValidationResult);

            _customerRepository.Update(customer);
            _customerRepository.SaveChanges();
        }
    }
}
