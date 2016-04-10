using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hera.DomainModeling.AggregareRoot
{
    public interface IAggregateRoot : IAmEventSourced, IHaveState<IAggregateRootState>
    {
    }
}
