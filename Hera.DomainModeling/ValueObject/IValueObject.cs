using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hera.DomainModeling.ValueObject
{
    public interface IValueObject<T> : IEqualityComparer<T>, IEquatable<T>
    {
        IEnumerable<object> GetAttributesToIncludeInEqualityCheck();
    }
}
