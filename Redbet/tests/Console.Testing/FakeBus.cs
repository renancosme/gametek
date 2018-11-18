using System;
using Redbet.Domain.Core.Bus;
using Redbet.Domain.Core.Commands;
using Redbet.Domain.Core.Events;
using Redbet.Domain.Core.Notifications;
using Redbet.Domain.Models.Customer.CommandHandlers;
using Redbet.Domain.Models.Customer.EventHandlers;

namespace Console.Testing
{
    internal class FakeBus : IBus
    {
        public FakeBus()
        {
        }

        public void RaiseEvent<T>(T theEvent) where T : Event
        {
            Publish(theEvent);
        }
                
        public void SendCommand<T>(T theCommand) where T : Command
        {
            System.Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine($"Comando { theCommand.MessageType } lançado");

            Publish(theCommand);
        }

        private static void Publish<T>(T message) where T : Message
        {
            var messageType = message.MessageType;

            if (messageType.Equals("DomainNotification"))
            {
                var obj = new DomainNotificationHandler();
                ((IDomainNotificationHandler<T>)obj).Handle(message);
            }

            if (messageType.Equals("AddCustomerCommand") || 
                messageType.Equals("UpdateCustomerCommand") || 
                messageType.Equals("DeleteCustomerCommand"))
            {
                var obj = new CustomerCommandHandler(new FakeCustomerRepository(), new FakeUow(), new FakeBus(), new DomainNotificationHandler());
                ((IHandler<T>)obj).Handle(message);
            }

            if (messageType.Equals("AddedCustomerEvent") ||
                messageType.Equals("UpdatedCustomerEvent") ||
                messageType.Equals("DeletedCustomerEvent"))
            {
                var obj = new CustomerEventHandler();
                ((IHandler<T>)obj).Handle(message);
            }
        }
    }
}