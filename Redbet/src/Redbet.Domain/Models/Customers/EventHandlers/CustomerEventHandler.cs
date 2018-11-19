using Redbet.Domain.Core.Events;
using Redbet.Domain.Models.Customers.Events;
using System;

namespace Redbet.Domain.Models.Customers.EventHandlers
{
    public class CustomerEventHandler :
        IHandler<AddedCustomerEvent>,
        IHandler<UpdatedCustomerEvent>,
        IHandler<DeletedCustomerEvent>
    {
        public void Handle(AddedCustomerEvent message)
        {
            // Ex: Send an event, send an e-mail, log register ...
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Customer Added");
        }

        public void Handle(UpdatedCustomerEvent message)
        {
            // Ex: Send an event, send an e-mail, log register ...
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Customer Updated");
        }

        public void Handle(DeletedCustomerEvent message)
        {
            // Ex: Send an event, send an e-mail, log register ...
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Customer Deleted");
        }
    }
}
