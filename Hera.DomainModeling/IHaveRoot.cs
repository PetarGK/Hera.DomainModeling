namespace Hera.DomainModeling
{
    public interface IHaveRoot<TRoot>
    {
        TRoot Root { get; set; }
    }
}
