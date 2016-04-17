using System;
using System.Collections.Generic;

namespace Hera.DomainModeling.ValueObject
{
    public interface IValueObject<T> : IEqualityComparer<T>, IEquatable<T>
    {
        IEnumerable<object> GetAttributesToIncludeInEqualityCheck();
    }
}
