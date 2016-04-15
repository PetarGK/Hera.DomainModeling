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
        public OrderState()
        {
            Items = new List<OrderItem>();
        }

        public DateTime CreationDate { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItem> Items { get; set; }

        public void When(OrderCreated @event)
        {
            Id = @event.Id;
            CreationDate = @event.CreationDate;
            Status = OrderStatus.Created;
        }
        public void When(MarkAsPaid @event)
        {
            Status = OrderStatus.Paid;
        }
        public void When(ReadyForDelivery @event)
        {
            Status = OrderStatus.ReadyForDelivery;
        }
        public void When(OrderDelivered @event)
        {
            Status = OrderStatus.Delivered;
        }
        public void When(ProductAdded @event)
        {
            var orderItem = new OrderItem((Order)Root, @event.OrderItemId, @event.ProductId, @event.Price, @event.Count);

            Items.Add(orderItem);
        }
    }

    public class OrderId : GuidIdentity
    {
        public static OrderId NewId = new OrderId(Guid.NewGuid());
        public OrderId(Guid id) : base(id) { }
    }

    public enum OrderStatus
    {
        Created,
        Paid,
        ReadyForDelivery,
        Delivered
    }
}
