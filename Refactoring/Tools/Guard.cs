using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Refactoring.Tools
{
    public static class Guard
    {
        public static void ExpectCount<T>(IEnumerable<T> items, int count, [CallerArgumentExpression("items")] string? paramName = null)
        {
            if (items.Count() != count)
            {
                throw new ArgumentException($"{count} elements were expected, but found {items.Count()}", paramName);
            }
        }

        public static void ExpectEqualOrMore<T>(IEnumerable<T> items, int count, [CallerArgumentExpression("items")] string? paramName = null)
        {
            if (items.Count() < count)
            {
                throw new ArgumentException($"{count} elements or more were expected, but found {items.Count()}", paramName);
            }
        }
    }
}
