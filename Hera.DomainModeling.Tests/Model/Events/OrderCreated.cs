using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hera.DomainModeling.Tests.Model.Events
{
    public class OrderCreated : IEvent
    {
        public OrderCreated(OrderId id, DateTime creationDate)
        {
            Id = id;
            CreationDate = creationDate;
        }

        public OrderId Id { get; private set; }
        public DateTime CreationDate { get; private set; }
    }
}
