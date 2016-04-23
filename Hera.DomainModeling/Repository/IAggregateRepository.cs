using Hera.DomainModeling.AggregareRoot;
using Hera.DomainModeling.Identity;

namespace Hera.DomainModeling.Repository
{
    public interface IAggregateRepository
    {
        void Save<TAggregateRoot>(TAggregateRoot aggregateRoot) where TAggregateRoot : IAggregateRoot;
        void Save<TAggregateRoot>(TAggregateRoot aggregateRoot, string boundedContext) where TAggregateRoot : IAggregateRoot;
        TAggregateRoot Load<TAggregateRoot>(IIdentity aggregateRootId) where TAggregateRoot : IAggregateRoot;
        TAggregateRoot Load<TAggregateRoot>(IIdentity aggregateRootId, string boundedContext) where TAggregateRoot : IAggregateRoot;
    }
}
