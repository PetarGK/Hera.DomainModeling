using Hera.DomainModeling.Entity;
using Hera.DomainModeling.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hera.DomainModeling.AggregareRoot
{
    public interface IAmEventSourced
    {
        void ReplayEvents(IEnumerable<IEvent> events, int currentRevision);
        IEnumerable<IEvent> UncommittedEvents { get; }
        int Revision { get; }
        void RegisterEntity(IIdentity entityId, IEntity entity);
    }
}
