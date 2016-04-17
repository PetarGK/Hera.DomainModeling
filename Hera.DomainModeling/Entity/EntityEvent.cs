using Hera.DomainModeling.DomainEvent;
using Hera.DomainModeling.Identity;

namespace Hera.DomainModeling.Entity
{
    public class EntityEvent : IDomainEvent
    {
        private EntityEvent() { }
        public EntityEvent(IIdentity id, IDomainEvent @event)
        {
            EntityId = id;
            Event = @event;
        }

        public IIdentity EntityId { get; private set; }
        public IDomainEvent Event { get; private set; }
    }
}
