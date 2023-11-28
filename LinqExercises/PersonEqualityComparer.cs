using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExercises
{
    internal class PersonEqualityComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person? x, Person? y)
        {
            if (x is null && y is null)
            {
                return true;
            }

            if (x is null || y is null)
            {
                return false;
            }

            bool areEqual = string.Equals(x.FirstName, y.FirstName, StringComparison.OrdinalIgnoreCase) &&
                            string.Equals(x.LastName, y.LastName, StringComparison.OrdinalIgnoreCase) &&
                            x.Gender == y.Gender &&
                            x.DateOfBirth == y.DateOfBirth;

            return areEqual;
        }

        public int GetHashCode([DisallowNull] Person obj)
        {
            if (obj is null)
            {
                return default;
            }

            return HashCode.Combine(obj.FirstName, obj.LastName, obj.Gender, obj.DateOfBirth);
        }
    }
}
