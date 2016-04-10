using Hera.DomainModeling.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hera.DomainModeling.AggregareRoot
{
    public interface IAmEventSourced
    {
        void ReplayEvents(List<IEvent> events, int currentRevision);
        IEnumerable<IEvent> UncommittedEvents { get; }
        int Revision { get; }
        void RegisterEntity(Guid entityId, IEntity entity);
    }
}
