using Hera.DomainModeling.Identity;

namespace Hera.DomainModeling.AggregareRoot
{
    public interface IAggregateRootState : IHaveId<IIdentity>, IHaveRoot<IAggregateRoot>
    {
    }
}
