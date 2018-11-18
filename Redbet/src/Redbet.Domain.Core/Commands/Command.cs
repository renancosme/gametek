using Redbet.Domain.Core.Events;
using System;

namespace Redbet.Domain.Core.Commands
{
    public class Command : Message
    {
        public Command()
        {
            Timestamp = DateTime.Now;
        }

        public DateTime Timestamp { get; private set; }
    }
}
