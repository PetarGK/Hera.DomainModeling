using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hera.DomainModeling.Entity
{
    public class EntityEvent
    {
        private EntityEvent() { }
        public EntityEvent(Guid id, IEvent @event)
        {
            EntityId = id;
            Event = @event;
        }

        public Guid EntityId { get; private set; }
        public IEvent Event { get; private set; }
    }
}
