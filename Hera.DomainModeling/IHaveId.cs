namespace Hera.DomainModeling
{
    public interface IHaveId<TId>
    {
        TId Id { get; set; }
    }
}
