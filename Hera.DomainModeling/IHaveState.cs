namespace Hera.DomainModeling
{
    public interface IHaveState<out TState>
    {
        TState State { get; }
    }
}
