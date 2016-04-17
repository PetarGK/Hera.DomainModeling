using System;
using System.Collections.Generic;

namespace Hera.DomainModeling.Identity
{
    public abstract class StringIdentity : IIdentity, IEqualityComparer<string>, IEquatable<string>
    {
        bool IEquatable<string>.Equals(string other)
        {
            throw new NotImplementedException();
        }
        bool IEqualityComparer<string>.Equals(string x, string y)
        {
            throw new NotImplementedException();
        }
        int IEqualityComparer<string>.GetHashCode(string obj)
        {
            throw new NotImplementedException();
        }
    }
}
