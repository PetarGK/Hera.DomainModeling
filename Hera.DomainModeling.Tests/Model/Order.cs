using Hera.DomainModeling.AggregareRoot;
using Hera.DomainModeling.Tests.Model.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hera.DomainModeling.Tests.Model
{
    public class Order : AggregateRoot<OrderState>
    {
        protected Order() : base() { }

        public Order(OrderId id)
        {
            // Validation logic here

            Apply(new OrderCreated(id, DateTime.Now));
        }

        public void AddProduct(ProductId productId, Price price, int count)
        {
            // Validate logic

            Apply(new ProductAdded(new OrderItemId(Guid.NewGuid()), productId, price, count));
        }

        public void UpdateProductPrice(ProductId productId, Price price)
        {
            //Validate existing of the product

            State.Items.Single(s => s.ProductId == productId).UpdatePrice(price);
        }

        public void MarkAsPaid()
        {
            // Validation logic here
            if (State.Status == OrderStatus.Created)
                Apply(new MarkAsPaid());
            else
                throw new ApplicationException("Invalid status");
        }
        public void ReadyForDelivery()
        {
            // Validation logic here
            if (State.Status == OrderStatus.Paid)
                Apply(new ReadyForDelivery());
            else
                throw new ApplicationException("Invalid status");
        }
        public void Delivered()
        {
            // Validation logic here
            if (State.Status == OrderStatus.ReadyForDelivery)
                Apply(new OrderDelivered());
            else
                throw new ApplicationException("Invalid status");
        }
    }
}
