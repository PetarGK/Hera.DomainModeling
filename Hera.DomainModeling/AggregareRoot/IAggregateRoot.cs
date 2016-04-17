namespace Hera.DomainModeling.AggregareRoot
{
    public interface IAggregateRoot : IAmEventSourced, IHaveState<IAggregateRootState>
    {
    }
}
