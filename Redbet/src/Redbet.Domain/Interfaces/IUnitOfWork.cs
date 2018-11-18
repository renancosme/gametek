using Redbet.Domain.Core.Commands;
using System;

namespace Redbet.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
