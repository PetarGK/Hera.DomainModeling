using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hera.DomainModeling.ValueObject
{
    public abstract class ValueObject<T> : IValueObject<T> where T : ValueObject<T>
    {
        public override int GetHashCode()
        {
            int hash = 17;
            foreach (var obj in ((IValueObject<T>)this).GetAttributesToIncludeInEqualityCheck())
                hash = hash * 31 + (obj == null ? 0 : obj.GetHashCode());

            return hash;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as T);
        }
        bool IEquatable<T>.Equals(T other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;

            return ((IValueObject<T>)this).GetAttributesToIncludeInEqualityCheck().SequenceEqual(((IValueObject<T>)other).GetAttributesToIncludeInEqualityCheck());
        }
        bool IEqualityComparer<T>.Equals(T x, T y)
        {
            if (ReferenceEquals(null, x) && ReferenceEquals(null, y))
                return true;
            if (ReferenceEquals(null, x))
                return false;

            return x.Equals(y);
        }
        IEnumerable<object> IValueObject<T>.GetAttributesToIncludeInEqualityCheck()
        {
            return GetAttributesToIncludeInEqualityCheck();
        }
        int IEqualityComparer<T>.GetHashCode(T obj)
        {
            return obj.GetHashCode();
        }

        public static bool operator ==(ValueObject<T> left, ValueObject<T> right)
        {
            if (ReferenceEquals(null, left) && ReferenceEquals(null, right))
                return true;
            if (ReferenceEquals(null, left))
                return false;

            return left.Equals(right);
        }
        public static bool operator !=(ValueObject<T> left, ValueObject<T> right)
        {
            return !(left == right);
        }

        protected virtual IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            // By default use all properties of the type for comparation
            return GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public).Select(s => s.GetValue(this));
        }
    }
}
