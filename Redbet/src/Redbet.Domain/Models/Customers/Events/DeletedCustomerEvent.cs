using System;

namespace Redbet.Domain.Models.Customers.Events
{
    public class DeletedCustomerEvent : BaseCustomerEvent
    {
        public DeletedCustomerEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}
