using Hera.DomainModeling.AggregareRoot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hera.DomainModeling.Tests.Model
{
    public class Order : AggregateRoot<OrderState>
    {
        public Order()
        {

        }

        public void MarkAsPaid()
        {

        }

        public void ReadyForDelivery()
        {

        }

        public void Delivered()
        {

        }
    }
}
