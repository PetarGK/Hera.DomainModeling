using Hera.DomainModeling.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hera.DomainModeling.Identity
{
    public abstract class GuidIdentity : IIdentity, IEqualityComparer<Guid>, IEquatable<Guid>
    {
        bool IEquatable<Guid>.Equals(Guid other)
        {
            throw new NotImplementedException();
        }
        bool IEqualityComparer<Guid>.Equals(Guid x, Guid y)
        {
            throw new NotImplementedException();
        }
        int IEqualityComparer<Guid>.GetHashCode(Guid obj)
        {
            throw new NotImplementedException();
        }
    }
}
