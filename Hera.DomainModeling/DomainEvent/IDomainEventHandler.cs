namespace Hera.DomainModeling.DomainEvent
{
    public interface IDomainEventHandler<in T> where T : IDomainEvent
    {
        void Handle(T @event);
    }
}
