using Redbet.Domain.Core.Commands;
using Redbet.Domain.Interfaces;
using Redbet.Infra.Data.Context;

namespace Redbet.Infra.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CustomersContext _context;

        public UnitOfWork(CustomersContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            var rowsAffected = _context.SaveChanges();
            return new CommandResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
