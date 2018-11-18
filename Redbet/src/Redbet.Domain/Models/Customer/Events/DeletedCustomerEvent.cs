using System;
using System.Collections.Generic;
using System.Text;

namespace Redbet.Domain.Models.Customer.Events
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
