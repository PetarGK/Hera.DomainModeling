using Hera.DomainModeling.Identity;
using System.Runtime.Serialization;
using System;

namespace Hera.DomainModeling.Entity
{
    public abstract class EntityState<TId> : ISerializable, IEntityState where TId : IIdentity
    {
        public TId Id { get; set; }
        IIdentity IHaveId<IIdentity>.Id
        {
            get { return Id; }
            set { Id = (TId)value; }
        }

        public EntityState() { }
        public EntityState(SerializationInfo info, StreamingContext context)
        {
            Id = (TId)info.GetValue("Id", typeof(TId));
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            GetObjectData(info, context);
        }
        protected virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", Id, typeof(TId));
        }
    }
}
