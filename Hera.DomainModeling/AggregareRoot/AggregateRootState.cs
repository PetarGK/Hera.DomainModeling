using Hera.DomainModeling.Identity;
using System.Runtime.Serialization;
using System;

namespace Hera.DomainModeling.AggregareRoot
{
    public abstract class AggregateRootState<TId> : IAggregateRootState, ISerializable
        where TId : IIdentity
    {
        public TId Id { get; set; }
        public IAggregateRoot Root { get; set; }
        IIdentity IHaveId<IIdentity>.Id
        {
            get { return Id; }
            set { Id = (TId)value; }
        }

        public AggregateRootState()
        {
        }
        public AggregateRootState(SerializationInfo info, StreamingContext context) 
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
