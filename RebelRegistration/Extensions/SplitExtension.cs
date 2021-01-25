using System;
using System.Collections.Generic;

namespace RebelRegistration.Extensions
{
    public static class SplitExtension
    {
        public static IEnumerable<List<T>> Split<T>(this List<T> locations, int nSize = 50)
        {
            for (var i = 0; i < locations.Count; i += nSize)
            {
                yield return locations.GetRange(i, Math.Min(nSize, locations.Count - i));
            }
        }
    }
}
