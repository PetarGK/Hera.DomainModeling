using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Hera.DomainModeling.Identity
{
    public abstract class GuidIdentity : IIdentity, IEqualityComparer<GuidIdentity>, IEquatable<GuidIdentity>, ISerializable
    {
        private Guid _id;

        protected GuidIdentity() { }

        public GuidIdentity(Guid id)
        {
            _id = id;
        }

        public override bool Equals(object obj)
        {
            return _id.Equals(((GuidIdentity)obj)._id);
        }
        bool IEquatable<GuidIdentity>.Equals(GuidIdentity other)
        {
            return _id.Equals(other._id);
        }
        bool IEqualityComparer<GuidIdentity>.Equals(GuidIdentity x, GuidIdentity y)
        {
            return x._id.Equals(y._id);
        }
        int IEqualityComparer<GuidIdentity>.GetHashCode(GuidIdentity obj)
        {
            return obj.GetHashCode();
        }
        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }
        public override string ToString()
        {
            return _id.ToString();
        }

        public GuidIdentity(SerializationInfo info, StreamingContext context)
        {
            _id = (Guid)info.GetValue("_id", typeof(Guid));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("_id", _id, typeof(Guid));
        }
    }
}
