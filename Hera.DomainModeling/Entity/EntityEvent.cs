using Hera.DomainModeling.Identity;
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
        public EntityEvent(IIdentity id, IEvent @event)
        {
            EntityId = id;
            Event = @event;
        }

        public IIdentity EntityId { get; private set; }
        public IEvent Event { get; private set; }
    }
}
