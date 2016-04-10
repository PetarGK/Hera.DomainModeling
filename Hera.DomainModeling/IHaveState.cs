using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hera.DomainModeling
{
    public interface IHaveState<out TState>
    {
        TState State { get; }
    }
}
