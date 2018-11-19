using System;

namespace Redbet.Domain.Models.Customers.Commands
{
    public class DeleteCustomerCommand : BaseCustomerCommand
    {
        public DeleteCustomerCommand(Guid id)
        {
            Id = id;
            AggregateId = Id;
        }
    }
}
