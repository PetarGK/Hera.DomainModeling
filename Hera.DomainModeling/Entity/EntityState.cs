using Hera.DomainModeling.Identity;

namespace Hera.DomainModeling.Entity
{
    public abstract class EntityState<TId> : IEntityState where TId : IIdentity
    {
        public TId Id { get; set; }
        IIdentity IHaveId<IIdentity>.Id
        {
            get { return Id; }
            set { Id = (TId)value; }
        }
    }
}
