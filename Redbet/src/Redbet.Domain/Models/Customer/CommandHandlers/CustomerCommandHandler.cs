using Redbet.Domain.CommandHandlers;
using Redbet.Domain.Core.Bus;
using Redbet.Domain.Core.Events;
using Redbet.Domain.Core.Notifications;
using Redbet.Domain.Interfaces;
using Redbet.Domain.Models.Customer.Commands;
using Redbet.Domain.Models.Customer.Events;
using Redbet.Domain.Models.Customer.Repository;
using System;

namespace Redbet.Domain.Models.Customer.CommandHandlers
{
    public class CustomerCommandHandler : CommandHandler,
        IHandler<AddCustomerCommand>,
        IHandler<UpdateCustomerCommand>,
        IHandler<DeleteCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IBus _bus;

        public CustomerCommandHandler(
            ICustomerRepository customerRepository, 
            IUnitOfWork unitOfWork, IBus bus,
            IDomainNotificationHandler<DomainNotification> domainNotificationHandler) 
            : base(unitOfWork, bus, domainNotificationHandler)
        {
            _customerRepository = customerRepository;
            _bus = bus;
        }

        public void Handle(AddCustomerCommand message)
        {
            var customer = new Customer(message.FirstName, message.LastName, message.Address, message.FavoriteFootballTeam);

            // Validations
            if (!IsValidCustomer(customer)) return;

            // Persistency
            _customerRepository.Add(customer);

            if (Commit())
            {
                // Notify process finished
                Console.WriteLine("Customer registred");
                _bus.RaiseEvent(new AddedCustomerEvent(customer.Id, customer.FirstName, customer.LastName, customer.Address, customer.FavoriteFootballTeam));
            }
        }

        public void Handle(UpdateCustomerCommand message)
        {
            if (!CustomerExists(message.Id, message.MessageType)) return;

            var customer = Customer.CustomerFactory.NewCompleteCustomer(message.Id, message.FirstName, message.LastName, message.Address, message.FavoriteFootballTeam);

            // Validations
            if (!IsValidCustomer(customer)) return;

            // Persistency
            _customerRepository.Add(customer);

            if (Commit())
            {
                // Notify process finished
                Console.WriteLine("Customer updated");
                _bus.RaiseEvent(new UpdatedCustomerEvent(customer.Id, customer.FirstName, customer.LastName, customer.Address, customer.FavoriteFootballTeam));
            }
        }
                
        public void Handle(DeleteCustomerCommand message)
        {
            if (!CustomerExists(message.Id, message.MessageType)) return;

            _customerRepository.Remove(message.Id);

            if (Commit())
            {
                // Notify process finished
                Console.WriteLine("Customer removed");
                _bus.RaiseEvent(new DeletedCustomerEvent(message.Id));
            }
        }

        private bool IsValidCustomer(Customer customer)
        {
            if (customer.IsValid()) return true;

            NotifyErrorValidations(customer.ValidationResult);
            return false;
        }

        private bool CustomerExists(Guid id, string messageType)
        {
            var customer = _customerRepository.GetById(id);

            if (customer != null) return true;

            _bus.RaiseEvent(new DomainNotification(messageType, "Customer not found."));
            return false;
        }
    }
}
