using Redbet.Domain.Core.Bus;
using Redbet.Domain.Core.Commands;
using Redbet.Domain.Core.Events;
using Redbet.Domain.Core.Notifications;
using System;

namespace Redbet.Infra.CrossCutting.Bus
{
    public sealed class InMemoryBus : IBus
    {
        public static Func<IServiceProvider> DIContainerAccessor { get; set; }

        private static IServiceProvider DIContainter => DIContainerAccessor();

        public void RaiseEvent<T>(T theEvent) where T : Event
        {
            Publish(theEvent);
        }

        public void SendCommand<T>(T theCommand) where T : Command
        {
            Publish(theCommand);
        }

        private static void Publish<T>(T message) where T : Message
        {
            if (DIContainter == null) return;
            
            var obj = DIContainter.GetService(message.MessageType.Equals("DomainNotification")
                ? typeof(IDomainNotificationHandler<T>)
                : typeof(IHandler<T>));

            ((IHandler<T>)obj).Handle(message);
        }
    }
}
