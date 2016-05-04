using Hera.DomainModeling.DomainEvent;
using Hera.DomainModeling.Identity;
using System.Runtime.Serialization;
using System;

namespace Hera.DomainModeling.Entity
{
    public class EntityEvent : IDomainEvent, ISerializable
    {
        private EntityEvent() { }
        public EntityEvent(IIdentity id, IDomainEvent @event)
        {
            EntityId = id;
            Event = @event;
        }
        public EntityEvent(SerializationInfo info, StreamingContext context)
        {
            EntityId = (IIdentity)info.GetValue("EntityId", EntityId.GetType());
            Event = (IDomainEvent)info.GetValue("Event", Event.GetType());
        }

        public IIdentity EntityId { get; private set; }
        public IDomainEvent Event { get; private set; }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("EntityId", EntityId, EntityId.GetType());
            info.AddValue("Event", Event, Event.GetType());
        }
    }
}
