using System;

namespace Redbet.Domain.Models.Customer.Commands
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
