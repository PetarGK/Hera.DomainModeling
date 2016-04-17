using System;
using System.Collections.Generic;

namespace Hera.DomainModeling.Identity
{
    public abstract class IntIdentity : IIdentity, IEqualityComparer<int>, IEquatable<int>
    {
        bool IEquatable<int>.Equals(int other)
        {
            throw new NotImplementedException();
        }
        bool IEqualityComparer<int>.Equals(int x, int y)
        {
            throw new NotImplementedException();
        }
        int IEqualityComparer<int>.GetHashCode(int obj)
        {
            throw new NotImplementedException();
        }
    }
}
