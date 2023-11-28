using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExercises
{
    internal class LambdaEqualityComparer<T> : IEqualityComparer<T>
    {
        private readonly Func<T, T, bool> equalityComparerFunc;

        public LambdaEqualityComparer(Func<T, T, bool> equalityComparerFunc)
        {
            this.equalityComparerFunc = equalityComparerFunc ?? throw new ArgumentNullException(nameof(equalityComparerFunc));
        }

        public bool Equals([AllowNull] T x, [AllowNull] T y)
        {
            return this.equalityComparerFunc(x, y);
        }

        public int GetHashCode([DisallowNull] T obj)
        {
            return HashCode.Combine(obj);
        }
    }
}
