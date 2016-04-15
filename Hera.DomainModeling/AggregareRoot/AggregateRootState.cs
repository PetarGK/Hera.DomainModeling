using Hera.DomainModeling.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hera.DomainModeling.AggregareRoot
{
    public abstract class AggregateRootState<TId> : IAggregateRootState 
        where TId : IIdentity
    {
        public TId Id { get; set; }
        public IAggregateRoot Root { get; set; }

        IIdentity IHaveId<IIdentity>.Id
        {
            get { return Id; }
            set { Id = (TId)value; }
        }

    }
}
