using Hera.DomainModeling.Entity;
using Hera.DomainModeling.Identity;
using Hera.DomainModeling.Tests.Model.Events;
using Hera.DomainModeling.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hera.DomainModeling.Tests.Model
{
    public class OrderItemState : EntityState<OrderItemId>
    {
        public ProductId ProductId { get; set; }
        public Price Price { get; set; }
        public int Count { get; set; }

        public void When(UpdateProductPrice @event)
        {
            Price = @event.Price;
        }
    }

    public class OrderItemId : GuidIdentity
    {
        public OrderItemId(Guid id) : base(id) { }
    }
    public class ProductId : GuidIdentity
    {
        public ProductId(Guid id) : base(id) { }
    }

    public class Price : ValueObject<Price>
    {
        private decimal _value;

        public Price(decimal value)
        {
            // Validate invariants

            _value = value;
        }
    }
}
