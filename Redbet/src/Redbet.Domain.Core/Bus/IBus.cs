using Redbet.Domain.Core.Commands;
using Redbet.Domain.Core.Events;

namespace Redbet.Domain.Core.Bus
{
    public interface IBus
    {
        void SendCommand<T>(T theCommand) where T : Command;

        void RaiseEvent<T>(T theEvent) where T : Event;
    }
}
