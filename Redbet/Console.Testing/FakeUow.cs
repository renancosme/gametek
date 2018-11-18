using Redbet.Domain.Core.Commands;
using Redbet.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Console.Testing
{
    public class FakeUow : IUnitOfWork
    {
        public CommandResponse Commit()
        {
            return new CommandResponse(true);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
