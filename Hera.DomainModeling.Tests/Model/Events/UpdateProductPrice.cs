using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hera.DomainModeling.Tests.Model.Events
{
    public class UpdateProductPrice : IEvent
    {
        public UpdateProductPrice(Price price)
        {
            Price = price;
        }

        public Price Price { get; private set; }
    }
}
