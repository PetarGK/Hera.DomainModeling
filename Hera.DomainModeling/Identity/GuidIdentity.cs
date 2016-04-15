using Hera.DomainModeling.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hera.DomainModeling.Identity
{
    public abstract class GuidIdentity : IIdentity, IEqualityComparer<GuidIdentity>, IEquatable<GuidIdentity>
    {
        private Guid _id;

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
    }
}
