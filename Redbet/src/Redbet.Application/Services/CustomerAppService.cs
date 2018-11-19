using AutoMapper;
using Redbet.Application.Interfaces;
using Redbet.Application.ViewModels;
using Redbet.Domain.Core.Bus;
using Redbet.Domain.Models.Customers.Commands;
using Redbet.Domain.Models.Customers.Repository;
using System;
using System.Collections.Generic;

namespace Redbet.Application.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly IBus _bus;
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public CustomerAppService(IBus bus, IMapper mapper, ICustomerRepository customerRepository)
        {
            _bus = bus;
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public void Add(CustomerViewModel customerViewModel)
        {
            var addingCustomerCommand = _mapper.Map<AddCustomerCommand>(customerViewModel);
            _bus.SendCommand(addingCustomerCommand);
        }

        public IEnumerable<CustomerViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<CustomerViewModel>>(_customerRepository.GetAll());
        }

        public CustomerViewModel GetById(Guid id)
        {
            return _mapper.Map<CustomerViewModel>(_customerRepository.GetById(id));
        }

        public void Remove(Guid id)
        {
            _bus.SendCommand(new DeleteCustomerCommand(id));
        }

        public void Update(CustomerViewModel customerViewModel)
        {
            var updateCustomerCommand = _mapper.Map<UpdateCustomerCommand>(customerViewModel);
            _bus.SendCommand(updateCustomerCommand);
        }

        public void Dispose()
        {
            _customerRepository.Dispose();
        }
    }
}
