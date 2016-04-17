using Hera.DomainModeling.AggregareRoot;

namespace Hera.DomainModeling.Entity
{
    public interface IEntity : IHaveState<IEntityState>, IHaveRoot<IAggregateRoot>
    {
    }
}
