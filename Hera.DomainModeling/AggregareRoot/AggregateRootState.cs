using Hera.DomainModeling.Identity;

namespace Hera.DomainModeling.AggregareRoot
{
    public abstract class AggregateRootState<TId> : IAggregateRootState 
        where TId : IIdentity
    {
        public TId Id { get; set; }
        public IAggregateRoot Root { get; set; }

        IIdentity IHaveId<IIdentity>.Id
        {
            get { return Id; }
            set { Id = (TId)value; }
        }

    }
}
