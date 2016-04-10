using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hera.DomainModeling.Entity
{
    public abstract class EntityState : IEntityState 
    {
        public Guid Id { get; set; }
    }
}
