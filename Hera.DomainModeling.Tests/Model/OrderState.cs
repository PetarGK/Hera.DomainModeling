using Hera.DomainModeling.AggregareRoot;
using Hera.DomainModeling.Tests.Model.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hera.DomainModeling.Identity;

namespace Hera.DomainModeling.Tests.Model
{
    public class OrderState : AggregateRootState<OrderId>
    {
        public DateTime CreationDate { get; set; }
        public OrderStatus Status { get; set; }


        public void When(OrderCreated @event)
        {
            Id = @event.Id;
            CreationDate = @event.CreationDate;
            Status = OrderStatus.Created;
        }
    }

    public class OrderId : GuidIdentity
    {

    }

    public enum OrderStatus
    {
        Created,
        Paid,
        ReadyForDelivery,
        Delivered
    }
}
