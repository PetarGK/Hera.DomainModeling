using Hera.DomainModeling.DomainEvent;
using Hera.DomainModeling.Entity;
using Hera.DomainModeling.Identity;
using System.Collections.Generic;

namespace Hera.DomainModeling.AggregareRoot
{
    public interface IAmEventSourced
    {
        void ReplayEvents(IEnumerable<IDomainEvent> events, int currentRevision);
        IEnumerable<IDomainEvent> UncommittedEvents { get; }
        int Revision { get; }
        void RegisterEntity(IIdentity entityId, IEntity entity);
    }
}
