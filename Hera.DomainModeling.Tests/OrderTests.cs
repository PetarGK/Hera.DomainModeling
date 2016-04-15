using Hera.DomainModeling.AggregareRoot;
using Hera.DomainModeling.Tests.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hera.DomainModeling.Tests
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void CreateOrder()
        {
            var productId = new ProductId(Guid.NewGuid());


            var order = new Order(OrderId.NewId);

            order.MarkAsPaid();

            order.AddProduct(productId, new Price(20.0m), 10);

            order.UpdateProductPrice(productId, new Price(25.0m));

            IAmEventSourced ev = order as IAmEventSourced;

            Order order2 = (Order)Activator.CreateInstance(typeof(Order), true);
            IAmEventSourced ev2 = order2 as IAmEventSourced;

            ev2.ReplayEvents(ev.UncommittedEvents, ev.Revision);
        }
    }
}
