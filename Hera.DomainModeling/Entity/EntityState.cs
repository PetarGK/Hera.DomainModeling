using Hera.DomainModeling.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hera.DomainModeling.Entity
{
    public abstract class EntityState<TId> : IEntityState where TId : IIdentity
    {
        public TId Id { get; set; }
        IIdentity IHaveId<IIdentity>.Id
        {
            get { return Id; }
            set { Id = (TId)value; }
        }
    }
}
